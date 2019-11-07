<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="InviteVers2.aspx.cs" Inherits="EventReady.Application_Layer.InviteVers2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
</asp:Content>








<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div style="width: 100%;
    min-height: 100vh;
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    align-items: center;
    padding: 15px;
    background-repeat: no-repeat;
    background-size: cover;
    background-position: center;
    position: relative;
    z-index: 1;"">
		<div class="wrap-login100 p-l-55 p-r-55 p-t-80 p-b-30">
			<form class="login100-form validate-form" runat="server">
				<div class="login100-form-title p-b-37" >




    <label>Invite Guests to your invite using an email</label>

	<div class="wrap-input100 validate-input m-b-25">
	<asp:textbox class="input100" runat="server" ID="CounterTextBox" AutoPostBack="true" />
	<span class="focus-input100"></span>
	</div>


    

    
   <div class="container-login100-form-btn">
    <asp:button runat="server" class="login100-form-btn" Text="Add Field" ID="btnAddField" OnClick="btnAddField_Click"/> 
        </div>
<br/>

        <div class="container-login100-form-btn">
    <asp:button runat="server" class="login100-form-btn" Text="Confirm Guest List" ID="btnConfirmGuests" OnClick="btnConfirmGuests_Click"/> 
     </div>

<br/>

<div class="wrap-input100 validate-input m-b-20">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server" > </asp:PlaceHolder>
    <span class="focus-input100"></span>
 </div>

    
                    
			

				</div>

			</form>


		</div>
	</div>
    



</asp:Content>

