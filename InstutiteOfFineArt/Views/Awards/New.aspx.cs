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


namespace InstutiteOfFineArt.Views.Awards
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
            string val = drlCompetitionId.SelectedValue;            
            load_listview(Convert.ToInt32(val));
        }

        protected void drlCompetitionId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = drlCompetitionId.SelectedValue;         
            load_listview(Convert.ToInt32(val));
        }

        private void load_listview(int val)
        {
            Dictionary<string, object> query = new Dictionary<string, object>();
            query.Add("CompetitionId", val);
            DataTable dtPainting = PaintingDAO.Where(query);
            ListView1.DataSource = dtPainting;
            ListView1.DataBind();
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            if (Validate_Control())
            {
                InstutiteOfFineArt.Models.Award a = new InstutiteOfFineArt.Models.Award();
                a.AdwardName = txtAwardDess.Text;
                a.CompetitionId = Convert.ToInt32(drlCompetitionId.SelectedValue);
                a.PaintingId = Convert.ToInt32(txtPatingID.Value);
                if (rdb1st.Checked)
                    a.AdwardRank = "1st";
                else if (rdb2nd.Checked)
                    a.AdwardRank = "2nd";
                else
                    a.AdwardRank = "3rd";
                a.AwardDescription = txtAwardDess.Text;
                if (AwardDAO.Create(a))
                {
                    Flash.dictFlash.Add("success", String.Format("Created Award [<b>{0}</b>] successfully", a.AdwardName));
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    Flash.dictFlash.Add("danger", "[<b>Award name</b>] are already used");
                    Response.Redirect("New.aspx");
                }

            }
        }

        protected bool Validate_Control()
        {
            if (!ValidateClass.Validate_Require(txtAwardName.Text))
            {
                lbAwardNameErr.Text = "* Name cannot be blank";
                return false;
            }
            return true;
        }
    }
}