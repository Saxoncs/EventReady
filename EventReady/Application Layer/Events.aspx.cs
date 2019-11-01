using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EventReady.Business_Layer;
using static EventReady.Business_Layer.EventBL;
using static EventReady.Data_Access_Layer.EventDataAccess;

namespace EventReady.Application_Layer
{
    public partial class Events : System.Web.UI.Page
    {
        protected string mode;
        protected string user;
        protected int eventDelete;


        //User layer Event doesn't need an active component as all events here are going to be active - Saxon
        protected class EventUL
        {
            public string eventId { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public int daysDelayed { get; set; }
            public DateTime start { get; set; }
            public DateTime deadline { get; set; }
            public string userId { get; set; }
        }

        protected List<EventUL> displayedEventList;

        protected EventBL eventInfo = new EventBL();

        protected string selectedEvent;


        protected void Page_Load(object sender, EventArgs e)
        {

            //This query is currently what is used to determine what user's information will be displayed on the page it might be better to use userSession I don't know at the moment -Saxon
            user = Request.QueryString["user"];

            //Get the mode from the other page and index of which event needs to be deleted
            mode = Request.QueryString["mode"];

            eventDelete = Convert.ToInt32(Request.QueryString["event"]);

            User userSession = (User)Session["user"];

            //Convert data access events to native events - Saxon
            List<Event> eventList = eventInfo.GetActiveEvents(user);

            displayedEventList = new List<EventUL>();

            foreach (Event eventInfo in eventList)
            {
                EventUL displayedEvent = new EventUL();
                displayedEvent.eventId = eventInfo.eventId;
                displayedEvent.name = eventInfo.name;
                displayedEvent.description = eventInfo.description;
                displayedEvent.daysDelayed = eventInfo.daysDelayed;
                displayedEvent.start = eventInfo.start;
                displayedEvent.deadline = eventInfo.deadline;
                displayedEvent.userId = eventInfo.userId;

                displayedEventList.Add(displayedEvent);
            }


            if (mode != null)
            {
                if (mode.Equals("toggleDelete"))
                {
                    //Delete an event
                    GlobalData.Events.RemoveAt(eventDelete);
                    Response.Redirect("Home.aspx?remove=true");
                    
                  
                }
            }
        }
    }
}