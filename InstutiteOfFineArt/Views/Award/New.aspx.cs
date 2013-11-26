using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using InstutiteOfFineArt.Codes;
using InstutiteOfFineArt.Daos;
using InstutiteOfFineArt.Models;


namespace InstutiteOfFineArt.Views.Award
{
    public partial class New : System.Web.UI.Page
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
            DataTable competition = CompetitionDAO.All();
            drlCompetitionId.DataSource = competition;
            drlCompetitionId.DataTextField = "Topic";
            drlCompetitionId.DataValueField = "Id";
            drlCompetitionId.DataBind();
        }

        protected void drlCompetitionId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = drlCompetitionId.SelectedValue;
            Dictionary<string, object> query = new Dictionary<string, object>();
            query.Add("CompetitionId", val);       
            DataTable dtPainting = PaintingDAO.Where(query);
            ListView1.DataSource = dtPainting;
            ListView1.DataBind();

        }
    }
}