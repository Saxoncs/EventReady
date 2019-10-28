﻿using System;
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
            if(IsValid)
            {
               GlobalData.userMap.Add(txtbxEmail.Text, new User(txtbxFirstName.Text, txtbxLastName.Text, txtbxEmail.Text, txtbxPw.Text));
                Response.Redirect("LoginVer2.aspx");
            }
        }
    }
}