using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;
using EventReady.Business_Layer;
using static EventReady.Business_Layer.EmailBL;

namespace EventReady.Application_Layer
{
    public partial class InviteVers2 : System.Web.UI.Page
    {
        //List<String> guestListTemp;
        protected EventBL eventbl;
        protected String eventID; 
        //protected List<String> list;
        TextBox tb;
        static int i = 0;
        static int p = 0;
        static int j = 0;
        int count = 0;
        int z = 0;
        string testthis;
        //Date: 23/mar/14
        //Author: Win
        //URL: https://stackoverflow.com/questions/22591756/get-values-from-dynamically-added-textboxes-asp-net-c-sharp
        //USE: to get values out of dynamic created textboxes

            private List <String> guestListTemp
        {
            get;
            set;
        }
        private List<String> guestListString
        {
            get;
            set;
        }
        //List of strings for the ids for all the textboxes created
        private List<string> TextBoxIdCollection
        {
            get
            {
                var collection = ViewState["TextBoxIdCollection"] as List<string>;
                return collection ?? new List<string>();
            }
            set { ViewState["TextBoxIdCollection"] = value; }
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session timeout
            UserBL session = (UserBL)Session["user"];

            if (session == null)
            {
                Response.Redirect("SessionTimeout.aspx");
            }

            //Needed this in page load or the textbox IDs would not be saved on page load
            foreach (string textboxId in TextBoxIdCollection)
            {
                var textbox = new TextBox { ID = textboxId };
                textbox.Text = "Email here";
                textbox.CssClass = "input100";
                textbox.MaxLength = 30;
                PlaceHolder1.Controls.Add(textbox);
            }



        }
       

        
        protected void btnAddField_Click(object sender, EventArgs e)
        {
          
           
            var collection = new List<string>();
            int total;

        

            //Get number of textboxes user wants then add IDs to each of those textboxes and add them to the list to be saved in page load
            if (Int32.TryParse(CounterTextBox.Text, out total))
            {
                for (int i = 1; i <= total; i++)
                {
                    var textbox = new TextBox { ID = "TextBox" + i };
                    textbox.Text = "Email here";
                    textbox.CssClass = "input100";
                    textbox.MaxLength = 30;
                    collection.Add(textbox.ID);
                    PlaceHolder1.Controls.Add(textbox);
                    
                }
                TextBoxIdCollection = collection;
            }
        }


    
        private string PopulateBody()
        {
            guestListString = new List<String>();
            string body = string.Empty;
            

                    using (StreamReader reader = new StreamReader(Server.MapPath("../Application Layer/EmailTemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            //Adds details to the event based on edited values or creating a new event
            //if (Session["eventEdit"] != null)
            //{
                //eventbl = (EventBL)Session["eventEdit"];

                body = body.Replace("{EventName}", eventbl.EventName);
                body = body.Replace("{Date}", eventbl.EventDate);
                //body = body.Replace("{Phone}", eventbl.ContactPhone);
                //body = body.Replace("{Email}", eventbl.ContactEmail);
                //body = body.Replace("{Address}", eventbl.EventAddress);
                //body = body.Replace("{FirstName}", eventbl.FirstName);
                //body = body.Replace("{LastName}", eventbl.LastName);

            //}
            //else if (Session["event"] != null)
            //{
               // eventbl = (EventBL)Session["event"];

                //body = body.Replace("{EventName}", eventbl.EventName);
                //body = body.Replace("{Date}", eventbl.EventDate);
                //body = body.Replace("{Phone}", eventbl.ContactPhone);
                //body = body.Replace("{Email}", eventbl.ContactEmail);
                //body = body.Replace("{Address}", eventbl.EventAddress);
                //body = body.Replace("{FirstName}", eventbl.FirstName);
                //body = body.Replace("{LastName}", eventbl.LastName);

            //}
           
            return body;
            
        }
        private void SendHtmlFormattedEmail(string body)
        {
            guestListTemp = new List<String>();

            //Loop through all the texboxes created in the placeholder
            foreach (Control ctr in PlaceHolder1.Controls)
            {
                //Check to see if the control is a textbox
                if (ctr is TextBox)
                {
                    //Try catch to stop app from crashing if sending email fails
                    try
                    {
                        //string check = "TextBox" + p.ToString();
                        //TextBox t = (TextBox)Page.FindControl("TextBox" + p.ToString());
                        //TextBox tt = this.FindControl("ContentPlaceHolder1_TextBox" + p.ToString()) as TextBox;*/

                        SmtpClient client = new SmtpClient();
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.EnableSsl = true;
                        client.Host = "smtp.gmail.com";
                        client.Port = 587;
                        System.Net.NetworkCredential credentials =
                        new System.Net.NetworkCredential("eventready281@gmail.com", "eventready123");
                        client.UseDefaultCredentials = false;
                        client.Credentials = credentials;
                        //------------------------------------------------------------------------------


                        //Add email content including from, to, subject and body
                        MailMessage msg = new MailMessage();
                        msg.From = new MailAddress("eventready281@gmail.com");
                        msg.To.Add(new MailAddress(((TextBox)ctr).Text));
                        msg.Subject = "EventReady - Invitation";
                        //Add the guest email for each email sent as a variable for the RSVP buttons

                        body = body.Replace("{guestEmail}", ((TextBox)ctr).Text);

                        string testthis = ((TextBox)ctr).Text;
                        msg.Body = body;
                        msg.IsBodyHtml = true;

                        AlternateView view = AlternateView
                         .CreateAlternateViewFromString(
                             body, null, "text/html");
                        string imgPathOne = Server.MapPath("../Image/ribbon.png");
                        LinkedResource img = new LinkedResource(imgPathOne);
                        img.ContentId = "ribbonImage";
                        view.LinkedResources.Add(img);

                        msg.AlternateViews.Add(view);

                        //Getting textbox value
                        string tempEmail = ((TextBox)ctr).Text;

                    
                    
                        //Adding it to a new list
                        guestListTemp.Add(tempEmail);
                        count++;
                       
                        client.Send(msg);
                       //Changes the email value back to guestEmail so it can redo for the next loop
                        body = body.Replace(((TextBox)ctr).Text, "{guestEmail}");


                        EmailBL emailInfo = new EmailBL();

                        eventID = Request.QueryString["eventValue"];
                        //needs eventId
                        
                        emailInfo.AddToGuestList(((TextBox)ctr).Text, eventID);
                        
                        

                    }

                    catch
                    {
                        //Display error message for email failing to send 
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invitations were unable to be sent to all guests. Emails with correct addresses were sent');window.location ='Home.aspx';", true);
                    }
                }
                }

            }
        
        protected void btnConfirmGuests_Click(object sender, EventArgs e)
        {
            

            string body = this.PopulateBody();
            this.SendHtmlFormattedEmail(body);
            //If a new event is being created
           /* if (Session["event"] != null)
            {
                //list = (List<String>)Session["event"];
                eventbl = (EventBL)Session["event"];
               //Add finalised guest list to event data
                eventbl.GuestList = guestListTemp;
                GlobalData.Events.Add(eventbl);

                //For session for next create new event
                Session.Remove("event");
            }
            //If an event is being edited
            else if (Session["eventEdit"] != null)
            {
                //Edit an event based on session value given with and change required fields
                eventbl = (EventBL)Session["eventEdit"];
                int value = Convert.ToInt32(Session["eventValue"]);

                eventbl.GuestList = guestListTemp;
                GlobalData.Events[value].EventName = eventbl.EventName;
                GlobalData.Events[value].FirstName = eventbl.FirstName;
                GlobalData.Events[value].LastName = eventbl.LastName;
                GlobalData.Events[value].EventDate = eventbl.EventDate;
                GlobalData.Events[value].EventAddress = eventbl.EventAddress;
                GlobalData.Events[value].ContactEmail = eventbl.ContactEmail;
                GlobalData.Events[value].ContactPhone = eventbl.ContactPhone;
                GlobalData.Events[value].Description = eventbl.Description;
                GlobalData.Events[value].GuestList = eventbl.GuestList;

                //Remove session for next edit
                Session.Remove("eventEdit");
                Session.Remove("eventValue");

                

            }*/
            count = 0;
            //Send User back to home page with message about emails being sent
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Emails have been sent to the guests');window.location ='Home.aspx';", true);
        }
    }
}