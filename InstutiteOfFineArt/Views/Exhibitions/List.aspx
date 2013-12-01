<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Home.Master"
    AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="InstutiteOfFineArt.Views.Exhibitions.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<%@ Import Namespace="InstutiteOfFineArt.Models" %>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyClass" runat="server">
    page
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CssJs" runat="server">
    <link rel="stylesheet" type="text/css" href="../../Assets/Css/competitions.css" />
    <link rel="stylesheet" type="text/css" href="../../Assets/Css/jquery.jscrollpane.css"
        media="all" />
    <script type="text/javascript" src="../../Assets/Js/jquery.easing.1.3.js"></script>
    <!-- the jScrollPane script -->
    <script type="text/javascript" src="../../Assets/Js/jquery.mousewheel.js"></script>
    <script type="text/javascript" src="../../Assets/Js/jquery.contentcarousel.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSite" runat="server">
    <form id="Form1" runat="server">
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title">
                    </h4>
                </div>
                <div class="modal-body">
                    <asp:HiddenField ID="hdID" runat="server" />
                    <asp:HiddenField ID="hdManager" runat="server" />
                    <asp:TextBox ID="txtEdit" runat="server" TextMode="MultiLine" CssClass="form-control"
                        Height="200px"></asp:TextBox>
                    <br />
                    <div id="edit-desc">
                        <b>Start Date:</b>
                        <asp:TextBox runat="server" ID="txtEditStart" CssClass="form-control"></asp:TextBox>
                        <br />
                        <b>End Date:</b>
                        <asp:TextBox runat="server" ID="txtEditEnd" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        Close</button>
                    <asp:Button ID="btnSave" runat="server" Text="Save Changes" OnClick="btnSave_Click"
                        CssClass="btn btn-primary" />
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
    <nav class="cbp-spmenu-upload cbp-spmenu-vertical-upload cbp-spmenu-right" id="cbp-spmenu-s1">
            <h3><i class="glyphicon glyphicon-calendar" style="margin-right: 10px"></i><b>Add Exhibition</b></h3>
            <div class="menu-upload">
                <div class="row">
                    <div class="col-md-12">
                        <b>Name:</b>
                        <asp:TextBox ID="txtExName" CssClass="control form-control" runat="server"></asp:TextBox>
                        <b>Description:</b>
                        <asp:TextBox ID="txtDesc" Height="100px" TextMode="MultiLine" CssClass="control form-control" runat="server"></asp:TextBox>
                        <b>Start Date:</b>
                        <asp:TextBox runat="server" ID="txtStartDate" CssClass="control form-control"></asp:TextBox>
                        <b>End Date:</b>
                        <asp:TextBox runat="server" ID="txtEndDate" CssClass="control form-control"></asp:TextBox>
                        <center>
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Accept" CssClass="btn btn-success btn-lg"  />
                        <a href="#" class="btn btn-danger btn-lg" id="btnCancel" >Cancel</a>
                    </div>
                </div>
            </div>
        </nav>
    <div id="ca-container" class="ca-container">
        <div class="ca-wrapper">
            <asp:ListView ID="lvCompetitions" runat="server">
                <ItemTemplate>
                    <div class="ca-item ca-item-1">
                        <div class="ca-item-main">
                            <div class="ca-icon">
                                <img src="../../Assets/Images/Paintings/<%# ShowPainting(Eval("Id")) %>">
                            </div>
                            <h3>
                                <%# Eval("ExhibitionName") %></h3>
                            <h4>
                                <span>
                                    <%# Truncate(Eval("ExhibitionDescription").ToString()) %></span><br>
                                <span><b>Start Date:</b>
                                    <%# String.Format("{0: dd/MM/yyyy}",Eval("StartDate")) %></span> <span><b>End Date:</b>
                                        <%# String.Format("{0: dd/MM/yyyy}",Eval("EndDate")) %></span>
                            </h4>
                            <a href="#" class="ca-more">more...</a>
                        </div>
                        <div class="ca-content-wrapper">
                            <div class="ca-content">
                                <h6>
                                    <%# Eval("ExhibitionName") %></h6>
                                <a href="#" class="ca-close">close</a>
                                <div class="ca-content-text">
                                    <p class="desc">
                                        <%# Eval("ExhibitionDescription") %></p>
                                </div>
                                <ul>
                                    <p id="desc" style="display: none">
                                        <%# Eval("ExhibitionDescription") %></p>
                                    <p id="id-com" style="display: none">
                                        <%# Eval("Id") %></p>
                                    <p id="start" style="display: none">
                                        <%# String.Format("{0:dd/MM/yyyy}",Eval("StartDate")) %></p>
                                    <p id="end" style="display: none">
                                        <%# String.Format("{0:dd/MM/yyyy}",Eval("EndDate")) %></p>
                                    <p id="manager" style="display: none">
                                        <%# Eval("ManagerId") %></p>
                                    <%# Btn_Role(Eval("Id"))%>
                                    <% User u = (User)Session["current_user"];
                                       if (Session["current_user"] != null)
                                       { 
                                    %>
                                    <% if (u.Permission == 2)
                                       {  %>
                                    <li>
                                        <asp:LinkButton ID="Destroy" runat="server" CommandArgument='<%# Eval("Id")%>' OnClientClick="return processConfirm();"
                                            OnClick="Destroy_Click" CssClass="delete-exhibition btn btn-danger btn-sm">
                                            Delete
                                        </asp:LinkButton>
                                    </li>
                                    <% } %>
                                    <% } %>
                                    
                                </ul>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
    <div class="co-footer">
        <center>
            <div class="col-md-5">
                <% if (InstutiteOfFineArt.Codes.Flash.dictFlash != null) %>
                <% foreach (var key in InstutiteOfFineArt.Codes.Flash.dictFlash.Keys)
                   { %>
                <center>
                    <div class="alert alert-<%= key %> alert-small" style="margin-top: 30px; margin-left: 60px">
                        <%= InstutiteOfFineArt.Codes.Flash.dictFlash[key] %>
                    </div>
                </center>
                <% } %>
                <% InstutiteOfFineArt.Codes.Flash.dictFlash.Clear(); %>
            </div>

            <% User u = (User)Session["current_user"];
               if (Session["current_user"] != null)
               { 
            %>
            <% if (u.Permission == 2)
               {  %>
            <div class="col-md-6">
                <h1>
                    Exhibition List <a href="#" class="btn btn-primary " id="showRightPush" style="margin-left: 60px">
                        Add Exhibition</a></h1>
            </div>
            <% } %>
            <% } %>
            
        </center>
    </div>
    </form>
    <script type="text/javascript">
        processConfirm = function () {
            var result = confirm("Are you sure you want to delete this exhibition?");
            if (!result) {
                return false; //cancel postback
            }
            return true; //perform postback
        }
    </script>
    <script type="text/javascript">

        $('.edit-desc').click(function () {
            $('#myModal').modal({
                keyboard: false
            })
            $(".modal-title").html("Edit Description")
            $("#<%= txtEdit.ClientID %>").html($(this).parent().siblings("#desc").html())
            $("#<%= hdID.ClientID %>").val($(this).parent().siblings("#id-com").html())
            $("#<%= txtEditStart.ClientID %>").val($(this).parent().siblings("#start").html())
            $("#<%= txtEditEnd.ClientID %>").val($(this).parent().siblings("#end").html())
            $("#<%= hdManager.ClientID %>").val($(this).parent().siblings("#manager").html())
        })
        $('#ca-container').contentcarousel();
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

        $(function () {
            $("#<%= txtEndDate.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy"
            });
            $("#<%= txtStartDate.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy"
            });
            $("#<%= txtEditEnd.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy"
            });
            $("#<%= txtEditStart.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy"
            });
        });

    </script>
</asp:Content>
