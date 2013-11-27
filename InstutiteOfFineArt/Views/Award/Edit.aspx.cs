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

namespace InstutiteOfFineArt.Views.Award
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(Request.QueryString["ID"]);
            if (Request.QueryString["ID"] != null)
            {
                if (!IsPostBack)
                {
                    Load_Data();
                    InstutiteOfFineArt.Models.Award a = AwardDAO.Find(Id);
                    txtAwardName.Text = a.AdwardName;
                    txtAwardDess.Text = a.AwardDescription;
                    rbtListRank.SelectedValue = a.AdwardRank;
                    drlCompetitionId.SelectedValue = a.CompetitionId.ToString();
                    txtPatingID.Value = a.PaintingId.ToString();
                }
            }
            else
            {
                Response.Redirect("Index.aspx");
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
                InstutiteOfFineArt.Models.Award a = new InstutiteOfFineArt.Models.Award();
                a.Id = Convert.ToInt32(Request.QueryString["ID"]);
                a.AdwardName = lbAwardName.Text;
                a.CompetitionId = Convert.ToInt32(drlCompetitionId.SelectedValue);
                a.PaintingId = Convert.ToInt32(txtPatingID.Value);
                a.AdwardRank = rbtListRank.SelectedValue;
                a.AwardDescription = txtAwardDess.Text;
                if (AwardDAO.Update(a))
                {
                    Flash.dictFlash.Add("success", String.Format("Updated Award [<b>{0}</b>] successfully", a.AdwardName));
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