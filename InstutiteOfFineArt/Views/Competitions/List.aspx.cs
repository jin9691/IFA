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
    public partial class List : System.Web.UI.Page
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
            List<string> query = new List<string>();
            query.Add("Id != 0");
            DataTable dtCompetitons = CompetitionDAO.Search(query);
            lvCompetitions.DataSource = dtCompetitons;
            lvCompetitions.DataBind();
        }

        public string ShowPainting(object ID)
        {
            ID = Convert.ToInt32(ID.ToString());
            Dictionary<string,object> query = new Dictionary<string,object>();
            query.Add("CompetitionID",ID);
            DataTable dt = PaintingDAO.Where(query);
            if (dt.Rows.Count > 0)
            {
                Random ra = new Random();
                int index = ra.Next(0, dt.Rows.Count);
                return dt.Rows[index]["PaintingURL"].ToString();
            }
            else
            {
                return "joinnow.png";
            }
        }

        protected void Destroy_Click(object sender, EventArgs e)
        {
            LinkButton a = sender as LinkButton;
            int id = Convert.ToInt32(a.CommandArgument);
            InstutiteOfFineArt.Models.Competition c = CompetitionDAO.Find(id);
            if (CompetitionDAO.Destroy(c))
            {
                Flash.dictFlash.Add("success", String.Format("Delete competition [<b>{0}</b>] successfully", c.Topic));
            }
            else
            {
                Flash.dictFlash.Add("success", String.Format("Cannot delete competition [<b>{0}</b>]", c.Topic));
            }
            Response.Redirect("List.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Validate_Control())
            {
                Competition c =CompetitionDAO.Find(Convert.ToInt32(hdID.Value));
                if (hdEdit.Value.Equals("desc"))
                    c.CompetitionDescription = txtEdit.Text;
                else
                    c.Remark = txtEdit.Text;
                c.StartDate = DateTime.Parse(txtEditStart.Text);
                c.DueDate = DateTime.Parse(txtEditDue.Text);
                c.Condition = txtEditCon.Text;
                if (CompetitionDAO.Update(c))
                    Flash.dictFlash.Add("success", "Update successfully");
                else
                    Flash.dictFlash.Add("danger", "Update error");
                Response.Redirect("List.aspx");
            }
        }

        private bool Validate_Control()
        {
            if(hdEdit.Value.Equals("remark"))
            {
                if (!ValidateClass.Validate_Length(txtEdit.Text, 100, 300))
                {
                    Flash.dictFlash.Add("danger","Remark must be lenght from 100 to 300 character");
                    return false;
                }
            }
            else{
                if (!ValidateClass.Validate_Length(txtEdit.Text, 100, 500))
                {
                    Flash.dictFlash.Add("danger", "Description must be lenght from 100 to 300 character");
                    return false;
                }
                if (!ValidateClass.Validate_Datetime(txtEditDue.Text))
                {
                    Flash.dictFlash.Add("danger", "* End date must be valid date");
                    return false;
                }
                if (!ValidateClass.Validate_Datetime(txtEditStart.Text))
                {
                    Flash.dictFlash.Add("danger", "* Start date must be valid date");
                    return false;
                }

            }
            return true;
        }

        private bool Validate_Add()
        {
            if (!ValidateClass.Validate_Require(txtTopic.Text))
            {
                Flash.dictFlash.Add("danger", "* Topic cannot be blank");
                return false;
            }
            if (!ValidateClass.Validate_Datetime(txtStartDate.Text))
            {
                Flash.dictFlash.Add("danger", "* Start date must be valid date");
                return false;
            }
            if (!ValidateClass.Validate_Datetime(txtDueDate.Text))
            {
               Flash.dictFlash.Add("danger", "* End date must be valid date");
                return false;
            }
            if (!ValidateClass.Validate_Require(txtCondition.Text))
            {
                Flash.dictFlash.Add("danger", "Conditition can not be blank");
                return false;
            }
            if (!ValidateClass.Validate_Require(txtDesc.Text))
            {
                 Flash.dictFlash.Add("danger", "* Description can not be blank");
                return false;
            }
            return true;

        }

        public string Btn_Role(object Id) {
            string btn = "";

            if (Id != null)
            {
                int val = Convert.ToInt32(Id.ToString());
                User u = (User)Session["current_user"];
                if (Session["current_user"] != null)
                {
                    string all_image = "<li><a href='Show.aspx?ID=" + Id + "' class='btn btn-primary btn-sm'>All images</a></li>";
                    string remark = "<li><a href='#' class='edit-remark btn btn-success btn-sm' >Remark</a></li>";
                    string edit = "<li><a href='#' class='edit-desc btn btn-warning btn-sm'>Edit</a></li>";
                    
                    switch (u.Permission)
                    {                        
                        case 1: btn = all_image + remark + edit;
                            break;
                        case 2: btn = all_image;
                            break;
                        case 3: btn = all_image;
                            break;
                    }
                }
                
            }
            return btn;       
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validate_Add())
            {
                User u = (User)Session["current_user"];
                Competition c = new Competition();
                c.StaffId = u.Id;
                c.StartDate = DateTime.Parse(txtStartDate.Text);
                c.DueDate = DateTime.Parse(txtDueDate.Text);
                c.Topic = txtTopic.Text;
                c.Condition = txtCondition.Text;
                c.CompetitionDescription = txtDesc.Text;
                if (CompetitionDAO.Create(c))
                {
                    Flash.dictFlash.Add("success", String.Format("Created competition [<b>{0}</b>] successfully", c.Topic));
                    Response.Redirect("List.aspx");
                }
                else
                {
                    Flash.dictFlash.Add("danger", " Cannot create competition !!!");
                    Response.Redirect("List.aspx");
                }
            }
        }
    }
}