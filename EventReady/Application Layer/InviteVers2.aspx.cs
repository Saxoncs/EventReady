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

        protected EventBL eventbl;
        protected String eventID;
        TextBox tb;
        static int i = 0;
        static int p = 0;
        static int j = 0;
        int count = 0;
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
                // Adding validators to every textbox created
                var textbox = new TextBox { ID = textboxId };
                RequiredFieldValidator validator = new RequiredFieldValidator();
                validator.ControlToValidate = textbox.ID;
                validator.ErrorMessage = "Textbox cannot be empty";
                validator.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                validator.Display = ValidatorDisplay.Dynamic;
                validator.Font.Size = new System.Web.UI.WebControls.FontUnit("14px");
                RegularExpressionValidator validtorReg = new RegularExpressionValidator();
                validtorReg.ControlToValidate = textbox.ID;
                validtorReg.ErrorMessage = "Incorrect Email";
                validtorReg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                validtorReg.Display = ValidatorDisplay.Dynamic;
                validtorReg.Font.Size = new System.Web.UI.WebControls.FontUnit("14px");
                validtorReg.ValidationExpression = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                textbox.Text = "Email here";
                textbox.CssClass = "input100";
                textbox.MaxLength = 30;
                PlaceHolder1.Controls.Add(validtorReg);
                PlaceHolder1.Controls.Add(validator);
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
                    // Adding validators to every textbox created and placing each textbox in the placeholder
                    var textbox = new TextBox { ID = "TextBox" + i };
                    textbox.Text = "Email here";
                    textbox.CssClass = "input100";
                    textbox.MaxLength = 30;
                    RequiredFieldValidator validator = new RequiredFieldValidator();
                    validator.ControlToValidate = textbox.ID;
                    validator.ErrorMessage = "Textbox cannot be empty";
                    validator.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                    validator.Display = ValidatorDisplay.Dynamic;
                    validator.Font.Size = new System.Web.UI.WebControls.FontUnit("14px");
                    RegularExpressionValidator validtorReg = new RegularExpressionValidator();
                    validtorReg.ControlToValidate = textbox.ID;
                    validtorReg.ErrorMessage = "Incorrect Email";
                    validtorReg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ff0000");
                    validtorReg.Display = ValidatorDisplay.Dynamic;
                    validtorReg.Font.Size = new System.Web.UI.WebControls.FontUnit("14px");
                    validtorReg.ValidationExpression = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                    collection.Add(textbox.ID);
                    PlaceHolder1.Controls.Add(validtorReg);
                    PlaceHolder1.Controls.Add(validator);
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

                eventbl = new EventBL();
                eventID = Request.QueryString["eventId"];
                eventbl = eventbl.GetActiveEvent(eventID);
                //Replace certain values in the email template with given variables
                body = body.Replace("{EventName}", eventbl.name);
                body = body.Replace("{Date}", eventbl.deadline.ToString());
                body = body.Replace("{EventId}", eventID.ToString());

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

                        SmtpClient client = new SmtpClient();
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.EnableSsl = true;
                        client.Host = "smtp.gmail.com";
                        client.Port = 587;
                        System.Net.NetworkCredential credentials =
                        new System.Net.NetworkCredential("eventready281@gmail.com", "eventready123");
                        client.UseDefaultCredentials = false;
                        client.Credentials = credentials;


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

                        eventID = Request.QueryString["eventId"];
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
            count = 0;
            //Send User back to home page with message about emails being sent
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Emails have been sent to the guests');window.location ='Home.aspx';", true);
        }
    }
}