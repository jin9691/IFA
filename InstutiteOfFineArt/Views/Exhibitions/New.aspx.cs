using InstutiteOfFineArt.Codes;
using InstutiteOfFineArt.Daos;
using InstutiteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InstutiteOfFineArt.Views.Exhibitions
{
    public partial class New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> query = new List<string>();
                query.Add(String.Format("Permission like '%{0}%'", 2));

                ddlManagerName.DataSource = UserDAO.Search(query);
                ddlManagerName.DataValueField = "Id"; //The Value of the DropDownList, to get it you should call ddlDepartments.SelectedValue;
                ddlManagerName.DataTextField = "Name"; //The Name shown of the DropDownList.
                ddlManagerName.DataBind();
            }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            if (Validate_Control())
            {
                Exhibition exhibition = new Exhibition();

                exhibition.ExhibitionName = txtExhibitionName.Text;
                exhibition.ManagerId = int.Parse(ddlManagerName.SelectedValue);
                exhibition.StartDate = DateTime.Parse(txtStartDate.Text);
                exhibition.EndDate = DateTime.Parse(txtEndDate.Text);
                exhibition.ExhibitionDescription = txtExhibitionDescription.Text;

                if (ExhibitionDAO.Create(exhibition))
                {
                    Flash.dictFlash.Add("success", String.Format("Created Exhibition [<b>{0}</b>] successfully", exhibition.ExhibitionName));
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    Flash.dictFlash.Add("danger", "Error create Exhibition. You should check again.");
                    Response.Redirect("New.aspx");
                }
            }
        }

        protected bool Validate_Control()
        {
            if (!ValidateClass.Validate_Require(txtExhibitionName.Text))
            {
                lbExhibitionNameErr.Text = "* Name cannot be blank";
                return false;
            }
            else
                lbExhibitionNameErr.Text = "";

            #region Validate Datetime

            if (!ValidateClass.Validate_Datetime(txtStartDate.Text))
            {
                lbStartDateErr.Text = "* Start Date must be valid date";
                return false;
            }
            else
                lbStartDateErr.Text = "";

            if (!ValidateClass.Validate_Datetime(txtEndDate.Text))
            {
                lblEndDateErr.Text = "* End Date must be valid date";
                return false;
            }
            else
                lblEndDateErr.Text = "";

            // Kiem tra StartDate va EndDate
            DateTime startDate;
            DateTime endDate;
            startDate = DateTime.Parse(txtStartDate.Text);
            endDate = DateTime.Parse(txtEndDate.Text);

            int result = DateTime.Compare(endDate, startDate);

            if (result < 0)
            {
                Flash.dictFlash.Add("danger", "Begin date must be before end date");
                return false;
            } 

            #endregion

            if (!ValidateClass.Validate_Require(txtExhibitionDescription.Text))
            {
                lblExhibitionDescriptionErr.Text = "* Exhibition Description cannot be blank";
                return false;
            }
            else
                lblExhibitionDescriptionErr.Text = "";

            return true;
        }
            
    }
}