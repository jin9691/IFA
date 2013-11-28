using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InstutiteOfFineArt.Codes;
using InstutiteOfFineArt.Models;
using InstutiteOfFineArt.Daos;
using System.Data;

namespace InstutiteOfFineArt.Views.Award
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
            query.Add(String.Format("AwardName like '%{0}%'", Session["search_query"]));
            query.Add(String.Format("AwardRank like '%{0}%'", Session["search_query"]));
            DataTable dtAward = AwardDAO.Search(query);
            if (dtAward.Rows.Count > 0)
            {
                Flash.dictFlash.Add("success", String.Format("Found <b>{0} award</b> matched '<b>{1}</b>'", dtAward.Rows.Count, Session["search_query"]));
                gdvAward.DataSource = dtAward;
                gdvAward.DataBind();
            }
            else
            {
                Flash.dictFlash.Add("warning", "No data match found");
            }
        }

        protected void gdvAward_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvAward.PageIndex = e.NewPageIndex;
            Load_Data();
        }

        protected void Destroy_Click(object sender, EventArgs e)
        {
            LinkButton a = sender as LinkButton;
            int id = Convert.ToInt32(a.CommandArgument);
            InstutiteOfFineArt.Models.Award award = AwardDAO.Find(id);
            if (AwardDAO.Destroy(award))
            {
                Flash.dictFlash.Add("success", String.Format("Delete award [<b>{0}</b>] successfully", award.AdwardName));
            }
            else
            {
                Flash.dictFlash.Add("success", String.Format("Cannot delete award [<b>{0}</b>]", award.AdwardName));
            }
            Response.Redirect("Index.aspx");
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

    }
}