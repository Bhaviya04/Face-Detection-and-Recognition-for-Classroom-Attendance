using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Dip_Assignment
{
    public partial class FrmAdminLogin : Form
    {
        SqlConnection con = new SqlConnection("Data Source=CSUFLAPTOP-242\\SQLEXPRESS;Initial Catalog=hello;User Id=akash;Password=akash1234;");
        public FrmAdminLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "" || txtPassword.Text == "")
            {
                txtUsername.Text = "";
                txtPassword.Text = "";
                MessageBox.Show("Please Input Username and Password");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from professor where username=@name and password=@pwd;", con);
                cmd.Parameters.Add(new SqlParameter("@name", txtUsername.Text));
                cmd.Parameters.Add(new SqlParameter("@pwd", txtPassword.Text));
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                if (count >= 1)
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("select prof_id,prof_name from professor where username=@name and password=@pwd;", con);
                    cmd1.Parameters.Add(new SqlParameter("@name", txtUsername.Text));
                    cmd1.Parameters.Add(new SqlParameter("@pwd", txtPassword.Text));
                    SqlDataReader dr = cmd1.ExecuteReader();
                    while(dr.Read())
                    {
                        Global.Professor = dr["prof_name"].ToString();
                        Global.Professorid = dr["prof_id"].ToString();
                    }
                    dr.Close();
                    MessageBox.Show("Login Successful. Welcome Professor " + Global.Professor);
                    con.Close();
                    var adminSelectCourse = new FrmAdminSelectCourse();
                    Hide();
                    if (adminSelectCourse.ShowDialog() == DialogResult.Cancel)
                    {
                        Application.Exit();
                    }
                    //var adminOptionsForm = new FrmAdminOptions();
                    //Hide();
                    //if (adminOptionsForm.ShowDialog() == DialogResult.Cancel)
                    //{
                    //    Show();
                    //}
                }
                else
                {
                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    MessageBox.Show("Invalid Username/Password");
                }
            }
        }

        private void FrmAdminLogin_Load(object sender, EventArgs e)
        {
            Hide();
            //Show SplashScreen first
            var splashScreen = new FrmSplashScreen(this);
            splashScreen.Show();
        }

        //private void btnUserLogin_Click(object sender, EventArgs e)
        //{
        //    Hide();
        //    var mainForm = new FrmMain(true);
        //    if (mainForm.ShowDialog() == DialogResult.Cancel)
        //    {
        //        Show();
        //    }
        //}
    }
}
