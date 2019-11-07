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
                            <th class="text-left, text-list-colour"><strong>GUEST NAME</strong></th>
                            <th class="text-left, text-list-colour"><strong>GUEST EMAIL</strong></th>
                            <th class="text-left, text-list-colour"><strong>STATUS</strong></th>
                           
                        </tr>
                    </thead>
                    <tbody>
                        <%int countID = 0; %>
                         <%foreach (EmailBL.GuestBL g in guestList)
                             {
                                 //saved the database classes as local variables -saxon
                                 string guestName = g.name;
                                 string guestEmail = g.email;
                                 string guestRSVP = g.rsvp;

                                 countID++;
                                     %> 
                    <tr>
                            
                       
       
                            <td class="no"><%= countID %></td>
                            
                            <td class="text-left">
                                <p class="text-list-colour"> <%= guestName %></p>
                                
                            </td>

                            
                            <td class="text-left">
                                <p class="text-list-colour"> <%= guestEmail %></p>
                                
                            </td>
                            
                                
                           <!-- Adds rsvp status -->
                            <td class="text-left">
                                <p class="text-list-colour"> <%= guestRSVP %> </p>
                            </td>
                                
                            
                            
                        </tr>
                         <%} %>
                        </tbody>
                     </table>

                                <input type="button" class="btn btn-danger" value="ADD GUESTS" onclick="window.location.href = 'InviteVers2.aspx?eventId=<%= selectedEvent %>'; return false"/>
                                <!-- GlobalData.Events.IndexOf(e) --> 
                      
            </div>
        </div>
    </div>
</asp:Content>
