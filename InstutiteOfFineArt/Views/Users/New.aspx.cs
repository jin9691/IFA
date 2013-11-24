using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InstutiteOfFineArt.Models;
using InstutiteOfFineArt.Daos;
using InstutiteOfFineArt.Codes;

namespace InstutiteOfFineArt.Views.Users
{
    public partial class New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            if (Validate_Control())
            {
                User u = new User();
                u.Name = txtFullname.Text;
                u.Username = txtUsername.Text;
                u.Password = Md5.To_Md5(txtPassword.Text);
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
                if (UserDAO.Create(u))
                {
                    Flash.dictFlash.Add("success", String.Format("Created user [<b>{0}</b>] with email address [<b>{1}</b>] successfully", u.Username, u.Email));
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    Flash.dictFlash.Add("danger", "[<b>Username</b>] or [<b>Email address]</b> are already used");
                    Response.Redirect("New.aspx");
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
            if (!txtPassword.Text.Equals(txtConfirm.Text))
            {
                lbConfirmErr.Text = "* Password does not match confirmation";
                lbPasswordErr.Text = "* Password does not match confirmation";
                return false;
            }
            else
            {
                lbConfirmErr.Text = "";
                lbPasswordErr.Text = "";
            }
            if (!ValidateClass.Validate_Length(txtPassword.Text, 6, 10))
            {
                lbPasswordErr.Text = "* Password must be between 6 and 10 characters";
                return false;
            }
            else
                lbPasswordErr.Text = "";
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