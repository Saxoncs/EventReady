<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="EventReady.Application_Layer.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
    <link rel="stylesheet" type="text/css" href="login.css" />
 
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="heading">
        	            <hr/>
        		            <h1>Register</h1>
          		            <img src="strip4.jpg" alt="EVENTREADY LOGO" style="width:80px;height:80px;"/>
     		             <hr/>
    	            </div>
                  <div class="center">

                        <div>

                            <label for="firstName">First Name</label>

                            <asp:Textbox id="firstName" runat="server"/> <br/>
                            <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="firstName" class="label-error" ErrorMessage="Firstname field cannot be empty"/>

                        </div>

                        <br/>

                        <div>

                            <label for="lastName">Last Name</label>

                            <asp:Textbox id="lastName" runat="server"/> <br />
                            <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="lastName" class="label-error" ErrorMessage="Lastname field cannot be empty"/>
                        </div>

                        <br/>


                        <br/>

                        <div>

                            <label for="emailAddress">Email Address</label>

                            <asp:Textbox id="emailAddress" runat="server"/> <br /> 
                             <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="emailAddress" class="label-error" ErrorMessage="Email field cannot be empty"/>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1" CssClass="label-error" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="emailAddress" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                        </div>

                        <br/>

                        <div>
                            <label for="emailAddress">Confirm Email Address</label>

                            <asp:Textbox id="confirmEmail" runat="server"/> <br /> 
                            <asp:CompareValidator
                                   ID="CompareValidator2" Display="Dynamic" Operator="Equal" runat="server"
                                   ValidationGroup="Validate" ControlToValidate="emailAddress"  
                                   ControlToCompare="confirmEmail" CssClass="label-error" ErrorMessage="Passwords do not match." SetFocusOnError="true">
                            </asp:CompareValidator>
                        </div>
                      <br />

                        <div>

                            <label for="password">Password</label>

                            <asp:Textbox id="password" runat="server"/> <br />
                            <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="password" class="label-error" ErrorMessage="Password field cannot be empty"/>
                        </div>

                        <br/>

                        <div>

                            <label for="confirmPassword">Confirm Password</label>

                            <asp:Textbox id="confirmPassword" runat="server"/> <br />
                            <asp:CompareValidator
                                   ID="comparePasswords" Display="Dynamic" Operator="Equal" runat="server"
                                   ValidationGroup="Validate" ControlToValidate="password"  
                                   ControlToCompare="confirmPassword" CssClass="label-error" ErrorMessage="Passwords do not match." SetFocusOnError="true">
                            </asp:CompareValidator>
                        </div>

                        <br/>


                  <!--<a href="needhelpage.html">need help?</a>-->

                        <input type="submit" value="Login">


                </div>
        </div>
    </form>
</body>
</html>
