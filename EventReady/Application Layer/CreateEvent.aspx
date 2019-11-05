<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="EventReady.Application_Layer.CreateEvent" %>
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
    <div class="container-login100" style="background-image: url('../Image/header-bg.jpg');">
		    <div class="wrap-login100 p-l-55 p-r-55 p-t-80 p-b-30">
    <form runat="server">
        
                <div class="login100-form-title p-b-37" >
				    <div>
                        <img src="../Image/er.jpg"  style="width:80px;height:80px;"/> 
				    </div>
                    <h1>Event Ready</h1>
				</div>
                <span class="login100-form-title p-b-37">
					Create an Event by filling out the form
				</span>
                <%if (eventToEdit == null)
                    {%>
                <p>THIS MEANS THAT THE THERE IS NO EVENT TO EDIT</p>
                <div>
                    <asp:requiredfieldvalidator display="Dynamic" ID="ValEventName" ControlToValidate="txtbxEventName" ErrorMessage="Event name field cannot be empty" style="color:red" runat="server" class="input100"></asp:requiredfieldvalidator>
                    <div class="wrap-input100 validate-input m-b-25">
                        <span class="focus-input100"></span>
                        <asp:TextBox runat="server" ID="txtbxEventName" class="input100" placeholder="Event Name"></asp:TextBox> 
                    </div>
                </div>
                <div>
                    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValFirstName" ControlToValidate="txtbxFirstName" ErrorMessage="Firstname field cannot be empty" style="color:red" class="input100"></asp:requiredfieldvalidator>
                    <div class="wrap-input100 validate-input m-b-25">

                        <span class="focus-input100"></span>
                        <asp:TextBox runat="server" id="txtbxFirstName" class="input100" placeholder="Firstname"></asp:TextBox>
                    </div>
                 </div>
    
                 <div>
                    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValLastName" ControlToValidate="txtbxLastName" ErrorMessage="Lastname field cannot be empty" style="color:red" class="input100"></asp:requiredfieldvalidator>
                    <div class="wrap-input100 validate-input m-b-25">
                        <span class="focus-input100"></span>
                    <asp:TextBox runat="server" id="txtbxLastName" class="input100" placeholder="Last Name"></asp:TextBox>
                    </div>
                  </div>
    
                  <div>
                      <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValDate" ControlToValidate="txtbxDate" ErrorMessage="Date field cannot be empty" style="color:red" class="input100"></asp:requiredfieldvalidator>
                        <asp:CompareValidator Display="Dynamic" ID="valDateCheck" Operator="GreaterThanEqual" type="Date" ControltoValidate="txtbxDate" ErrorMessage="Date has to be today or later" runat="server" style="color:red" class="input100"/>
                      <div class="wrap-input100 validate-input m-b-25">
                           <asp:label runat="server"  Text="Event Date" style="font-family: SourceSansPro-Bold; font-size: 16px; color: #4b2354; padding: 0 20px 0 23px;"/>
                        <span class="focus-input100"></span>
                        
                        <asp:TextBox runat="server" TextMode="Date" ID="txtbxDate" class="input100"></asp:TextBox>
                    </div>
                  </div>
                <div>
                    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValAddress" ControlToValidate="txtbxAddress" ErrorMessage="Address field cannot be empty" style="color:red" class="input100"></asp:requiredfieldvalidator>
                    <div class="wrap-input100 validate-input m-b-25">
                        
                        <span class="focus-input100"></span>
                        <asp:TextBox runat="server" ID="txtbxAddress" class="input100" placeholder="Address"></asp:TextBox>
                    </div>
                </div>
                <div>
                    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValConPhone" ControlToValidate="txtbxConPhone" ErrorMessage="Phone number field cannot be empty" style="color:red" class="input100"></asp:requiredfieldvalidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ID="regexPhone" runat="server" ValidationExpression="^[0-9]{10}$" ControlToValidate="txtbxConPhone" ErrorMessage="Invalid Phone Number (10 digits)" style="color:red" class="input100"></asp:RegularExpressionValidator>
                    <div class="wrap-input100 validate-input m-b-25">
                        <span class="focus-input100"></span>
                        <asp:TextBox runat="server" ID="txtbxConPhone" class="input100" placeholder="Contact Phone"></asp:TextBox>
                    </div>
                </div>
    
                 <div>
                        <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValConEmailEmpty" ControlToValidate="txtbxConEmail" ErrorMessage="Email field cannot be empty" style="color:red" class="input100"></asp:requiredfieldvalidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ID="ValConEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtbxConEmail" ErrorMessage="Invalid Email Format" style="color:red" class="input100"></asp:RegularExpressionValidator>
                    <div class="wrap-input100 validate-input m-b-25">
                        <span class="focus-input100"></span>
                        <asp:TextBox runat="server" ID="txtbxConEmail" class="input100" placeholder="Contact Email"></asp:TextBox>
                    </div>
                </div>
    
                  <div>
                    <div class="wrap-input100 validate-input m-b-25">
                        <span class="focus-input100"></span>
                        <asp:TextBox runat="server" ID="txtbxDescription" TextMode="MultiLine" class="input100" placeholder="Description"></asp:TextBox>
                    </div>
                      
                </div>
        
            
    <%} %>
    <% else if (eventToEdit != null )
        {%>
    <p>THIS MEANS THAT THERE IS AN EVENT TO EDIT</p>
                <div>
                    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValENEdit" ControlToValidate="txtbxEventNameEdit" ErrorMessage="Event name field cannot be empty" style="color:red" class="input100"></asp:requiredfieldvalidator>
                     <div class="wrap-input100 validate-input m-b-25">
                        <asp:TextBox runat="server" ID="txtbxEventNameEdit" class="input100" placeholder="EventName"></asp:TextBox> 
                         <span class="focus-input100"></span>
                    </div>
                </div>

                <div>
                    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValDateEdit" ControlToValidate="txtbxDateEdit" ErrorMessage="Date field cannot be empty" style="color:red" class="input100"></asp:requiredfieldvalidator>
                        <asp:CompareValidator Display="Dynamic" ID="valDateCheckEdit" Operator="GreaterThanEqual" type="Date" ControltoValidate="txtbxDateEdit" ErrorMessage="Date has to be today or later" runat="server" style="color:red" class="input100"/>
                     <div class="wrap-input100 validate-input m-b-25">
                         <asp:label runat="server"  Text="Event Date" style="font-family: SourceSansPro-Bold; font-size: 16px; color: #4b2354; padding: 0 20px 0 23px;"/>
                        <asp:TextBox runat="server" TextMode="Date" ID="txtbxDateEdit" class="input100"></asp:TextBox>
                         <span class="focus-input100"></span>
                    </div>
                </div>
    
                <div>
                     <div class="wrap-input100 validate-input m-b-25">
                        <asp:TextBox runat="server" ID="txtbxDescriptionEdit" TextMode="MultiLine" class="input100" placeholder="Description"></asp:TextBox>
                         <span class="focus-input100"></span>
                        </div>
                </div>
        
    <%} %>
    
       <div class="container-login100-form-btn">
           <asp:Button runat="server" id="btnContinue" OnClick="btnContinue_Click" class="login100-form-btn" Text="Continue"/>
       </div>
        
        
        </form>
    </div>
 </div>
</asp:Content>
