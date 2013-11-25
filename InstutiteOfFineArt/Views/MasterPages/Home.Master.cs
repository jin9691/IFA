using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InstutiteOfFineArt.Models;

namespace InstutiteOfFineArt.Views.MasterPages
{
    public partial class Home : System.Web.UI.MasterPage
    {
        public User current_user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["current_user"] != null)
            {
                current_user = (User)Session["current_user"];
            }
        }
    }
}