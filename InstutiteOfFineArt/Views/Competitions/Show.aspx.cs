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
            if (!IsPostBack)
            {
                Load_Data();
            }
            if (Session["current_user"] != null)
            {
                int Id = Convert.ToInt32(Request.QueryString["ID"]);
                Dictionary<string, object> query = new Dictionary<string, object>();
                query.Add("CompetitionId", Id);
                User u = (User)Session["current_user"];
                query.Add("StudentId", u.Id);
                DataTable dt = PaintingDAO.Where(query);
                hdImage.Value = dt.Rows[0]["Id"].ToString();
            }
        }

        private void Load_Data()
        {
            if (Request.QueryString["ID"] != null)
            {
                int Id = Convert.ToInt32(Request.QueryString["ID"]);
                Dictionary<string, object> query = new Dictionary<string, object>();
                query.Add("CompetitionId", Id);
                DataTable dtPainting = PaintingDAO.Where(query);
                hdID.Value = Id.ToString();
                lvPxsSliderWrapper.DataSource = dtPainting;
                lvPxsSliderWrapper.DataBind();
                lvPxsSliderSmall.DataSource = dtPainting;
                lvPxsSliderSmall.DataBind();
            }
            else
            {
                Response.Redirect("List.aspx");
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            int CompetitionID = Convert.ToInt32(hdID.Value);

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
                    if (PaintingDAO.Create(p))
                    {
                        Flash.dictFlash.Add("success", String.Format("Upload painting [<b>{0}</b>] successfully", fileUploadField.FileName));
                        Response.Redirect("Show.aspx?ID=" + hdID.Value);
                    }
                    else
                    {
                        Flash.dictFlash.Add("danger", " Cannot create Painting !!!");
                        Response.Redirect("Show.aspx?ID=" + hdID.Value);
                    }
                }
                else
                {
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
                lbDescErr.Text = "Description must be lenght from 100 to 700 character";
                lbfileUploadErr.Text = "Upload try again";
                return false;
            }
            else
                lbDescErr.Text = "";

            return true;
        }

        private bool Validate_Edit()
        {
            if (hdEdit.Value.Equals("remark"))
            {
                if (!ValidateClass.Validate_Length(txtEdit.Text, 100, 300))
                {
                    Flash.dictFlash.Add("danger", "Remark must be lenght from 100 to 300 character");
                    return false;
                }
            }
            else
            {
                if (!ValidateClass.Validate_Length(txtEdit.Text, 100, 500))
                {
                    Flash.dictFlash.Add("danger", "Description must be lenght from 100 to 300 character");
                    return false;
                }
            }
            return true;
        }

        public string Student_Name(object Id)
        {
            int val = Convert.ToInt32(Id.ToString());
            User user = UserDAO.Find(val);
            return user.Name;
        }

        public string Check_Painting(bool check)
        {
            int Id = Convert.ToInt32(hdID.Value);
            Dictionary<string, object> query = new Dictionary<string, object>();
            query.Add("CompetitionId", Id);
            DataTable dt = PaintingDAO.Where(query);
            if (check)
            {
                if (dt.Rows.Count > 0)
                    return "inline";
                else
                    return "none";
            }
            else
            {
                if (dt.Rows.Count > 0)
                    return "none";
                else
                    return "inline";
            }
        }

        public string Mark_Equal(object point)
        {
            int val = Convert.ToInt32(point.ToString());
            switch (val)
            {
                case 1: return Painting.MARK_BAD;
                    break;
                case 2: return Painting.MARK_Normal;
                    break;
                case 3: return Painting.MARK_GOOD;
                    break;
                case 4: return Painting.MARK_BEST;
                    break;
            }
            return "";
        }

        public string Btn_Role(object Id)
        {
            string btn = "";

            if (Id != null)
            {
                int val = Convert.ToInt32(Id.ToString());
                User u = (User)Session["current_user"];
                if (Session["current_user"] != null)
                {
                    string award = "<a href='#' id='" + Id + "' class='award btn btn-success btn-sm pull-right' style='margin-left: 5px; margin-right: 5px'>Award</a>";
                    string remark = "<a href='#' class='edit-remark btn btn-warning btn-sm pull-right' style='margin-left: 5px' >Remark</a>";
                    string edit = "<a href='#' class='edit-desc btn btn-info btn-sm pull-right' style='margin-left: 5px; margin-right: 5px'>Edit</a>";

                    switch (u.Permission)
                    {
                        case 1: btn = award + remark;
                            break;
                        case 3: btn = edit;
                            break;
                    }
                }

            }
            return btn;
        }

        protected void lbtDelete_Click(object sender, EventArgs e)
        {
            LinkButton a = sender as LinkButton;
            int id = Convert.ToInt32(a.CommandArgument);
            InstutiteOfFineArt.Models.Painting p = PaintingDAO.Find(id);
            if (PaintingDAO.Destroy(p))
            {
                Flash.dictFlash.Add("success", String.Format("Delete painting successfully"));
            }
            else
            {
                Flash.dictFlash.Add("danger", String.Format("Cannot delete this painting! Please check <b>\"Award\"</b>"));
            }
            Response.Redirect("Show.aspx?ID=" + hdID.Value);
        }

        protected void Best_Click(object sender, EventArgs e)
        {
            LinkButton a = sender as LinkButton;
            int id = Convert.ToInt32(a.CommandArgument);
            InstutiteOfFineArt.Models.Painting p = PaintingDAO.Find(id);
            p.Mark = 4;
            if (PaintingDAO.Update(p))
            {
                Flash.dictFlash.Add("success", String.Format("Set mark successfully"));
            }
            else
            {
                Flash.dictFlash.Add("danger", String.Format("Cannot set mark this painting"));
            }
            Response.Redirect("Show.aspx?ID=" + hdID.Value);
        }

        protected void Good_Click(object sender, EventArgs e)
        {
            LinkButton a = sender as LinkButton;
            int id = Convert.ToInt32(a.CommandArgument);
            InstutiteOfFineArt.Models.Painting p = PaintingDAO.Find(id);
            p.Mark = 3;
            if (PaintingDAO.Update(p))
            {
                Flash.dictFlash.Add("success", String.Format("Set mark successfully"));
            }
            else
            {
                Flash.dictFlash.Add("danger", String.Format("Cannot set mark this painting"));
            }
            Response.Redirect("Show.aspx?ID=" + hdID.Value);
        }

        protected void Normal_Click(object sender, EventArgs e)
        {
            LinkButton a = sender as LinkButton;
            int id = Convert.ToInt32(a.CommandArgument);
            InstutiteOfFineArt.Models.Painting p = PaintingDAO.Find(id);
            p.Mark = 2;
            if (PaintingDAO.Update(p))
            {
                Flash.dictFlash.Add("success", String.Format("Set mark successfully"));
            }
            else
            {
                Flash.dictFlash.Add("danger", String.Format("Cannot set mark this painting"));
            }
            Response.Redirect("Show.aspx?ID=" + hdID.Value);
        }

        protected void Bad_Click(object sender, EventArgs e)
        {
            LinkButton a = sender as LinkButton;
            int id = Convert.ToInt32(a.CommandArgument);
            InstutiteOfFineArt.Models.Painting p = PaintingDAO.Find(id);
            p.Mark = 1;
            if (PaintingDAO.Update(p))
            {
                Flash.dictFlash.Add("success", String.Format("Set mark successfully"));
            }
            else
            {
                Flash.dictFlash.Add("danger", String.Format("Cannot set mark this painting"));
            }
            Response.Redirect("Show.aspx?ID=" + hdID.Value);
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {

            Award a = new Award();
            a.CompetitionId = Convert.ToInt32(hdID.Value);
            a.PaintingId = Convert.ToInt32(hdIDPaint.Value);
            a.AwardName = txtAdName.Text;
            if (rdb1st.Checked)
                a.AwardRank = "1st";
            else if (rdb2nd.Checked)
                a.AwardRank = "2nd";
            else
                a.AwardRank = "3rd";
            a.AwardDescription = txtAwardDesc.Text;
            if (Check_Paint_Award(a.CompetitionId, a.PaintingId, a.AwardRank))
            {
                if (AwardDAO.Create(a))
                    Flash.dictFlash.Add("success", "Set award successfully");
                else
                    Flash.dictFlash.Add("danger", "Set award error");
            }
        }

        private bool Check_Paint_Award(int iD, int pID, string rank)
        {
            Dictionary<string, object> query = new Dictionary<string, object>();
            query.Add("CompetitionID", iD);
            DataTable dt = AwardDAO.Where(query);
            if (dt.Rows.Count > 3)
            {
                Flash.dictFlash.Add("warning", "One contest only three paintings are awarded");
                return false;
            }
            else
            {
                query.Add("AwardRank", rank);
                dt = AwardDAO.Where(query);
                if (dt.Rows.Count > 0)
                {
                    Flash.dictFlash.Add("warning", String.Format("This competition had award rank {0}", rank));
                    return false;
                }
                else
                {
                    query.Add("PaintingID", pID);
                    dt = AwardDAO.Where(query);
                    if (dt.Rows.Count > 0)
                    {
                        Flash.dictFlash.Add("warning", "This painting are awarded");
                        return false;
                    }
                }
            }
            return true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Validate_Edit())
            {
                Painting p = PaintingDAO.Find(Convert.ToInt32(hdPEdit.Value));
                if (hdEdit.Value.Equals("desc"))
                    p.PaintingDescription = txtEdit.Text;
                else
                    p.Comment = txtEdit.Text;
                if (PaintingDAO.Update(p))
                    Flash.dictFlash.Add("success", "Update successfully");
                else
                    Flash.dictFlash.Add("danger", "Update error");
                Response.Redirect("Show.aspx?Id="+p.CompetitionId);
            }
        }

    }
}