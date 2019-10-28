<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="EventReady.Application_Layer.CreateEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" ID ="lblHeader">Please fill out empty fields to start creating an event</asp:Label> <br />
    <asp:Label runat="server" ID="lblEventName">Event Name</asp:Label><br />
    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValEventName" ControlToValidate="txtbxEventName" ErrorMessage="Event name field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
    <asp:TextBox runat="server" ID="txtbxEventName"></asp:TextBox> <br />
    <asp:Label runat="server" ID ="lblNames">Name of person inviting people to the event</asp:Label> <br/>
    <asp:Label runat="server">Firstname</asp:Label><br/>
    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValFirstName" ControlToValidate="txtbxFirstName" ErrorMessage="Firstname field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
    <asp:TextBox runat="server" id="txtbxFirstName"></asp:TextBox><br/>
    <asp:Label runat="server">Lastname</asp:Label><br/>
    <asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValLastName" ControlToValidate="txtbxLastName" ErrorMessage="Lastname field cannot be empty" style="color:red"></asp:requiredfieldvalidator>
    <asp:TextBox runat="server" id="txtbxLastName"></asp:TextBox><br/>
    <asp:Label runat="server">Date of event</asp:Label><br/>
    <!--<asp:requiredfieldvalidator display="Dynamic" runat="server" ID="ValDate" ControlToValidate="txtbxLastName" ErrorMessage="Lastname field cannot be empty" style="color:red"></asp:requiredfieldvalidator>-->
    <asp:CompareValidator ID="valDateCheck" Operator="LessThan" type="String" ControltoValidate="txtbxDate" ErrorMessage="Date is invalid" runat="server" />
    <asp:TextBox runat="server" TextMode="Date" ID="txtbxDate"></asp:TextBox><br/>
    <asp:Label runat="server">Event Address</asp:Label><br/>
    <asp:TextBox runat="server" ID="txtbxAddress"></asp:TextBox><br/>
    <asp:Label runat="server">Contact Phone Number</asp:Label><br/>
    <asp:TextBox runat="server" ID="txtbxConPhone"></asp:TextBox><br />
    <asp:Label runat="server" >Contact Email Address</asp:Label><br/>
    <asp:RegularExpressionValidator Display="Dynamic" ID="ValConEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtbxConEmail" ErrorMessage="Invalid Email Format" style="color:red"></asp:RegularExpressionValidator>
    <asp:TextBox runat="server" ID="txtbxConEmail"></asp:TextBox><br/>
    <asp:Label runat="server" ID="lblDescription">Description</asp:Label><br />
    <asp:TextBox runat="server" ID="txtbxDescription" TextMode="MultiLine"></asp:TextBox>
    
    <asp:Button runat="server" id="btnContinue" OnClick="btnContinue_Click"/>
</asp:Content>
