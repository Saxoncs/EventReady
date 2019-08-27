using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;

namespace EventReady.Application_Layer
{
    public partial class GuestList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    
        //https://www.aspsnippets.com/Articles/Create-and-send-HTML-Formatted-Emails-in-ASP.Net-using-C-and-VB.Net.aspx
        private string PopulateBody()
        {
            string body = string.Empty;
            
            
            using (StreamReader reader = new StreamReader(Server.MapPath("../Application Layer/EmailTemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            //Adding an image to the email

            //view.LinkedResources.Add(img);

            //body = body.Replace("{ribbonImgPlaceHolder}", img.ContentId);
          
            return body;
        }
        private void SendHtmlFormattedEmail(string body)
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
        protected void btnInviteGuest(object sender, EventArgs e)
        {
            string body = this.PopulateBody();
            this.SendHtmlFormattedEmail(body);
        }
    }
}