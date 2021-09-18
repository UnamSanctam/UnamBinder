namespace UnamBinder
{
    partial class File
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(File));
            this.mephTheme1 = new MephTheme();
            this.btnIconBrowse = new MephButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilename = new MephTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toggleExecute = new MephToggleSwitch();
            this.label2 = new System.Windows.Forms.Label();
            this.comboDropLocation = new MephComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBindfile = new MephTextBox();
            this.mephTheme1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mephTheme1
            // 
            this.mephTheme1.AccentColor = System.Drawing.Color.Indigo;
            this.mephTheme1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mephTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.mephTheme1.Controls.Add(this.btnIconBrowse);
            this.mephTheme1.Controls.Add(this.label4);
            this.mephTheme1.Controls.Add(this.txtFilename);
            this.mephTheme1.Controls.Add(this.label3);
            this.mephTheme1.Controls.Add(this.toggleExecute);
            this.mephTheme1.Controls.Add(this.label2);
            this.mephTheme1.Controls.Add(this.comboDropLocation);
            this.mephTheme1.Controls.Add(this.label1);
            this.mephTheme1.Controls.Add(this.txtBindfile);
            this.mephTheme1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.mephTheme1.Location = new System.Drawing.Point(0, 0);
            this.mephTheme1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mephTheme1.MaximumSize = new System.Drawing.Size(253, 276);
            this.mephTheme1.MinimumSize = new System.Drawing.Size(253, 276);
            this.mephTheme1.Name = "mephTheme1";
            this.mephTheme1.Size = new System.Drawing.Size(253, 276);
            this.mephTheme1.SubHeader = "File to bind";
            this.mephTheme1.TabIndex = 0;
            this.mephTheme1.Text = "Edit File";
            // 
            // btnIconBrowse
            // 
            this.btnIconBrowse.BackColor = System.Drawing.Color.Transparent;
            this.btnIconBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.btnIconBrowse.Location = new System.Drawing.Point(175, 142);
            this.btnIconBrowse.Name = "btnIconBrowse";
            this.btnIconBrowse.Size = new System.Drawing.Size(63, 24);
            this.btnIconBrowse.TabIndex = 18;
            this.btnIconBrowse.Text = "Browse";
            this.btnIconBrowse.Click += new System.EventHandler(this.btnIconBrowse_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(15, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Filename:";
            // 
            // txtFilename
            // 
            this.txtFilename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtFilename.ForeColor = System.Drawing.Color.Silver;
            this.txtFilename.Location = new System.Drawing.Point(18, 91);
            this.txtFilename.MaxLength = 32767;
            this.txtFilename.MultiLine = false;
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(220, 24);
            this.txtFilename.TabIndex = 7;
            this.txtFilename.Text = "File.exe";
            this.txtFilename.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFilename.UseSystemPasswordChar = false;
            this.txtFilename.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(15, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Execute File:";
            // 
            // toggleExecute
            // 
            this.toggleExecute.BackColor = System.Drawing.Color.Transparent;
            this.toggleExecute.Checked = true;
            this.toggleExecute.ForeColor = System.Drawing.Color.Black;
            this.toggleExecute.Location = new System.Drawing.Point(188, 236);
            this.toggleExecute.Name = "toggleExecute";
            this.toggleExecute.Size = new System.Drawing.Size(50, 24);
            this.toggleExecute.TabIndex = 5;
            this.toggleExecute.Text = "toggleExecuteFile";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(15, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Drop location:";
            // 
            // comboDropLocation
            // 
            this.comboDropLocation.BackColor = System.Drawing.Color.Transparent;
            this.comboDropLocation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboDropLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDropLocation.Font = new System.Drawing.Font("Verdana", 8F);
            this.comboDropLocation.ForeColor = System.Drawing.Color.Silver;
            this.comboDropLocation.FormattingEnabled = true;
            this.comboDropLocation.ItemHeight = 16;
            this.comboDropLocation.ItemHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.comboDropLocation.Items.AddRange(new object[] {
            "Temp",
            "AppData",
            "UserProfile",
            "LocalAppData",
            "SystemRoot"});
            this.comboDropLocation.Location = new System.Drawing.Point(18, 197);
            this.comboDropLocation.Name = "comboDropLocation";
            this.comboDropLocation.Size = new System.Drawing.Size(220, 22);
            this.comboDropLocation.StartIndex = 0;
            this.comboDropLocation.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(15, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "FIle to bind:";
            // 
            // txtBindfile
            // 
            this.txtBindfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtBindfile.ForeColor = System.Drawing.Color.Silver;
            this.txtBindfile.Location = new System.Drawing.Point(18, 142);
            this.txtBindfile.MaxLength = 32767;
            this.txtBindfile.MultiLine = false;
            this.txtBindfile.Name = "txtBindfile";
            this.txtBindfile.Size = new System.Drawing.Size(151, 24);
            this.txtBindfile.TabIndex = 0;
            this.txtBindfile.Text = "Browse file...";
            this.txtBindfile.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBindfile.UseSystemPasswordChar = false;
            this.txtBindfile.WordWrap = false;
            // 
            // File
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(253, 276);
            this.Controls.Add(this.mephTheme1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "File";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit File";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.File_FormClosing);
            this.mephTheme1.ResumeLayout(false);
            this.mephTheme1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MephTheme mephTheme1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        public MephTextBox txtFilename;
        public MephTextBox txtBindfile;
        public MephToggleSwitch toggleExecute;
        public MephComboBox comboDropLocation;
        private MephButton btnIconBrowse;
    }
}