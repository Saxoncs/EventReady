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
        protected int eventDelete;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get the mode from the other page and index of which event needs to be deleted
            mode = Request.QueryString["mode"];
            eventDelete = Convert.ToInt32(Request.QueryString["event"]);

            if (mode != null)
            {
                if (mode.Equals("toggleDelete"))
                {
                    //Delete an event
                    GlobalData.Events.RemoveAt(eventDelete);
                }
            }
        }
    }
}