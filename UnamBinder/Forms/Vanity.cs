using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TsudaKageyu;
using System.Drawing;

namespace UnamBinder
{
    public partial class Vanity : Form
    {
        public Vanity()
        {
            InitializeComponent();
        }

        private void Vanity_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void checkAssembly_CheckedChanged(object sender)
        {
            txtAssemblyTitle.Enabled = chkAssembly.Checked;
            txtAssemblyDescription.Enabled = chkAssembly.Checked;
            txtAssemblyCompany.Enabled = chkAssembly.Checked;
            txtAssemblyProduct.Enabled = chkAssembly.Checked;
            txtAssemblyCopyright.Enabled = chkAssembly.Checked;
            txtAssemblyTrademark.Enabled = chkAssembly.Checked;
            txtAssemblyVersion1.Enabled = chkAssembly.Checked;
            txtAssemblyVersion2.Enabled = chkAssembly.Checked;
            txtAssemblyVersion3.Enabled = chkAssembly.Checked;
            txtAssemblyVersion4.Enabled = chkAssembly.Checked;
            btnAssemblyClone.Enabled = chkAssembly.Checked;
        }

        private void checkIcon_CheckedChanged(object sender)
        {
            btnIconBrowse.Enabled = chkIcon.Checked;
            btnIconClone.Enabled = chkIcon.Checked;
            txtIconPath.Enabled = chkIcon.Checked;
        }

        private void btnAssemblyClone_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Exe Files (.exe)|*.exe|All Files (*.*)|*.*";
            dialog.InitialDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileVersionInfo cloneInfo = FileVersionInfo.GetVersionInfo(dialog.FileName);
                txtAssemblyTitle.Text = cloneInfo.InternalName;
                txtAssemblyDescription.Text = cloneInfo.FileDescription;
                txtAssemblyCompany.Text = cloneInfo.CompanyName;
                txtAssemblyProduct.Text = cloneInfo.ProductName;
                txtAssemblyCopyright.Text = cloneInfo.LegalCopyright;
                txtAssemblyTrademark.Text = cloneInfo.LegalTrademarks;

                try
                {
                    string[] version = cloneInfo.FileVersion.Contains(",") ? cloneInfo.FileVersion.Split(',') : cloneInfo.FileVersion.Split('.');

                    txtAssemblyVersion1.Text = version[0];
                    txtAssemblyVersion2.Text = version[1];
                    txtAssemblyVersion3.Text = version[2];
                    txtAssemblyVersion4.Text = version[3];
                }
                catch { }
            }
        }

        private void btnIconBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Icon |*.ico";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtIconPath.Text = dialog.FileName;
                imageIcon.ImageLocation = dialog.FileName;
            }
        }
        private void btnIconClone_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Executable Files (*.exe) |*.exe|Dynamic Link Library Files (*.dll)|*.dll";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                IconExtractor ie = new IconExtractor(dialog.FileName);
                string savePath = Environment.CurrentDirectory + @"\TempIcon\icon.ico";
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\TempIcon\");
                try
                {
                    Icon icon1 = ie.GetIcon(0);
                    using (FileStream stream = new FileStream(savePath, FileMode.Create))
                    {
                        icon1.Save(stream);
                        txtIconPath.Text = savePath;
                        imageIcon.ImageLocation = savePath;
                    }
                }
                catch
                {
                    MessageBox.Show("The icon is invalid. Try a different one!", "Invalid icon");
                }
            }
        }
    }
}
