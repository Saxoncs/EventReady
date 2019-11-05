using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EventReady.Business_Layer;

namespace EventReady.Application_Layer
{
    public partial class Events : System.Web.UI.Page
    {
        protected string mode;
        protected string user;
        protected int eventDelete;



        //not sure why I have to do this but without an object to call the GetActiveEvents function from it just won't work.
        EventBL eventInfo = new EventBL();

        protected List<EventBL> eventList = new List<EventBL>();


        protected string selectedEvent;


        protected void Page_Load(object sender, EventArgs e)
        {

            

            //This code is here from a merge conflict and I'm not sure if it has a place, is this a redirect to login if the session expires? if so Uncomment it -Saxon
            UserBL session = (UserBL)Session["user"];

            if (session == null)
            {
                Response.Redirect("SessionTimeout.aspx");
            }

            //This query is currently what is used to determine what user's information will be displayed on the page it might be better to use userSession I don't know at the moment -Saxon
            user = Request.QueryString["user"];

            //Get the mode from the other page and index of which event needs to be deleted
            mode = Request.QueryString["mode"];

            eventDelete = Convert.ToInt32(Request.QueryString["event"]);
            
            //I don't think i need this
            //User userSession = (User)Session["user"];

            //Convert data access events to native events - Saxon
            eventList = eventInfo.GetActiveEvents(user);

            //Checks to see if the delete button was clicked
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