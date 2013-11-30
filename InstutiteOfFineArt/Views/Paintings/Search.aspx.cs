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
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Form["txtSearchPainting"] != null && Request.Form["txtSearchPainting"] != "")
                {
                    Session["txtSearchPainting"] = Request.Form["txtSearchPainting"];
                    Load_Data();
                }
                else
                {
                    Flash.dictFlash.Add("danger", "Query string cannot be blank");
                }
            }
        }
        protected void Destroy_Click(object sender, EventArgs e)
        {
            LinkButton a = sender as LinkButton;
            int id = Convert.ToInt32(a.CommandArgument);
            Painting u = PaintingDAO.Find(id);
            if (PaintingDAO.Destroy(u))
            {
                Delete_Image(u.PaintingURL);
                Flash.dictFlash.Add("success", String.Format("Delete painting [<b>{0}</b>] successfully", u.PaintingURL));

            }
            else
            {
                Flash.dictFlash.Add("success", String.Format("Cannot delete painting [<b>{0}</b>]", u.PaintingURL));
            }
            Response.Redirect("Index.aspx");
        }

        protected void gdvPaintings_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvPaintings.PageIndex = e.NewPageIndex;
            Load_Data();
        }

        private void Load_Data()
        {
            List<string> query = new List<string>();
            query.Add(String.Format("Username like '%{0}%'", Session["txtSearchPainting"]));
            DataTable dtUsers = UserDAO.Search(query);
            if (dtUsers.Rows.Count > 0)
            {
                List<object> queryPaint = new List<object>();
                for (int index = 0; index < dtUsers.Rows.Count; index++) {
                    queryPaint.Add(String.Format("StudentID = {0}", dtUsers.Rows[index]["ID"]));
                }
                DataTable dtPaintings = PaintingDAO.Search(queryPaint);
                if (dtPaintings.Rows.Count > 0) {
                    gdvPaintings.DataSource = dtPaintings;
                    gdvPaintings.DataBind();
                }
                else
                {
                    Flash.dictFlash.Add("warning", "No data match found");
                }
                
                
            }
            else
            {
                Flash.dictFlash.Add("warning", "No data match found");
            }

        }

        public User Student_Name(object ID)
        {
            int id = Convert.ToInt32(ID);
            return UserDAO.Find(id);
        }

        public Competition Competition_Name(object ID)
        {
            int id = Convert.ToInt32(ID);
            return CompetitionDAO.Find(id);
        }
        public string Painting_show(object url)
        {
            return "../../Assets/Images/Paintings/" + url;
        }

        public void Delete_Image(string url)
        {
            File.Delete(Server.MapPath(@"\Assets\Images\Paintings\") + url);
        }
    }
}