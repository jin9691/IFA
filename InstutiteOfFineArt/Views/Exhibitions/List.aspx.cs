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
    public partial class List : System.Web.UI.Page
    {
        private User manager = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["current_user"] != null)
            {
                manager = (User)Session["current_user"];
            }

            if (!IsPostBack)
            {
                dtlShowExhibition.DataSource = ExhibitionDAO.All();
                dtlShowExhibition.DataBind();
            }
        }

        protected void btnAddExhibition_Click(object sender, EventArgs e)
        {
            if (manager != null)
            {
                if (ValidateControl())
                {
                    Exhibition exhibition = new Exhibition();

                    exhibition.ManagerId = manager.Id;
                    exhibition.ExhibitionName = txtTopic.Text;

                    exhibition.StartDate = DateTime.Parse(txtStartDate.Text);
                    exhibition.EndDate = DateTime.Parse(txtEndDate.Text);

                    exhibition.ExhibitionDescription = txtExhibitionDesc.Text;

                    Debug.WriteLine("Tao exhibition :" + exhibition.ExhibitionName);

                    if (ExhibitionDAO.Create(exhibition))
                    {
                        Debug.WriteLine("Tao exhibition thanh cong");
                        Flash.dictFlash.Add("success", String.Format("Created Exhibition [<b>{0}</b>] successfully", exhibition.ExhibitionName));
                        Response.Redirect("List.aspx");
                    }
                    else
                    {
                        Flash.dictFlash.Add("danger", "Error create Exhibition. You should check again.");
                        Response.Redirect("List.aspx#");
                    }
                }
            }
            else
            {
                Debug.WriteLine("Phai login");
                Flash.dictFlash.Add("danger", " You must login !!!");
                Response.Redirect("List.aspx");
            }
        }

        private bool ValidateControl()
        {
            if (!ValidateClass.Validate_Require(txtTopic.Text))
            {
                lblErr.Text = "Name cannot be blank";
                Debug.WriteLine("lblErr (txtTopic.Text): " + lblErr.Text);
                return false;
            }
            else
                lblErr.Text = "";

            if (!ValidateClass.Validate_Length(txtExhibitionDesc.Text, 50, 620))
            {
                lblErr.Text = "Description has length to 50 from 620";
                Debug.WriteLine("lblErr (txtExhibitionDesc.Text): " + lblErr.Text);
                return false;
            }
            else
                lblErr.Text = "";
            
            return true;
        }
    }
}