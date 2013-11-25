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

namespace InstutiteOfFineArt.Views.Users
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Data();
            }
        }

        private void Load_Data()
        {
            DataTable dtUsers = UserDAO.All();
            gdvUsers.DataSource = dtUsers;
            gdvUsers.DataBind();
            lbCountPaintings.Text = dtUsers.Rows.Count.ToString();
        }

        public string Permission_Label(object permission)
        {
            int val = Convert.ToInt32(permission.ToString());
            if(val == 0)
                return "<span class='label label-danger'>Admin</span>"; //Is admin
            else if (val == 1)
                return "<span class='label label-primary'>Staff</span>"; //Is Staff
            else if (val == 2)
                return "<span class='label label-success'>Manager</span>"; //Is Manager
            else
                return "<span class='label label-default'>Student</span>"; //Is Student
        }

        protected void Destroy_Click(object sender, EventArgs e)
        {
            LinkButton a = sender as LinkButton;
            int id = Convert.ToInt32(a.CommandArgument);
            User u = UserDAO.Find(id);
            if (UserDAO.Destroy(u))
            {
                Flash.dictFlash.Add("success", String.Format("Delete user [<b>{0}</b>] successfully", u.Username));
            }
            else
            {
                Flash.dictFlash.Add("success", String.Format("Cannot delete user [<b>{0}</b>]", u.Username));
            }
            Response.Redirect("Index.aspx");
        }

        protected void gdvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvUsers.PageIndex = e.NewPageIndex;
            Load_Data();
        }
    }
}