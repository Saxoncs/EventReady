<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="InviteVers2.aspx.cs" Inherits="EventReady.Application_Layer.InviteVers2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <label>Invite Guests to your invite using an email</label>

    <asp:TextBox runat="server" ID="CounterTextBox" AutoPostBack="true" />
    <asp:button runat="server" Text="Add Field" ID="btnAddField" OnClick="btnAddField_Click"/> 
    <asp:button runat="server" Text="Confirm Guest List" ID="btnConfirmGuests" OnClick="btnConfirmGuests_Click"/> 
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
    </asp:PlaceHolder>
    
</asp:Content>
