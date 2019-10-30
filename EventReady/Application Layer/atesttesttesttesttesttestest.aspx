<%@ Page Title="" Language="C#" MasterPageFile="~/Application Layer/MasterPage.Master" AutoEventWireup="true" CodeBehind="atesttesttesttesttesttestest.aspx.cs" Inherits="EventReady.Application_Layer.Home" %>
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
    <link rel="stylesheet" href="../Style/StyleTemplate/responsive.css">
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

    <div class="wrapper" style="background-image: url('../Image/header-bg.jpg'); background-size: 100% auto; position: relative; background-repeat: no-repeat;">
        <header class="header">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="header-top">
                            <div class="row">
                                <div class="col-md-3 col-sm-12 col-xs-12">
                                    <div>
                                        <img src="../Image/er.jpg" alt="Image/er.jpg" style="width:80px;height:80px;" />

                                    </div>
                                    <% User user = (User)Session["user"]; %>
                                </div>
                                <div class="col-md-9 col-sm-12 col-xs-12">
                                    <div class="menu">
                                    

























                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                
                </div>
         
        </header>
        </div>

   

</asp:Content>
