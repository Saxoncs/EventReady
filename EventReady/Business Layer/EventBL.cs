﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EventReady.Data_Access_Layer.EventDataAccess;

namespace EventReady.Business_Layer
{
    public class EventBL
    {
        //the actual information retrieved from the database
        public string eventId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int daysDelayed { get; set; }
        public DateTime start { get; set; }
        public DateTime deadline { get; set; }
        public string userId { get; set; }


        public EventBL(string newEventId, string newName, string newDescription, DateTime newDeadline, string newUserId)
        {
            eventId = newEventId;
            name = newName;
            description = newDescription;
            start = DateTime.Today;
            deadline = newDeadline;
            userId = newUserId;

        }

        //These should be deleted and the system rebuilt to work with the classes from the database using the "GetActiveEvents" function -Saxon

        public string UserEmail { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EventDate { get; set; }
        public string EventAddress { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }

        public List<String> GuestList { get; set; }

        //An empty constructor so that the code doesn't get upset when I instantiate one that doesn't have the temporary global data in it, this can be deleted with the rest of this code.
        public EventBL()
        {

        }


        public EventBL(string useremail, string eventname, string description, string firstname, string lastname, string eventdate, string eventaddress, string contactphone, string contactemail, List<String> guestlist)
        {
            UserEmail = useremail;
            EventName = eventname;
            Description = description;
            FirstName = firstname;
            LastName = lastname;
            EventDate = eventdate;
            EventAddress = eventaddress;
            ContactPhone = contactphone;
            ContactEmail = contactemail;
            GuestList = guestlist;
        }
        // All this should go - Saxon


        //Needs to get the user id from session data, should otherwise return a list of guests associated with the logged in user to be worked with by the user layer - Saxon
        public List<EventBL> GetActiveEvents(string userId)
        {

            List<Event> eventList = GetEvents(userId);
            List<EventBL> activeEvents = new List<EventBL>();

            foreach (Event singleEvent in eventList)
            {
                if (singleEvent.active)
                {
                    EventBL singleEventBL = new EventBL();

                    singleEventBL.name = singleEvent.name;
                    singleEventBL.description = singleEvent.description;
                    singleEventBL.eventId = singleEvent.eventId;
                    singleEventBL.daysDelayed = singleEvent.daysDelayed;
                    singleEventBL.start = singleEvent.start;
                    singleEventBL.deadline = singleEvent.deadline;
                    singleEventBL.userId = singleEvent.userId;

                    activeEvents.Add(singleEventBL);
                }
            }
            return activeEvents;
        }



        public EventBL GetActiveEvent(string eventId)
        {

            Event singleEvent = GetEvent(eventId);
            EventBL singleEventBL = new EventBL();

            singleEventBL.name = singleEvent.name;
            singleEventBL.description = singleEvent.description;
            singleEventBL.eventId = singleEvent.eventId;
            singleEventBL.daysDelayed = singleEvent.daysDelayed;
            singleEventBL.start = singleEvent.start;
            singleEventBL.deadline = singleEvent.deadline;
            singleEventBL.userId = singleEvent.userId;


            return singleEventBL;
            
        }



        public void ReplaceEvent(string oldEventId)
        {
            Event newEvent = new Event();

            newEvent.eventId = this.eventId;
            newEvent.name = this.name;
            newEvent.description = this.description;
            newEvent.start = this.start;
            newEvent.deadline = this.deadline;
            newEvent.userId = this.userId;

            UpdateEvent(oldEventId, newEvent);
        }



        public void AddNewEvent(EventBL eventInfo)
        {
            Event ev = new Event();

            ev.name = eventInfo.name;
            ev.description = eventInfo.description;
            ev.start = eventInfo.start;
            ev.deadline = eventInfo.deadline;
            ev.userId = eventInfo.userId;

            AddEvent(ev);

        }



        public void DeactivateEvent(string eventId)
        {
            SetEventInactive(eventId);
        }



    }
}