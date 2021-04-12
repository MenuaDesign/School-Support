using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using System.Web.Security;

namespace Index.Dashboard
{
    public partial class Profile : System.Web.UI.Page
    {
        Business _business = new Business();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblName.Text = _business.username(Convert.ToInt32(Session["user_id"]));
                lblprofileRole.Text = Session["user_role"].ToString();
                lblprofileName.Text = Session["user_name"].ToString();
                lblprofileEmail.Text = Session["email"].ToString();
            }
        }

        protected void btnprofileName_Click(object sender, EventArgs e)
        {
            lblprofileName.Visible = false;
            txtprofileName.Visible = true;
            btnprofileName.Visible = false;
            btnokName.Visible = true;
        }

        protected void btnokName_Click(object sender, EventArgs e)
        {
            lblprofileName.Visible = true;
            txtprofileName.Visible = false;
            btnprofileName.Visible = true;
            btnokName.Visible = false;
            int user_id = Convert.ToInt16(Session["user_id"]);
            string Name = txtprofileName.Text;
            _business.editName(user_id, Name);
            lblprofileName.Text = Name;
        }

        protected void btnokEmail_Click(object sender, EventArgs e)
        {
            lblprofileEmail.Visible = true;
            txtprofileEmail.Visible = false;
            btnprofileEmail.Visible = true;
            btnokEmail.Visible = false;
            int user_id = Convert.ToInt16(Session["user_id"]);
            string Email = txtprofileEmail.Text;
            if (_business.Available(Email))
            {
                lblprofileEmail.Text = Email;
                lblerrorEmail.Visible = false;
                _business.editEmail(user_id, Email);
            }
            else
            {
                string getEmail = _business.getEmail(user_id);
                lblprofileEmail.Text = getEmail;
                lblerrorEmail.Visible = true;
                lblerrorEmail.Text = "Email already exist.";
            }
        }

        protected void btnprofileEmail_Click(object sender, EventArgs e)
        {
            lblprofileEmail.Visible = false;
            txtprofileEmail.Visible = true;
            btnprofileEmail.Visible = false;
            btnokEmail.Visible = true;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            int user_id = Convert.ToInt16(Session["user_id"]);
            string cPassword = txtcPassword.Text;
            string nPassword = txtnPassword.Text;
            string confPassword = txtconfPassword.Text;
            string password = _business.getPassword(user_id);
            string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(cPassword, "SHA1");
            string nhash = FormsAuthentication.HashPasswordForStoringInConfigFile(nPassword, "SHA1");
            if (hash == password)
            {

                if (nPassword == confPassword)
                {
                    _business.editPassword(user_id, nhash);
                    lblerrorPassword.Visible = true;
                    lblerrorPassword.Text = "Your password has been changed.";
                }
                else
                {
                    lblerrorPassword.Visible = true;
                    lblerrorPassword.Text = "Try again!";
                }
            }
            else
            {
                lblerrorPassword.Visible = true;
                lblerrorPassword.Text = "Try again!";
            }
        }
    }
}