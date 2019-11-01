using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EventReady.Business_Layer;

namespace EventReady.Application_Layer
{
    public partial class RSVPPage : System.Web.UI.Page
    {
        protected string guestList;
        protected void Page_Load(object sender, EventArgs e)
        {
            User session = (User)Session["user"];

            if (session == null)
            {
                Response.Redirect("LoginVer2.aspx");
            }
            guestList = Request.QueryString["guestList"];
        }
    }
}