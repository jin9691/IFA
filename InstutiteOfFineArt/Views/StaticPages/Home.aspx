<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Home.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="InstutiteOfFineArt.Views.StaticPages.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Home Page - IFA
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyClass" runat="server">
    page
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CssJs" runat="server">
    <link rel="Stylesheet" type="text/css" href="../../Assets/Css/elastislide.css" />
    <script type="text/javascript" src="../../Assets/Js/modernizr.custom.17475.js"></script>
    <script type="text/javascript" src="../../Assets/Js/jquerypp.custom.js"></script>
    <script type="text/javascript" src="../../Assets/Js/jquery.elastislide.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentSite" runat="server">
     <div class="container">
            <div class="row show-image">
                <div class="col-md-5" style="margin-left:50px;">
                    <center>
                    <img class="image"  src="../../Assets/Images/Paintings/1.jpg" alt="image01" />
                    </center>
                </div>
                <div class="col-md-6"  style="margin-left:20px">
                    <div class="row">
                        <div class="col-md-1" style="margin-right:20px">
                            <img  src="../../Assets/Images/Pages/ifa-icon.png" class="home-logo" />
                        </div>
                        <div class="col-md-10">
                            <h1 style="color:#a11619">Institute of Fine Art</h1>
                            
                        </div>
                    </div>
                    <hr>
                    <p>
                        <h3>Welcome to the Institute of Fine Arts!</h3>
                        Thank you for visiting the website of Institute of Fine Arts. The Institute is dedicated to graduate teaching and advanced research in the history of art, archaeology, and the conservation and technology of works of art. The Institute plays a vital role in the public dissemination and discussion of art historical research through an active program of lectures and conferences. This website is designed to introduce our programs and to support the needs of our faculty and students. Although we hope that you will find the site engaging and informative. The Institute provides a deeper understanding of a major area of the discipline and develops a capacity for independent scholarship. Research is as important a part of the program as classroom instruction. In the course of its history since 1931, the Institute of Fine Arts has trained a high number of the world's most distinguished art history professors, curators, museum administrators, and conservators.
                    </p><br>
                </div>
            </div>
            <div class="demo-3">
                <div class="fixed-bar">
                    <!-- Elastislide Carousel -->
                    <ul id="carousel" class="elastislide-list">
                        <li>
                            <a><img src="../../Assets/Images/Paintings/1.jpg" alt="image01" /></a>
                        </li>
                        <li>
                            <a><img src="../../Assets/Images/Paintings/2.jpg" alt="image02" /></a>
                        </li>
                        <li>
                            <a><img src="../../Assets/Images/Paintings/3.jpg" alt="image03" /></a>
                        </li>
                        <li>
                            <a><img src="../../Assets/Images/Paintings/4.jpg" alt="image04" /></a>
                        </li>
                        <li>
                            <a><img src="../../Assets/Images/Paintings/5.jpg" alt="image05" /></a>
                        </li>
                        <li>
                            <a><img src="../../Assets/Images/Paintings/6.jpg" alt="image06" /></a>
                        </li>
                        <li>
                            <a><img src="../../Assets/Images/Paintings/7.jpg" alt="image07" /></a>
                        </li>
                        <li>
                            <a><img src="../../Assets/Images/Paintings/8.jpg" alt="image08" /></a>
                        </li>
                        <li>
                            <a><img src="../../Assets/Images/Paintings/9.jpg" alt="image09" /></a>
                        </li>
                        <li>
                            <a><img src="../../Assets/Images/Paintings/10.jpg" alt="image10" /></a>
                        </li>
                        <li>
                            <a><img src="../../Assets/Images/Paintings/11.jpg" alt="image11" /></a>
                        </li>
                        <li>
                            <a><img src="../../Assets/Images/Paintings/12.jpg" alt="image12" /></a>
                        </li>
                        <li>
                            <a><img src="../../Assets/Images/Paintings/13.jpg" alt="image13" /></a>
                        </li>
                        <li>
                            <a><img src="../../Assets/Images/Paintings/14.jpg" alt="image14" /></a>
                        </li>
                    </ul>
                    <!-- End Elastislide Carousel -->
                </div>
            </div>
        </div>
    <script>
        $( '#carousel' ).elastislide( {
            minItems : 2
        } );

        $('.elastislide-list > li > a > img').hover(function(){
            $(this).css({border: '0 solid #428bca'}).animate({ 
                borderWidth: '2px',
                padding: '5px'
            },200)
            var src = $(this).attr("src");
            $(".show-image").children().children().children(".image").attr("src",src)

        },function(){
            $(this).stop(true, true).animate({ borderWidth: "0px", padding: "0px" },200)
        });
        </script>
</asp:Content>
