using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EventReady.Data_Access_Layer.EventDataAccess;

namespace EventReady.Business_Layer
{
    public class EventBL
    {

        //    //These should be deleted and the system rebuilt to work with the classes from the database using the "GetActiveEvents" function -Saxon

        //    public string UserEmail { get; set; }
        //    public string EventName { get; set; }
        //    public string Description { get; set; }
        //    public string FirstName { get; set; }
        //    public string LastName { get; set; }
        //    public string EventDate { get; set; }
        //    public string EventAddress { get; set; }
        //    public string ContactPhone { get; set; }
        //    public string ContactEmail { get; set; }

        //    public List<String> GuestList { get; set; }

        //    public EventBL(string useremail, string eventname, string description, string firstname, string lastname, string eventdate, string eventaddress, string contactphone, string contactemail, List<String> guestlist)
        //    {
        //        UserEmail = useremail;
        //        EventName = eventname;
        //        Description = description;
        //        FirstName = firstname;
        //        LastName = lastname;
        //        EventDate = eventdate;
        //        EventAddress = eventaddress;
        //        ContactPhone = contactphone;
        //        ContactEmail = contactemail;
        //        GuestList = guestlist; 
        //    }
        //    // All this should go - Saxon


        //Needs to get the user id from session data, should otherwise return a list of guests associated with the logged in user to be worked with by the user layer - Saxon
        public List<Event> GetActiveEvents(string userId)
        {

            List<Event> eventList = GetEvents(userId);
            List<Event> activeEvents = new List<Event>();

            foreach (Event singleEvent in eventList)
            {
                if (singleEvent.active)
                {
                    activeEvents.Add(singleEvent);
                }
            }




            return activeEvents;
        }
    }
}