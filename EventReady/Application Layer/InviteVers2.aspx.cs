﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;
using EventReady.Business_Layer;

namespace EventReady.Application_Layer
{
    public partial class InviteVers2 : System.Web.UI.Page
    {
        //List<String> guestListTemp;
        protected EventBL eventbl;
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
        //protected
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
            UserBL session = (UserBL)Session["user"];

            if (session == null)
            {
                Response.Redirect("SessionTimeout.aspx");
            }


            foreach (string textboxId in TextBoxIdCollection)
            {
                var textbox = new TextBox { ID = textboxId };
                PlaceHolder1.Controls.Add(textbox);
            }


        }
       

        
        protected void btnAddField_Click(object sender, EventArgs e)
        {
          
           
            var collection = new List<string>();
            int total;

        


            if (Int32.TryParse(CounterTextBox.Text, out total))
            {
                for (int i = 1; i <= total; i++)
                {
                    var textbox = new TextBox { ID = "TextBox" + i };
                    
                    collection.Add(textbox.ID);
                    PlaceHolder1.Controls.Add(textbox);
                    
                }
                TextBoxIdCollection = collection;
            }
            
             
            /*i++;
          
            for (j = 1; j <= i; j++)
            {
                
                tb = new TextBox();
                tb.Text = "TextBox" + j.ToString();
                tb.ID = "TextBox" + j.ToString();
                PlaceHolder1.Controls.Add(tb);
                //PlaceHolder1.Controls.Add(new TextBox());
                collection.Add(tb.ID); 

               

            }
            TextBoxIdCollection = collection; */


            /*int index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + 1;
            TextBox txt = new TextBox();
            txt.ID = "TextBox" + index;
            pnlTextBoxes.Controls.Add(txt);
            Literal lt = new Literal();
            lt.Text = "<br />";
            pnlTextBoxes.Controls.Add(lt);*/
            //this.CreateTextBox("TextBox" + index);

            //IterateThroughChildren(this);
            /*pnlTextBoxes.Controls.Clear();
            int index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + 1;
            this.CreateTextBox("txtDynamic" + index);*/

            // z = Convert.ToInt32(HowManyToGenerateTextBox.Text);
            //Panel1.Controls.Clear();



            /* for (int i = 0; i < z; i++)
             {
                 TextBox s = new TextBox();
                 s.ID = "tb" + i.ToString();
                 Session[s.ID] = s;
                 Panel1.Controls.Add(s);
             }*/

        }


       /* private void CreateTextBox(string id)
        {

            TextBox txt = new TextBox();
            txt.ID = id;
            pnlTextBoxes.Controls.Add(txt);

            Literal lt = new Literal();
            lt.Text = "<br />";
            pnlTextBoxes.Controls.Add(lt);

        }*/
        /*void IterateThroughChildren(Control parent)
        {
            
            foreach (Control c in parent.Controls)
            {
                if (c.GetType().ToString().Equals("System.Web.UI.WebControls.TextBox")
                      && c.ID == null)
                {
                    ((TextBox)c).Text = "TextBox" + count.ToString();
                    ((TextBox)c).ID = "TextBox"+count.ToString();
                    count++;
                }

                if (c.Controls.Count > 0)
                {
                    IterateThroughChildren(c);
                }
            }
        }*/


        private string PopulateBody()
        {
            guestListString = new List<String>();
            string body = string.Empty;
            

                    using (StreamReader reader = new StreamReader(Server.MapPath("../Application Layer/EmailTemplate.html")))
            {
                body = reader.ReadToEnd();
            }

            if (Session["eventEdit"] != null)
            {
                eventbl = (EventBL)Session["eventEdit"];

                body = body.Replace("{EventName}", eventbl.EventName);
                body = body.Replace("{Date}", eventbl.EventDate);
                body = body.Replace("{Phone}", eventbl.ContactPhone);
                body = body.Replace("{Email}", eventbl.ContactEmail);
                body = body.Replace("{Address}", eventbl.EventAddress);
                body = body.Replace("{FirstName}", eventbl.FirstName);
                body = body.Replace("{LastName}", eventbl.LastName);

            }
            else if (Session["event"] != null)
            {
                eventbl = (EventBL)Session["event"];

                body = body.Replace("{EventName}", eventbl.EventName);
                body = body.Replace("{Date}", eventbl.EventDate);
                body = body.Replace("{Phone}", eventbl.ContactPhone);
                body = body.Replace("{Email}", eventbl.ContactEmail);
                body = body.Replace("{Address}", eventbl.EventAddress);
                body = body.Replace("{FirstName}", eventbl.FirstName);
                body = body.Replace("{LastName}", eventbl.LastName);

            }
            /*body = body.Replace("{EventName}", eventbl.EventName);
            body = body.Replace("{Date}", eventbl.EventDate);
            body = body.Replace("{Phone}", eventbl.ContactPhone);
            body = body.Replace("{Email}", eventbl.ContactEmail);
            body = body.Replace("{Address}", eventbl.EventAddress);
            body = body.Replace("{FirstName}", eventbl.FirstName);
            body = body.Replace("{LastName}", eventbl.LastName);*/
            //Adding an image to the email

            //view.LinkedResources.Add(img);
            
            //body = body.Replace("{ribbonImgPlaceHolder}", img.ContentId);
            return body;
            
        }
        private void SendHtmlFormattedEmail(string body)
        {
            guestListTemp = new List<String>();

            //for (p = 1; p <= j; p++)
            //{ 
            foreach (Control ctr in PlaceHolder1.Controls)
            {
                if (ctr is TextBox)
                {






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
                        //If html does not exist return non-html email
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


                        string tempEmail = ((TextBox)ctr).Text;

                    
                    
                
                        guestListTemp.Add(tempEmail);
                        count++;
                       
                        client.Send(msg);
                       //Changes the email value back to guestEmail so it can redo for the next loop
                        body = body.Replace(((TextBox)ctr).Text, "{guestEmail}");
                        

                    }

                    catch
                    {
                        //Display error message for email failing to send 
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Only emails with correct structure were sent');window.location ='Home.aspx';", true);
                    }
                }
                }

            }
        
        protected void btnConfirmGuests_Click(object sender, EventArgs e)
        {
            

            string body = this.PopulateBody();
            this.SendHtmlFormattedEmail(body);
            if (Session["event"] != null)
            {
                //list = (List<String>)Session["event"];
                eventbl = (EventBL)Session["event"];
               
                eventbl.GuestList = guestListTemp;
                GlobalData.Events.Add(eventbl);

                
                Session.Remove("event");
            }
            else if (Session["eventEdit"] != null)
            {
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

                Session.Remove("eventEdit");
                Session.Remove("eventValue");

                

            }
            count = 0;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Emails have been sent to the guests');window.location ='Home.aspx';", true);
        }
    }
}