using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EventReady.Data_Access_Layer.EmailDataAccess;

namespace EventReady.Business_Layer
{
    public class EmailBL
    {
        
        //Needs to get the user id from session data, should otherwise return a list of guests associated with the logged in user to be worked with by the user layer - Saxon
        public List<Guest> GetActiveGuests(string userId)
        {
            
            List<Guest> guestList = GetGuests(userId);
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
        
        

      

    }
}