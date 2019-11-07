using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EventReady.Business_Layer;

namespace EventReady.Application_Layer
{
    public partial class LoginVer2 : System.Web.UI.Page
    {
        protected UserBL userInfo = new UserBL();

        protected string log;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //Clear all sessions
            log = Request.QueryString["log"];

            if (log=="Logout")
            {
                Session.Remove("user");
                Session.Remove("event");
                Session.Remove("eventValue");
                Session.Remove("eventEdit");
                Session.Clear();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = ((TextBox)FindControl("txtbxEmail")).Text;
            string pword = ((TextBox)FindControl("txtbxPassword")).Text;

            UserBL user = userInfo.GetLogingUser(email);

            //Check to see if user exists
            if (user.Email != null)
            {
                //Check to see if the password is correct
                if (user.Password.Equals(pword))
                {
                    Session.Add("user", user);
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lblErrorMessage.Text = "The email or password is incorrect";
                    lblErrorMessage.Visible = true;
                }
            }
            else
            {
                lblErrorMessage.Text = "The email or password is incorrect";
                lblErrorMessage.Visible = true;
            }
        }
    }
}