using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InstutiteOfFineArt.Models;

namespace InstutiteOfFineArt.Views.MasterPages
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["current_user"] != null)
            {
                User u = (User)Session["current_user"];
                if (u.Permission != 0)
                    Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Redirect("../StaticPages/Home.aspx");
            }
        }
    }
}