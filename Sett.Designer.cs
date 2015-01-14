namespace YATE {
    partial class Sett {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonSaveSett = new System.Windows.Forms.Button();
            this.CB_topDraw = new System.Windows.Forms.ComboBox();
            this.CB_botDraw = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CB_botFrame = new System.Windows.Forms.ComboBox();
            this.CB_topFrame = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CHK0 = new System.Windows.Forms.CheckBox();
            this.CHK1 = new System.Windows.Forms.CheckBox();
            this.CHK2 = new System.Windows.Forms.CheckBox();
            this.CHK3 = new System.Windows.Forms.CheckBox();
            this.CHK4 = new System.Windows.Forms.CheckBox();
            this.CHK5 = new System.Windows.Forms.CheckBox();
            this.CHK6 = new System.Windows.Forms.CheckBox();
            this.CHK7 = new System.Windows.Forms.CheckBox();
            this.CHK8 = new System.Windows.Forms.CheckBox();
            this.CHK9 = new System.Windows.Forms.CheckBox();
            this.CHK10 = new System.Windows.Forms.CheckBox();
            this.CHK11 = new System.Windows.Forms.CheckBox();
            this.CHK12 = new System.Windows.Forms.CheckBox();
            this.CHK13 = new System.Windows.Forms.CheckBox();
            this.CHK14 = new System.Windows.Forms.CheckBox();
            this.CHK15 = new System.Windows.Forms.CheckBox();
            this.CHK16 = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CB_botDraw);
            this.groupBox1.Controls.Add(this.CB_topDraw);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Draw Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bottom bottom:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Top screen:";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(12, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 244);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Colors";
            // 
            // buttonSaveSett
            // 
            this.buttonSaveSett.Location = new System.Drawing.Point(515, 362);
            this.buttonSaveSett.Name = "buttonSaveSett";
            this.buttonSaveSett.Size = new System.Drawing.Size(113, 26);
            this.buttonSaveSett.TabIndex = 2;
            this.buttonSaveSett.Text = "Save";
            this.buttonSaveSett.UseVisualStyleBackColor = true;
            this.buttonSaveSett.Click += new System.EventHandler(this.buttonSaveSett_Click);
            // 
            // CB_topDraw
            // 
            this.CB_topDraw.FormattingEnabled = true;
            this.CB_topDraw.Items.AddRange(new object[] {
            "None",
            "Solid Color",
            "Solid w/ Texture squares",
            "Texture"});
            this.CB_topDraw.Location = new System.Drawing.Point(90, 29);
            this.CB_topDraw.Name = "CB_topDraw";
            this.CB_topDraw.Size = new System.Drawing.Size(98, 21);
            this.CB_topDraw.TabIndex = 2;
            // 
            // CB_botDraw
            // 
            this.CB_botDraw.FormattingEnabled = true;
            this.CB_botDraw.Items.AddRange(new object[] {
            "None",
            "Solid Color",
            "Invalid",
            "Texture"});
            this.CB_botDraw.Location = new System.Drawing.Point(90, 55);
            this.CB_botDraw.Name = "CB_botDraw";
            this.CB_botDraw.Size = new System.Drawing.Size(98, 21);
            this.CB_botDraw.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CB_botFrame);
            this.groupBox3.Controls.Add(this.CB_topFrame);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(220, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(202, 94);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Frame Type";
            // 
            // CB_botFrame
            // 
            this.CB_botFrame.FormattingEnabled = true;
            this.CB_botFrame.Items.AddRange(new object[] {
            "Normal scroll",
            "None",
            "Flipbook (cyclic)",
            "Slow scroll",
            "Flipbook (tile)"});
            this.CB_botFrame.Location = new System.Drawing.Point(90, 55);
            this.CB_botFrame.Name = "CB_botFrame";
            this.CB_botFrame.Size = new System.Drawing.Size(98, 21);
            this.CB_botFrame.TabIndex = 3;
            // 
            // CB_topFrame
            // 
            this.CB_topFrame.FormattingEnabled = true;
            this.CB_topFrame.Items.AddRange(new object[] {
            "Normal scroll",
            "None",
            "Slow scroll"});
            this.CB_topFrame.Location = new System.Drawing.Point(90, 29);
            this.CB_topFrame.Name = "CB_topFrame";
            this.CB_topFrame.Size = new System.Drawing.Size(98, 21);
            this.CB_topFrame.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Bottom bottom:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Top screen:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CHK16);
            this.groupBox4.Controls.Add(this.CHK15);
            this.groupBox4.Controls.Add(this.CHK14);
            this.groupBox4.Controls.Add(this.CHK13);
            this.groupBox4.Controls.Add(this.CHK12);
            this.groupBox4.Controls.Add(this.CHK11);
            this.groupBox4.Controls.Add(this.CHK10);
            this.groupBox4.Controls.Add(this.CHK9);
            this.groupBox4.Controls.Add(this.CHK8);
            this.groupBox4.Controls.Add(this.CHK7);
            this.groupBox4.Controls.Add(this.CHK6);
            this.groupBox4.Controls.Add(this.CHK5);
            this.groupBox4.Controls.Add(this.CHK4);
            this.groupBox4.Controls.Add(this.CHK3);
            this.groupBox4.Controls.Add(this.CHK2);
            this.groupBox4.Controls.Add(this.CHK1);
            this.groupBox4.Controls.Add(this.CHK0);
            this.groupBox4.Location = new System.Drawing.Point(428, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 344);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Flags";
            // 
            // CHK0
            // 
            this.CHK0.AutoSize = true;
            this.CHK0.Location = new System.Drawing.Point(6, 28);
            this.CHK0.Name = "CHK0";
            this.CHK0.Size = new System.Drawing.Size(86, 17);
            this.CHK0.TabIndex = 0;
            this.CHK0.Text = "Enable 0x2C";
            this.CHK0.UseVisualStyleBackColor = true;
            // 
            // CHK1
            // 
            this.CHK1.AutoSize = true;
            this.CHK1.Location = new System.Drawing.Point(6, 51);
            this.CHK1.Name = "CHK1";
            this.CHK1.Size = new System.Drawing.Size(85, 17);
            this.CHK1.TabIndex = 1;
            this.CHK1.Text = "Enable 0x34";
            this.CHK1.UseVisualStyleBackColor = true;
            // 
            // CHK2
            // 
            this.CHK2.AutoSize = true;
            this.CHK2.Location = new System.Drawing.Point(6, 74);
            this.CHK2.Name = "CHK2";
            this.CHK2.Size = new System.Drawing.Size(86, 17);
            this.CHK2.TabIndex = 2;
            this.CHK2.Text = "Enable 0x3C";
            this.CHK2.UseVisualStyleBackColor = true;
            // 
            // CHK3
            // 
            this.CHK3.AutoSize = true;
            this.CHK3.Location = new System.Drawing.Point(6, 97);
            this.CHK3.Name = "CHK3";
            this.CHK3.Size = new System.Drawing.Size(85, 17);
            this.CHK3.TabIndex = 3;
            this.CHK3.Text = "Enable 0x48";
            this.CHK3.UseVisualStyleBackColor = true;
            // 
            // CHK4
            // 
            this.CHK4.AutoSize = true;
            this.CHK4.Location = new System.Drawing.Point(6, 120);
            this.CHK4.Name = "CHK4";
            this.CHK4.Size = new System.Drawing.Size(85, 17);
            this.CHK4.TabIndex = 4;
            this.CHK4.Text = "Enable 0x50";
            this.CHK4.UseVisualStyleBackColor = true;
            // 
            // CHK5
            // 
            this.CHK5.AutoSize = true;
            this.CHK5.Location = new System.Drawing.Point(6, 143);
            this.CHK5.Name = "CHK5";
            this.CHK5.Size = new System.Drawing.Size(86, 17);
            this.CHK5.TabIndex = 5;
            this.CHK5.Text = "Enable 0x5C";
            this.CHK5.UseVisualStyleBackColor = true;
            // 
            // CHK6
            // 
            this.CHK6.AutoSize = true;
            this.CHK6.Location = new System.Drawing.Point(6, 166);
            this.CHK6.Name = "CHK6";
            this.CHK6.Size = new System.Drawing.Size(85, 17);
            this.CHK6.TabIndex = 6;
            this.CHK6.Text = "Enable 0x64";
            this.CHK6.UseVisualStyleBackColor = true;
            // 
            // CHK7
            // 
            this.CHK7.AutoSize = true;
            this.CHK7.Location = new System.Drawing.Point(6, 189);
            this.CHK7.Name = "CHK7";
            this.CHK7.Size = new System.Drawing.Size(86, 17);
            this.CHK7.TabIndex = 7;
            this.CHK7.Text = "Enable 0x6C";
            this.CHK7.UseVisualStyleBackColor = true;
            // 
            // CHK8
            // 
            this.CHK8.AutoSize = true;
            this.CHK8.Location = new System.Drawing.Point(6, 212);
            this.CHK8.Name = "CHK8";
            this.CHK8.Size = new System.Drawing.Size(85, 17);
            this.CHK8.TabIndex = 8;
            this.CHK8.Text = "Enable 0x78";
            this.CHK8.UseVisualStyleBackColor = true;
            // 
            // CHK9
            // 
            this.CHK9.AutoSize = true;
            this.CHK9.Location = new System.Drawing.Point(6, 235);
            this.CHK9.Name = "CHK9";
            this.CHK9.Size = new System.Drawing.Size(85, 17);
            this.CHK9.TabIndex = 9;
            this.CHK9.Text = "Enable 0x80";
            this.CHK9.UseVisualStyleBackColor = true;
            // 
            // CHK10
            // 
            this.CHK10.AutoSize = true;
            this.CHK10.Location = new System.Drawing.Point(6, 258);
            this.CHK10.Name = "CHK10";
            this.CHK10.Size = new System.Drawing.Size(85, 17);
            this.CHK10.TabIndex = 10;
            this.CHK10.Text = "Enable 0x88";
            this.CHK10.UseVisualStyleBackColor = true;
            // 
            // CHK11
            // 
            this.CHK11.AutoSize = true;
            this.CHK11.Location = new System.Drawing.Point(6, 281);
            this.CHK11.Name = "CHK11";
            this.CHK11.Size = new System.Drawing.Size(85, 17);
            this.CHK11.TabIndex = 11;
            this.CHK11.Text = "Enable 0x90";
            this.CHK11.UseVisualStyleBackColor = true;
            // 
            // CHK12
            // 
            this.CHK12.AutoSize = true;
            this.CHK12.Location = new System.Drawing.Point(6, 304);
            this.CHK12.Name = "CHK12";
            this.CHK12.Size = new System.Drawing.Size(85, 17);
            this.CHK12.TabIndex = 12;
            this.CHK12.Text = "Enable 0x98";
            this.CHK12.UseVisualStyleBackColor = true;
            // 
            // CHK13
            // 
            this.CHK13.AutoSize = true;
            this.CHK13.Location = new System.Drawing.Point(98, 28);
            this.CHK13.Name = "CHK13";
            this.CHK13.Size = new System.Drawing.Size(86, 17);
            this.CHK13.TabIndex = 13;
            this.CHK13.Text = "Enable 0xA0";
            this.CHK13.UseVisualStyleBackColor = true;
            // 
            // CHK14
            // 
            this.CHK14.AutoSize = true;
            this.CHK14.Location = new System.Drawing.Point(97, 51);
            this.CHK14.Name = "CHK14";
            this.CHK14.Size = new System.Drawing.Size(86, 17);
            this.CHK14.TabIndex = 14;
            this.CHK14.Text = "Enable 0xA8";
            this.CHK14.UseVisualStyleBackColor = true;
            // 
            // CHK15
            // 
            this.CHK15.AutoSize = true;
            this.CHK15.Location = new System.Drawing.Point(97, 74);
            this.CHK15.Name = "CHK15";
            this.CHK15.Size = new System.Drawing.Size(86, 17);
            this.CHK15.TabIndex = 15;
            this.CHK15.Text = "Enable 0xB0";
            this.CHK15.UseVisualStyleBackColor = true;
            // 
            // CHK16
            // 
            this.CHK16.AutoSize = true;
            this.CHK16.Location = new System.Drawing.Point(97, 97);
            this.CHK16.Name = "CHK16";
            this.CHK16.Size = new System.Drawing.Size(86, 17);
            this.CHK16.TabIndex = 16;
            this.CHK16.Text = "Enable 0xB8";
            this.CHK16.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(396, 362);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(113, 26);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // Sett
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 392);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonSaveSett);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Sett";
            this.Text = "Theme Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSaveSett;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_botDraw;
        private System.Windows.Forms.ComboBox CB_topDraw;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox CB_botFrame;
        private System.Windows.Forms.ComboBox CB_topFrame;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox CHK16;
        private System.Windows.Forms.CheckBox CHK15;
        private System.Windows.Forms.CheckBox CHK14;
        private System.Windows.Forms.CheckBox CHK13;
        private System.Windows.Forms.CheckBox CHK12;
        private System.Windows.Forms.CheckBox CHK11;
        private System.Windows.Forms.CheckBox CHK10;
        private System.Windows.Forms.CheckBox CHK9;
        private System.Windows.Forms.CheckBox CHK8;
        private System.Windows.Forms.CheckBox CHK7;
        private System.Windows.Forms.CheckBox CHK6;
        private System.Windows.Forms.CheckBox CHK5;
        private System.Windows.Forms.CheckBox CHK4;
        private System.Windows.Forms.CheckBox CHK3;
        private System.Windows.Forms.CheckBox CHK2;
        private System.Windows.Forms.CheckBox CHK1;
        private System.Windows.Forms.CheckBox CHK0;
        private System.Windows.Forms.Button cancelButton;
    }
}