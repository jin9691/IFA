using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using InstutiteOfFineArt.Codes;
using InstutiteOfFineArt.Daos;
using InstutiteOfFineArt.Models;

namespace InstutiteOfFineArt.Views.Award
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
            DataTable dtAward = AwardDAO.All();
            gdvAward.DataSource = dtAward;
            gdvAward.DataBind();
            lbCountAward.Text = dtAward.Rows.Count.ToString();
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