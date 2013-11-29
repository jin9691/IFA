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

namespace InstutiteOfFineArt.Views.Awards
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(RouteData.Values["id"]);
            if (RouteData.Values["id"] != null)
            {
                if (!IsPostBack)
                {
                    Load_Data();
                    Award a = AwardDAO.Find(Id);
                    txtAwardName.Text = a.AwardName;
                    txtAwardDess.Text = a.AwardDescription;
                    if (a.AwardRank == "1st")
                        rdb1st.Checked = true;
                    else if (a.AwardRank == "2nd")
                        rdb2nd.Checked = true;
                    else
                        rdb3rd.Checked = true;
                    drlCompetitionId.SelectedValue = a.CompetitionId.ToString();
                    txtPatingID.Value = a.PaintingId.ToString();
                    load_listview(Convert.ToInt32(drlCompetitionId.SelectedValue));
                }
            }
            else
            {
                Response.Redirect("/awards");
            }
        }

        protected void drlCompetitionId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = drlCompetitionId.SelectedValue;
            load_listview(Convert.ToInt32(val));
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
                int Id = Convert.ToInt32(RouteData.Values["id"]);
                Award a = new InstutiteOfFineArt.Models.Award();
                a.Id = Id;
                a.AwardName = txtAwardName.Text;
                a.CompetitionId = Convert.ToInt32(drlCompetitionId.SelectedValue);
                a.PaintingId = Convert.ToInt32(txtPatingID.Value);
                if (rdb1st.Checked)
                    a.AwardRank = "1st";
                else if (rdb2nd.Checked)
                    a.AwardRank = "2nd";
                else
                    a.AwardRank = "3rd";
                a.AwardDescription = txtAwardDess.Text;
                if (AwardDAO.Update(a))
                {
                    Flash.dictFlash.Add("success", String.Format("Updated Award [<b>{0}</b>] successfully", a.AwardName));
                    Response.Redirect("/awards");
                }
                else
                {
                    Flash.dictFlash.Add("danger", "[<b>Award name</b>] are already used");
                    Response.Redirect(String.Format("/award/{0}/edit",Id));
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