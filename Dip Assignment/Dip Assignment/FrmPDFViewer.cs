using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dip_Assignment
{
    public partial class FrmPDFViewer : Form
    {
        public String FilePath;
        public FrmPDFViewer(String filePath)
        {
            FilePath = filePath;
            InitializeComponent();
        }

        private void FrmPDFViewer_Load(object sender, EventArgs e)
        {
            pdfWebBrowser.Navigate(@FilePath);
        }
    }
}
