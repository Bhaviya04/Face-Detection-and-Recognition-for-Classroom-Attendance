using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Face_Recognition_Admin_Portal
{
    public partial class password : System.Web.UI.Page
    {
        MainClass mc = new MainClass();
        SqlConnection cn;
        protected void Page_Load(object sender, EventArgs e)
        {
            cn = mc.Connect();

            if (!(Page.IsPostBack))
            {
                if (Session["profname"] != "")
                {
                    if (Session["profname"] != null)
                    {
                        if (Session["update"] == "updated")
                        {
                            Session["update"] = "";
                            Response.Write("<script language='javascript'>window.alert('Your information updated.');</script>");

                        }
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("update professor set password=@pwd where prof_name=@name;",cn);
            cmd.Parameters.Add(new SqlParameter("@pwd", txtpassword.Text));
            cmd.Parameters.Add(new SqlParameter("@name", Session["profname"].ToString()));
            cmd.ExecuteNonQuery();
            cn.Close();
            Session["update"] = "updated";
            Response.Redirect("password.aspx");
        }
    }
}