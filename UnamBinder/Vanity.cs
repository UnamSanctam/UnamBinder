using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

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
            txtAssemblyTitle.Enabled = checkAssembly.Checked;
            txtAssemblyDescription.Enabled = checkAssembly.Checked;
            txtAssemblyCompany.Enabled = checkAssembly.Checked;
            txtAssemblyProduct.Enabled = checkAssembly.Checked;
            txtAssemblyCopyright.Enabled = checkAssembly.Checked;
            txtAssemblyTrademark.Enabled = checkAssembly.Checked;
            txtAssemblyVersion1.Enabled = checkAssembly.Checked;
            txtAssemblyVersion2.Enabled = checkAssembly.Checked;
            txtAssemblyVersion3.Enabled = checkAssembly.Checked;
            txtAssemblyVersion4.Enabled = checkAssembly.Checked;
            btnAssemblyClone.Enabled = checkAssembly.Checked;
        }

        private void checkIcon_CheckedChanged(object sender)
        {
            btnIconBrowse.Enabled = checkIcon.Checked;
            txtIconPath.Enabled = checkIcon.Checked;
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
    }
}
