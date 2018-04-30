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
using System.Net.Mail;
using System.Net;

namespace Face_Recognition_Admin_Portal
{
    public partial class professor : System.Web.UI.Page
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
            SqlDataAdapter da = new SqlDataAdapter("select * from professor;", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["mode"] == "Edit")
            {
                string pwd = CreatePassword(9);
                cn.Open();

                SqlCommand cmd = new SqlCommand("update professor set prof_name=@pname,username=@uname,password=@pwd where prof_id=@id;", cn);
                cmd.Parameters.Add(new SqlParameter("@id", Convert.ToInt32(Request.QueryString["id"])));
                cmd.Parameters.Add(new SqlParameter("@pname", txtname.Text));
                cmd.Parameters.Add(new SqlParameter("@uname", txtusername.Text));
                cmd.Parameters.Add(new SqlParameter("@pwd", pwd));

                cmd.ExecuteNonQuery();

                cn.Close();

                // Send Email containing password
                string emailto = txtusername.Text + "@fullerton.edu";
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("adityashahhabit@gmail.com");
                    mail.To.Add(emailto);
                    mail.Subject = "Attendance System Updates";
                    mail.Body = "To log in to the Admin Portal - Username=" + txtusername.Text + " and Password=" + pwd;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("adityashahhabit@gmail.com", "adityashah123");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                Session["update"] = "updated";
                Response.Redirect("professor.aspx");
            }
            else
            {
                string pwd = CreatePassword(9);
                cn.Open();

                SqlCommand cmd = new SqlCommand("insert into professor values(@pname,@uname,@pwd);", cn);
                cmd.Parameters.Add(new SqlParameter("@pname", txtname.Text));
                cmd.Parameters.Add(new SqlParameter("@uname", txtusername.Text));
                cmd.Parameters.Add(new SqlParameter("@pwd", pwd));

                cmd.ExecuteNonQuery();

                cn.Close();

                // Send Email containing password

                string emailto = txtusername.Text + "@fullerton.edu";
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("adityashahhabit@gmail.com");
                    mail.To.Add(emailto);
                    mail.Subject = "Attendance System Updates";
                    mail.Body = "To log in to the Admin Portal - Username=" + txtusername.Text + " and Password=" + pwd;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("adityashahhabit@gmail.com", "adityashah123");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                Session["insert"] = "inserted";
                Response.Redirect("professor.aspx");
            }
        }
        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                Response.Redirect("professor.aspx?mode=Edit&id=" + e.CommandArgument);
            }
        }
        protected void getdetails()
        {
            cn.Open();

            SqlCommand cmd4 = new SqlCommand("select * from professor where prof_id=@id;", cn);
            cmd4.Parameters.Add(new SqlParameter("@id", Request.QueryString["id"]));
            SqlDataReader dr4 = cmd4.ExecuteReader();
            if (dr4.Read())
            {
                txtname.Text = dr4[1].ToString();
                txtusername.Text = dr4[2].ToString();
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