using System;
using System.IO;
using System.Windows.Forms;

namespace UnamBinder
{
    public partial class File : Form
    {
        public Builder builder = (Builder)Application.OpenForms["Builder"];

        public File()
        {
            InitializeComponent();
        }

        private void File_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            int count = builder.listFiles.Items.Count;
            for (int i = 0; i < count; i++)
            {
                builder.listFiles.Items[i] = builder.listFiles.Items[i];
            }
            Hide();
        }

        public override string ToString()
        {
            return txtFilename.Text + " - " + txtBindfile.Text;
        }

        private void btnIconBrowse_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Files (*.*)|*.*";
            dialog.InitialDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtBindfile.Text = dialog.FileName;
                txtFilename.Text = Path.GetFileName(dialog.FileName);
            }
        }
    }
}
