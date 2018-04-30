namespace Dip_Assignment
{
    partial class Form1
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
            this.imgCamUser = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgCamUser)).BeginInit();
            this.SuspendLayout();
            // 
            // imgCamUser
            // 
            this.imgCamUser.Location = new System.Drawing.Point(24, 25);
            this.imgCamUser.Name = "imgCamUser";
            this.imgCamUser.Size = new System.Drawing.Size(711, 432);
            this.imgCamUser.TabIndex = 2;
            this.imgCamUser.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 491);
            this.Controls.Add(this.imgCamUser);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgCamUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Emgu.CV.UI.ImageBox imgCamUser;
    }
}

