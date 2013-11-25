using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InstutiteOfFineArt.Codes;
using InstutiteOfFineArt.Daos;
using InstutiteOfFineArt.Models;

namespace InstutiteOfFineArt.Views.Sessions
{
    public partial class New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["current_user"] != null)
            {
                Response.Redirect("../StaticPages/Home.aspx");
            }
        }

        protected void SignIn_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> myQuery = new Dictionary<string, object>();
            myQuery.Add("Username", txtUsername.Text);
            myQuery.Add("Password", Md5.To_Md5(txtPassword.Text));
            User u = UserDAO.Where(myQuery);
            if (u != null)
            {
                Session["current_user"] = u;
                Response.Redirect("../StaticPages/Home.aspx");
            }
            else
            {
                Flash.dictFlash.Add("danger", "Wrong <b>Username</b> Or <b>Password</b>");
            }
        }
    }
}