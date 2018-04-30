using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Face_Recognition_Admin_Portal
{
    public class MainClass
    {
        SqlConnection con;
        public SqlConnection Connect()
        {
            con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ConnectionString);
            return con;
        }
    }
}