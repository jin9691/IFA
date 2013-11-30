using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InstutiteOfFineArt.Codes;
using InstutiteOfFineArt.Daos;

namespace InstutiteOfFineArt.Views.Competitions
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
            DataTable dtCompetitons = CompetitionDAO.Search(query);
            lvCompetitions.DataSource = dtCompetitons;
            lvCompetitions.DataBind();
        }

        public string ShowPainting(object ID)
        {
            ID = Convert.ToInt32(ID.ToString());
            Dictionary<string,object> query = new Dictionary<string,object>();
            query.Add("CompetitionID",ID);
            DataTable dt = PaintingDAO.Where(query);
            if (dt.Rows.Count > 0)
            {
                Random ra = new Random();
                int index = ra.Next(0, dt.Rows.Count);
                return dt.Rows[index]["PaintingURL"].ToString();
            }
            else
            {
                return "joinnow.png";
            }
        }

        protected void Destroy_Click(object sender, EventArgs e)
        {
            LinkButton a = sender as LinkButton;
            int id = Convert.ToInt32(a.CommandArgument);
            InstutiteOfFineArt.Models.Competition c = CompetitionDAO.Find(id);
            if (CompetitionDAO.Destroy(c))
            {
                Flash.dictFlash.Add("success", String.Format("Delete competition [<b>{0}</b>] successfully", c.Topic));
            }
            else
            {
                Flash.dictFlash.Add("success", String.Format("Cannot delete competition [<b>{0}</b>]", c.Topic));
            }
            Response.Redirect("List.aspx");
        }
    }
}