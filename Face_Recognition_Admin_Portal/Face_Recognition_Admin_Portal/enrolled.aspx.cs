using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Face_Recognition_Admin_Portal
{
    public partial class enrolled : System.Web.UI.Page
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

                        if (Session["insert"] == "inserted")
                        {
                            Session["insert"] = "";
                            Response.Write("<script language='javascript'>window.alert('Your information added.');</script>");

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
            SqlDataAdapter da = new SqlDataAdapter("select * from student;", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void Upload(object sender, EventArgs e)
        {
            //Upload and save the file
            string csvPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(csvPath);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("cwid", typeof(Int64)),
            new DataColumn("uname", typeof(string)),
            new DataColumn("course_number",typeof(string)) });


            string csvData = File.ReadAllText(csvPath);
            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;
                    foreach (string cell in row.Split(','))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell.Trim();
                        i++;
                    }
                }
            }

            string consString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (SqlConnection con = new SqlConnection(consString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name
                    sqlBulkCopy.DestinationTableName = "dbo.student";
                    sqlBulkCopy.ColumnMappings.Add("cwid", "cwid");
                    sqlBulkCopy.ColumnMappings.Add("uname", "uname");
                    sqlBulkCopy.ColumnMappings.Add("course_number", "course_number");
                    con.Open();
                    sqlBulkCopy.WriteToServer(dt);
                    con.Close();
                }
            }
            Session["insert"] = "inserted";
            Response.Redirect("enrolled.aspx");
        }
    }
}