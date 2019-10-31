<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterVers2.aspx.cs" Inherits="EventReady.Application_Layer.RegisterVers2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="../Style/StyleTemplate/bootstrap.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="../Style/StyleTemplate/font-awesome.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="../Style/StyleTemplate/material-design-iconic-font.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="../Style/StyleTemplate/animate.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="../Style/StyleTemplate/hamburgers.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="../Style/StyleTemplate/animsition.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="../Style/StyleTemplate/select2.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="../Style/StyleTemplate/daterangepicker.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="../Style/StyleTemplate/util.css"/>
	<link rel="stylesheet" type="text/css" href="../Style/StyleTemplate/main.css"/>
    <!--===============================================================================================-->
	<script src="../js/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="../js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="../Scripts/popper.js"></script>
	<script src="../Scripts/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="vendor/daterangepicker/moment.min.js"></script>
	<script src="../vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="js/main.js"></script>
</head>
<body>
   
        <div class="container-login100" style="background-image: url('../Image/header-bg.jpg');">
		<div class="wrap-login100 p-l-55 p-r-55 p-t-80 p-b-30">
			<form class="login100-form validate-form" runat="server">
				<div class="login100-form-title p-b-37" >

				<div>
					<img src="../Image/er.jpg"  style="width:80px;height:80px;"/>
				</div>

					<h1>Event Ready</h1>
				</div>
				<span class="login100-form-title p-b-37">
					Register
				</span>

                <asp:requiredfieldvalidator display="Dynamic" class="input100" runat="server" ID="ValEmail" ControlToValidate="txtbxEmail" ErrorMessage="Email field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
                <asp:RegularExpressionValidator Display="Dynamic" class="input100" ID="ValEmailCheck" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtbxEmail" ErrorMessage="Invalid Email Format" style="color:red"></asp:RegularExpressionValidator>
                <div class="wrap-input100 validate-input m-b-20" data-validate="Enter email">
					<asp:textbox class="input100" type="text" id="txtbxEmail" placeholder="Email" runat="server" />
					<span class="focus-input100"></span>
				</div>
                <asp:CompareValidator 
                                   ID="compareEmails" Display="Dynamic" Operator="Equal" runat="server"
                                   ValidationGroup="Validate" ControlToValidate="txtbxEmail" class="input100"
                                   ControlToCompare="txtbxEmailConfirm" ErrorMessage="Emails do not match." SetFocusOnError="true" style="color:red;">
                            </asp:CompareValidator>
                <div class="wrap-input100 validate-input m-b-20" data-validate="Enter email">
					<asp:textbox class="input100" type="text" id="txtbxEmailConfirm" placeholder="Confirm Email" runat="server" />
					<span class="focus-input100"></span>
				</div>

                <asp:requiredfieldvalidator display="Dynamic" class="input100" runat="server" ID="ValPassword" ControlToValidate="txtbxPw" ErrorMessage="Password field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
				<div class="wrap-input100 validate-input m-b-25" data-validate = "Enter password">
					<asp:textbox class="input100" textmode="Password" id="txtbxPw" placeholder="Password" runat="server" />
					<span class="focus-input100"></span>
				</div>
                <asp:CompareValidator 
                                   ID="comparePasswords" Display="Dynamic" Operator="Equal" runat="server"
                                   ValidationGroup="Validate" ControlToValidate="txtbxPw" class="input100"
                                   ControlToCompare="txtbxPwConfirm" ErrorMessage="Passwords do not match." SetFocusOnError="true" style="color:red;">
                            </asp:CompareValidator>
                <div class="wrap-input100 validate-input m-b-25" data-validate = "Confirm password">
					<asp:textbox class="input100" textmode="Password" id="txtbxPwConfirm" placeholder="Confirm Password" runat="server" />
					<span class="focus-input100"></span>
				</div>

                <asp:requiredfieldvalidator display="Dynamic" class="input100" runat="server" ID="ValFirstName" ControlToValidate="txtbxFirstName" ErrorMessage="Firstname field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
				<div class="wrap-input100 validate-input m-b-20" data-validate="Enter First Name">
					<asp:textbox class="input100" type="text" id="txtbxFirstName" placeholder="First Name" runat="server"/>
					<span class="focus-input100"></span>
				</div>

                <asp:requiredfieldvalidator display="Dynamic" class="input100" runat="server" ID="ValLastName" ControlToValidate="txtbxLastName" ErrorMessage="Lastname field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
				<div class="wrap-input100 validate-input m-b-20" data-validate="Enter Last Name">
					<asp:textbox class="input100" type="text" id="txtbxLastName" placeholder="Last Name" runat="server"/>
					<span class="focus-input100"></span>
				</div>

				

				<div class="container-login100-form-btn">
					<asp:Button class="login100-form-btn"  Text="Register" runat="server" ID="btnRegister" OnClick="btnRegister_Click"/>
				</div>
                
                <br/>

			</form>


		</div>
	</div>



	<div id="dropDownSelect1"></div>
  
</body>
</html>
