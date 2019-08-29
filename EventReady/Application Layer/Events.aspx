<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="EventReady.Application_Layer.Events" %>
<%@ Import Namespace="EventReady.Business_Layer"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    <link href="../Content/stylesheet.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/bootstrap.bundle.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="viewItemlist">
        <div class="overflow-auto">
            <div style="min-width: 600px">
                 <table border="0">
                    <thead>
                        <tr>
                            <!-- The names of all the headings in the table -->
                            <th>ID #</th>
                            <th class="text-left">NAME</th>
                            <th class="text-right">DESCRIPTION</th>
                            <th class="text-right">DurationModifier</th>
                            <th class="text-right">EDIT</th>
                            <th class="text-right">DELETE</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%int countID = 0; %>
                        <%foreach (Event e in GlobalData.Events)
                            {
                                countID++;  %>
                        <!-- Adds the event name to the page -->
                    <tr>
                            <td class="no"><%= countID %></td>
                            <td class="text-left">
                                <p><%=e.Name %></p>
                                
                            </td>
                            
                                
                           <!-- Adds event description -->
                            <td class="text-left">
                                <p><%=e.Description %></p>
                                
                            </td>
 
                            
                            <!-- Adds event duration modifier -->
                            <td class="text-left">
                                <p><%=e.DurationModifier %></p>
                                
                            </td>

                            <td class="text-left">
                                 <td class="text-left">
                                    <input type="button" class="btn btn-success" value="EDIT"/>
                                </td>
         
                            </td>
                        
                            <td class="text-left">
                                <input type="button" class="btn btn-danger" value="DELETE" onclick="window.location.href = 'Events.aspx?mode=toggleDelete&event=<%=GlobalData.Events.IndexOf(e)%>'; return false"/>
 
                            </td>
                        </tr>
                        <% } %>
                        </tbody>
                     </table>
            </div>
        </div>
    </div>








   
</asp:Content>
