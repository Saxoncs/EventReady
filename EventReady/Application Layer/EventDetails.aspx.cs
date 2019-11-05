using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EventReady.Business_Layer;

namespace EventReady.Application_Layer
{
    public partial class EventDetails : System.Web.UI.Page
    {
        protected EventBL eventbl;
        //protected List<String> list; 
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session timeout
            UserBL session = (UserBL)Session["user"];
            if (session == null)
            {
                Response.Redirect("SessionTimeout.aspx");
            }
            //Checking to see if event session is not null which represents creating a new event
            if (Session["event"] != null )
            {
                //Fill labels with session data for new event 
                eventbl = (EventBL)Session["event"];
              

                lblEName.Text = eventbl.EventName;
                lblFName.Text = eventbl.FirstName;
                lblLName.Text = eventbl.LastName;
                lblEDate.Text = eventbl.EventDate;
                lblEAddress.Text = eventbl.EventAddress;
                lblEPhone.Text = eventbl.ContactPhone;
                lblEEmail.Text = eventbl.ContactEmail;
                lblEDescription.Text = eventbl.Description;


            }
            //Checks if session eventEdit is not null representing editing a spefic event 
            else if (Session["eventEdit"] != null)
            {
                //Fill labels with session data for edited event
                eventbl = (EventBL)Session["eventEdit"];

                
                lblEName.Text = eventbl.EventName;
                lblFName.Text = eventbl.FirstName;
                lblLName.Text = eventbl.LastName;
                lblEDate.Text = eventbl.EventDate;
                lblEAddress.Text = eventbl.EventAddress;
                lblEPhone.Text = eventbl.ContactPhone;
                lblEEmail.Text = eventbl.ContactEmail;
                lblEDescription.Text = eventbl.Description;
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Response.Redirect("InviteVers2.aspx");
        }

       
    }
}