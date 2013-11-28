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

namespace InstutiteOfFineArt.Views.Competitions
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                if (!IsPostBack)
                {
                    int Id = Convert.ToInt32(Request.QueryString["ID"]);
                    if (Request.QueryString["ID"] != null)
                    {
                        Competition c = CompetitionDAO.Find(Id);
                        txtConditition.Text = c.Condition;
                        txtDescription.Text = c.CompetitionDescription;
                        txtEndDate.Text = c.DueDate.ToShortDateString();
                        txtRemark.Text = c.Remark;
                        txtStartDate.Text = c.StartDate.ToShortDateString();
                        txtTopic.Text = c.Topic;

                        Dictionary<string, object> query = new Dictionary<string, object>();
                        query.Add("Permission", 1);
                        DataTable dtStudent = UserDAO.Where(query);
                        cbStaff.DataValueField = "Id";
                        cbStaff.DataTextField = "Name";
                        cbStaff.DataSource = dtStudent;
                        cbStaff.DataBind();
                        cbStaff.SelectedValue = c.StaffId.ToString();
                    }
                    else
                    {
                        Response.Redirect("Index.aspx");
                    }

                }
        }
        protected void btnAccept_Click(object sender, EventArgs e)
        {
            if (validateControl())
            {

                Competition c = new Competition();
                c.Remark = txtRemark.Text;
                if (cbStaff.SelectedValue != null)
                    c.StaffId = Convert.ToInt32(cbStaff.SelectedValue);
                c.StartDate = DateTime.Parse(txtStartDate.Text);
                c.DueDate = DateTime.Parse(txtEndDate.Text);
                c.Topic = txtTopic.Text;
                c.Condition = txtConditition.Text;
                c.CompetitionDescription = txtConditition.Text;
                if (CompetitionDAO.Update(c))
                {
                    Flash.dictFlash.Add("success", String.Format("Created competition [<b>{0}</b>] successfully", c.Topic));
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    Flash.dictFlash.Add("danger", " Cannot create competition !!!");
                    Response.Redirect("New.aspx");
                }
            }
        }
        private bool validateControl()
        {
            if (!ValidateClass.Validate_Require(txtTopic.Text))
            {
                lbTopicErr.Text = "* Topic cannot be blank";
                return false;
            }
            else lbTopicErr.Text = "";
            if (!ValidateClass.Validate_Datetime(txtStartDate.Text))
            {
                lbStartDateErr.Text = "* Start date must be valid date";
                return false;
            }
            else
                lbStartDateErr.Text = "";
            if (!ValidateClass.Validate_Datetime(txtEndDate.Text))
            {
                lbEndDateErr.Text = "* End date must be valid date";
                return false;
            }
            else
                lbEndDateErr.Text = "";
            if (!ValidateClass.Validate_Require(txtConditition.Text))
            {
                lbCondititionErr.Text = "* Conditition can not be blank";
                return false;
            }
            else
                lbCondititionErr.Text = "";
            if (!ValidateClass.Validate_Require(txtRemark.Text))
            {
                lbRemarkErr.Text = "* Remark can not be blank";
                return false;
            }
            else
                lbRemarkErr.Text = "";
            DateTime Start = DateTime.Parse(txtStartDate.Text);
            DateTime End = DateTime.Parse(txtEndDate.Text);
            if (DateTime.Compare(Start, End) >= 0)
            {
                lbEndDateErr.Text = "Start date must earlier than end date";
                return false;
            }
            else
            {
                lbEndDateErr.Text = "";
            }
            return true;

        }
    }
}
