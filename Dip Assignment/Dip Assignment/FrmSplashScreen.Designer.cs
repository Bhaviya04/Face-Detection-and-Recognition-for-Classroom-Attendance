namespace Dip_Assignment
{
    partial class FrmSplashScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSplashScreen));
            this.splashTimer = new System.Windows.Forms.Timer(this.components);
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblAppDescription = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splashTimer
            // 
            this.splashTimer.Enabled = true;
            this.splashTimer.Interval = 1000;
            this.splashTimer.Tick += new System.EventHandler(this.splashTimer_Tick);
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.Location = new System.Drawing.Point(72, 54);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(24, 24);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "..";
            // 
            // lblAppDescription
            // 
            this.lblAppDescription.AutoSize = true;
            this.lblAppDescription.Location = new System.Drawing.Point(76, 117);
            this.lblAppDescription.Name = "lblAppDescription";
            this.lblAppDescription.Size = new System.Drawing.Size(13, 13);
            this.lblAppDescription.TabIndex = 1;
            this.lblAppDescription.Text = "..";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(368, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 240);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // FrmSplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 296);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblAppDescription);
            this.Controls.Add(this.lblAppName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSplashScreen";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmSplashScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer splashTimer;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblAppDescription;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}