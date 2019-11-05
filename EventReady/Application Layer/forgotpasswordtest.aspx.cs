using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using EventReady.Business_Layer;

namespace EventReady.Application_Layer
{
    public partial class forgotpasswordtest : System.Web.UI.Page
    {
        int check = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            check = 0;
        }
        private string GetForgotPasswordMessage(bool isHtml, string emailPassword)
        {
            //Content if html is available 
            if (isHtml)
                return "<html><head><title>Forgotten Password"
                        + " </title></head>"
                        + "<body><img src=cid:logoImage>" + "<br />"
                        + "<h3> Thanks for contacting us to retreive your password.</h3>"
                        + "<p>The password linked to the account "
                        + txtForgottenEmail.Text + " is: <strong>" + emailPassword + "</strong>.</p></body></html>";
            //PLain text if html is not
            else
                return "Thanks for contacting us to retreive your password. \r\n"
                        + "The password linked to the account "
                        + txtForgottenEmail.Text + "is: " + emailPassword + ".";
        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {

            string email = txtForgottenEmail.Text;
            if (GlobalData.userMap.ContainsKey(email))
            {

                lblEmailMessage.Visible = false;

                // Author:  
                // URL: https://stackoverflow.com/questions/4559011/sending-asp-net-email-through-gmail/4559071
                // Date Used: 06/06/19
                // Website Name: Stackover Flow forms
                // Use: To send an email form gmail rather than using papercut
                //---------------------------------------------------------------------------
                //Accessing gmail account to send email
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
                msg.To.Add(new MailAddress(txtForgottenEmail.Text));
                msg.Subject = "Event Ready - Account Password Retrieval";
                //If html does not exist return non-html email
                msg.Body = GetForgotPasswordMessage(false, GlobalData.userMap[email].Password);

                //create an alternate HTML view that includes images and formatting 
                string html = GetForgotPasswordMessage(true, GlobalData.userMap[email].Password);
                AlternateView view = AlternateView
                    .CreateAlternateViewFromString(
                        html, null, "text/html");

                //Adding an image to the email
                string imgPath = Server.MapPath("../Image/er.jpg");
                LinkedResource img = new LinkedResource(imgPath);
                img.ContentId = "logoImage";
                view.LinkedResources.Add(img);

                //add the HTML view to the message and send
                msg.AlternateViews.Add(view);

                try
                {
                    client.Send(msg);
                    //Author: Rick schott 
                    //https://stackoverflow.com/questions/8570766/how-to-get-alert-message-before-redirect-a-page
                    //Date: 20/12/11
                    //Use: Redirect to a page with a message
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Email containing the password has been sent');window.location ='LoginVer2.aspx';", true);
                }
                catch
                {
                    //Display error message for email failing to send 
                    lblEmailMessage.Text = "Error sending email";
                    lblEmailMessage.Visible = true;
                }

                check = 1;



            }
            if (check == 0)
            {
                lblEmailMessage.Text = "This email is not registered at EventReady";
                lblEmailMessage.Visible = true;
            }
        }


    }
}