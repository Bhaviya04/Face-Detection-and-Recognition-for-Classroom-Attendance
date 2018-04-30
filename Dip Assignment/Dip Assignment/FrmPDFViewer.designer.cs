namespace Dip_Assignment
{
    partial class FrmPDFViewer
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
            this.pdfWebBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // pdfWebBrowser
            // 
            this.pdfWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.pdfWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.pdfWebBrowser.Name = "pdfWebBrowser";
            this.pdfWebBrowser.Size = new System.Drawing.Size(1122, 664);
            this.pdfWebBrowser.TabIndex = 0;
            // 
            // FrmPDFViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 664);
            this.Controls.Add(this.pdfWebBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPDFViewer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PDF Viewer";
            this.Load += new System.EventHandler(this.FrmPDFViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser pdfWebBrowser;
    }
}