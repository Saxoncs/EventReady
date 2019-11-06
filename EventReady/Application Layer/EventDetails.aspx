<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="EventDetails.aspx.cs" Inherits="EventReady.Application_Layer.EventDetails" %>
<%@ Import Namespace="EventReady.Business_Layer" %>
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
    <script src="../Style/StyleSheetStyle.css"></script>
</asp:Content>










<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-login100" style="width: 100%;
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
    z-index: 1;">
		<div class="wrap-login100 p-l-55 p-r-55 p-t-80 p-b-30">
			<form class="login100-form validate-form" runat="server">
				<div class="login100-form-title p-b-37" >
                
					
    
      <h2>Confirmed Details:</h2> <br/>
      
      
      
    
    <asp:Label runat="server" class="detail" ID="lblEName" Text=""></asp:Label>
    <asp:Label runat="server" class="detail" ID="lblFName" Text=""></asp:Label> <br />
    <asp:Label runat="server" class="detail" ID="lblLName" Text=""></asp:Label> <br />
    <asp:Label runat="server" class="detail" ID="lblEDate" Text=""></asp:Label> <br />
    <asp:Label runat="server" class="detail" ID="lblEAddress" Text=""></asp:Label> <br />
    <asp:Label runat="server" class="detail" ID="lblEDescription" Text=""></asp:Label> <br />
    <asp:Label runat="server" class="detail" ID="lblEEmail" Text=""></asp:Label> <br />
    <asp:Label runat="server" class="detail" ID="lblEPhone" Text=""></asp:Label> <br/>

    
    <div class="container-login100-form-btn">
    <asp:Button runat="server" class="login100-form-btn"  ID="Button1" Text="Confirm" OnClick="btnConfirm_Click"/> 
    </div><br/>
				   





        <% if (Session["event"] != null)
    {
        UserBL user = (UserBL)Session["user"]; %>
                    <div class="container-login100-form-btn">
        
                    <input type="button" class="login100-form-btn" value="Back" onclick="window.location.href = 'CreateEvent.aspx?check=value&user=<%=user.Email%>'; return false"/>
                    
                    </div>
        <% 
    }
    else if (Session["eventEdit"] != null)
    {
        int value = Convert.ToInt32(Session["eventValue"]);%>
                    <div class="container-login100-form-btn">
        <input type="button" class="login100-form-btn" value="Back" onclick="window.location.href = 'CreateEvent.aspx?value=<%=value%>'; return false"/>
        </div>
        <% 
    }%>

                  
    
   

    
                    





                      
                    
				</div>

				

			</form>


		</div>
	</div>

   

</asp:Content>

