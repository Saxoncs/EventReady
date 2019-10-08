using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EventReady.Data_Access_Layer.EventDataAccess;

namespace EventReady.Business_Layer
{
    public class CalendarBL
    {

        //Needs to get the user id from session data, should otherwise return a list of guests associated with the logged in user to be worked with by the user layer, there is an identical function in Event BL at the moment but I think it's important to have both as they will likely change as we sort out what exactly we need / don't need from the call and adjust accordingly - Saxon
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


        //Gets a list of steps used for a specified event, a basic call routed through the business layer might need to be changed to allow for the ordering of steps by predicted completion or actual completion dates - Saxon
        public List<Step> GetActiveSteps(string eventId)
        {
            List<Step> stepList = GetSteps(eventId);
            List<Step> activeSteps = new List<Step>();

            foreach (Step singleStep in stepList)
            {
                    activeSteps.Add(singleStep);
            }
            return activeSteps;
        }


    }
}