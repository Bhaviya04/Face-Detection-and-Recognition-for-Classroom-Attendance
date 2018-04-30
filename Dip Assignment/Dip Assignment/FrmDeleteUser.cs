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
    public partial class FrmDeleteUser : Form
    {
        private readonly String _databasePath = Application.StartupPath + "/face_store.db";
        public FrmDeleteUser()
        {
            InitializeComponent();
        }

        private void FrmDeleteUser_Load(object sender, EventArgs e)
        {
            LoadAllUsers();
        }

        private void LoadAllUsers()
        {
            IDataStoreAccess dataStore = new DataStoreAccess(_databasePath);
            var allUsernames = dataStore.GetAllUsernames();
            lstBoxUsernames.DataSource = allUsernames;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            IDataStoreAccess dataStore = new DataStoreAccess(_databasePath);
            var selectedUsername = (String)lstBoxUsernames.SelectedValue;
            if (String.Empty != selectedUsername)
            {
                var messageBox = MessageBox.Show(String.Format("Are you sure you want to Disenroll {0}?", selectedUsername.ToUpper()), "Disenroll Student",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (messageBox == DialogResult.Yes)
                {
                        dataStore.DeleteUser(selectedUsername);
                        MessageBox.Show(selectedUsername.ToUpper() + " has been Disenrolled", "Student Deleted",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadAllUsers();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            var adminoptions = new FrmAdminOptions();
            if (adminoptions.ShowDialog() == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }
    }
}
