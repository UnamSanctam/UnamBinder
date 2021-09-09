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
            this.mephTheme1 = new MephTheme();
            this.imageAdmin1 = new System.Windows.Forms.PictureBox();
            this.linkGitHub = new System.Windows.Forms.LinkLabel();
            this.btnBuild = new MephButton();
            this.checkWD = new MephCheckBox();
            this.checkAdmin = new MephCheckBox();
            this.btnEdit = new MephButton();
            this.btnRemove = new MephButton();
            this.btnAdd = new MephButton();
            this.label1 = new System.Windows.Forms.Label();
            this.listFiles = new MephListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.mephTheme1.SuspendLayout();
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
            // mephTheme1
            // 
            this.mephTheme1.AccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.mephTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.mephTheme1.Controls.Add(this.imageAdmin1);
            this.mephTheme1.Controls.Add(this.linkGitHub);
            this.mephTheme1.Controls.Add(this.btnBuild);
            this.mephTheme1.Controls.Add(this.checkWD);
            this.mephTheme1.Controls.Add(this.checkAdmin);
            this.mephTheme1.Controls.Add(this.btnEdit);
            this.mephTheme1.Controls.Add(this.btnRemove);
            this.mephTheme1.Controls.Add(this.btnAdd);
            this.mephTheme1.Controls.Add(this.label1);
            this.mephTheme1.Controls.Add(this.listFiles);
            this.mephTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mephTheme1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.mephTheme1.Location = new System.Drawing.Point(0, 0);
            this.mephTheme1.Margin = new System.Windows.Forms.Padding(4);
            this.mephTheme1.Name = "mephTheme1";
            this.mephTheme1.Size = new System.Drawing.Size(348, 327);
            this.mephTheme1.SubHeader = "Created by Unam Sanctam";
            this.mephTheme1.TabIndex = 0;
            this.mephTheme1.Text = "Unam Binder 1.0.0";
            // 
            // imageAdmin1
            // 
            this.imageAdmin1.BackColor = System.Drawing.Color.Transparent;
            this.imageAdmin1.Image = global::UnamBinder.Properties.Resources.microsoft_admin;
            this.imageAdmin1.Location = new System.Drawing.Point(284, 241);
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
            this.btnBuild.Location = new System.Drawing.Point(25, 279);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(75, 23);
            this.btnBuild.TabIndex = 8;
            this.btnBuild.Text = "Build";
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // checkWD
            // 
            this.checkWD.AccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.checkWD.BackColor = System.Drawing.Color.Transparent;
            this.checkWD.Checked = false;
            this.checkWD.ForeColor = System.Drawing.Color.Gray;
            this.checkWD.Location = new System.Drawing.Point(25, 242);
            this.checkWD.Name = "checkWD";
            this.checkWD.Size = new System.Drawing.Size(269, 24);
            this.checkWD.TabIndex = 6;
            this.checkWD.Text = "Add Windows Defender exclusions";
            // 
            // checkAdmin
            // 
            this.checkAdmin.AccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.checkAdmin.BackColor = System.Drawing.Color.Transparent;
            this.checkAdmin.Checked = false;
            this.checkAdmin.ForeColor = System.Drawing.Color.Black;
            this.checkAdmin.Location = new System.Drawing.Point(25, 212);
            this.checkAdmin.Name = "checkAdmin";
            this.checkAdmin.Size = new System.Drawing.Size(250, 24);
            this.checkAdmin.TabIndex = 5;
            this.checkAdmin.Text = "Run as Administrator";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(22, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Files:";
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
            this.ClientSize = new System.Drawing.Size(348, 327);
            this.Controls.Add(this.mephTheme1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Builder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unam Binder 1.0.0";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.mephTheme1.ResumeLayout(false);
            this.mephTheme1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageAdmin1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MephTheme mephTheme1;
        private MephButton btnEdit;
        private MephButton btnRemove;
        private MephButton btnAdd;
        private System.Windows.Forms.Label label1;
        private MephCheckBox checkWD;
        private MephCheckBox checkAdmin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MephButton btnBuild;
        private System.Windows.Forms.LinkLabel linkGitHub;
        public MephListBox listFiles;
        private System.Windows.Forms.PictureBox imageAdmin1;
    }
}

