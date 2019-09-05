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

                            <input type="text" name="firstName" id="firstName">

                        </div>

                        <br/>

                        <div>

                            <label for="lastName">Last Name</label>

                            <input type="text" name="lastName" id="lastName">

                        </div>

                        <br/>

                        <div>

                            <label for="Username">Username</label>

                            <input type="text" name="username" id="username">

                        </div>

                        <br/>

                        <div>

                            <label for="emailAddress">Email Address</label>

                            <input type="text" name="emailAddress" id="emailAddress">

                        </div>

                        <br/>

                        <div>

                            <label for="password">Password</label>

                            <input type="password" name="password" id="password">

                        </div>

                        <br/>

                        <div>

                            <label for="confirmPassword">Confirm Password</label>

                            <input type="password" name="confirmPassword" id="confirmPassword">

                        </div>

                        <br/>


                  <a href="needhelpage.html">need help?</a>

                        <input type="submit" value="Login">


                </div>
        </div>
    </form>
</body>
</html>
