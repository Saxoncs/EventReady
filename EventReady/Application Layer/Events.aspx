﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="EventReady.Application_Layer.Events" %>
<%@ Import Namespace="EventReady.Business_Layer"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Style/StyleSheetStyle.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/bootstrap.bundle.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
     <style> 

     </style>
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
                            <th class="text-left, text-list-colour"><strong>EVENT DATE</strong></th>
                            <th class="text-left, text-list-colour"><strong>GUEST LIST</strong></th>
                            <th class="text-left, text-list-colour"><strong>EDIT</strong></th>
                            <th class="text-left, text-list-colour"><strong>REMOVE</strong></th>
                        </tr>
                    </thead>
                    <tbody>
                        <%int countID = 0; %>
                        <!-- Loop through all events -->
                        <%foreach (EventBL e in eventList)
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
 
                            
                            <!-- Event Date -->
                            <td class="text-left">
                                <p class ="text-list-colour"><%=e.deadline %></p>
                            </td>              
                            
                            <!-- RSVP Page link -->
                            <td class="text-left">
                                    <a href="RSVPPage.aspx?selectedEvent=<% =e.eventId %>"> RSVP List</a>
                            </td>

                            <!--Edit event button -->
                            <td class="text-left">
                                 <% UserBL user = (UserBL)Session["user"]; %>
                                    <input type="button" class="btn btn-success" value="EDIT" onclick="window.location.href = 'CreateEvent.aspx?eventToEdit=<%= e.eventId %>&user=<% =user.UserId %>'; return false"/>
                            </td>
                        
                            <!-- this button still hasn't been formatted for the database and will need to be changed -->
                        <!-- Delete BUtton -->
                            <td class="text-left">
                                <input type="button" class="btn btn-danger" value="REMOVE" onclick="window.location.href = 'Events.aspx?mode=toggleDelete&eventToDelete=<%= e.eventId %>&user=<% =user.UserId %>'; return false"/>
                            </td>
                        </tr>
                        <% } %>
                        </tbody>
                     </table>
            </div>
        </div>
    </div>








   
</asp:Content>
