using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EventReady.Data_Access_Layer.EventDataAccess;

namespace EventReady.Business_Layer
{
    public class EventBL
    {

        //These should be deleted and the system rebuilt to work with the classes from the database using the "GetActiveEvents" function -Saxon
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationModifier { get; set; }

        public EventBL(string name, string description, int durationmodifier)
        {
            Name = name;
            Description = description;
            DurationModifier = durationmodifier;
        }
        // All this should go - Saxon


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