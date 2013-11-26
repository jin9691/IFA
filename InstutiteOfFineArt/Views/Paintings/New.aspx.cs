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
                cbCompetition.DataMember = "Id";
                cbCompetition.DataTextField = "Topic";
                cbCompetition.DataSource = dt;
                cbCompetition.DataBind();
                cbCompetition.SelectedIndex = 0;

                DataTable dtExhibition = ExhibitionDAO.All();
                cbExhibition.DataMember = "Id";
                cbExhibition.DataTextField = "ExhibitionName";
                cbExhibition.DataSource = dtExhibition;
                cbExhibition.DataBind();
                cbExhibition.SelectedIndex = 0;

                DataTable dtCustomers = CustomerDAO.All();
                cbCustomer.DataMember = "Id";
                cbCustomer.DataTextField = "CustomerName";
                cbCustomer.DataSource = dtCustomers;
                cbCustomer.DataBind();
                cbCustomer.SelectedIndex = 0;

                Dictionary<string, object> query = new Dictionary<string, object>();
                query.Add("Permission", 3);
                DataTable dtStudent = UserDAO.Where(query);
                cbStudent.DataMember = "Id";
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
                if (cbCompetition.SelectedValue != null)
                    p.CompetitionId = Convert.ToInt32(cbCompetition.SelectedValue);
                if (cbCustomer.SelectedValue != null)
                    p.CustomerId = Convert.ToInt32(cbCustomer.SelectedValue);
                if (cbExhibition.SelectedValue != null)
                    p.ExhibitionId = Convert.ToInt32(cbExhibition.SelectedValue);
                p.IsExhibited = rbdPaid.Checked;
                p.IsPaid = rbdPaid.Checked;
                p.Mark = Convert.ToInt32(txtMark.Text);
                p.PaintingDescription = txtDescription.Text;
                p.Price = Convert.ToInt32(txtPrice.Text);
                if (cbStudent.SelectedValue != null)
                    p.StudentId = Convert.ToInt32(cbStudent.SelectedValue);
                UploadImage(flImage);

                //PaintingDAO.Create(p);
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

        private void UploadImage(FileUpload flImage)
        {
            string extentions = Path.GetExtension(flImage.FileName);
            string newfileName = Path.GetFileNameWithoutExtension(flImage.FileName) + DateTime.Now.ToBinary();
            string fullName = Server.MapPath(@"\Assets\Images\Paintings\") + newfileName + extentions;
            flImage.SaveAs(fullName);
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

            if (!ValidateClass.Validate_Length(txtMark.Text, 0, 10))
            {
                lbMarkErr.Text = "Mark must be number from 0 to 10";
                return false;
            }
            else
                lbMarkErr.Text = "";

            if (!ValidateClass.Validate_Number(txtPrice.Text))
            {
                lbPriceErr.Text = "Price must be number";
                return false;
            }
            else
                lbPriceErr.Text = "";
            return true;
        }
    }
}