<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="EventDetails.aspx.cs" Inherits="EventReady.Application_Layer.EventDetails" %>
<%@ Import Namespace="EventReady.Business_Layer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <asp:Label runat="server" ID="lblEName" Text=""></asp:Label>
    <asp:Label runat="server" ID="lblFName" Text=""></asp:Label> <br />
    <asp:Label runat="server" ID="lblLName" Text=""></asp:Label> <br />
    <asp:Label runat="server" ID="lblEDate" Text=""></asp:Label> <br />
    <asp:Label runat="server" ID="lblEAddress" Text=""></asp:Label> <br />
    <asp:Label runat="server" ID="lblEDescription" Text=""></asp:Label> <br />
    <asp:Label runat="server" ID="lblEEmail" Text=""></asp:Label> <br />
    <asp:Label runat="server" ID="lblEPhone" Text=""></asp:Label> 
        <% if (Session["event"] != null)
    {
        UserBL user = (UserBL)Session["user"]; %>
        <input type="button" value="Back" onclick="window.location.href = 'CreateEvent.aspx?check=value&user=<%=user.Email%>'; return false"/>
    
        <% 
    }
    else if (Session["eventEdit"] != null)
    {
        int value = Convert.ToInt32(Session["eventValue"]);%>
        <input type="button" value="Back" onclick="window.location.href = 'CreateEvent.aspx?value=<%=value%>'; return false"/>
        
        <% 
    }%>
  <asp:Button runat="server"  ID="btnConfirm" Text="Confirm" OnClick="btnConfirm_Click"/>
        </form>
</asp:Content>
