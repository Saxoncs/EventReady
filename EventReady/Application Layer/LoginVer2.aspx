<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginVer2.aspx.cs" Inherits="EventReady.Application_Layer.LoginVer2" %>

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
    <form id="form1" runat="server" class="login100-form validate-form">
        
			
				<div class="login100-form-title p-b-37" >

				<div>
			
                    <img src="../Image/er.jpg"  style="width:300px;height:300px;"/> 
				</div>


				</div>
				<span class="login100-form-title p-b-37">
					Sign In
				</span>
          
                <asp:requiredfieldvalidator display="Dynamic" class="input100" runat="server" ID="ValEmailEmpty" ControlToValidate="txtbxEmail" ErrorMessage="Email field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
                <asp:RegularExpressionValidator Display="Dynamic" ID="ValEmail" class="input100" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtbxEmail" ErrorMessage="Invalid Email Format" style="color:red"></asp:RegularExpressionValidator>
				<div class="wrap-input100 validate-input m-b-20" data-validate="Enter username or email">
                  
					<asp:Textbox class="input100" runat="server" placeholder="Email" ID="txtbxEmail"/>
                    
					<span class="focus-input100"></span>
				</div>
                
                <asp:requiredfieldvalidator display="Dynamic" class="input100" runat="server" ID="ValPassword" ControlToValidate="txtbxPassword" ErrorMessage="Password field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
				<div class="wrap-input100 validate-input m-b-25" data-validate = "Enter password">
					<asp:Textbox class="input100" runat="server" placeholder="Password" ID="txtbxPassword" type="password"/>
                    
					<span class="focus-input100"></span>
				</div>



				<div class="container-login100-form-btn">
					<asp:button class="login100-form-btn" runat="server" Text="Sign In" OnClick="btnLogin_Click"/>
						
				</div>
<br/>
				<div class="text-center">
					<a href="RegisterVers2.aspx" class="txt2 hov1">
						Sign Up
					</a>
				</div>
                <div class="text-center">
					<asp:HyperLink id="forgotPasswordLink" NavigateUrl="forgotpasswordtest.aspx" Text="Forgot your password?" runat="server"></asp:HyperLink>
				</div>
			</form>


		</div>
	</div>



	<div id="dropDownSelect1"></div>


 
</body>
</html>
