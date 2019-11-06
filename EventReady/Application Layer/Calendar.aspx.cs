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
    public partial class Calendar : System.Web.UI.Page
    {
        protected string user;

        EventBL eventInfo = new EventBL();

        protected List<EventBL> eventList = new List<EventBL>();

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //Redirects to event list page if an event date was clicked
            
            foreach (EventBL r in eventList)
            {

                
                    if (calEvents.SelectedDate == Convert.ToDateTime(r.deadline))
                    {
                        Response.Redirect("Events.aspx?user=" + r.userId);
                    }
               
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];
            //Checks for user session if not redirect
            UserBL session = (UserBL)Session["user"];

            if (session == null)
            {
                Response.Redirect("SessionTimeout.aspx");
            }

            eventList = eventInfo.GetActiveEvents(user);

        }

   
        public void calEvent_DayRender(object o, DayRenderEventArgs e)

        {
            
            //Add event names to dates where events are created
            user = Request.QueryString["user"];
            foreach (EventBL f in eventList)
            {
                //Matches user logged in with their events so only their events will be added

                //Author: Adlai King
                //https://www.youtube.com/watch?v=zeFLzcNZc4g
                //Date: 08/02/17
                //Use: To add text to calendar days
                string testhis = Convert.ToString(f.deadline);
                string test = Convert.ToString(e.Day.Date); 
                    if (e.Day.Date == f.deadline)
                    {
                        e.Cell.Controls.Add(new LiteralControl("<p>" + f.name + "</p>"));
                        e.Cell.BackColor = System.Drawing.Color.Purple;
                        e.Cell.ForeColor = System.Drawing.Color.Goldenrod;
                        e.Cell.Font.Bold = true; 

                        
                    }
                
            }
        }

        protected void calEvents_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}