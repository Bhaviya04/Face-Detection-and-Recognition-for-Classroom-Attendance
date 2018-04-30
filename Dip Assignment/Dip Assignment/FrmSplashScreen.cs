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
    public partial class FrmSplashScreen : Form
    {
        private int _timeShown = 0;
        private FrmAdminLogin _frmAdminLogin;
        public FrmSplashScreen(FrmAdminLogin adminLoginForm)
        {
            _frmAdminLogin = adminLoginForm;
            InitializeComponent();
        }

        private void splashTimer_Tick(object sender, EventArgs e)
        {
            if (_timeShown > 5)
            {
                splashTimer.Stop();
                splashTimer.Enabled = false;
              _frmAdminLogin.Show();
                Close();
            }else _timeShown++;
        }

        private void FrmSplashScreen_Load(object sender, EventArgs e)
        {
            //lblAppName.Text = (String)Properties.Settings.Default["appName"];
            //lblAppDescription.Text = (String)Properties.Settings.Default["appDescriptionText"];
            lblAppName.Text = "Face Recognition Application";
            lblAppDescription.Text = "Built and Developed by Bhaviya Rajesh Gandani";
        }
    }
}
