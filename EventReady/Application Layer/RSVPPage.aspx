<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="RSVPPage.aspx.cs" Inherits="EventReady.Application_Layer.RSVPPage" %>
<%@ Import Namespace="EventReady.Business_Layer"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Style/StyleSheet.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/bootstrap.bundle.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="viewItemlist">
        <div class="itemlist overflow-auto">
            <div style="min-width: 600px">
                 <table border="0">
                    <thead>
                        <tr>
                            <!-- The names of all the headings in the table -->
                            <th class="text-list-colour"><strong>ID #</strong></th>
                            <th class="text-left, text-list-colour"><strong>GUEST EMAIL</strong></th>
                            <th class="text-left, text-list-colour"><strong>STATUS</strong></th>
                           
                        </tr>
                    </thead>
                    <tbody>
                        <%int countID = 0; %>
                         <%foreach (EventBL e in GlobalData.Events)
    {
        if (Convert.ToInt32(guestList) == GlobalData.Events.IndexOf(e))
        {
            countID++;  %>
                        <!-- Adds the event name to the page -->
                    <tr>
                            <td class="no"><%= countID %></td>
                            <%// Need a for each here that will loop through the guest list 
                            %>
                            <td class="text-left">
                                <p class="text-list-colour"><%//= %></p>
                                
                            </td>
                            <% %>
                                
                           <!-- Adds event description -->
                            <td class="text-left">
                                <p class="text-list-colour"> Not Responded </p>
                                
                            </td>
 
                            
                            
                        </tr>
                        <% }
    }%>
                        </tbody>
                     </table>
            </div>
        </div>
    </div>
</asp:Content>
