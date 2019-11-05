using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EventReady.Business_Layer;

namespace EventReady.Application_Layer
{
    public partial class Calendar : System.Web.UI.Page
    {
        protected string user;

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //Redirects to event list page if an event date was clicked
            user = Request.QueryString["user"];
            foreach (EventBL f in GlobalData.Events)
            {

                if (user.Equals(f.UserEmail))
                {
                    if (calEvents.SelectedDate == Convert.ToDateTime(f.EventDate))
                    {
                        Response.Redirect("Events.aspx?user=" + f.UserEmail);
                    }
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checks for user session if not redirect
            UserBL session = (UserBL)Session["user"];

            if (session == null)
            {
                Response.Redirect("SessionTimeout.aspx");
            }
        }

   
        public void calEvent_DayRender(object o, DayRenderEventArgs e)

        {
            
            //Add event names to dates where events are created
            user = Request.QueryString["user"];
            foreach (EventBL f in GlobalData.Events)
            {

                if (user.Equals(f.UserEmail))
                {
                    //Author: Adlai King
                    //https://www.youtube.com/watch?v=zeFLzcNZc4g
                    //Date: 08/02/17
                    //Use: To add text to calendar days
                    if (e.Day.Date == Convert.ToDateTime(f.EventDate))
                    {
                        e.Cell.Controls.Add(new LiteralControl("<p>" + f.EventName + "</p>"));
                        e.Cell.BackColor = System.Drawing.Color.Purple;
                        e.Cell.ForeColor = System.Drawing.Color.Goldenrod;
                        e.Cell.Font.Bold = true; 

                        
                    }
                }
            }
        }

        protected void calEvents_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}