using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace Face_Recognition_Admin_Portal
{
    public partial class showreport : System.Web.UI.Page
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
                        showtotallectures();
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
            //SqlDataAdapter da = new SqlDataAdapter("select r.uname,c.course_number,count(r.uname) as present from registered r join course c on r.course_id = c.course_id where r.course_id = @courseid group by r.uname, c.course_number", cn);
            //SqlDataAdapter da = new SqlDataAdapter("select r.uname,c.course_number,count(r.date) as present,(select count(distinct(date)) from registered where course_id=@courseid) as lectures, (select (count(re.date)/count(distinct(rg.date))) * 100 from registered re join registered rg on re.course_id=rg.course_id where rg.course_id=@courseid group by re.uname,re.course_id) as grades from registered r join course c on r.course_id = c.course_id where r.course_id = @courseid group by r.uname, c.course_number;", cn);
            SqlDataAdapter da = new SqlDataAdapter("select r.uname,c.course_number,count(r.date) as present, (select count(distinct(date)) from registered where course_id=@courseid) as lectures from registered r join course c on r.course_id = c.course_id where r.course_id = @courseid group by r.uname, c.course_number;", cn);
            da.SelectCommand.Parameters.AddWithValue("@courseid", Convert.ToInt32(Request.QueryString["course"]));
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void showtotallectures()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select count(distinct(date)) from registered where course_id=@courseid;", cn);
            cmd.Parameters.Add(new SqlParameter("@courseid", Convert.ToInt32(Request.QueryString["course"])));
            lbltotallectures.Text = cmd.ExecuteScalar().ToString();
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
        protected void ExportToExcel(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView1.AllowPaging = false;
                showgrid();

                GridView1.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    cell.BackColor = GridView1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                GridView1.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> TABLE { border: 1px solid black; } TD { border: 1px solid black; } </style> ";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
    }
}