using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EventReady.Data_Access_Layer.EmailDataAccess;

namespace EventReady.Business_Layer
{
    public class EmailBL
    {

        //Needs to get the user id and event id from session data, should otherwise return a list of guests associated with the logged in user and selected event to be worked with by the user layer this will work for the RSVP page - Saxon
        public List<GuestBL> GetActiveGuests(string eventId)
        {

            List<Guest> guestList = GetGuests(eventId);
            List<GuestBL> activeGuests = new List<GuestBL>();

            foreach (Guest guest in guestList)
            {
                if (guest.active)
                {
                    GuestBL newGuest = new GuestBL();

                    newGuest.email = guest.email;
                    newGuest.name = guest.name;
                    newGuest.eventId = guest.eventId;
                    newGuest.rsvp = guest.rsvp;

                    activeGuests.Add(newGuest);
                }
            }

            return activeGuests;
        }

        public GuestBL GetActiveGuest(string eventId, string email)
        {
            List<Guest> guestList = GetGuests(eventId);
            GuestBL selectedGuest = new GuestBL();
            foreach (Guest guest in guestList)
            {
                if (guest.active && guest.email == email)
                {

                    selectedGuest.name = guest.name;
                    selectedGuest.email = guest.email;
                    selectedGuest.eventId = guest.eventId;
                    selectedGuest.rsvp = selectedGuest.rsvp;


                } else return null;
            }
            return selectedGuest;
        }


        public class GuestBL
        {
            public string email { get; set; }
            public string name { get; set; }
            public string eventId { get; set; }
            public string rsvp { get; set; }
            public bool active { get; set; }

        }


        public int AddToGuestList(string email, string eventId)
        {
            Guest guest = new Guest();
            guest.name = "";
            guest.email = email;
            guest.eventId = eventId;

            int successCheck = AddGuest(guest);

            return successCheck;


        }
        
        public int ChangeGuestRSVP(GuestBL guestToRSVP, int response)
        {
            Guest original_Guest = new Guest();
            Guest guest = new Guest();

            guest.name = guestToRSVP.name;
            guest.email = guestToRSVP.email;
            guest.eventId = guestToRSVP.eventId;

            if (response == 1)
            {
                guest.rsvp = "Attending";
            }
            else if (response == 2)
            {
                guest.rsvp = "Not Attending";
            }
            else return 0;

            int successCheck = UpdateGuestRSVP(guest);

            return successCheck;

        }
      

    }
}