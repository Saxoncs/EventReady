using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EventReady.Business_Layer;

namespace EventReady.Application_Layer
{
    public partial class CreateEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                EventBL ev = new EventBL(txtbxEventName.Text, txtbxDescription.Text, txtbxFirstName.Text, txtbxLastName.Text, txtbxDate.Text, txtbxAddress.Text, txtbxConPhone.Text, txtbxConEmail.Text);
                
                Session.Add("event", ev);
                Response.Redirect("EventDetails.aspx");
            }
        }
    }
}