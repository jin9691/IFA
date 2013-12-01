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
                a.AwardName = txtAwardName.Text;
                a.CompetitionId = Convert.ToInt32(drlCompetitionId.SelectedValue);
                a.PaintingId = Convert.ToInt32(txtPatingID.Value);
                if (rdb1st.Checked)
                    a.AwardRank = "1st";
                else if (rdb2nd.Checked)
                    a.AwardRank = "2nd";
                else
                    a.AwardRank = "3rd";
                a.AwardDescription = txtAwardDesc.Text;
                if (AwardDAO.Create(a))
                {
                    Flash.dictFlash.Add("success", String.Format("Created Award [<b>{0}</b>] successfully", a.AwardName));
                    Response.Redirect("/awards");
                }
                else
                {
                    Flash.dictFlash.Add("danger", "[<b>Award name</b>] are already used");
                    Response.Redirect("awards/new");
                }

            }
        }

        protected bool Validate_Control()
        {
            Dictionary<string, object> query = new Dictionary<string, object>();
            query.Add("CompetitionId", Convert.ToInt32(drlCompetitionId.SelectedValue));
            DataTable dtAward = AwardDAO.Where(query);

            if(dtAward.Rows.Count == 3){
                Flash.dictFlash.Add("danger", "This competition has 3 Awards. Can't add any more");
                return false;
            }

            string AwardRank = "";
            if (rdb1st.Checked)
                AwardRank = "1st";
            else if (rdb2nd.Checked)
                AwardRank = "2nd";
            else
                AwardRank = "3rd";
            Dictionary<string, object> query_s = new Dictionary<string, object>();
            query_s.Add("CompetitionId", Convert.ToInt32(drlCompetitionId.SelectedValue));
            query_s.Add("AwardRank", AwardRank);
            DataTable dtAward_s = AwardDAO.Where(query_s);

            if (dtAward_s.Rows.Count >= 1 )
            {
                Flash.dictFlash.Add("danger", "This competition has picture with " + AwardRank + ". Please choice another rank");
                return false;
            }

            if (!ValidateClass.Validate_Require(txtAwardName.Text))
            {
                lbAwardNameErr.Text = "* Name cannot be blank";
                return false;
            }
            else
                lbAwardNameErr.Text = "";
            if (!ValidateClass.Validate_Require(txtPatingID.Value))
            {
                lbPatingIDErr.Text = "You must choice picture";
                return false;
            }
            else
                lbPatingIDErr.Text = "";
            if (!ValidateClass.Validate_Length(txtAwardDesc.Text, 50, 100))
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