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


        protected EventBL eventInfo = new EventBL();

        protected string user;
        protected string eventToEdit;

        protected void Page_Load(object sender, EventArgs e)
        {
            UserBL session = (UserBL)Session["user"];

            if (session == null)
            {
                Response.Redirect("LoginVer2.aspx");
            }
            user = Request.QueryString["user"];

            eventToEdit = Request.QueryString["eventToEdit"];

            valDateCheck.ValueToCompare = DateTime.Now.ToShortDateString();

            valDateCheckEdit.ValueToCompare = DateTime.Now.ToShortDateString();

            List<EventBL> eventList = eventInfo.GetActiveEvents(user);

            if (!IsPostBack)
            {
                if (eventToEdit != null)
                {
                    foreach (EventBL ev in eventList)
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