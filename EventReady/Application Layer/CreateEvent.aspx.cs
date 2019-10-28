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
        protected string user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];
            valDateCheck.ValueToCompare = DateTime.Now.ToShortDateString();
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                List<String> temp = new List<String>();
                temp.Add("");
                EventBL ev = new EventBL(user, txtbxEventName.Text, txtbxDescription.Text, txtbxFirstName.Text, txtbxLastName.Text, txtbxDate.Text, txtbxAddress.Text, txtbxConPhone.Text, txtbxConEmail.Text, temp);
                //List<String> temp2 = new List<String>();
                //temp2.Add(user);
                //temp2.Add(txtbxEventName.Text);
                //temp2.Add(txtbxDescription.Text);
                //temp2.Add(txtbxFirstName.Text);
                //temp2.Add(txtbxLastName.Text);
                //temp2.Add(txtbxDate.Text);
                //temp2.Add(txtbxAddress.Text);
                //temp2.Add(txtbxConPhone.Text);
                //temp2.Add(txtbxConEmail.Text);


                //temp2 = new List<String>(user, txtbxEventName.Text, txtbxDescription.Text, txtbxFirstName.Text, txtbxLastName.Text, txtbxDate.Text, txtbxAddress.Text, txtbxConPhone.Text, txtbxConEmail.Text, temp);
                Session.Add("event", ev);
                //Session.Add("event", ev);
                Response.Redirect("EventDetails.aspx");
            }
        }
    }
}