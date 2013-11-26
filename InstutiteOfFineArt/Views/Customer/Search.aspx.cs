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

namespace InstutiteOfFineArt.Views.Customer
{
    public partial class Search : System.Web.UI.Page
    {
        private string search_query;
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
                query.Add(String.Format("CustomerName like '%{0}%'", Session["search_query"]));
                query.Add(String.Format("CustomerEmail like '%{0}%'", Session["search_query"]));
                DataTable dtCustomers = CustomerDAO.Search(query);
                if (dtCustomers.Rows.Count > 0)
                {
                    Flash.dictFlash.Add("success", String.Format("Found <b>{0} Customer(s)</b> matched '<b>{1}</b>'", dtCustomers.Rows.Count, Session["search_query"]));
                    gdvCustomers.DataSource = dtCustomers;
                    gdvCustomers.DataBind();
                }
                else
                {
                    Flash.dictFlash.Add("warning","No data match found");
                }
            
        }

        public string Gender_Label(object gender)
        {
            Boolean val = Convert.ToBoolean(gender.ToString());
            if (val == true)
                return "<span class='label label-danger'>Male</span>"; 
            else
                return "<span class='label label-primary'>Female</span>"; 
        }


        protected void Destroy_Click(object sender, EventArgs e)
        {
            LinkButton a = sender as LinkButton;
            int id = Convert.ToInt32(a.CommandArgument);
            Models.Customer u = CustomerDAO.Find(id);
            if (CustomerDAO.Destroy(u))
            {
                Flash.dictFlash.Add("success", String.Format("Delete Customer [<b>{0}</b>] successfully", u.CustomerName));
            }
            else
            {
                Flash.dictFlash.Add("success", String.Format("Cannot delete Customer [<b>{0}</b>]", u.CustomerName));
            }
            Response.Redirect("Index.aspx");
        }

        protected void gdvCustomers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvCustomers.PageIndex = e.NewPageIndex;
            Load_Data();
            Flash.dictFlash.Clear();
        }
    }
}