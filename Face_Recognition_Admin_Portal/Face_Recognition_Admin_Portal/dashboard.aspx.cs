using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Face_Recognition_Admin_Portal
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["profname"] != "")
            {
                if (Session["profname"] != null)
                {
                    
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}