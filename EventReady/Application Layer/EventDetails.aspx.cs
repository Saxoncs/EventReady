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
            if (Session["event"] != null )
            {
                //list = (List<String>)Session["event"];
                eventbl = (EventBL)Session["event"];
                //lblEName.Text = list[1];
                //lblEDescription.Text = list[2];
                //lblFName.Text = list[3];
                //lblLName.Text = list[4];
                //lblEDate.Text = list[5];
                //lblEAddress.Text = list[6];
                //lblEPhone.Text = list[7];
                //lblEEmail.Text = list[8];

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
                Response.Redirect("InviteVers2.aspx");
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            eventbl = (EventBL)Session["event"];
           
           // GlobalData.Events.Add(eventbl);
            
            /*foreach (Product p in order.Products)
            {
                foreach (Product p2 in GlobalData.productList)
                {
                    if (p2.Name.Equals(p.Name))
                    {
                        p2.Stock -= p.Quantity;
                    }
                }
            }
            foreach (Product p in GlobalData.productList)
            {
                if (p.Stock > 0)
                {
                    temp.Add(GlobalData.productList[GlobalData.productList.IndexOf(p)]);
                }
            }*/
            //GlobalData.productList = temp;
            //Session.Remove("event");
            Response.Redirect("InviteVers2.aspx");
        }
    }
}