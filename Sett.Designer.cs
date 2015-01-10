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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonSaveSett = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.texTopDraw = new System.Windows.Forms.TextBox();
            this.texBotDraw = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.texBotDraw);
            this.groupBox1.Controls.Add(this.texTopDraw);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 149);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flags";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(12, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 189);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Colors";
            // 
            // buttonSaveSett
            // 
            this.buttonSaveSett.Location = new System.Drawing.Point(234, 362);
            this.buttonSaveSett.Name = "buttonSaveSett";
            this.buttonSaveSett.Size = new System.Drawing.Size(113, 26);
            this.buttonSaveSett.TabIndex = 2;
            this.buttonSaveSett.Text = "Save";
            this.buttonSaveSett.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Top Draw:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bottom Draw:";
            // 
            // texTopDraw
            // 
            this.texTopDraw.Location = new System.Drawing.Point(90, 32);
            this.texTopDraw.Name = "texTopDraw";
            this.texTopDraw.Size = new System.Drawing.Size(35, 20);
            this.texTopDraw.TabIndex = 2;
            // 
            // texBotDraw
            // 
            this.texBotDraw.Location = new System.Drawing.Point(90, 58);
            this.texBotDraw.Name = "texBotDraw";
            this.texBotDraw.Size = new System.Drawing.Size(35, 20);
            this.texBotDraw.TabIndex = 3;
            // 
            // Sett
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 392);
            this.Controls.Add(this.buttonSaveSett);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Sett";
            this.Text = "Theme Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSaveSett;
        private System.Windows.Forms.TextBox texBotDraw;
        private System.Windows.Forms.TextBox texTopDraw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}