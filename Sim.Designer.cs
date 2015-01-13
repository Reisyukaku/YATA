namespace YATE {
    partial class Sim {
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
            this.bottomImage = new System.Windows.Forms.PictureBox();
            this.topImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bottomImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topImage)).BeginInit();
            this.SuspendLayout();
            // 
            // bottomImage
            // 
            this.bottomImage.Location = new System.Drawing.Point(40, 240);
            this.bottomImage.Name = "bottomImage";
            this.bottomImage.Size = new System.Drawing.Size(320, 240);
            this.bottomImage.TabIndex = 1;
            this.bottomImage.TabStop = false;
            // 
            // topImage
            // 
            this.topImage.Location = new System.Drawing.Point(0, 0);
            this.topImage.Name = "topImage";
            this.topImage.Size = new System.Drawing.Size(400, 240);
            this.topImage.TabIndex = 0;
            this.topImage.TabStop = false;
            // 
            // Sim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(400, 482);
            this.Controls.Add(this.bottomImage);
            this.Controls.Add(this.topImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Sim";
            this.Text = "Theme Simulator";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Sim_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bottomImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox topImage;
        private System.Windows.Forms.PictureBox bottomImage;
    }
}