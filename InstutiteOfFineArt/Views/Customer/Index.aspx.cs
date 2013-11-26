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

namespace InstutiteOfFineArt.Views.Customer
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
            DataTable dtCustomer = CustomerDAO.All();
            gdvCustomers.DataSource = dtCustomer;
            gdvCustomers.DataBind();
            lbCountCustomer.Text = dtCustomer.Rows.Count.ToString();
        }

        public string Gender_Label(object gender)
        {
            Boolean val = Convert.ToBoolean(gender.ToString());
            if(val == true)
                return "<span class='label label-danger'>Male</span>"; //Is admin
            else
                return "<span class='label label-primary'>Female</span>"; //Is Staff
        }

        protected void Destroy_Click(object sender, EventArgs e)
        {
            LinkButton a = sender as LinkButton;
            int id = Convert.ToInt32(a.CommandArgument);
            Models.Customer u = CustomerDAO.Find(id);
            if (CustomerDAO.Destroy(u))
            {
                Flash.dictFlash.Add("success", String.Format("Delete customer [<b>{0}</b>] successfully", u.CustomerName));
            }
            else
            {
                Flash.dictFlash.Add("success", String.Format("Cannot delete customer [<b>{0}</b>]", u.CustomerName));
            }
            Response.Redirect("Index.aspx");
        }

        protected void gdvCustomers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvCustomers.PageIndex = e.NewPageIndex;
            Load_Data();
        }
    }
}