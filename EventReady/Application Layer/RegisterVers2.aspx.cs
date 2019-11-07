using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EventReady.Business_Layer;

namespace EventReady.Application_Layer
{
    public partial class RegisterVers2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //Creating a new user if all the validators are correct
            if(IsValid)
            {
                UserBL userInfo = new UserBL();

                string email = ((TextBox)FindControl("txtbxEmail")).Text;
                UserBL user = userInfo.GetLogingUser(email);

                //Checks if the user already exists that duplicate accounts with the same email wont be created or crash
                if (user.Email == null)
                {
                    userInfo.CreateNewUser(txtbxFirstName.Text, txtbxLastName.Text, txtbxEmail.Text, txtbxPw.Text);
                    Response.Redirect("LoginVer2.aspx");
                }
                else
                {
                    lblErrorMessage.Text = "This account already exists";
                    lblErrorMessage.Visible = true;
                }
               //GlobalData.userMap.Add(txtbxEmail.Text, new UserBL(txtbxFirstName.Text, txtbxLastName.Text, txtbxEmail.Text, txtbxPw.Text, "3282914"));
            }
        }
    }
}