using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Text;

namespace Face_Recognition_Admin_Portal
{
    public partial class admin : System.Web.UI.MasterPage
    {
        MainClass mc = new MainClass();
        SqlConnection cn;
        protected void Page_Load(object sender, EventArgs e)
        {
            cn = mc.Connect();
            if (Session["profname"] != "")
            {
                if (Session["profname"] != null)
                {
                    if(Session["profname"] == "admin")
                    {
                        pnl_admin.Visible = true;
                        ltr_prof.Visible = false;
                        pnl_changepassword.Visible = false;
                    }
                    else
                    {
                        pnl_admin.Visible = false;
                        ltr_prof.Visible = true;
                        pnl_changepassword.Visible = true;
                        getcourses();
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
        protected void link_emailverify_click(object sender, EventArgs e)
        {
            Session["profname"] = null;

            Response.Redirect("Default.aspx");
        }
        protected void getcourses()
        {
            StringBuilder sb = new StringBuilder();
            cn.Open();
            SqlCommand cmd = new SqlCommand("select c.course_id,c.course_name from course c join professor p on c.prof_id = p.prof_id where p.prof_name=@name;",cn);
            cmd.Parameters.Add(new SqlParameter("@name", Session["profname"].ToString()));
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                sb.Append("<li>");
                sb.Append("<a href='showdetails.aspx?course=" + dr[0].ToString() + "'>");
                sb.Append("<span class='fa fa-edit'></span>");
                sb.Append(dr[1].ToString());
                sb.Append("</a>");
                sb.Append("</li>");
            }
            dr.Close();
            cn.Close();

            ltr_prof.Text = sb.ToString();
        }
    }
}