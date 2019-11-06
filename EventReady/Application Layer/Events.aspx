<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="EventReady.Application_Layer.Events" %>
<%@ Import Namespace="EventReady.Business_Layer"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Style/StyleSheetStyle.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/bootstrap.bundle.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
     <style> 
         .center {
    text-align: center;
}

.heading {
    text-align: center;
}


.errorMessage {
    color: red;
}

#itemlist {
    padding: 30px;
}

.itemlist {
    position:relative;
    background-color: #FFF;
    min-height: 680px;
    padding: 15px;
    margin-top: 70px;
    
}

    .itemlist header {
        padding: 10px 0;
        margin-bottom: 20px;
        border-bottom: 1px solid #3989c6
    }

    .itemlist .company-details {
        text-align: right
    }

        .itemlist .company-details .name {
            margin-top: 0;
            margin-bottom: 0
        }

    .itemlist .contacts {
        margin-bottom: 20px
    }

    .itemlist .itemlist-to {
        text-align: left
    }

        .itemlist .itemlist-to .to {
            margin-top: 0;
            margin-bottom: 0
        }

    .itemlist .itemlist-details {
        text-align: right
    }

        .itemlist .itemlist-details .itemlist-id {
            margin-top: 0;
            color: #3989c6
        }

    .itemlist table {
        width: 100%;
        border-collapse: collapse;
        border-spacing: 0;
        margin-bottom: 20px
    }

        .itemlist table td, .itemlist table th {
            padding: 15px;
            background: #eee;
            border-bottom: 1px solid #fff
        }

        .itemlist table th {
            white-space: nowrap;
            font-weight: 400;
            font-size: 16px
        }

        .itemlist table td h3 {
            margin: 0;
            font-weight: 400;
            color: #3989c6;
            font-size: 1.2em
        }

        .itemlist table .qty, .itemlist table .total, .itemlist table .unit {
            text-align: right;
            font-size: 1.2em
        }

        .itemlist table .no {
            color: #fff;
            font-size: 1.6em;
            background: #3989c6
        }

        .itemlist table .unit {
            background: #ddd
        }

        .itemlist table .total {
            background: #3989c6;
            color: #fff
        }

        .itemlist table tbody tr:last-child td {
            border: none
        }

        .itemlist table tfoot td {
            background: 0 0;
            border-bottom: none;
            white-space: nowrap;
            text-align: right;
            padding: 10px 20px;
            font-size: 1.2em;
            border-top: 1px solid #aaa
        }

        .itemlist table tfoot tr:first-child td {
            border-top: none
        }

        .itemlist table tfoot tr:last-child td {
            color: #3989c6;
            font-size: 1.4em;
            border-top: 1px solid #3989c6
        }

        .itemlist table tfoot tr td:first-child {
            border: none
        }

    .itemlist footer {
        width: 100%;
        text-align: center;
        color: #777;
        border-top: 1px solid #aaa;
        padding: 8px 0
    }

@media print {
    .itemlist {
        font-size: 11px !important;
        overflow: hidden !important
    }

        .itemlist footer {
            position: absolute;
            bottom: 10px;
            page-break-after: always
        }

        .itemlist > div:last-child {
            page-break-before: always
        }
}

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
 
                            
                            
                            <td class="text-left">
                                <p class ="text-list-colour"><%=e.deadline %></p>
                                
                            </td>              

                            <td class="text-left">
                                
                                    <!-- pressing the RSVP button currently hard codes the selected event to be event 0000001 -->
                                    <a href="RSVPPage.aspx?selectedEvent=0000001"> RSVP List</a>
                            
         
                            </td>

                            <td class="text-left">
                                 <% UserBL user = (UserBL)Session["user"]; %>
                                    <input type="button" class="btn btn-success" value="EDIT" onclick="window.location.href = 'CreateEvent.aspx?eventToEdit=<%= e.eventId %>&user=<% =user.UserId %>'; return false"/>
                            </td>
                        
                            <!-- this button still hasn't been formatted for the database and will need to be changed -->
                            <td class="text-left">
                                <input type="button" class="btn btn-danger" value="REMOVE" onclick="window.location.href = 'Events.aspx?mode=toggleDelete&eventToDelete=<%= e.eventId %>&user=<% =user.UserId %>'; return false"/>
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
