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
    public partial class CreateEvent : System.Web.UI.Page
    {

        //User layer Event doesn't need an active component as all events here are going to be active, there are multiple versions of these on different pages ideally this would be in the business logic but there's no time to sort it out - Saxon
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



        protected EventBL eventInfo = new EventBL();


        protected string user;
        protected string eventToEdit;
        protected string check;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserBL session = (UserBL)Session["user"];

            if (session == null)
            {
                Response.Redirect("SessionTimeout.aspx");
            }
            user = Request.QueryString["user"];
            eventToEdit = Request.QueryString["eventToEdit"];
            check = Request.QueryString["check"];
            valDateCheck.ValueToCompare = DateTime.Now.ToShortDateString();
            valDateCheckEdit.ValueToCompare = DateTime.Now.ToShortDateString();



            List<Event> eventList = eventInfo.GetActiveEvents(user);

            if (!IsPostBack)
            {
                // If back button is clicked on event details fill the textboxes with data from session so they dont have to refill every textbox. 
                if (check != null)
                {
                    eventInfo = (EventBL)Session["event"];
                    txtbxEventName.Text = eventInfo.EventName;
                    txtbxDescription.Text = eventInfo.Description;
                    txtbxFirstName.Text = eventInfo.FirstName;
                    txtbxLastName.Text = eventInfo.LastName;
                    txtbxDate.Text = eventInfo.EventDate;
                    txtbxAddress.Text = eventInfo.EventAddress;
                    txtbxConPhone.Text = eventInfo.ContactPhone;
                    txtbxConEmail.Text = eventInfo.ContactEmail;
                    

                }
                //Remove any sessions so that the textboxes arent altered further
                Session.Remove("event");
                Session.Remove("eventEdit");
                if (eventToEdit != null)
                {
                    foreach (Event ev in eventList)
                    {
                        if (eventToEdit == ev.eventId)
                        {
                            txtbxEventNameEdit.Text = ev.name;
                            txtbxDescriptionEdit.Text = ev.description;
                            txtbxLNEdit.Text = ev.start.ToString();
                            txtbxDateEdit.Text = ev.deadline.ToString();
                            txtbxAddressEdit.Text = "This needs to be implemented";
                        }
                    }
                }
                
                
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {

            List<String> temp = new List<String>();
            temp.Add("");
            if (eventToEdit == null)
            {
                EventBL ev = new EventBL(user, txtbxEventName.Text, txtbxDescription.Text, txtbxFirstName.Text, txtbxLastName.Text, txtbxDate.Text, txtbxAddress.Text, txtbxConPhone.Text, txtbxConEmail.Text, temp);
                Session.Add("event", ev);
                //Session.Add("event", ev);
                Response.Redirect("EventDetails.aspx");
            }
            else if (eventToEdit != null)
            {
                EventBL ev = new EventBL(user, txtbxEventNameEdit.Text, txtbxDescriptionEdit.Text, txtbxFNEdit.Text, txtbxLNEdit.Text, txtbxDateEdit.Text, txtbxAddressEdit.Text, txtbxConNumEdit.Text, txtbxEmailEdit.Text, temp);

                Session.Add("eventEdit", ev);
                Session.Add("eventValue", eventToEdit);
                //Session.Add("event", ev);
                Response.Redirect("EventDetails.aspx");
            }

        //    temp2 = new List<String>(user, txtbxEventName.Text, txtbxDescription.Text, txtbxFirstName.Text, txtbxLastName.Text, txtbxDate.Text, txtbxAddress.Text, txtbxConPhone.Text, txtbxConEmail.Text, temp);
        //    Session.Add("event", ev);
        //    Session.Add("event", ev);
        //    Response.Redirect("EventDetails.aspx");
        //}
    }
    }
}