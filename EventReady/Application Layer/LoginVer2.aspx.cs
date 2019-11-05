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
        protected string log;
        protected void Page_Load(object sender, EventArgs e)
        {
           

            log = Request.QueryString["log"];

            if (log=="Logout")
            {
                Session.Remove("user");
                Session.Remove("event");
                Session.Remove("eventValue");
                Session.Remove("eventEdit");

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = ((TextBox)FindControl("txtbxEmail")).Text;
            string pword = ((TextBox)FindControl("txtbxPassword")).Text;

            if (GlobalData.userMap.ContainsKey(email))
            {
                if (GlobalData.userMap[email].Password.Equals(pword))
                {
                    Session.Add("user", GlobalData.userMap[email]);
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    //((Label)FindControl("errorMessage")).Visible = true;
                }
            }
            else
            {
                //((Label)FindControl("errorMessage")).Visible = true;
            }
        }
    }
}