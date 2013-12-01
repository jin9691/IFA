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

namespace InstutiteOfFineArt.Views.Awards
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
            DataTable dt = ExhibitionDAO.Search(query);
            cbExhibition.DataValueField = "Id";
            cbExhibition.DataTextField = "ExhibitionName";
            cbExhibition.DataSource = dt;
            cbExhibition.DataBind();
            DataTable dtCompetitons = CompetitionDAO.Join();
            lvCompetitions.DataSource = dtCompetitons;
            lvCompetitions.DataBind();
        }

        protected void Destroy_Click(object sender, EventArgs e)
        {
            LinkButton a = sender as LinkButton;
            int idP = Convert.ToInt32(a.CommandArgument);
            int idC = Convert.ToInt32(a.CommandName);
            Dictionary<string, object> query = new Dictionary<string, object>();
            query.Add("PaintingId", idP);
            query.Add("CompetitionId", idC);
            DataTable dt = AwardDAO.Where(query);
            int idA = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
            Award aw = AwardDAO.Find(idA);
            AwardDAO.Destroy(aw);
            Response.Redirect("List.aspx");
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                int id = Convert.ToInt32(hdIDPaint.Value);
                Painting p = PaintingDAO.Find(id);
                p.ExhibitionId = Convert.ToInt32(cbExhibition.SelectedValue);
                p.Price = Convert.ToInt32(txtPrice.Text);
                p.IsExhibited = true;
                if (PaintingDAO.Update(p))
                    Flash.dictFlash.Add("success", "Set painting to exhibition success");
                else
                    Flash.dictFlash.Add("danger", "Set painting to exhibition error");
            }
        }

        private bool Validate()
        {
            if (!ValidateClass.Validate_Number(txtPrice.Text))
            {
                Flash.dictFlash.Add("warning", "Price must be number");
                return false;
            }
            return true;
        }
    }
}