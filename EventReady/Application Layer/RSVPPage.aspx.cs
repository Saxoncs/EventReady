using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EventReady.Business_Layer;

using static EventReady.Business_Layer.EmailBL;


namespace EventReady.Application_Layer
{
    public partial class RSVPPage : System.Web.UI.Page
    {

        protected List<GuestBL> guestList = new List<GuestBL>();

        protected EmailBL email = new EmailBL();

        protected string selectedEvent;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session timeout
            UserBL session = (UserBL)Session["user"];

            if (session == null)
            {
                Response.Redirect("LoginVer2.aspx");
            }
            //Gets the selected event from Event.aspx -Saxon
            selectedEvent = Request.QueryString["selectedEvent"];
            

            //Convert data access guests to native guests - Saxon
            guestList = email.GetActiveGuests(selectedEvent);

        }



    }
}