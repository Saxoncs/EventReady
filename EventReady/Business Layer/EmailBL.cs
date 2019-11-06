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
        public List<Guest> GetActiveGuests(string eventId)
        {

            List<Guest> guestList = GetGuests(eventId);
            List<Guest> activeGuests = new List<Guest>();

            foreach (Guest guest in guestList)
            {
                if (guest.active)
                {
                    activeGuests.Add(guest);
                }
            }

            return activeGuests;
        }


        public class GuestBL
        {
            string email { get; set; }
            string name { get; set; }
            string eventId { get; set; }
            string rsvp { get; set; }
            bool active { get; set; }

        }


        
        

      

    }
}