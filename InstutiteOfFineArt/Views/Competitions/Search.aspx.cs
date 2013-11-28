using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InstutiteOfFineArt.Codes;
using InstutiteOfFineArt.Daos;
using InstutiteOfFineArt.Models;
namespace InstutiteOfFineArt.Views.Competitions
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Form["txtSearch"] != null && Request.Form["txtSearch"] != "")
                {
                    Session["search_query"] = Request.Form["txtSearch"];
                    Load_Data();
                }
                else
                {
                    Flash.dictFlash.Add("danger", "Query string cannot be blank");
                }
            }
        }
        private void Load_Data()
        {
            List<string> query = new List<string>();
            query.Add(String.Format("Topic like '%{0}%'", Session["search_query"]));
          
            DataTable dtCompetition = CompetitionDAO.Search(query);
            if (dtCompetition.Rows.Count > 0)
            {
                Flash.dictFlash.Add("success", String.Format("Found <b>{0} competition </b> matched '<b>{1}</b>'", dtCompetition.Rows.Count, Session["search_query"]));
                gdvCompetitions.DataSource = dtCompetition;
                gdvCompetitions.DataBind();
                lbCountCompetition.Text = dtCompetition.Rows.Count.ToString();
            }
            else
            {
                Flash.dictFlash.Add("warning", "No data match found");
            }
           
        }

        public string Staff_Label(object id)
        {
            int val = Convert.ToInt32(id.ToString());
           User user = InstutiteOfFineArt.Daos.UserDAO.Find(val);
            return user.Name;
        }
        public string Description_Label(object des)
        {
            string val = Convert.ToString(des);
            if (val.Length > 10)
                val = val.Substring(0, 10) + "...";
            return val;

        }
        protected void Destroy_Click(object sender, EventArgs e)
        {
            LinkButton a = sender as LinkButton;
            int id = Convert.ToInt32(a.CommandArgument);
            Dictionary<string, object> query1 = new Dictionary<string, object>();
            query1.Add("CompetitionId", id);
            Competition u = CompetitionDAO.Find(id);
            if (PaintingDAO.Where(query1).Rows.Count >= 1 || AwardDAO.Where(query1).Rows.Count >= 1)
            {
                Flash.dictFlash.Add("danger", String.Format("Cannot delete competition [<b>{0}</b>].Please delete all the painting/ award related.", u.Topic));

            }
            else
            {

                if (CompetitionDAO.Destroy(u))
                {
                    Flash.dictFlash.Add("success", String.Format("Delete competition [<b>{0}</b>] successfully", u.Topic));
                }
                else
                {
                    Flash.dictFlash.Add("success", String.Format("Cannot delete competition [<b>{0}</b>]", u.Topic));
                }
            }

            Response.Redirect("Index.aspx");
        }

        protected void gdvCompetitions_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvCompetitions.PageIndex = e.NewPageIndex;
            Load_Data();
            Flash.dictFlash.Clear();
        }
    }
}