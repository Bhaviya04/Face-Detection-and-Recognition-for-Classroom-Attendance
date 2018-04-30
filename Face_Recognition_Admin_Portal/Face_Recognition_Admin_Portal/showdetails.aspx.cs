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
    public partial class showdetails : System.Web.UI.Page
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
                        showdates();
                        showcourse();
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
            SqlDataAdapter da = new SqlDataAdapter("select uname,CONVERT(VARCHAR(11), date, 106) as date from registered where course_id=@courseid;", cn);
            da.SelectCommand.Parameters.AddWithValue("@courseid", Convert.ToInt32(Request.QueryString["course"]));
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void showdates()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select distinct(CONVERT(VARCHAR(11), date, 106)) from registered where course_id=@courseid;", cn);
            cmd.Parameters.Add(new SqlParameter("@courseid", Convert.ToInt32(Request.QueryString["course"])));
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListItem i = new ListItem(dr[0].ToString(), dr[0].ToString());
                ddldate.Items.Add(i);
            }
            dr.Close();
            cn.Close();
        }
        protected void showcourse()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select course_number from course where course_id=@courseid;", cn);
            cmd.Parameters.Add(new SqlParameter("@courseid", Convert.ToInt32(Request.QueryString["course"])));
            lblcoursename.Text = cmd.ExecuteScalar().ToString();
            lblcoursename1.Text = cmd.ExecuteScalar().ToString();
            cn.Close();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "" && ddldate.SelectedValue.ToString() == "0")
            {
                lblerror.Visible = true;
            }
            else
            {
                lblerror.Visible = false;
                if (txtname.Text != "" && ddldate.SelectedValue.ToString() == "0")
                {
                    SqlDataAdapter da = new SqlDataAdapter("select uname,CONVERT(VARCHAR(11), date, 106) as date from registered where uname=@name and course_id=@courseid;", cn);
                    da.SelectCommand.Parameters.AddWithValue("@name", txtname.Text);
                    da.SelectCommand.Parameters.AddWithValue("@courseid", Convert.ToInt32(Request.QueryString["course"]));
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                if (txtname.Text == "" && ddldate.SelectedValue.ToString() != "0")
                {
                    SqlDataAdapter da = new SqlDataAdapter("select uname,CONVERT(VARCHAR(11), date, 106) as date from registered where date=@date and course_id=@courseid;", cn);
                    da.SelectCommand.Parameters.AddWithValue("@date", Convert.ToDateTime(ddldate.SelectedValue));
                    da.SelectCommand.Parameters.AddWithValue("@courseid", Convert.ToInt32(Request.QueryString["course"]));
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                if (txtname.Text != "" && ddldate.SelectedValue.ToString() != "0")
                {
                    SqlDataAdapter da = new SqlDataAdapter("select uname,CONVERT(VARCHAR(11), date, 106) as date from registered where uname=@name and date=@date and course_id=@courseid;", cn);
                    da.SelectCommand.Parameters.AddWithValue("@name", txtname.Text);
                    da.SelectCommand.Parameters.AddWithValue("@date", Convert.ToDateTime(ddldate.SelectedValue));
                    da.SelectCommand.Parameters.AddWithValue("@courseid", Convert.ToInt32(Request.QueryString["course"]));
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("showreport.aspx?course="+Request.QueryString["course"].ToString());
        }
    }
}