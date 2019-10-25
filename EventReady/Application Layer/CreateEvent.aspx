<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="EventReady.Application_Layer.CreateEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" ID ="lblHeader">Please fill out empty fields to start creating an event</asp:Label> <br />
    <asp:Label runat="server" ID="lblEventName">Event Name</asp:Label><br />
    <asp:TextBox runat="server" ID="txtbxEventName"></asp:TextBox> <br />
    <asp:Label runat="server" ID ="lblNames">Name of person inviting people to the event</asp:Label> <br/>
    <asp:Label runat="server">Firstname</asp:Label><br/>
    <asp:TextBox runat="server" id="txtbxFirstName"></asp:TextBox><br/>
    <asp:Label runat="server">Lastname</asp:Label><br/>
    <asp:TextBox runat="server" id="txtbxLastName"></asp:TextBox><br/>
    <asp:Label runat="server">Date of event</asp:Label><br/>
    <asp:TextBox runat="server" TextMode="Date" ID="txtbxDate"></asp:TextBox><br/>
    <asp:Label runat="server">Event Address</asp:Label><br/>
    <asp:TextBox runat="server" ID="txtbxAddress"></asp:TextBox><br/>
    <asp:Label runat="server">Contact Phone Number</asp:Label><br/>
    <asp:TextBox runat="server" ID="txtbxConPhone"></asp:TextBox><br />
    <asp:Label runat="server" >Contact Email Address</asp:Label><br/>
    <asp:TextBox runat="server" ID="txtbxConEmail"></asp:TextBox><br/>
    <asp:Label runat="server" ID="lblDescription">Description</asp:Label><br />
    <asp:TextBox runat="server" ID="txtbxDescription" TextMode="MultiLine"></asp:TextBox>
    
    <asp:Button runat="server" id="btnContinue" OnClick="btnContinue_Click"/>
</asp:Content>
