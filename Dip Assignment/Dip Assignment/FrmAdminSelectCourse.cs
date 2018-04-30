using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace Dip_Assignment
{
    public partial class FrmAdminSelectCourse : Form
    {
        SqlConnection con = new SqlConnection("Data Source=CSUFLAPTOP-242\\SQLEXPRESS;Initial Catalog=hello;User Id=akash;Password=akash1234;");
        public FrmAdminSelectCourse()
        {
            InitializeComponent();
        }
        private void FrmAdminSelectCourse_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> comboSource = new Dictionary<string,string>();
            comboSource.Add("0", "Select");
            comboBox1.Items.Add(new { Text = "Select", Value = "Select" });
            con.Open();
            SqlCommand cmd = new SqlCommand("select course_id,course_number,course_name from course where prof_id=@profid;",con);
            cmd.Parameters.Add(new SqlParameter("@profid",Convert.ToInt32(Global.Professorid)));
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                comboSource.Add(dr["course_id"].ToString(), dr["course_number"].ToString() + " - " + dr["course_name"].ToString());
            }
            dr.Close();
            con.Close();
            comboBox1.DataSource = new BindingSource(comboSource, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            lblprofessor.Text = "Hello Professor " + Global.Professor;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please Select the Course");
            }
            else
            {
                Global.Courseid = comboBox1.SelectedValue.ToString();
                var adminOptionsForm = new FrmAdminOptions();
                Hide();
                if (adminOptionsForm.ShowDialog() == DialogResult.Cancel)
                {
                    Application.Exit();
                }
            }
        }
    }
}
