<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="EventReady.Application_Layer.Home" %>

<%@ Import Namespace="EventReady.Business_Layer"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://fonts.googleapis.com/css?family=Dancing+Script:400,700|Open+Sans:400,600,700,800" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Raleway:400,500,600,700,800,900" rel="stylesheet">
    <link rel="stylesheet" href="../Content/bootstrap.css">
    <link rel="stylesheet" href="../Style/StyleTemplate/font-awesome.min.css">
    <link rel="stylesheet" href="../Style/StyleTemplate/owl.carousel.min.css">
    <link rel="stylesheet" href="../Style/StyleTemplate/owl.theme.default.min.css">
    <link rel="stylesheet" href="../Style/StyleTemplate/magnific-popup.css">
    <link rel="stylesheet" href="../Style/StyleTemplate/style.css">
    <link rel="stylesheet" href="../Style/StyleSheetStyle.css">
    <link rel="stylesheet" href="../Style/StyleTemplate/responsive.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round" rel="stylesheet">
    <script src="../js/jquery-3.1.1.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/owl.carousel.min.js"></script>
    <script src="../js/isotope.pkgd.js"></script>
    <script src="../js/masonry.js"></script>
    <script src="../js/jquery.magnific-popup.min.js"></script>
    <script src="../js/active.js"></script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Generated datasource for testing -->
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [userInfo]"></asp:SqlDataSource>
    <!-- end of test datasource -->

    <!--background-image: url('../Image/header-bg.jpg');-->
    <div class="wrapper" style="background-size: 100% auto; position: relative; background-repeat: no-repeat; background-image: url('../Image/backgroundImage.jpg');">
        <header class="header">
            <% UserBL user = (UserBL)Session["user"]; %>
            <div class="container">
                
                <div class="row">
                    <div class="col-md-12">
                        <div class="header-carousal owl-carousel owl-theme">
                            <div class="item">
                                <h4>Here you can</h4>
                                <h2>Create an Event</h2>
                                <!-- Button will redirect to create event if user is logged in-->
                                <%if (Session["user"] != null)
                                    {%>
                                <input type="button" value="Create Event" onclick="window.location.href = 'CreateEvent.aspx?user=<%=user.UserId%>'; return false"/>
                                <%}// if a user is not logged it will redirect for the same button to the login page
                                    else if (Session["user"] == null) { %>
                                <input type="button" value="Create Event" onclick="window.location.href = 'LoginVer2.aspx'; return false"/>
                                <%} %>
                            </div>
                            <div class="item">
                                <h4>See the steps in creating an event</h4>
                                <h2>View Guide</h2>
                                <input type="button" value="View Guide" onclick="window.location.href = 'Guide.aspx'; return false"/>
                            </div>
                            <!-- If a user is logged in it will add a calendar option to select if no user is logged in this option wont be available -->
                            <%if (Session["user"] != null)
                                {%>
                            <div class="item">
                                <h4>Calender to display your events</h4>
                                <h2>View Calender</h2>
                                <!-- user.Email will need to be changed to user.userId -Saxon -->
                                <input type="button" value="View Calendar" onclick="window.location.href = 'Calendar.aspx?user=<%=user.UserId%>'; return false"/>
                            </div>
                            <%} %>
                        </div>
                    </div>
                </div>
            </div>
        </header>
        </div>

   

</asp:Content>
