<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="EventReady.Application_Layer.Calendar" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Style/StyleSheetStyle.css" rel="stylesheet" type="text/css" media="screen" runat="server"/>  


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <form id="form1" runat="server">
                           <div class="calcenter" >

        <asp:Calendar ID="calEvents" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="410px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="656px" OnSelectionChanged="calEvents_SelectionChanged" style="margin-right: 0px">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
            <DayStyle Width="14%" />
            <NextPrevStyle Font-Size="8pt" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
            <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
            <TodayDayStyle BackColor="#CCCC99" />
        </asp:Calendar>
                       </div>
 
    </form>

    
</asp:Content>
