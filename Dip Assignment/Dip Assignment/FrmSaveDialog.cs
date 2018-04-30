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
    public partial class FrmSaveDialog : Form
    {
        public string _identificationNumber = "";
        public FrmSaveDialog()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _identificationNumber = txtUsername.Text;
        }
    }
}
