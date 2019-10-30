using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EventReady.Business_Layer;
using static EventReady.Business_Layer.EmailBL;
using static EventReady.Data_Access_Layer.EmailDataAccess;

namespace EventReady.Application_Layer
{
    public partial class RSVPPage : System.Web.UI.Page
    {
        //User layer guest doesn't need an active component as all guests here are going to be active
        protected class GuestUL
        {
            public string name { get; set; }
            public string email { get; set; }
            public string eventId { get; set; }
            public string rsvp { get; set; }

        }

        protected List<GuestUL> displayedGuestList;

        protected EmailBL email = new EmailBL();

        protected string selectedEvent;
        protected void Page_Load(object sender, EventArgs e)
        {
            selectedEvent = Request.QueryString["selectedEvent"];

            //0000001 needs to be replaced with the event number of whichever event is clicked
            
            //Function for converting data guests to native guests
            List<Guest> guestList = email.GetActiveGuests("0000001");
            displayedGuestList = new List<GuestUL>();

            foreach (Guest guest in guestList)
            {
                GuestUL displayedGuest = new GuestUL();
                displayedGuest.name = guest.name;
                displayedGuest.email = guest.email;
                displayedGuest.eventId = guest.eventId;
                displayedGuest.rsvp = guest.rsvp;
                displayedGuestList.Add(displayedGuest);
            }

            

            


        }



    }
}