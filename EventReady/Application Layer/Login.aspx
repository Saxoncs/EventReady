<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EventReady.Application_Layer.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
    <link rel="stylesheet" type="text/css" href="login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="heading">
              <hr/>

              <h1>Event Ready</h1>

                <img src="strip4.jpg" alt="EVENTREADY LOGO" style="width:80px;height:80px;"/>
            <hr/>
            </div>



         

            <div class="center">
                  <div>
                      <label for="email">Email Address</label>
                      <asp:Textbox runat="server" id="email"/> <br />
                      <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1" CssClass="label-error" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="email" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                  </div>
                  <br/>
                  <div>
                      <label for="password">Password</label>
                      <asp:Textbox runat="server" id="password"/>
                  </div>
                  <br/>
            <a href="needhelpage.html">need help?</a>

                  <asp:Button runat="server" Text="Login" OnClick="login_Click"/>
                  <asp:Label runat="server" ID="errorMessage" Text="This login attempt has failed" Visible="false" class= "errorMessage"/>
            </div>
        </div>
    </form>
</body>
</html>
