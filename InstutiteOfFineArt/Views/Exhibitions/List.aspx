<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Home.Master"
    AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="InstutiteOfFineArt.Views.Exhibitions.List" %>

<%@ Import Namespace="InstutiteOfFineArt.Codes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyClass" runat="server">
    page
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CssJs" runat="server">
    <link rel="stylesheet" type="text/css" href="../../Assets/Css/competitions.css" />
    <link rel="stylesheet" type="text/css" href="../../Assets/Css/jquery.jscrollpane.css" media="all" />
    <script type="text/javascript" src="../../Assets/Js/jquery.easing.1.3.js"></script>
    <!-- the jScrollPane script -->
    <script type="text/javascript" src="../../Assets/Js/jquery.mousewheel.js"></script>
    <script type="text/javascript" src="../../Assets/Js/jquery.contentcarousel.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentSite" runat="server">
    <% if (Flash.dictFlash != null) %>
    <% foreach (var key in Flash.dictFlash.Keys)
       { %>
    <center>
        <div class="alert alert-<%= key %>">
            <%= Flash.dictFlash[key] %>
        </div>
    </center>
    <% } %>
    <% Flash.dictFlash.Clear(); %>
    <nav class="cbp-spmenu-upload cbp-spmenu-vertical-upload cbp-spmenu-right" id="cbp-spmenu-s1">
        <h3><i class="glyphicon glyphicon-picture" style="margin-right: 10px"></i><b>Add Exhibition</b></h3>
        <div class="menu-upload">
            <form id="frmAddExhibition" runat="server" method="Post">
                <div class="row">
                    <div class="col-md-12">
                        <b>Name:</b>
                        <asp:TextBox ID="txtTopic" CssClass="control form-control" runat="server"></asp:TextBox>
                        <b>Start Date:</b>
                        <asp:TextBox ID="txtStartDate" CssClass="control form-control" runat="server"></asp:TextBox>
                        <b>End Date:</b>
                        <asp:TextBox ID="txtEndDate" CssClass="control form-control" runat="server"></asp:TextBox>
                        <b>Description:</b>
                        <asp:TextBox ID="txtExhibitionDesc" Height="100px" TextMode="MultiLine" CssClass="control form-control" runat="server"></asp:TextBox>
                        <asp:Label ID="lblErr" Text="" runat="server" ForeColor="White"></asp:Label>
                        <center>
                            <asp:Button ID="btnAddExhibition" runat="server" Text="Accept" CssClass="btn btn-success btn-lg" OnClick="btnAddExhibition_Click">
                            </asp:Button>
                            <a href="#" class="btn btn-danger btn-lg" id="btnCancel">Cancel</a>
                        </center>
                    </div>
                </div>
            </form>
        </div>
    </nav>


    <asp:DataList ID="dtlShowExhibition" runat="server" CssClass="ca-container">
        <ItemTemplate>
            <div class="ca-wrapper">
                <div class="ca-item ca-item-1">
                    <div class="ca-item-main">
                        <div class="ca-icon">
                            <img src="../../Assets/Images/Paintings/1.jpg">
                        </div>
                        <h3>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("ExhibitionName") %>'></asp:Label></h3>
                        <h4>
                            <span>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ExhibitionName") %>'></asp:Label>
                            </span>
                        </h4>
                        <a href="#" class="ca-more">more...</a>
                    </div>
                    <div class="ca-content-wrapper">
                        <div class="ca-content">
                            <h6>Animals are not commodities</h6>
                            <a href="#" class="ca-close">close</a>
                            <div class="ca-content-text">
                                <p>I am so happy, my dear friend, so absorbed in the exquisite sense of mere tranquil existence, that I neglect my talents. I should be incapable of drawing a single stroke at the present moment; and yet I feel that I never was a greater artist than now.</p>
                                <p>When, while the lovely valley teems with vapour around me, and the meridian sun strikes the upper surface of the impenetrable foliage of my trees, and but a few stray gleams steal into the inner sanctuary, I throw myself down among the tall grass by the trickling stream;</p>
                                <p>She packed her seven versalia, put her initial into the belt and made herself on the way.</p>
                            </div>
                            <ul>
                                <li><a href="../Paintings/List.aspx" class="btn btn-primary btn-sm">All images</a></li>
                                <li><a href="#" class="delete-competition btn btn-danger btn-sm">Delete</a></li>
                                <li><a href="#" class="edit-desc btn btn-warning btn-sm">Edit</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>

    <div class="co-footer">
        <center>
        <h1>Exhibitions <a href="#" class="btn btn-primary btn-lg" id="showRightPush" style="margin-left:60px">Add Exhibition</a></h1>
    </center>
    </div>
    <script type="text/javascript">
        //$('#ca-container').contentcarousel();
        $('#dtlShowExhibition').contentcarousel();
        $("#btnCancel").click(function () {
            $("#showRightPush").trigger("click");
        })

        var menuRight = document.getElementById('cbp-spmenu-s1'),
        showRightPush = document.getElementById('showRightPush'),
        body_upload = document.body,
        menu_upload = document.getElementById('menu-upload');

        showRightPush.onclick = function () {
            classie.toggle(this, 'active');
            classie.toggle(body_upload, 'cbp-spmenu-push-toleft');
            classie.toggle(menuRight, 'cbp-spmenu-open');
            classie.toggle(menu_upload, 'cbp-spmenu-push-toleft');
        };

        $(document).ready(function () {
            $("#<%= txtStartDate.ClientID %>").datepicker();
            $("#<%= txtEndDate.ClientID %>").datepicker();
        });
    </script>
</asp:Content>
