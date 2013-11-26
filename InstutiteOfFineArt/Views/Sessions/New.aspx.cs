using System;
using System.Collections.Generic;
using System.Data;
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
            DataTable dt = UserDAO.Where(myQuery);
            if (dt.Rows.Count > 0)
            {
                User u = new User();
                u.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                u.Name = dt.Rows[0]["Name"].ToString();
                u.Username = dt.Rows[0]["Username"].ToString();
                u.Email = dt.Rows[0]["Email"].ToString();
                u.Gender = bool.Parse(dt.Rows[0]["Gender"].ToString());
                u.Birthday = DateTime.Parse(dt.Rows[0]["Birthday"].ToString());
                u.Address = dt.Rows[0]["Address"].ToString();
                u.Phone = dt.Rows[0]["Phone"].ToString();
                u.Permission = Convert.ToInt32(dt.Rows[0]["Permission"].ToString());
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