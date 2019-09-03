<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="Invite.aspx.cs" Inherits="EventReady.Application_Layer.Invite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox runat="server"></asp:TextBox>


     <!-- trying to connect the front end to the back end database through EmailDataAccess -Saxon-->
    <asp:DropDownList runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="name" DataValueField="email">
    </asp:DropDownList>
    
    <!-- Default value for Data source is set to the test value in the database should be changed later -Saxon -->
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetGuests" TypeName="EventReady.Data_Access_Layer.EmailDataAccess">
        <SelectParameters>
            <asp:Parameter DefaultValue="3282914" Name="userId" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
