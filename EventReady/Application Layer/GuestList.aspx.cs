using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace EventReady.Application_Layer
{
    public partial class GuestList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private string invitationMessage(bool isHtml)
        {
            //Content if html is available 
            if (isHtml)
                return "<html><head><title>Guest Invitation"
                        + " </title></head>"
                        + "<body><img src=cid:logoImage>" + "<br />"
                        + "<h3> This is a test email</h3>"
                        + "<p>Test</p></body></html>";
            //PLain text if html is not
            else
                return "Guest Invitation \r\n"
                        + "Test";
        }

        protected void btnInviteGuest(object sender, EventArgs e)
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
            //------------------------------------------------------------------------------


            //Add email content including from, to, subject and body
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("eventready281@gmail.com");
            msg.To.Add(new MailAddress("robertpiercy2199@gmail.com"));
            msg.Subject = "EventReady - Invitation";
            //If html does not exist return non-html email
            msg.Body = invitationMessage(false);

            //create an alternate HTML view that includes images and formatting 
            string html = invitationMessage(true);
            AlternateView view = AlternateView
                .CreateAlternateViewFromString(
                    html, null, "text/html");

            //add the HTML view to the message and send
            msg.AlternateViews.Add(view);

            try
            {
                client.Send(msg);
                //Send to main page with pop message about sent email
            }
            catch
            {
                //Display error message for email failing to send 

            }
        }
    }
}