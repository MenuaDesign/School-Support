using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;  
using System.Configuration;
using Domain;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System.Collections;

namespace Index
{
    public partial class Login : System.Web.UI.Page
    {
        Business _business = new Business();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int user_id = _business.Login(emailTextbox.Text, passwdTextbox.Text);
            if (user_id == 0)
            {

            }
            else
            {
                Session["user_id"] = user_id;
                Session["email"] = emailTextbox.Text;
                Response.Redirect("/Dashboard/Index.aspx");
            }
        }
    }
}