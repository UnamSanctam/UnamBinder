namespace UnamBinder
{
    partial class Vanity
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vanity));
            this.mephTheme1 = new MephTheme();
            this.chkAssembly = new MephCheckBox();
            this.chkIcon = new MephCheckBox();
            this.imageIcon = new System.Windows.Forms.PictureBox();
            this.txtIconPath = new MephTextBox();
            this.btnIconBrowse = new MephButton();
            this.btnAssemblyClone = new MephButton();
            this.txtAssemblyVersion4 = new MephTextBox();
            this.txtAssemblyVersion3 = new MephTextBox();
            this.txtAssemblyVersion2 = new MephTextBox();
            this.txtAssemblyVersion1 = new MephTextBox();
            this.labelVanityVersion = new System.Windows.Forms.Label();
            this.txtAssemblyTrademark = new MephTextBox();
            this.txtAssemblyCopyright = new MephTextBox();
            this.txtAssemblyProduct = new MephTextBox();
            this.txtAssemblyCompany = new MephTextBox();
            this.txtAssemblyDescription = new MephTextBox();
            this.txtAssemblyTitle = new MephTextBox();
            this.mephTheme1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // mephTheme1
            // 
            this.mephTheme1.AccentColor = System.Drawing.Color.Indigo;
            this.mephTheme1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mephTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.mephTheme1.Controls.Add(this.chkAssembly);
            this.mephTheme1.Controls.Add(this.chkIcon);
            this.mephTheme1.Controls.Add(this.imageIcon);
            this.mephTheme1.Controls.Add(this.txtIconPath);
            this.mephTheme1.Controls.Add(this.btnIconBrowse);
            this.mephTheme1.Controls.Add(this.btnAssemblyClone);
            this.mephTheme1.Controls.Add(this.txtAssemblyVersion4);
            this.mephTheme1.Controls.Add(this.txtAssemblyVersion3);
            this.mephTheme1.Controls.Add(this.txtAssemblyVersion2);
            this.mephTheme1.Controls.Add(this.txtAssemblyVersion1);
            this.mephTheme1.Controls.Add(this.labelVanityVersion);
            this.mephTheme1.Controls.Add(this.txtAssemblyTrademark);
            this.mephTheme1.Controls.Add(this.txtAssemblyCopyright);
            this.mephTheme1.Controls.Add(this.txtAssemblyProduct);
            this.mephTheme1.Controls.Add(this.txtAssemblyCompany);
            this.mephTheme1.Controls.Add(this.txtAssemblyDescription);
            this.mephTheme1.Controls.Add(this.txtAssemblyTitle);
            this.mephTheme1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.mephTheme1.Location = new System.Drawing.Point(0, 0);
            this.mephTheme1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mephTheme1.MaximumSize = new System.Drawing.Size(556, 231);
            this.mephTheme1.MinimumSize = new System.Drawing.Size(556, 231);
            this.mephTheme1.Name = "mephTheme1";
            this.mephTheme1.Size = new System.Drawing.Size(556, 231);
            this.mephTheme1.SubHeader = "";
            this.mephTheme1.TabIndex = 0;
            this.mephTheme1.Text = "Change Icon or Assembly";
            // 
            // chkAssembly
            // 
            this.chkAssembly.AccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.chkAssembly.BackColor = System.Drawing.Color.Transparent;
            this.chkAssembly.Checked = false;
            this.chkAssembly.ForeColor = System.Drawing.Color.Black;
            this.chkAssembly.Location = new System.Drawing.Point(18, 71);
            this.chkAssembly.Name = "chkAssembly";
            this.chkAssembly.Size = new System.Drawing.Size(276, 24);
            this.chkAssembly.TabIndex = 21;
            this.chkAssembly.Text = "Assembly";
            this.chkAssembly.CheckedChanged += new MephCheckBox.CheckedChangedEventHandler(this.checkAssembly_CheckedChanged);
            // 
            // chkIcon
            // 
            this.chkIcon.AccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.chkIcon.BackColor = System.Drawing.Color.Transparent;
            this.chkIcon.Checked = false;
            this.chkIcon.ForeColor = System.Drawing.Color.Black;
            this.chkIcon.Location = new System.Drawing.Point(311, 71);
            this.chkIcon.Name = "chkIcon";
            this.chkIcon.Size = new System.Drawing.Size(229, 24);
            this.chkIcon.TabIndex = 20;
            this.chkIcon.Text = "Icon";
            this.chkIcon.CheckedChanged += new MephCheckBox.CheckedChangedEventHandler(this.checkIcon_CheckedChanged);
            // 
            // imageIcon
            // 
            this.imageIcon.BackColor = System.Drawing.Color.Transparent;
            this.imageIcon.Location = new System.Drawing.Point(392, 131);
            this.imageIcon.Name = "imageIcon";
            this.imageIcon.Size = new System.Drawing.Size(75, 79);
            this.imageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageIcon.TabIndex = 19;
            this.imageIcon.TabStop = false;
            // 
            // txtIconPath
            // 
            this.txtIconPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtIconPath.Enabled = false;
            this.txtIconPath.ForeColor = System.Drawing.Color.Silver;
            this.txtIconPath.Location = new System.Drawing.Point(392, 101);
            this.txtIconPath.MaxLength = 32767;
            this.txtIconPath.MultiLine = false;
            this.txtIconPath.Name = "txtIconPath";
            this.txtIconPath.Size = new System.Drawing.Size(148, 24);
            this.txtIconPath.TabIndex = 18;
            this.txtIconPath.Text = "Path to Icon...";
            this.txtIconPath.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtIconPath.UseSystemPasswordChar = false;
            this.txtIconPath.WordWrap = false;
            // 
            // btnIconBrowse
            // 
            this.btnIconBrowse.BackColor = System.Drawing.Color.Transparent;
            this.btnIconBrowse.Enabled = false;
            this.btnIconBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.btnIconBrowse.Location = new System.Drawing.Point(311, 101);
            this.btnIconBrowse.Name = "btnIconBrowse";
            this.btnIconBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnIconBrowse.TabIndex = 17;
            this.btnIconBrowse.Text = "Browse";
            this.btnIconBrowse.Click += new System.EventHandler(this.btnIconBrowse_Click);
            // 
            // btnAssemblyClone
            // 
            this.btnAssemblyClone.BackColor = System.Drawing.Color.Transparent;
            this.btnAssemblyClone.Enabled = false;
            this.btnAssemblyClone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.btnAssemblyClone.Location = new System.Drawing.Point(159, 191);
            this.btnAssemblyClone.Name = "btnAssemblyClone";
            this.btnAssemblyClone.Size = new System.Drawing.Size(135, 23);
            this.btnAssemblyClone.TabIndex = 16;
            this.btnAssemblyClone.Text = "Clone File";
            this.btnAssemblyClone.Click += new System.EventHandler(this.btnAssemblyClone_Click);
            // 
            // txtAssemblyVersion4
            // 
            this.txtAssemblyVersion4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtAssemblyVersion4.Enabled = false;
            this.txtAssemblyVersion4.ForeColor = System.Drawing.Color.Silver;
            this.txtAssemblyVersion4.Location = new System.Drawing.Point(134, 191);
            this.txtAssemblyVersion4.MaxLength = 32767;
            this.txtAssemblyVersion4.MultiLine = false;
            this.txtAssemblyVersion4.Name = "txtAssemblyVersion4";
            this.txtAssemblyVersion4.Size = new System.Drawing.Size(18, 24);
            this.txtAssemblyVersion4.TabIndex = 15;
            this.txtAssemblyVersion4.Text = "0";
            this.txtAssemblyVersion4.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAssemblyVersion4.UseSystemPasswordChar = false;
            this.txtAssemblyVersion4.WordWrap = false;
            // 
            // txtAssemblyVersion3
            // 
            this.txtAssemblyVersion3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtAssemblyVersion3.Enabled = false;
            this.txtAssemblyVersion3.ForeColor = System.Drawing.Color.Silver;
            this.txtAssemblyVersion3.Location = new System.Drawing.Point(112, 191);
            this.txtAssemblyVersion3.MaxLength = 32767;
            this.txtAssemblyVersion3.MultiLine = false;
            this.txtAssemblyVersion3.Name = "txtAssemblyVersion3";
            this.txtAssemblyVersion3.Size = new System.Drawing.Size(18, 24);
            this.txtAssemblyVersion3.TabIndex = 14;
            this.txtAssemblyVersion3.Text = "0";
            this.txtAssemblyVersion3.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAssemblyVersion3.UseSystemPasswordChar = false;
            this.txtAssemblyVersion3.WordWrap = false;
            // 
            // txtAssemblyVersion2
            // 
            this.txtAssemblyVersion2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtAssemblyVersion2.Enabled = false;
            this.txtAssemblyVersion2.ForeColor = System.Drawing.Color.Silver;
            this.txtAssemblyVersion2.Location = new System.Drawing.Point(90, 191);
            this.txtAssemblyVersion2.MaxLength = 32767;
            this.txtAssemblyVersion2.MultiLine = false;
            this.txtAssemblyVersion2.Name = "txtAssemblyVersion2";
            this.txtAssemblyVersion2.Size = new System.Drawing.Size(18, 24);
            this.txtAssemblyVersion2.TabIndex = 13;
            this.txtAssemblyVersion2.Text = "0";
            this.txtAssemblyVersion2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAssemblyVersion2.UseSystemPasswordChar = false;
            this.txtAssemblyVersion2.WordWrap = false;
            // 
            // txtAssemblyVersion1
            // 
            this.txtAssemblyVersion1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtAssemblyVersion1.Enabled = false;
            this.txtAssemblyVersion1.ForeColor = System.Drawing.Color.Silver;
            this.txtAssemblyVersion1.Location = new System.Drawing.Point(69, 191);
            this.txtAssemblyVersion1.MaxLength = 32767;
            this.txtAssemblyVersion1.MultiLine = false;
            this.txtAssemblyVersion1.Name = "txtAssemblyVersion1";
            this.txtAssemblyVersion1.Size = new System.Drawing.Size(18, 24);
            this.txtAssemblyVersion1.TabIndex = 12;
            this.txtAssemblyVersion1.Text = "0";
            this.txtAssemblyVersion1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAssemblyVersion1.UseSystemPasswordChar = false;
            this.txtAssemblyVersion1.WordWrap = false;
            // 
            // labelVanityVersion
            // 
            this.labelVanityVersion.AutoSize = true;
            this.labelVanityVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelVanityVersion.ForeColor = System.Drawing.Color.Gray;
            this.labelVanityVersion.Location = new System.Drawing.Point(15, 193);
            this.labelVanityVersion.Name = "labelVanityVersion";
            this.labelVanityVersion.Size = new System.Drawing.Size(54, 17);
            this.labelVanityVersion.TabIndex = 11;
            this.labelVanityVersion.Text = "Version:";
            // 
            // txtAssemblyTrademark
            // 
            this.txtAssemblyTrademark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtAssemblyTrademark.Enabled = false;
            this.txtAssemblyTrademark.ForeColor = System.Drawing.Color.Silver;
            this.txtAssemblyTrademark.Location = new System.Drawing.Point(159, 161);
            this.txtAssemblyTrademark.MaxLength = 32767;
            this.txtAssemblyTrademark.MultiLine = false;
            this.txtAssemblyTrademark.Name = "txtAssemblyTrademark";
            this.txtAssemblyTrademark.Size = new System.Drawing.Size(135, 24);
            this.txtAssemblyTrademark.TabIndex = 10;
            this.txtAssemblyTrademark.Text = "Trademark...";
            this.txtAssemblyTrademark.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAssemblyTrademark.UseSystemPasswordChar = false;
            this.txtAssemblyTrademark.WordWrap = false;
            // 
            // txtAssemblyCopyright
            // 
            this.txtAssemblyCopyright.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtAssemblyCopyright.Enabled = false;
            this.txtAssemblyCopyright.ForeColor = System.Drawing.Color.Silver;
            this.txtAssemblyCopyright.Location = new System.Drawing.Point(159, 131);
            this.txtAssemblyCopyright.MaxLength = 32767;
            this.txtAssemblyCopyright.MultiLine = false;
            this.txtAssemblyCopyright.Name = "txtAssemblyCopyright";
            this.txtAssemblyCopyright.Size = new System.Drawing.Size(135, 24);
            this.txtAssemblyCopyright.TabIndex = 8;
            this.txtAssemblyCopyright.Text = "Copyright...";
            this.txtAssemblyCopyright.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAssemblyCopyright.UseSystemPasswordChar = false;
            this.txtAssemblyCopyright.WordWrap = false;
            // 
            // txtAssemblyProduct
            // 
            this.txtAssemblyProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtAssemblyProduct.Enabled = false;
            this.txtAssemblyProduct.ForeColor = System.Drawing.Color.Silver;
            this.txtAssemblyProduct.Location = new System.Drawing.Point(159, 101);
            this.txtAssemblyProduct.MaxLength = 32767;
            this.txtAssemblyProduct.MultiLine = false;
            this.txtAssemblyProduct.Name = "txtAssemblyProduct";
            this.txtAssemblyProduct.Size = new System.Drawing.Size(135, 24);
            this.txtAssemblyProduct.TabIndex = 6;
            this.txtAssemblyProduct.Text = "Product...";
            this.txtAssemblyProduct.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAssemblyProduct.UseSystemPasswordChar = false;
            this.txtAssemblyProduct.WordWrap = false;
            // 
            // txtAssemblyCompany
            // 
            this.txtAssemblyCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtAssemblyCompany.Enabled = false;
            this.txtAssemblyCompany.ForeColor = System.Drawing.Color.Silver;
            this.txtAssemblyCompany.Location = new System.Drawing.Point(18, 161);
            this.txtAssemblyCompany.MaxLength = 32767;
            this.txtAssemblyCompany.MultiLine = false;
            this.txtAssemblyCompany.Name = "txtAssemblyCompany";
            this.txtAssemblyCompany.Size = new System.Drawing.Size(135, 24);
            this.txtAssemblyCompany.TabIndex = 4;
            this.txtAssemblyCompany.Text = "Company...";
            this.txtAssemblyCompany.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAssemblyCompany.UseSystemPasswordChar = false;
            this.txtAssemblyCompany.WordWrap = false;
            // 
            // txtAssemblyDescription
            // 
            this.txtAssemblyDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtAssemblyDescription.Enabled = false;
            this.txtAssemblyDescription.ForeColor = System.Drawing.Color.Silver;
            this.txtAssemblyDescription.Location = new System.Drawing.Point(18, 131);
            this.txtAssemblyDescription.MaxLength = 32767;
            this.txtAssemblyDescription.MultiLine = false;
            this.txtAssemblyDescription.Name = "txtAssemblyDescription";
            this.txtAssemblyDescription.Size = new System.Drawing.Size(135, 24);
            this.txtAssemblyDescription.TabIndex = 2;
            this.txtAssemblyDescription.Text = "Description...";
            this.txtAssemblyDescription.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAssemblyDescription.UseSystemPasswordChar = false;
            this.txtAssemblyDescription.WordWrap = false;
            // 
            // txtAssemblyTitle
            // 
            this.txtAssemblyTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtAssemblyTitle.Enabled = false;
            this.txtAssemblyTitle.ForeColor = System.Drawing.Color.Silver;
            this.txtAssemblyTitle.Location = new System.Drawing.Point(18, 101);
            this.txtAssemblyTitle.MaxLength = 32767;
            this.txtAssemblyTitle.MultiLine = false;
            this.txtAssemblyTitle.Name = "txtAssemblyTitle";
            this.txtAssemblyTitle.Size = new System.Drawing.Size(135, 24);
            this.txtAssemblyTitle.TabIndex = 0;
            this.txtAssemblyTitle.Text = "Title...";
            this.txtAssemblyTitle.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAssemblyTitle.UseSystemPasswordChar = false;
            this.txtAssemblyTitle.WordWrap = false;
            // 
            // Vanity
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(556, 231);
            this.Controls.Add(this.mephTheme1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(556, 231);
            this.MinimumSize = new System.Drawing.Size(556, 231);
            this.Name = "Vanity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Icon or Assembly";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Vanity_FormClosing);
            this.mephTheme1.ResumeLayout(false);
            this.mephTheme1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MephTheme mephTheme1;
        private MephButton btnIconBrowse;
        private MephButton btnAssemblyClone;
        private System.Windows.Forms.Label labelVanityVersion;
        public MephCheckBox chkAssembly;
        public MephCheckBox chkIcon;
        public MephTextBox txtIconPath;
        public MephTextBox txtAssemblyVersion4;
        public MephTextBox txtAssemblyVersion3;
        public MephTextBox txtAssemblyVersion2;
        public MephTextBox txtAssemblyVersion1;
        public MephTextBox txtAssemblyTrademark;
        public MephTextBox txtAssemblyCopyright;
        public MephTextBox txtAssemblyProduct;
        public MephTextBox txtAssemblyCompany;
        public MephTextBox txtAssemblyDescription;
        public MephTextBox txtAssemblyTitle;
        public System.Windows.Forms.PictureBox imageIcon;
    }
}