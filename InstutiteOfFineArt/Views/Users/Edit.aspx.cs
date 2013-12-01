using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InstutiteOfFineArt.Codes;
using InstutiteOfFineArt.Daos;
using InstutiteOfFineArt.Models;

namespace InstutiteOfFineArt.Views.Users
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(Request.QueryString["ID"]);
            if (Request.QueryString["ID"]  != null)
            {
                if (!IsPostBack)
                {
                    User u = UserDAO.Find(Id);
                    txtFullname.Text = u.Name;
                    txtUsername.Text = u.Username;
                    txtEmail.Text = u.Email;
                    if (u.Gender)
                        rdbFemale.Checked = true;
                    else
                        rdbMale.Checked = true;
                    txtBirthday.Text = u.Birthday.ToShortDateString();
                    txtAddress.Text = u.Address;
                    txtPhone.Text = u.Phone;
                    if (u.Permission == 0)
                        rdbAdmin.Checked = true;
                    else if (u.Permission == 1)
                        rdbStaff.Checked = true;
                    else if (u.Permission == 2)
                        rdbManager.Checked = true;
                    else
                        rdbStudent.Checked = true;
                }
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            if (Validate_Control())
            {
                User u = UserDAO.Find(Convert.ToInt32(Request.QueryString["ID"]));
                u.Name = txtFullname.Text;
                u.Username = txtUsername.Text;
                u.Email = txtEmail.Text;
                if (rdbMale.Checked)
                    u.Gender = false;
                else
                    u.Gender = true;
                u.Birthday = DateTime.Parse(txtBirthday.Text);
                u.Address = txtAddress.Text;
                u.Phone = txtPhone.Text;
                if (rdbAdmin.Checked)
                    u.Permission = 0; //Is Admin
                else if (rdbStaff.Checked)
                    u.Permission = 1; //Is Staff
                else if (rdbManager.Checked)
                    u.Permission = 2; //Is Manager
                else
                    u.Permission = 3; //Is Student
                if (UserDAO.Update(u))
                {
                    Flash.dictFlash.Add("success", String.Format("Updated user [<b>{0}</b>] with email address [<b>{1}</b>] successfully", u.Username, u.Email));
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    Flash.dictFlash.Add("danger", "[<b>Username</b>] or [<b>Email address]</b> are already used");
                    Response.Redirect("Edit.aspx");
                }

            }
        }

        protected bool Validate_Control()
        {
            if (!ValidateClass.Validate_Require(txtFullname.Text))
            {
                lbFullnameErr.Text = "* Name cannot be blank";
                return false;
            }
            else
                lbFullnameErr.Text = "";
            if (!ValidateClass.Validate_Length(txtUsername.Text, 5, 16))
            {
                lbUsernameErr.Text = "* Username must be between 5 and 16 characters";
                return false;
            }
            else
                lbUsernameErr.Text = "";
            if (!ValidateClass.Validate_Email(txtEmail.Text))
            {
                lbEmailErr.Text = "* Email address is not valid";
                return false;
            }
            else
                lbEmailErr.Text = "";
            if (!ValidateClass.Validate_Datetime(txtBirthday.Text))
            {
                lbBirthdayErr.Text = "* Birthday must be valid date";
                return false;
            }
            else
                lbBirthdayErr.Text = "";
            return true;
        }
    }
}