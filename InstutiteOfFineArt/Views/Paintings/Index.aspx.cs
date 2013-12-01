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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                Load_Data();
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
                Flash.dictFlash.Add("danger", String.Format("Cannot delete painting [<b>{0}</b>]", u.PaintingURL));
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
            DataTable dtPainting = PaintingDAO.All();
            gdvPaintings.DataSource = dtPainting;
            gdvPaintings.DataBind();
            lbCountPaintings.Text = dtPainting.Rows.Count.ToString();
            
        }

        public User Student_Name(object ID) {
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