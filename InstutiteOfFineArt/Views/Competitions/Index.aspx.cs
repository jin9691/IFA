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
    public partial class Index : System.Web.UI.Page
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
            DataTable dtCompetition = CompetitionDAO.All();
            gdvCompetitions.DataSource = dtCompetition;
            gdvCompetitions.DataBind();
            lbCountCompetition.Text = dtCompetition.Rows.Count.ToString();
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
                    Flash.dictFlash.Add("danger", String.Format("Cannot delete competition [<b>{0}</b>].Please delete all the painting/ award related.",u.Topic ));
                  
                }
                else {
                   
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
        }
    }
}