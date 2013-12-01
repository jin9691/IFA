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

namespace InstutiteOfFineArt.Views.Exhibitions
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
            DataTable dtExhibition = ExhibitionDAO.Search(query);
            lvCompetitions.DataSource = dtExhibition;
            lvCompetitions.DataBind();
        }

        public string ShowPainting(object ID)
        {
            ID = Convert.ToInt32(ID.ToString());
            Dictionary<string, object> query = new Dictionary<string, object>();
            query.Add("ExhibitionID", ID);
            DataTable dt = PaintingDAO.Where(query);
            if (dt.Rows.Count > 0)
            {
                Random ra = new Random();
                int index = ra.Next(0, dt.Rows.Count);
                return dt.Rows[index]["PaintingURL"].ToString();
            }
            else
            {
                return "coming-soon.png";
            }

        }

        protected void Destroy_Click(object sender, EventArgs e)
        {
            LinkButton a = sender as LinkButton;
            int id = Convert.ToInt32(a.CommandArgument);
            InstutiteOfFineArt.Models.Exhibition ex = ExhibitionDAO.Find(id);
            if (ExhibitionDAO.Destroy(ex))
            {
                Flash.dictFlash.Add("success", String.Format("Delete exhibition [<b>{0}</b>] successfully", ex.ExhibitionName));
            }
            else
            {
                Flash.dictFlash.Add("success", String.Format("Cannot delete exhibition [<b>{0}</b>]", ex.ExhibitionName));
            }
            Response.Redirect("List.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Validate_Control())
            {
                Exhibition ex = new Exhibition();
                ex.Id = Convert.ToInt32(hdID.Value);
                ex.ManagerId = Convert.ToInt32(hdManager.Value);
                ex.ExhibitionDescription = txtEdit.Text;
                ex.StartDate = DateTime.Parse(txtEditStart.Text);
                ex.EndDate = DateTime.Parse(txtEditEnd.Text);
                if (ExhibitionDAO.Update(ex))
                    Flash.dictFlash.Add("success", "Update successfully");
                else
                    Flash.dictFlash.Add("danger", "Update error");
                Response.Redirect("List.aspx");
            }
        }

        private bool Validate_Add()
        {
            if (!ValidateClass.Validate_Require(txtExName.Text))
            {
                Flash.dictFlash.Add("danger", "* Name cannot be blank");
                return false;
            }
            if (!ValidateClass.Validate_Datetime(txtStartDate.Text))
            {
                Flash.dictFlash.Add("danger", "* Start date must be valid date");
                return false;
            }
            if (!ValidateClass.Validate_Datetime(txtEndDate.Text))
            {
                Flash.dictFlash.Add("danger", "* End date must be valid date");
                return false;
            }
            if (!ValidateClass.Validate_Require(txtDesc.Text))
            {
                Flash.dictFlash.Add("danger", "* Description can not be blank");
                return false;
            }
            return true;

        }

        private bool Validate_Control()
        {
            if (!ValidateClass.Validate_Length(txtEdit.Text, 100, 500))
            {
                Flash.dictFlash.Add("danger", "Description must be lenght from 100 to 300 character");
                return false;
            }
            if (!ValidateClass.Validate_Datetime(txtEditEnd.Text))
            {
                Flash.dictFlash.Add("danger", "* End date must be valid date");
                return false;
            }
            if (!ValidateClass.Validate_Datetime(txtEditStart.Text))
            {
                Flash.dictFlash.Add("danger", "* Start date must be valid date");
                return false;
            }
            return true;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validate_Add())
            {
                User u = (User)Session["current_user"];
                Exhibition ex = new Exhibition();
                ex.ManagerId = u.Id;
                ex.StartDate = DateTime.Parse(txtStartDate.Text);
                ex.EndDate = DateTime.Parse(txtEndDate.Text);
                ex.ExhibitionName = txtExName.Text;
                ex.ExhibitionDescription = txtDesc.Text;
                if (ExhibitionDAO.Create(ex))
                {
                    Flash.dictFlash.Add("success", String.Format("Created exhibition [<b>{0}</b>] successfully", ex.ExhibitionName));
                    Response.Redirect("List.aspx");
                }
                else
                {
                    Flash.dictFlash.Add("danger", " Cannot create exhibition !!!");
                    Response.Redirect("List.aspx");
                }
            }
        }
    }
}