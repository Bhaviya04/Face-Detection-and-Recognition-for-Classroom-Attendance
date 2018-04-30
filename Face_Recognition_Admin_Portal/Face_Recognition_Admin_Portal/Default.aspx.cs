using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace Face_Recognition_Admin_Portal
{
    public partial class Default : System.Web.UI.Page
    {
        MainClass mc = new MainClass();
        SqlConnection cn;
        protected void Page_Load(object sender, EventArgs e)
        {
            cn = mc.Connect();
            if (!(Page.IsPostBack))
            {
                if (Session["profname"] != null)
                {
                    Response.Redirect("dashboard.aspx");
                }
            }
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select count(prof_id) from professor where username=@name and password=@pwd;",cn);
            cmd.Parameters.Add(new SqlParameter("@name", txtusername.Text));
            cmd.Parameters.Add(new SqlParameter("@pwd", txtpassword.Text));
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();

            if(count == 1)
            {
                cn.Open();
                SqlCommand cmd1 = new SqlCommand("select prof_name from professor where username=@name and password=@pwd;", cn);
                cmd1.Parameters.Add(new SqlParameter("@name", txtusername.Text));
                cmd1.Parameters.Add(new SqlParameter("@pwd", txtpassword.Text));
                string prof_name = cmd1.ExecuteScalar().ToString();
                Session["profname"] = prof_name;
                Response.Redirect("dashboard.aspx");
                cn.Close();
            }
            else if (txtusername.Text == "admin" && txtpassword.Text == "admin")
            {
                Session["profname"] = "admin";
                Response.Redirect("dashboard.aspx");
            }
            else
            {
                lbldisplay.Text = "* Invalid username or password";
            }
        }
    }
}