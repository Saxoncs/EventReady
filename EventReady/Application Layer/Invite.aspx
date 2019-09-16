<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="Invite.aspx.cs" Inherits="EventReady.Application_Layer.Invite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox runat="server"></asp:TextBox>


     <!-- connecting the front end to the back end database through EmailDataAccess -Saxon -->
    <asp:DropdownList runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="name" DataValueField="email">
    </asp:DropdownList>
    <asp:DropdownList runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource2" DataTextField="name" DataValueField="email">
    </asp:DropdownList>
    <!-- Default value for Data source is set to the test value in the database, this should be changed later to be drawn from session data -Saxon -->
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetGuests" TypeName="EventReady.Data_Access_Layer.EmailDataAccess">
        <SelectParameters>
            <asp:Parameter DefaultValue="3282914" Name="userId" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <!-- 2nd version of the drop down list now checks to see that the guest is considered 'active' guests will be set as inactive if deleted from a user's page. -->
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetActiveGuests" TypeName="EventReady.Business_Layer.EmailBL">
        <SelectParameters>
            <asp:Parameter DefaultValue="3282914" Name="userId" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>
