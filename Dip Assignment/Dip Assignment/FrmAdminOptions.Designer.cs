namespace Dip_Assignment
{
    partial class FrmAdminOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdminOptions));
            this.btnEnroll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDisenroll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAttendance = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTrainRecognizer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEnroll
            // 
            this.btnEnroll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEnroll.BackgroundImage")));
            this.btnEnroll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEnroll.Location = new System.Drawing.Point(46, 29);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(99, 87);
            this.btnEnroll.TabIndex = 0;
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enroll Student";
            // 
            // btnDisenroll
            // 
            this.btnDisenroll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDisenroll.BackgroundImage")));
            this.btnDisenroll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDisenroll.Location = new System.Drawing.Point(639, 29);
            this.btnDisenroll.Name = "btnDisenroll";
            this.btnDisenroll.Size = new System.Drawing.Size(102, 87);
            this.btnDisenroll.TabIndex = 2;
            this.btnDisenroll.UseVisualStyleBackColor = true;
            this.btnDisenroll.Click += new System.EventHandler(this.btnDisenroll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(616, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Disenroll Student";
            // 
            // btnAttendance
            // 
            this.btnAttendance.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAttendance.BackgroundImage")));
            this.btnAttendance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAttendance.Location = new System.Drawing.Point(430, 29);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(99, 87);
            this.btnAttendance.TabIndex = 4;
            this.btnAttendance.UseVisualStyleBackColor = true;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(408, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Take Attendance";
            // 
            // btnTrainRecognizer
            // 
            this.btnTrainRecognizer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTrainRecognizer.BackgroundImage")));
            this.btnTrainRecognizer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTrainRecognizer.Location = new System.Drawing.Point(233, 29);
            this.btnTrainRecognizer.Name = "btnTrainRecognizer";
            this.btnTrainRecognizer.Size = new System.Drawing.Size(99, 87);
            this.btnTrainRecognizer.TabIndex = 6;
            this.btnTrainRecognizer.UseVisualStyleBackColor = true;
            this.btnTrainRecognizer.Click += new System.EventHandler(this.btnTrainRecognizer_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(217, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Train Reconizer";
            // 
            // FrmAdminOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 185);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnTrainRecognizer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAttendance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDisenroll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEnroll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdminOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrative Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDisenroll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAttendance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTrainRecognizer;
        private System.Windows.Forms.Label label4;
    }
}