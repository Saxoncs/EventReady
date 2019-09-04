<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="EventReady.Application_Layer.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Generated datasource for testing -->
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [userInfo]"></asp:SqlDataSource>
    <!-- end of test datasource -->
<p>
</p>
</asp:Content>
