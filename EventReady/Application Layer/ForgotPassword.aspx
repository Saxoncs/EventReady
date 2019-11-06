<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="EventReady.Application_Layer.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Content/stylesheet.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/bootstrap.bundle.min.js"></script>


</head>
<body>
    <form id="form1" runat="server">
        <div> <!--style="background-image: url('../Image/.jpg');"--> 
            <h3>Remember Password</h3>
            <!-- Information about password assistance -->
            <div>
                 <div>
                    <label> Enter the email you are registered with </label>
                 </div>
            </div>
            
            <div>
                    
                    <div>
                    <asp:TextBox ID="txtForgottenEmail" runat="server" class="form-control" placeholder="Email" MaxLength="80"/>
                    <!-- Check to see if field is empty -->
                    <asp:RequiredFieldValidator display="Dynamic" runat="server" ControlToValidate="txtForgottenEmail" class="label-error" ErrorMessage="Email field cannot be empty" style="color:red"/>
                    <asp:RegularExpressionValidator Display="Dynamic" ID="valForgottenPassword" CssClass="label-error" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtForgottenEmail" ErrorMessage="Invalid Email Format" style="color:red"></asp:RegularExpressionValidator>
                 </div>
            </div>

            <!-- Submission button -->
            <asp:Button runat="server" OnClick="btnContinue_Click" class="btn btnSubmit btn-block" Text="Continue"/>
            <asp:label runat="server" ID="lblEmailMessage" Visible="false" style="color:red;"> This email is not registered at EventReady </asp:label>
        </div>
    </form>
</body>
</html>
