using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EventReady.Business_Layer;
using static EventReady.Business_Layer.EmailBL;
using static EventReady.Data_Access_Layer.EmailDataAccess;

namespace EventReady.Application_Layer
{
    public partial class RSVPPage : System.Web.UI.Page
    {

        // EmailBL email = new EmailBL();

         protected string guestList;
        protected void Page_Load(object sender, EventArgs e)
        {
             guestList = Request.QueryString["guestList"];

            //0000001 needs to be replaced with the event number of whichever event is clicked
            //List<Guest> guestList = email.GetActiveGuests("0000001");
        }
    }
}