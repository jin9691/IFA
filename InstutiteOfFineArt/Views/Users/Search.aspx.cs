using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InstutiteOfFineArt.Codes;
using InstutiteOfFineArt.Models;
using InstutiteOfFineArt.Daos;

namespace InstutiteOfFineArt.Views.Users
{
    public partial class Search : System.Web.UI.Page
    {
        //private string search_query;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Form["txtSearch"] != null && Request.Form["txtSearch"] != "")
                {
                    Session["search_query"] = Request.Form["txtSearch"];
                    Load_Data();
                }
                else
                {
                    Flash.dictFlash.Add("danger", "Query string cannot be blank");
                }
            }
        }

        private void Load_Data()
        {
                List<string> query = new List<string>();
                query.Add(String.Format("Username like '%{0}%'", Session["search_query"]));
                query.Add(String.Format("Email like '%{0}%'", Session["search_query"]));
                DataTable dtUsers = UserDAO.Search(query);
                if (dtUsers.Rows.Count > 0)
                {
                    Flash.dictFlash.Add("success", String.Format("Found <b>{0} user</b> matched '<b>{1}</b>'", dtUsers.Rows.Count, Session["search_query"]));
                    gdvUsers.DataSource = dtUsers;
                    gdvUsers.DataBind();
                }
                else
                {
                    Flash.dictFlash.Add("warning","No data match found");
                }
            
        }

        public string Permission_Label(object permission)
        {
            int val = Convert.ToInt32(permission.ToString());
            if (val == 0)
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
            Flash.dictFlash.Clear();
        }
    }
}