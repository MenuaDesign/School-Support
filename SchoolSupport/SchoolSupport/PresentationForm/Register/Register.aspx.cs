using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;

namespace Index
{
    public partial class Register : System.Web.UI.Page
    {
        Business _business = new Business();
        protected void Page_Load(object sender, EventArgs e)
        {
            errorlbl.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (emailTextbox.Text == "" || passwordTextbox.Text == "" || confirmTextbox.Text == "")
            {
                errorlbl.Text = "Fill in all the fields";
                errorlbl.Visible = true;
            }
            else
            {
                if (passwordTextbox.Text == confirmTextbox.Text)
                {
                    string email = emailTextbox.Text;
                    string password = passwordTextbox.Text;
                    string name = nameTextbox.Text;
                    string register = _business.Register(email, password, name);
                    if (register == "true")
                    {
                        Response.Redirect("/Login/Login.aspx");
                    }
                    else
                    {
                        errorlbl.Text = register;
                        errorlbl.Visible = true;
                    }
                }
                else
                {
                    errorlbl.Text = "Password doesn't match";
                    errorlbl.Visible = true;
                }
            }
        }
    }
}