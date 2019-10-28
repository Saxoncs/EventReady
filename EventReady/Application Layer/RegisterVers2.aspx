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

				<div class="wrap-input100 validate-input m-b-20" data-validate="Enter First Name">
					<asp:textbox class="input100" type="text" name="First Name" placeholder="First Name" runat="server"/>
					<span class="focus-input100"></span>
				</div>

				<div class="wrap-input100 validate-input m-b-20" data-validate="Enter Last Name">
					<asp:textbox class="input100" type="text" name="Last Name" placeholder="Last Name" runat="server"/>
					<span class="focus-input100"></span>
				</div>

				<div class="wrap-input100 validate-input m-b-20" data-validate="Enter username">
					<asp:textbox class="input100" type="text" name="username" placeholder="Username" runat="server"/>
					<span class="focus-input100"></span>
				</div>

				<div class="wrap-input100 validate-input m-b-20" data-validate="Enter email">
					<asp:textbox class="input100" type="text" name="email" placeholder="Email" runat="server" />
					<span class="focus-input100"></span>
				</div>

				<div class="wrap-input100 validate-input m-b-25" data-validate = "Enter password">
					<asp:textbox class="input100" type="password" name="pass" placeholder="Password" runat="server" />
					<span class="focus-input100"></span>
				</div>



				<div class="container-login100-form-btn">
					<button class="login100-form-btn">
						Sign Up
					</button>
				</div>
</br>

			</form>


		</div>
	</div>



	<div id="dropDownSelect1"></div>
  
</body>
</html>
