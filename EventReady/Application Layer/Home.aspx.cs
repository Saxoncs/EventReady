using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EventReady.Business_Layer;

namespace EventReady.Application_Layer
{
    public partial class Home : System.Web.UI.Page
    {
        protected string value;
        protected string guest;
        protected string eventId;

        protected void Page_Load(object sender, EventArgs e)
        {
            value = Request.QueryString["eValue"];
            guest = Request.QueryString["Guest"];
            eventId = Request.QueryString["Event"];

            if (value != null && guest != null && eventId != null)
            {
                EmailBL emailNew = new EmailBL();
                //I need to be able to get the guest based off a guest email (DONT KNOW HOW)
                //___________________
                //The first arguement should equal that guest in the below line
                //emailNew.ChangeGuestRSVP(, Convert.ToInt32(value));
            }


        }
        protected void btnCreateEvent_Click(object sender, EventArgs e)
        {
           
        }

    }
}