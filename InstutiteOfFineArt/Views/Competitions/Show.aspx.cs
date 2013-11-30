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

namespace InstutiteOfFineArt.Views.Competitions
{
    public partial class Show : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                Load_Data();
            }
        }
        
        private void Load_Data(){
            int Id = (Request.QueryString["ID"] != null) ? Convert.ToInt32(Request.QueryString["ID"]) : 1;
            Dictionary<string, object> query = new Dictionary<string, object>();
            query.Add("CompetitionId", Id);
            DataTable dtPainting = PaintingDAO.Where(query);

            lvPxsSliderWrapper.DataSource = dtPainting;
            lvPxsSliderWrapper.DataBind();

            lvPxsSliderSmall.DataSource = dtPainting;
            lvPxsSliderSmall.DataBind();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            int CompetitionID = (Request.QueryString["ID"] != null) ? Convert.ToInt32(Request.QueryString["ID"]) : 1;
            
            if (validateControl())
            {              
                User u = (User)Session["current_user"];                    
                //Check Student unique Competition
                Dictionary<string, object> query = new Dictionary<string, object>();
                query.Add("CompetitionId", CompetitionID);
                query.Add("StudentId", Convert.ToInt32(u.Id));
                DataTable dt = PaintingDAO.Where(query);
                if (dt.Rows.Count == 0)
                {
                    //Upload painting
                    Painting p = new Painting();
                    p.PaintingDescription = txtDesc.Text;
                    p.PaintingURL = UploadImage(fileUploadField);
                    p.CompetitionId = CompetitionID;
                    p.UploadDate = DateTime.Now;
                    p.LastModify = DateTime.Now;
                    p.StudentId = Convert.ToInt32(u.Id);
                    if (PaintingDAO.CreateForStudent(p))
                    {
                        Flash.dictFlash.Add("success", String.Format("Upload painting [<b>{0}</b>] successfully", fileUploadField.FileName));
                        Response.Redirect("Show.aspx");
                    }
                    else
                    {
                        Flash.dictFlash.Add("danger", " Cannot create Painting !!!");
                        Response.Redirect("Show.aspx");
                    }
                }
                else {
                    Flash.dictFlash.Add("warning", String.Format("You have sent picture with this competition"));
                }
                
            }
        }

        private string UploadImage(FileUpload flImage)
        {
            string extentions = Path.GetExtension(flImage.FileName);
            string newfileName = DateTime.Now.ToFileTime().ToString();
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
                lbfileUploadErr.Text = "Image is required !!!";               
                return false;
            }
            else if (!ValidateClass.Validate_FileType(fileUploadField))
            {          
                lbfileUploadErr.Text = "File is not image";
                return false;
            }
            else
                lbfileUploadErr.Text = "";
            if (!ValidateClass.Validate_Length(txtDesc.Text, 100, 700))
            {         
                lbDescErr.Text = "Description must be leght from 100 to 700 character";
                lbfileUploadErr.Text = "Upload try again";
                return false;
            }
            else
                lbDescErr.Text = "";

            return true;
        }

        public string Student_Name(object Id)
        {
            int val = Convert.ToInt32(Id.ToString());
            User user = UserDAO.Find(val);
            return user.Name;
        }
    }
}