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
    public partial class Home : System.Web.UI.Page
    {
        protected string value;
        protected string guestEmail;
        protected string eventId;

        protected void Page_Load(object sender, EventArgs e)
        {
            value = Request.QueryString["eValue"];
            guestEmail = Request.QueryString["Guest"];
            eventId = Request.QueryString["Event"];


            //if the user has arrived here by clicking an rsvp link then the rsvp system has to save the guest information
            if (value != null && guestEmail != null && eventId != null)
            {
                EmailBL emailNew = new EmailBL();

                GuestBL guest = emailNew.GetActiveGuest(eventId, guestEmail);

                emailNew.ChangeGuestRSVP(guest, Convert.ToInt32(value));

            }


        }
        protected void btnCreateEvent_Click(object sender, EventArgs e)
        {
           
        }

    }
}