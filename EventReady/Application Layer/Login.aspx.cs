using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EventReady.Business_Layer;

namespace EventReady.Application_Layer
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            string email = ((TextBox)FindControl("email")).Text;
            string password = ((TextBox)FindControl("password")).Text;

            if (GlobalData.userMap.ContainsKey(email))
            {
                if (GlobalData.userMap[email].Password.Equals(password))
                {
                    Session.Add("user", GlobalData.userMap[email]);
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    ((Label)FindControl("errorMessage")).Visible = true;
                }
            }
            else
            {
                ((Label)FindControl("errorMessage")).Visible = true;
            }
        }
    }
}