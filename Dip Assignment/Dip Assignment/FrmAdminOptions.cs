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
    public partial class FrmAdminOptions : Form
    {
        public FrmAdminOptions()
        {
            InitializeComponent();
        }
        
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            Hide();
            var mainForm = new FrmMain("enroll");
            if (mainForm.ShowDialog() == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }

        private void btnDisenroll_Click(object sender, EventArgs e)
        {
            Hide();
            var deleteUserForm = new FrmDeleteUser();
            if (deleteUserForm.ShowDialog() == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }

        private void btnTrainRecognizer_Click(object sender, EventArgs e)
        {
            Hide();
            var mainForm = new FrmMain("recognizer");
            if (mainForm.ShowDialog() == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            Hide();
            var mainForm = new FrmMain("attendance");
            if (mainForm.ShowDialog() == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }
    }
}
