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
        protected string value;
        protected string check;
        protected EventBL eventbl;
        protected void Page_Load(object sender, EventArgs e)
        {
            User session = (User)Session["user"];

            if (session == null)
            {
                Response.Redirect("LoginVer2.aspx");
            }
            user = Request.QueryString["user"];
            value = Request.QueryString["value"];
            check = Request.QueryString["check"];
            valDateCheck.ValueToCompare = DateTime.Now.ToShortDateString();
            valDateCheckEdit.ValueToCompare = DateTime.Now.ToShortDateString();
            if (!IsPostBack)
            {
                if (check != null)
                {
                    eventbl = (EventBL)Session["event"];
                    txtbxEventName.Text = eventbl.EventName;
                    txtbxDescription.Text = eventbl.Description;
                    txtbxFirstName.Text = eventbl.FirstName;
                    txtbxLastName.Text = eventbl.LastName;
                    txtbxDate.Text = eventbl.EventDate;
                    txtbxAddress.Text = eventbl.EventAddress;
                    txtbxConPhone.Text = eventbl.ContactPhone;
                    txtbxConEmail.Text = eventbl.ContactEmail;
                }
                Session.Remove("event");
                Session.Remove("eventEdit");
                /*if (back != null)
                {
                    if (Session["event"] != null)
                    {
                        //list = (List<String>)Session["event"];
                        eventbl = (EventBL)Session["event"];


                        txtbxEventName.Text = eventbl.EventName;
                        txtbxFirstName.Text = eventbl.FirstName;
                        txtbxLastName.Text = eventbl.LastName;
                        txtbxDate.Text = eventbl.EventDate;
                        txtbxAddress.Text = eventbl.EventAddress;
                        txtbxConPhone.Text = eventbl.ContactPhone;
                        txtbxConEmail.Text = eventbl.ContactEmail;
                        txtbxDescription.Text = eventbl.Description;


                    }
                    else if (Session["eventEdit"] != null)
                    {
                        eventbl = (EventBL)Session["eventEdit"];


                        txtbxEventNameEdit.Text = eventbl.EventName;
                        txtbxFNEdit.Text = eventbl.FirstName;
                        txtbxLNEdit.Text = eventbl.LastName;
                        txtbxDateEdit.Text = eventbl.EventDate;
                        txtbxAddressEdit.Text = eventbl.EventAddress;
                        txtbxConNumEdit.Text = eventbl.ContactPhone;
                        txtbxEmailEdit.Text = eventbl.ContactEmail;
                        txtbxDescriptionEdit.Text = eventbl.Description;
                    }
                }*/
                if (value != null)
                {
                    foreach (EventBL f in GlobalData.Events)
                    {
                        if (Convert.ToInt32(value) == GlobalData.Events.IndexOf(f))
                        {
                            txtbxEventNameEdit.Text = f.EventName;
                            txtbxDescriptionEdit.Text = f.Description;
                            txtbxFNEdit.Text = f.FirstName;
                            txtbxLNEdit.Text = f.LastName;
                            txtbxDateEdit.Text = f.EventDate;
                            txtbxAddressEdit.Text = f.EventAddress;
                            txtbxConNumEdit.Text = f.ContactPhone;
                            txtbxEmailEdit.Text = f.ContactEmail;
                        }
                    }
                }
                
                
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            //if (IsValid)
            //{
             
                List<String> temp = new List<String>();
                temp.Add("");
            if (value == null)
            {
                EventBL ev = new EventBL(user, txtbxEventName.Text, txtbxDescription.Text, txtbxFirstName.Text, txtbxLastName.Text, txtbxDate.Text, txtbxAddress.Text, txtbxConPhone.Text, txtbxConEmail.Text, temp);
                Session.Add("event", ev);
                //Session.Add("event", ev);
                Response.Redirect("EventDetails.aspx");
            }
            else if (value != null)
            {
                EventBL ev = new EventBL(user, txtbxEventNameEdit.Text, txtbxDescriptionEdit.Text, txtbxFNEdit.Text, txtbxLNEdit.Text, txtbxDateEdit.Text, txtbxAddressEdit.Text, txtbxConNumEdit.Text, txtbxEmailEdit.Text, temp);
              
                Session.Add("eventEdit", ev);
                Session.Add("eventValue", value);
                //Session.Add("event", ev);
                Response.Redirect("EventDetails.aspx");
            }
                
                //temp2 = new List<String>(user, txtbxEventName.Text, txtbxDescription.Text, txtbxFirstName.Text, txtbxLastName.Text, txtbxDate.Text, txtbxAddress.Text, txtbxConPhone.Text, txtbxConEmail.Text, temp);
                //Session.Add("event", ev);
                //Session.Add("event", ev);
                //Response.Redirect("EventDetails.aspx");
            //}
        }
    }
}