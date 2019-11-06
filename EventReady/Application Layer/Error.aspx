<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="EventReady.Application_Layer.Error" %>

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
   
        <div class="container-login100" style="background-image: url('../Image/backgroundImage.jpg');">
		<div class="wrap-login100 p-l-55 p-r-55 p-t-80 p-b-30">
			<form class="login100-form validate-form" runat="server">
				<div class="login100-form-title p-b-37" >
                    <span class="login100-form-title p-b-37">
					An Error has occurred
				    </span>
                <div><a>This page does not exist on our website :(</a>
				</div>
				

				</div>
				

             
			    <div class="container-login100-form-btn">
                    <asp:Button runat="server" class="login100-form-btn" ID="backtohome" OnClick="btnOk_Click" Text="Back to Home Page" />
				</div>

				

			</form>


		</div>
	</div>



	<div id="dropDownSelect1"></div>
  
</body>
</html>
