using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EventReady.Business_Layer;
using static EventReady.Business_Layer.EventBL;

namespace EventReady.Application_Layer
{
    public partial class CreateEvent : System.Web.UI.Page
    {


        protected EventBL eventInfo = new EventBL();

        //user returns the user email of the person logged in
        protected string user;
        //EventtoEdit will return value if edit is clicked on events page
        protected string eventToEdit;


        //Check will return value if  back button is clicked on event details
        protected string check;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session timeout
            UserBL session = (UserBL)Session["user"];

            if (session == null)
            {
                Response.Redirect("SessionTimeout.aspx");
            }

            user = Request.QueryString["user"];

            eventToEdit = Request.QueryString["eventToEdit"];

            check = Request.QueryString["check"];

            //Validators to compare current date with selected date for event 
            valDateCheck.ValueToCompare = DateTime.Now.ToShortDateString();
            valDateCheckEdit.ValueToCompare = DateTime.Now.ToShortDateString();

            valDateCheck.ValueToCompare = DateTime.Now.ToShortDateString();

            valDateCheckEdit.ValueToCompare = DateTime.Now.ToShortDateString();

            List<EventBL> eventList = eventInfo.GetActiveEvents(user);

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
                //Remove any sessions so that the textboxes arent altered further from previous create event
                Session.Remove("event");
                Session.Remove("eventEdit");
                //Add values to textbox if edit button was clicked
                if (eventToEdit != null)
                {
                    foreach (EventBL ev in eventList)
                    {
                        if (eventToEdit == ev.eventId)
                        {
                            txtbxEventNameEdit.Text = ev.name;
                            txtbxDescriptionEdit.Text = ev.description;
                            txtbxDateEdit.Text = ev.deadline.ToString();
                        }
                    }
                }
                
                
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {

            List<String> temp = new List<String>();
            temp.Add("");
            //Add values to a session in a list if it is a new event
            if (eventToEdit == null)
            {
                EventBL ev = new EventBL(null, txtbxEventName.Text, txtbxDescription.Text, Convert.ToDateTime(txtbxDate.Text), user);

                ev.AddNewEvent(ev);

                Session.Add("event", ev);
                //Session.Add("event", ev);
                Response.Redirect("EventDetails.aspx");
            }
            //Add values to a session in a list if it is editing an event and an event value that represents the exact event that needs to be edited
            else if (eventToEdit != null)
            {
                EventBL ev = new EventBL(eventToEdit, txtbxEventNameEdit.Text, txtbxDescriptionEdit.Text, Convert.ToDateTime(txtbxDateEdit.Text), user);

                ev.ReplaceEvent(eventToEdit);

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