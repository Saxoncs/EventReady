<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="EventReady.Application_Layer.CreateEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <%if (value == null)
        {%>
    
    <asp:Label runat="server" ID ="lblHeader">Please fill out empty fields to start creating an event</asp:Label> <br />
    <asp:Label runat="server" ID="lblEventName">Event Name</asp:Label><br />
    <asp:requiredfieldvalidator display="Dynamic" ID="ValEventName" ControlToValidate="txtbxEventName" ErrorMessage="Event name field cannot be empty" style="color:red" runat="server"></asp:requiredfieldvalidator>
    <asp:TextBox runat="server" ID="txtbxEventName"></asp:TextBox> <br />
    
    <asp:Label runat="server" ID ="lblNames">Name of person inviting people to the event</asp:Label> <br/>
    <asp:Label runat="server">Firstname</asp:Label><br/>
    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValFirstName" ControlToValidate="txtbxFirstName" ErrorMessage="Firstname field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
    <asp:TextBox runat="server" id="txtbxFirstName"></asp:TextBox><br/>
    
    <asp:Label runat="server">Lastname</asp:Label><br/>
    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValLastName" ControlToValidate="txtbxLastName" ErrorMessage="Lastname field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
    <asp:TextBox runat="server" id="txtbxLastName"></asp:TextBox><br/>
    
    <asp:Label runat="server">Date of event</asp:Label><br/>
    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValDate" ControlToValidate="txtbxDate" ErrorMessage="Date field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
    <asp:CompareValidator Display="Dynamic" ID="valDateCheck" Operator="GreaterThanEqual" type="Date" ControltoValidate="txtbxDate" ErrorMessage="Date has to be today or later" runat="server" style="color:red"/>
    <asp:TextBox runat="server" TextMode="Date" ID="txtbxDate"></asp:TextBox><br/>
    
    <asp:Label runat="server">Event Address</asp:Label><br/>
    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValAddress" ControlToValidate="txtbxAddress" ErrorMessage="Address field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
    <asp:TextBox runat="server" ID="txtbxAddress"></asp:TextBox><br/>

    <asp:Label runat="server">Contact Phone Number (10 Digits)</asp:Label><br/>
    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValConPhone" ControlToValidate="txtbxConPhone" ErrorMessage="Phone number field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
    <asp:RegularExpressionValidator Display="Dynamic" ID="regexPhone" runat="server" ValidationExpression="^[0-9]{10}$" ControlToValidate="txtbxConPhone" ErrorMessage="Invalid Phone Number" style="color:red"></asp:RegularExpressionValidator>
    <asp:TextBox runat="server" ID="txtbxConPhone"></asp:TextBox><br />
    
    <asp:Label runat="server" >Contact Email Address</asp:Label><br/>
    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValConEmailEmpty" ControlToValidate="txtbxConEmail" ErrorMessage="Email field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
    <asp:RegularExpressionValidator Display="Dynamic" ID="ValConEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtbxConEmail" ErrorMessage="Invalid Email Format" style="color:red"></asp:RegularExpressionValidator>
    <asp:TextBox runat="server" ID="txtbxConEmail"></asp:TextBox><br/>
    
    <asp:Label runat="server" ID="lblDescription">Description</asp:Label><br />
    <asp:TextBox runat="server" ID="txtbxDescription" TextMode="MultiLine"></asp:TextBox><br />

    <%} %>
    <% else if (value != null )
        {%>

    <asp:Label runat="server" ID ="lblHeaderEdit">Please fill out empty fields to start creating an event</asp:Label> <br />
    <asp:Label runat="server" ID="lblEventNameEdit">Event Name</asp:Label><br />
    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValENEdit" ControlToValidate="txtbxEventNameEdit" ErrorMessage="Event name field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
    <asp:TextBox runat="server" ID="txtbxEventNameEdit"></asp:TextBox> <br />
    
    <asp:Label runat="server" ID ="lblNamesEdit">Name of person inviting people to the event</asp:Label> <br/>
    <asp:Label runat="server">Firstname</asp:Label><br/>
    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValFirstNameEdit" ControlToValidate="txtbxFNEdit" ErrorMessage="Firstname field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
    <asp:TextBox runat="server" id="txtbxFNEdit"></asp:TextBox><br/>
    
    <asp:Label runat="server">Lastname</asp:Label><br/>
    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValLNEdit" ControlToValidate="txtbxLNEdit" ErrorMessage="Lastname field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
    <asp:TextBox runat="server" id="txtbxLNEdit"></asp:TextBox><br/>
    
    <asp:Label runat="server">Date of event</asp:Label><br/>
    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValDateEdit" ControlToValidate="txtbxDateEdit" ErrorMessage="Date field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
    <asp:CompareValidator Display="Dynamic" ID="valDateCheckEdit" Operator="GreaterThanEqual" type="Date" ControltoValidate="txtbxDateEdit" ErrorMessage="Date has to be today or later" runat="server" style="color:red"/>
    <asp:TextBox runat="server" TextMode="Date" ID="txtbxDateEdit"></asp:TextBox><br/>
    
    <asp:Label runat="server">Event Address</asp:Label><br/>
    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValAddressEdit" ControlToValidate="txtbxAddressEdit" ErrorMessage="Address field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
    <asp:TextBox runat="server" ID="txtbxAddressEdit"></asp:TextBox><br/>

    <asp:Label runat="server">Contact Phone Number (10 Digits)</asp:Label><br/>
    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="Requiredfieldvalidator6" ControlToValidate="txtbxConPhone" ErrorMessage="Phone number field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
    <asp:RegularExpressionValidator Display="Dynamic" ID="ValConNumEdit" runat="server" ValidationExpression="^[0-9]{10}$" ControlToValidate="txtbxConNumEdit" ErrorMessage="Invalid Phone Number" style="color:red"></asp:RegularExpressionValidator>
    <asp:TextBox runat="server" ID="txtbxConNumEdit"></asp:TextBox><br />
    
    <asp:Label runat="server" >Contact Email Address</asp:Label><br/>
    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValEmailEdit" ControlToValidate="txtbxEmailEdit" ErrorMessage="Email field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
    <asp:RegularExpressionValidator Display="Dynamic" ID="ValEmailCheckEdit" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtbxEmailEdit" ErrorMessage="Invalid Email Format" style="color:red"></asp:RegularExpressionValidator>
    <asp:TextBox runat="server" ID="txtbxEmailEdit"></asp:TextBox><br/>
    
    <asp:Label runat="server" ID="lblDescriptionEdit">Description</asp:Label><br />
    <asp:TextBox runat="server" ID="txtbxDescriptionEdit" TextMode="MultiLine"></asp:TextBox><br />

    <%} %>
    
    <asp:Button runat="server" id="btnContinue" OnClick="btnContinue_Click"/>
        </form>
</asp:Content>
