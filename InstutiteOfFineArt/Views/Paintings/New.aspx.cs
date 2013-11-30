using InstutiteOfFineArt.Codes;
using InstutiteOfFineArt.Daos;
using InstutiteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InstutiteOfFineArt.Views.Paintings
{
    public partial class New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = CompetitionDAO.All();
                cbCompetition.DataValueField = "Id";
                cbCompetition.DataTextField = "Topic";
                cbCompetition.DataSource = dt;
                cbCompetition.DataBind();
                cbCompetition.SelectedIndex = 0;

                DataTable dtExhibition = ExhibitionDAO.All();
                cbExhibition.DataValueField = "Id";
                cbExhibition.DataTextField = "ExhibitionName";
                cbExhibition.DataSource = dtExhibition;
                cbExhibition.DataBind();
                cbExhibition.SelectedIndex = 0;

                DataTable dtCustomers = CustomerDAO.All();
                cbCustomer.DataValueField = "Id";
                cbCustomer.DataTextField = "CustomerName";
                cbCustomer.DataSource = dtCustomers;
                cbCustomer.DataBind();
                cbCustomer.SelectedIndex = 0;

                Dictionary<string, object> query = new Dictionary<string, object>();
                query.Add("Permission", 3);
                DataTable dtStudent = UserDAO.Where(query);
                cbStudent.DataValueField = "Id";
                cbStudent.DataTextField = "Name";
                cbStudent.DataSource = dtStudent;
                cbStudent.DataBind();
                cbStudent.SelectedIndex = 0;
            }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            if (validateControl())
            {
                Painting p = new Painting();
                p.Comment = txtComent.Text;
                if (cbCompetition.SelectedValue != null && cbCompetition.SelectedValue != "")
                    p.CompetitionId = Convert.ToInt32(cbCompetition.SelectedValue);
                if (cbCustomer.SelectedValue != null && cbCustomer.SelectedValue != "")
                    p.CustomerId = Convert.ToInt32(cbCustomer.SelectedValue);
                if (cbExhibition.SelectedValue != null && cbExhibition.SelectedValue != "")
                    p.ExhibitionId = Convert.ToInt32(cbExhibition.SelectedValue);
                p.IsExhibited = rbdPaid.Checked;
                p.IsPaid = rbdPaid.Checked;

                if (rdbBad.Checked)
                    p.Mark = 1;
                else if (rdbNormal.Checked)
                    p.Mark = 2;
                else if (rdbGood.Checked)
                    p.Mark = 3;
                else if (rdbBest.Checked)
                    p.Mark = 4;
                p.PaintingDescription = txtDescription.Text;
                if (!string.IsNullOrWhiteSpace(txtPrice.Text))
                    p.Price = Convert.ToInt32(txtPrice.Text);


                p.UploadDate = DateTime.Now;
                p.LastModify = DateTime.Now;
                if (cbStudent.SelectedValue != null && cbStudent.SelectedValue != "")
                    p.StudentId = Convert.ToInt32(cbStudent.SelectedValue);
                p.PaintingURL = UploadImage(flImage);
                if (!Validate_Image_ONCE())
                {
                    Flash.dictFlash.Add("danger", "This student had painting in this competition !!!");
                    Response.Redirect("New.aspx");
                }
                else
                {
                    if (PaintingDAO.Create(p))
                    {
                    Flash.dictFlash.Add("success", String.Format("Created painting [<b>{0}</b>] successfully", flImage.FileName));
                    Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        Flash.dictFlash.Add("danger", " Cannot create Painting !!!");
                        Response.Redirect("New.aspx");
                    }
                }
            }

        }

        private string UploadImage(FileUpload flImage)
        {
            if (flImage.HasFile)
            {
                string extentions = Path.GetExtension(flImage.FileName);
                string newfileName = DateTime.Now.ToFileTime().ToString();
                string fullName = Server.MapPath(@"\Assets\Images\Paintings\") + newfileName + extentions;
                flImage.SaveAs(fullName);
                return newfileName + extentions; 
            }
            return null;
        }

        private bool Validate_Image_ONCE()
        {
            int competitionID = Convert.ToInt32(cbCompetition.SelectedValue);
            int studentID = Convert.ToInt32(cbStudent.SelectedValue);
            Dictionary<string, object> query = new Dictionary<string, object>();
            query.Add("CompetitionID", competitionID);
            query.Add("StudentID", studentID);
            DataTable dt = PaintingDAO.Where(query);
            if (dt.Rows.Count > 0)
                return false;
            return true;
        }

        private bool validateControl()
        {
            if (!ValidateClass.Validate_Image_Require(flImage))
            {
                lbImageErr.Text = "Image is required";
                return false;
            }
            else if (!ValidateClass.Validate_FileType(flImage))
            {
                lbImageErr.Text = "File is not image";
                return false;
            }
            else
                lbImageErr.Text = "";


            if (ValidateClass.Validate_Require(txtPrice.Text))
            {
                if (!ValidateClass.Validate_Number(txtPrice.Text))
                {
                    lbPriceErr.Text = "Price must be number";
                    return false;
                }
                else
                    lbPriceErr.Text = "";

            }
            return true;


        }
    }
}