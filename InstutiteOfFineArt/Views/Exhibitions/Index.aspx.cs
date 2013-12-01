using InstutiteOfFineArt.Codes;
using InstutiteOfFineArt.Daos;
using InstutiteOfFineArt.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InstutiteOfFineArt.Views.Exhibitions
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
            List<string> query = new List<string>();
            query.Add("ID != 0");
            DataTable dtExhibition = ExhibitionDAO.Search(query);
            gdvExhibition.DataSource = dtExhibition;
            gdvExhibition.DataBind();
            lbCountExibition.Text = dtExhibition.Rows.Count.ToString();
        }

        public string Manager_Label(object userID)
        {
            return UserDAO.Find(int.Parse(userID.ToString())).Name;
        }

        protected void Destroy_Click(object sender, EventArgs e)
        {
            LinkButton a = sender as LinkButton;
            int id = Convert.ToInt32(a.CommandArgument);

            // Kiem tra xem bảng Painting 
            Dictionary<string, object> findPaiting = new Dictionary<string,object>();
            findPaiting.Add("ExhibitionId", id);
            DataTable paintTB = PaintingDAO.Where(findPaiting);

            Exhibition exhibition = ExhibitionDAO.Find(id);

            if (paintTB.Rows.Count <= 0)
            {
                if (ExhibitionDAO.Destroy(exhibition))
                {
                    Flash.dictFlash.Add("success", String.Format("Delete Exhibition [<b>{0}</b>] successfully", exhibition.ExhibitionName));
                }
                else
                {
                    Flash.dictFlash.Add("danger", String.Format("Cannot delete Exhibition [<b>{0}</b>]", exhibition.ExhibitionName));
                }
            }
            else
            {
                Flash.dictFlash.Add("danger", String.Format("Cannot delete Exhibition [<b>{0}</b>]. You must delete paint.", exhibition.ExhibitionName));
            }
            
            Response.Redirect("Index.aspx");
        }

        protected void gdvExhibition_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvExhibition.PageIndex = e.NewPageIndex;
            Load_Data();
        }
    }
}