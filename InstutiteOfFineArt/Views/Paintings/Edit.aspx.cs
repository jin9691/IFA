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
    public partial class Edit : System.Web.UI.Page
    {
        private int paintingID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null)
            {
                if (!IsPostBack)
                {
                    if (ValidateClass.Validate_Number(Request.QueryString["ID"]))
                    {
                        paintingID = Convert.ToInt32(Request.QueryString["ID"]);
                        if (paintingID > 0)
                        {
                            Painting p = PaintingDAO.Find(paintingID);
                            //p.Id = paintingID;
                            DataTable dt = CompetitionDAO.All();
                            cbCompetition.DataValueField = "Id";
                            cbCompetition.DataTextField = "Topic";
                            cbCompetition.DataSource = dt;
                            cbCompetition.DataBind();
                            cbCompetition.SelectedValue = p.CompetitionId.ToString();

                            DataTable dtExhibition = ExhibitionDAO.All();
                            cbExhibition.DataValueField = "Id";
                            cbExhibition.DataTextField = "ExhibitionName";
                            cbExhibition.DataSource = dtExhibition;
                            cbExhibition.DataBind();
                            cbExhibition.SelectedValue = p.ExhibitionId.ToString();

                            DataTable dtCustomers = CustomerDAO.All();
                            cbCustomer.DataValueField = "Id";
                            cbCustomer.DataTextField = "CustomerName";
                            cbCustomer.DataSource = dtCustomers;
                            cbCustomer.DataBind();
                            cbCustomer.SelectedValue = p.CustomerId.ToString();

                            Dictionary<string, object> query = new Dictionary<string, object>();
                            query.Add("Permission", 3);
                            DataTable dtStudent = UserDAO.Where(query);
                            cbStudent.DataValueField = "Id";
                            cbStudent.DataTextField = "Name";
                            cbStudent.DataSource = dtStudent;
                            cbStudent.DataBind();
                            cbStudent.SelectedValue = p.StudentId.ToString();
                            txtPrice.Text = p.Price.ToString();
                            txtComent.Text = p.Comment == null ? "" : p.Comment;
                            txtDescription.Text = p.Comment == null ? "" : p.PaintingDescription;
                            previewImage.ImageUrl = Server.MapPath(@"\Assets\Images\Paintings\") + p.PaintingURL;


                            if (p.Mark == 1)
                                rdbBad.Checked = true;
                            else if (p.Mark == 2)
                                rdbNormal.Checked = true;
                            else if (p.Mark == 3)
                                rdbGood.Checked = true;
                            else if (p.Mark == 4)
                                rdbBest.Checked = true;
                            if (p.IsPaid)
                            {
                                rbdPaid.Checked = true;
                            }
                            else
                                rbdNotPaid.Checked = true;
                            if (p.IsExhibited)
                            {
                                rdExhibitions.Checked = true;
                            }
                            else
                                rdbNotExhibition.Checked = true;

                            txtPrice.Text = p.Price.ToString();
                         
                        }
                    }
                }

            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }
        protected void btnAccept_Click(object sender, EventArgs e)
        {
            if (validateControl())
            {
                Painting p = new Painting();
                p.Comment = string.IsNullOrWhiteSpace(txtComent.Text) ? null : txtComent.Text;
                //p.Comment = txtComent.Text;
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
                //p.PaintingDescription = txtDescription.Text;
                p.PaintingDescription = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text;
                if (!string.IsNullOrWhiteSpace(txtPrice.Text))
                    p.Price = Convert.ToInt32(txtPrice.Text);
                
                if (cbStudent.SelectedValue != null && cbStudent.SelectedValue != "")
                    p.StudentId = Convert.ToInt32(cbStudent.SelectedValue);
                p.PaintingURL = UploadImage(flImage);
                //p.UploadDate = DateTime.Now;
                p.LastModify = DateTime.Now;
                //p.Id = paintingID;
                //PaintingDAO.Create(p);
                if (!Validate_Image_ONCE())
                {
                    Flash.dictFlash.Add("danger", "This student had painting in this competition !!!");
                    Response.Redirect("Edit.aspx?ID=" + paintingID);
                }
                else if (PaintingDAO.Update(p))                
                {
                    Flash.dictFlash.Add("success", String.Format("Update painting [<b>{0}</b>] successfully", flImage.FileName));
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    Flash.dictFlash.Add("danger", " Cannot update Painting !!!");
                    Response.Redirect("Edit.aspx?ID="+paintingID);
                }
            }

        }

        private bool Validate_Image_ONCE()
        {
            int competitionID = Convert.ToInt32(cbCompetition.SelectedValue);
            int studentID = Convert.ToInt32(cbStudent.SelectedValue);
            Dictionary<string, object> query = new Dictionary<string, object>();
            query.Add("CompetitionID", competitionID);
            query.Add("StudentID", studentID);
            DataTable dt = PaintingDAO.Where(query);
            if (dt.Rows.Count > 1)
                return false;
            return true;
        }

        private string UploadImage(FileUpload flImage)
        {
            string extentions = Path.GetExtension(flImage.FileName);
            string newfileName = Path.GetFileNameWithoutExtension(flImage.FileName) + DateTime.Now.ToBinary();
            string fullName = Server.MapPath(@"\Assets\Images\Paintings\") + newfileName + extentions;
            flImage.SaveAs(fullName);
            return newfileName + extentions;
        }

        private bool validateControl()
        {
            if (ValidateClass.Validate_Image_Require(flImage))
            {
                lbImageErr.Text = "Image is required";
               

                if (!ValidateClass.Validate_FileType(flImage))
                {
                    lbImageErr.Text = "File is not image";
                    return false;
                }
                else
                    lbImageErr.Text = "";
            }
            if (cbCompetition.SelectedIndex <= 0)
            {
                lbCompetitionErr.Text = "Must select one competition";
                return false;
            }
            else
                lbCompetitionErr.Text = "";

            if (cbStudent.SelectedIndex <= 0)
            {
                lbStudentErr.Text = "Must select one student";
            }
            else
                lbStudentErr.Text = "";


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