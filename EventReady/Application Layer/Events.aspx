﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="EventReady.Application_Layer.Events" %>
<%@ Import Namespace="EventReady.Business_Layer"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Style/StyleSheet.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/bootstrap.bundle.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</asp:Content>

<asp:Content ID="ViewContent2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="viewItemlist">
        <div class="itemlist overflow-auto">
            <div style="min-width: 600px">
                 <table border="0">
                    <thead>
                        <tr>
                            <!-- The names of all the headings in the table -->
                            <th class="text-list-colour"><strong>ID #</strong></th>
                            <th class="text-left, text-list-colour"><strong>NAME</strong></th>
                            <th class="text-left, text-list-colour"><strong>DESCRIPTION</strong></th>
                            <th class="text-left, text-list-colour"><strong>FIRSTNAME</strong></th>
                            <th class="text-left, text-list-colour"><strong>LASTNAME</strong></th>
                            <th class="text-left, text-list-colour"><strong>EVENT DATE</strong></th>
                            <th class="text-left, text-list-colour"><strong>EVENT ADDRESS</strong></th>
                            <th class="text-left, text-list-colour"><strong>CONTACT NUMBER</strong></th>
                            <th class="text-left, text-list-colour"><strong>CONTACT EMAIL</strong></th>
                            <th class="text-left, text-list-colour"><strong>GUEST LIST</strong></th>
                            <th class="text-left, text-list-colour"><strong>EDIT</strong></th>
                            <th class="text-left, text-list-colour"><strong>REMOVE</strong></th>
                        </tr>
                    </thead>
                    <tbody>
                        <%int countID = 0; %>
                        <%foreach (EventUL e in displayedEventList)
                            { 
                             countID++; %>
                        <!-- Adds the event name to the page -->
                    <tr>
                            <td class="no"><%= countID %></td>
                            <td class="text-left">
                                <p class="text-list-colour"><%=e.name %></p>
                                
                            </td>
                            
                                
                           <!-- Adds event description -->
                            <td class="text-left">
                                <p class="text-list-colour"> <%=e.description %></p>
                                
                            </td>
 
                            
                            <!-- Adds event duration modifier -->
                            <td class="text-left">
                                <p class ="text-list-colour"><%=e.daysDelayed %></p>
                                
                            </td>

                            <td class="text-left">
                                <p class ="text-list-colour"><%=e.start %></p>
                                
                            </td>

                            <td class="text-left">
                                <p class ="text-list-colour"><%=e.deadline %></p>
                                
                            </td>                     

                            <td class="text-left">
                                
                                    <!-- pressing the RSVP button currently hard codes the selected event to be event 0000001 -->
                                    <a href="RSVPPage.aspx?selectedEvent=0000001"> RSVP List</a>
                            
         
                            </td>

                            <td class="text-left">
                                 <% User user = (User)Session["user"]; %>
                                    <input type="button" class="btn btn-success" value="EDIT" onclick="window.location.href = 'CreateEvent.aspx?eventToEdit=<%= e.eventId %>&user=<% =user.UserId %>'; return false"/>
                            </td>
                        
                            <!-- this button still hasn't been formatted for the database and will need to be changed -->
                            <td class="text-left">
                                <input type="button" class="btn btn-danger" value="REMOVE" onclick="window.location.href = 'Events.aspx?mode=toggleDelete&event=<%=displayedEventList.IndexOf(e)%>'; return false"/>
                                <!-- GlobalData.Events.IndexOf(e) --> 
                            </td>
                        </tr>
                        <% } %>
                        </tbody>
                     </table>
            </div>
        </div>
    </div>








   
</asp:Content>
