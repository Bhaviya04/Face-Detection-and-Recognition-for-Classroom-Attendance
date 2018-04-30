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
    public partial class course : System.Web.UI.Page
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
                        showgrid();
                        showprofessors();

                        if (Session["insert"] == "inserted")
                        {
                            Session["insert"] = "";
                            Response.Write("<script language='javascript'>window.alert('Your information added.');</script>");

                        }

                        if (Session["update"] == "updated")
                        {
                            Session["update"] = "";
                            Response.Write("<script language='javascript'>window.alert('Your information updated.');</script>");

                        }

                        if (Request.QueryString["mode"] == "Edit")
                        {
                            getdetails();
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
        protected void showgrid()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from professor join course on course.prof_id = professor.prof_id;", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void showprofessors()
        {
            ddlprofessor.Items.Add(new ListItem("Select","0"));
            cn.Open();
            SqlCommand cmd = new SqlCommand("select prof_id,prof_name from professor;", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                ddlprofessor.Items.Add(new ListItem(dr[1].ToString(),dr[0].ToString()));
            }
            dr.Close();
            cn.Close();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["mode"] == "Edit")
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("update course set prof_id=@profid,course_name=@cname,course_number=@cnumber where course_id=@id;", cn);
                cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(Request.QueryString["id"])));
                cmd.Parameters.Add(new SqlParameter("@profid", Convert.ToInt32(ddlprofessor.SelectedValue)));
                cmd.Parameters.Add(new SqlParameter("@cname", txtcoursename.Text));
                cmd.Parameters.Add(new SqlParameter("@cnumber", txtcoursenumber.Text));

                cmd.ExecuteNonQuery();

                cn.Close();
                Session["update"] = "updated";
                Response.Redirect("course.aspx");
            }
            else
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("insert into course values(@profid,@cname,@cnumber);", cn);
                cmd.Parameters.Add(new SqlParameter("@profid", Convert.ToInt32(ddlprofessor.SelectedValue)));
                cmd.Parameters.Add(new SqlParameter("@cname", txtcoursename.Text));
                cmd.Parameters.Add(new SqlParameter("@cnumber", txtcoursenumber.Text));

                cmd.ExecuteNonQuery();

                cn.Close();
                Session["insert"] = "inserted";
                Response.Redirect("course.aspx");
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                Response.Redirect("course.aspx?mode=Edit&id=" + e.CommandArgument);
            }
        }
        protected void getdetails()
        {
            cn.Open();

            SqlCommand cmd4 = new SqlCommand("select * from course where course_id=@id;", cn);
            cmd4.Parameters.Add(new SqlParameter("@id", Request.QueryString["id"]));
            SqlDataReader dr4 = cmd4.ExecuteReader();
            ddlprofessor.ClearSelection();
            if (dr4.Read())
            {
                ddlprofessor.Items.FindByValue(dr4[1].ToString()).Selected = true;
                txtcoursename.Text = dr4[2].ToString();
                txtcoursenumber.Text = dr4[3].ToString();
                dr4.Close();
            }
            else
            {
                dr4.Close();
            }

            cn.Close();
        }
    }
}