using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InstutiteOfFineArt.Codes;
using InstutiteOfFineArt.Daos;
using InstutiteOfFineArt.Models;
using System.Data;
using System.IO;

namespace InstutiteOfFineArt.Views.Paintings
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string CompetitionID = "1";
            var date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (validateControl())
            {
                Painting p = new Painting();
                p.PaintingDescription = txtDesc.Text;
                p.PaintingURL = UploadImage(fileUploadField);
                p.CompetitionId = Convert.ToInt32(CompetitionID);
                p.UploadDate = DateTime.Now;
                p.LastModify = DateTime.Now;
                if (Session["current_user"] != null)
                {
                    User u = (User)Session["current_user"];
                    p.StudentId = Convert.ToInt32(u.Id);
                }
                if (PaintingDAO.CreateForStudent(p))
                {
                    Flash.dictFlash.Add("success", String.Format("Upload painting [<b>{0}</b>] successfully", fileUploadField.FileName));
                    Response.Redirect("List.aspx");
                }
                else
                {
                    Flash.dictFlash.Add("danger", " Cannot create Painting !!!");
                    Response.Redirect("List.aspx");
                }
            }
        }

        private string UploadImage(FileUpload flImage)
        {
            string extentions = Path.GetExtension(flImage.FileName);
            string newfileName = DateTime.Now.ToBinary().ToString();
            string fullName = Server.MapPath(@"\Assets\Images\Paintings\") + newfileName + extentions;
            flImage.SaveAs(fullName);
            return newfileName + extentions;
        }

        private bool validateControl()
        {
            if (Session["current_user"] == null)
            {
                Flash.dictFlash.Add("danger", " You must login !!!");
                return false;
            }
            if (!ValidateClass.Validate_Image_Require(fileUploadField))
            {
                lbfileUploadErr.Text = "Image is required";
                return false;
            }
            else if (!ValidateClass.Validate_FileType(fileUploadField))
            {
                lbfileUploadErr.Text = "File is not image";
                return false;
            }
            else
                lbfileUploadErr.Text = "";
            if (!ValidateClass.Validate_Length(txtDesc.Text, 50, 100))
            {
                lbDescErr.Text = "Description must be leght from 50 to 100 character";
                return false;
            }
            else
                lbDescErr.Text = "";
           
            return true;
        }
    }
}