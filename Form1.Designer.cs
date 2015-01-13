namespace YATE {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.FileDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.newFile = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.prefToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSettings = new System.Windows.Forms.ToolStripButton();
            this.SimToolStrip = new System.Windows.Forms.ToolStripButton();
            this.imgListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileLZ = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.EditDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.importToolstrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileDropDown,
            this.EditDropDown,
            this.toolStripSettings,
            this.SimToolStrip});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(556, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // FileDropDown
            // 
            this.FileDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FileDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFile,
            this.toolStripSeparator1,
            this.openFile,
            this.prefToolStrip});
            this.FileDropDown.Image = ((System.Drawing.Image)(resources.GetObject("FileDropDown.Image")));
            this.FileDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FileDropDown.Name = "FileDropDown";
            this.FileDropDown.Size = new System.Drawing.Size(38, 22);
            this.FileDropDown.Text = "File";
            this.FileDropDown.ToolTipText = "File";
            // 
            // newFile
            // 
            this.newFile.Name = "newFile";
            this.newFile.Size = new System.Drawing.Size(152, 22);
            this.newFile.Text = "New";
            this.newFile.Click += new System.EventHandler(this.newFile_Click);
            // 
            // openFile
            // 
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(152, 22);
            this.openFile.Text = "Open";
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // prefToolStrip
            // 
            this.prefToolStrip.Name = "prefToolStrip";
            this.prefToolStrip.Size = new System.Drawing.Size(152, 22);
            this.prefToolStrip.Text = "Preferences";
            this.prefToolStrip.Click += new System.EventHandler(this.prefToolStrip_Click);
            // 
            // toolStripSettings
            // 
            this.toolStripSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSettings.Enabled = false;
            this.toolStripSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSettings.Image")));
            this.toolStripSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSettings.Name = "toolStripSettings";
            this.toolStripSettings.Size = new System.Drawing.Size(53, 22);
            this.toolStripSettings.Text = "Settings";
            this.toolStripSettings.Click += new System.EventHandler(this.toolStripSettings_Click);
            // 
            // SimToolStrip
            // 
            this.SimToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SimToolStrip.Enabled = false;
            this.SimToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("SimToolStrip.Image")));
            this.SimToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SimToolStrip.Name = "SimToolStrip";
            this.SimToolStrip.Size = new System.Drawing.Size(57, 22);
            this.SimToolStrip.Text = "Simulate";
            this.SimToolStrip.Click += new System.EventHandler(this.SimToolStrip_Click);
            // 
            // imgListBox
            // 
            this.imgListBox.FormattingEnabled = true;
            this.imgListBox.Location = new System.Drawing.Point(12, 41);
            this.imgListBox.Name = "imgListBox";
            this.imgListBox.Size = new System.Drawing.Size(143, 251);
            this.imgListBox.TabIndex = 1;
            this.imgListBox.SelectedIndexChanged += new System.EventHandler(this.imgListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Images:";
            // 
            // openFileLZ
            // 
            this.openFileLZ.FileName = "body_LZ.bin";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(161, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1024, 256);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // EditDropDown
            // 
            this.EditDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EditDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolstrip});
            this.EditDropDown.Image = ((System.Drawing.Image)(resources.GetObject("EditDropDown.Image")));
            this.EditDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditDropDown.Name = "EditDropDown";
            this.EditDropDown.Size = new System.Drawing.Size(40, 22);
            this.EditDropDown.Text = "Edit";
            // 
            // importToolstrip
            // 
            this.importToolstrip.Name = "importToolstrip";
            this.importToolstrip.Size = new System.Drawing.Size(152, 22);
            this.importToolstrip.Text = "Import";
            this.importToolstrip.Click += new System.EventHandler(this.importToolstrip_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 301);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgListBox);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Yet Another Theme Editor (YATE) by Rei";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton FileDropDown;
        private System.Windows.Forms.ToolStripMenuItem openFile;
        private System.Windows.Forms.ToolStripButton SimToolStrip;
        private System.Windows.Forms.ListBox imgListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileLZ;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripButton toolStripSettings;
        private System.Windows.Forms.ToolStripMenuItem prefToolStrip;
        private System.Windows.Forms.ToolStripMenuItem newFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton EditDropDown;
        private System.Windows.Forms.ToolStripMenuItem importToolstrip;
    }
}

