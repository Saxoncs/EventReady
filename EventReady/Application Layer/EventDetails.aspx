<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="EventDetails.aspx.cs" Inherits="EventReady.Application_Layer.EventDetails" %>
<%@ Import Namespace="EventReady" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" ID="lblEName" Text=""></asp:Label>
    <asp:Label runat="server" ID="lblFName" Text=""></asp:Label> <br />
    <asp:Label runat="server" ID="lblLName" Text=""></asp:Label> <br />
    <asp:Label runat="server" ID="lblEDate" Text=""></asp:Label> <br />
    <asp:Label runat="server" ID="lblEAddress" Text=""></asp:Label> <br />
    <asp:Label runat="server" ID="lblEDescription" Text=""></asp:Label> <br />
    <asp:Label runat="server" ID="lblEEmail" Text=""></asp:Label> <br />
    <asp:Label runat="server" ID="lblEPhone" Text=""></asp:Label> 

    <asp:Button runat="server"  ID="btnConfirm" Text="Confirm" OnClick="btnConfirm_Click"/>
</asp:Content>
