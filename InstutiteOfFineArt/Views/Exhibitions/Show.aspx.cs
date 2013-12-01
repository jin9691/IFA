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
using System.IO;
using System.Globalization;

namespace InstutiteOfFineArt.Views.Exhibitions
{
    public partial class Show : System.Web.UI.Page
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
            int Id = (Request.QueryString["ID"] != null) ? Convert.ToInt32(Request.QueryString["ID"]) : 1;
            if (Request.QueryString["ID"] != null)
            {
                Dictionary<string, object> query = new Dictionary<string, object>();
                query.Add("ExhibitionId", Id);
                DataTable dtPainting = PaintingDAO.Where(query);
                lvPgPhotos.DataSource = dtPainting;
                lvPgPhotos.DataBind();          
            } else{
                Response.Redirect("List.aspx");
            }

            
        }

        public string Purchase_By(object Id) {
            if (Id != null) {
                int val = Convert.ToInt32(Id.ToString());
                Customer cus = CustomerDAO.Find(val);
                return cus.CustomerName;
            }
            return "";
            
        }
        public string Student_Name(object Id)
        {
            int val = Convert.ToInt32(Id.ToString());
            User user = UserDAO.Find(val);
            return user.Name;
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            int Id = (Request.QueryString["ID"] != null) ? Convert.ToInt32(Request.QueryString["ID"]) : 1;
            string format = "yyyy-MM-dd HH:mm:ss";
            if (Validate_Control())
            {
                Customer c = new Customer();
                c.CustomerName = txtFullname.Text;
                c.CustomerEmail = txtEmail.Text;
                if (rdbMale.Checked)
                    c.CustomerGender = false;
                else
                    c.CustomerGender = true;

                c.CustomerBirthday = Convert.ToDateTime(txtBirthday.Text); ;
                c.CustomerAddress = txtAddress.Text;
                c.CustomerPhone = txtPhone.Text;
                
                if (CustomerDAO.Create(c))
                {
                    DataTable dtCus = CustomerDAO.All();
                    Painting paint = PaintingDAO.Find(Convert.ToInt32(PaintingId.Value));                                       
                    paint.IsPaid = true;
                    paint.LastModify = DateTime.Now;
                    paint.CustomerId = Convert.ToInt32(dtCus.Rows[0][0]);
                    if (PaintingDAO.Update(paint))
                    {
                        Flash.dictFlash.Add("success", String.Format("Order successful, Wait for call"));
                        Response.Redirect("Show.aspx?ID=" + Id);
                    }
                    else {
                        Flash.dictFlash.Add("danger", "Have error in order process, Pless call");
                        Response.Redirect("Show.aspx?ID=" + Id);
                    }                  
                }
                else
                {
                    Flash.dictFlash.Add("danger", "You can't order with this picture");
                    Response.Redirect("Show.aspx?ID=" + Id);
                }
            }
        }

        protected bool Validate_Control()
        {
            if (!ValidateClass.Validate_Require(PaintingId.Value))
            {
                Flash.dictFlash.Add("danger", "You can't order with this picture");
                return false;
            }
            if (!ValidateClass.Validate_Require(txtFullname.Text))
            {
                lbFullnameErr.Text = "* Name cannot be blank";
                return false;
            }
            else
                lbFullnameErr.Text = "";
            if (!ValidateClass.Validate_Email(txtEmail.Text))
            {
                lbEmailErr.Text = "* Email address is not valid";
                return false;
            }
            else
                lbEmailErr.Text = "";
            if (!ValidateClass.Validate_Require(txtBirthday.Text))
            {
                lbBirthdayErr.Text = "* Birthday must be valid date";
                return false;
            }
            else
                lbBirthdayErr.Text = "";

            if (!ValidateClass.Validate_Require(txtAddress.Text))
            {
                lbAddressErr.Text = "* Address cannot be blank";
                return false;
            }
            else
                lbAddressErr.Text = "";

            if (!ValidateClass.Validate_Require(txtPhone.Text))
            {
                lbPhoneErr.Text = "* Phone number cannot be blank";
                return false;
            }
            else
                lbPhoneErr.Text = "";

            return true;
        }
    }


}