<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotpasswordtest.aspx.cs" Inherits="EventReady.Application_Layer.forgotpasswordtest" %>

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
    <form id="form1" runat="server">
        
			
				<div class="login100-form-title p-b-37" >

				<div>
			
                    <img src="../Image/er.jpg"  style="width:80px;height:80px;"/> 
				</div>

					<h1>Event Ready</h1>
				</div>
				<span class="login100-form-title p-b-37">
					Enter the email you are registered with
				</span>
         






            <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="txtForgottenEmail" class="input100" ErrorMessage="Email field cannot be empty" style="color:red"/>
                    <asp:RegularExpressionValidator Display="Dynamic" ID="valForgottenPassword" class="input100" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtForgottenEmail" ErrorMessage="Invalid Email Format" style="color:red"></asp:RegularExpressionValidator>
             <div>
                 
                    <div class="wrap-input100 validate-input m-b-25">
                    <asp:TextBox ID="txtForgottenEmail" runat="server" class="input100" placeholder="Email" MaxLength="80"/>
                    <span class="focus-input100"></span>
                    <!-- Check to see if field is empty -->
                    
                    </div>
            </div>

            <br/>



				<div  class="container-login100-form-btn">
					<asp:Button runat="server" OnClick="btnContinue_Click" class="login100-form-btn" Text="Continue"/>
                   			
                </div>
                <div class="text-center">
                    <asp:label runat="server" ID="lblEmailMessage" Visible="false" style="color:red;"> This email is not registered at EventReady </asp:label>	
                </div>
                <div class="text-center">
					<a href="LoginVer2.aspx" class="txt2 hov1">
						Back to Login
					</a>
				</div>


            


        






			</form>


		</div>
	</div>



	<div id="dropDownSelect1"></div>


 
</body>
</html>
