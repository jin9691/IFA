<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Home.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="InstutiteOfFineArt.Views.Competitions.List" %>

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
    <form id="Form1" runat="server">
        <div class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"></h4>
                    </div>
                    <div class="modal-body">
                        <asp:TextBox ID="txtEdit" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="lbErr" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-primary" />
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
        <nav class="cbp-spmenu-upload cbp-spmenu-vertical-upload cbp-spmenu-right" id="cbp-spmenu-s1">
            <h3><i class="glyphicon glyphicon-calendar" style="margin-right: 10px"></i><b>Add Competition</b></h3>
            <div class="menu-upload">
                <div class="row">
                    <div class="col-md-12">
                        <b>Topic:</b>
                        <asp:TextBox ID="txtTopic" CssClass="control form-control" runat="server"></asp:TextBox>
                        <b>Condition:</b>
                        <asp:TextBox ID="txtCondition" Height="50px" TextMode="MultiLine" CssClass="control form-control" runat="server"></asp:TextBox>
                        <b>Description:</b>
                        <asp:TextBox ID="txtDesc" Height="100px" TextMode="MultiLine" CssClass="control form-control" runat="server"></asp:TextBox>
                        <b>Due Date:</b>
                        <asp:TextBox runat="server" ID="txtDueDate" CssClass="control form-control"></asp:TextBox>
                        <br>
                        <center>
                        <asp:Button ID="btnUpload" runat="server" Text="Accept" CssClass="btn btn-success btn-lg"  />
                        <a href="#" class="btn btn-danger btn-lg" id="btnCancel" >Cancel</a>
                    </center>
                    </div>
                </div>
            </div>
        </nav>
        <div id="ca-container" class="ca-container">
            <div class="ca-wrapper">
                <asp:ListView ID="lvCompetitions" runat="server">
                    <ItemTemplate>
                        <div class="ca-item">
                            <div class="ca-item-main">
                                <div class="ca-icon">
                                    <img src="../../Assets/Images/Paintings/<%# ShowPainting(Eval("Id")) %>">
                                </div>
                                <h3><%# Eval("Topic") %></h3>
                                <h4>
                                    <span><%# Eval("Condition") %></span>
                                </h4>
                                <a href="#" class="ca-more">more...</a>
                            </div>
                            <div class="ca-content-wrapper">
                                <div class="ca-content">
                                    <h6><%# Eval("Topic") %></h6>
                                    <a href="#" class="ca-close">close</a>
                                    <div class="ca-content-text">
                                        <p><%# Eval("CompetitionDescription") %>.</p>
                                        <b>Remark:</b><br>
                                        <div class="remark">
                                            <%# Eval("Remark") %>
                                        </div>
                                    </div>
                                    <ul>
                                        <li><a href="Show.aspx?ID=<%# Eval("Id") %>" class="btn btn-primary btn-sm">All images</a></li>
                                        <li><a href="#" class="edit-remark btn btn-success btn-sm" data-toggle="modal" data-target="#myModal">Remark</a></li>
                                        <li>
                                            <asp:LinkButton ID="Destroy" runat="server" CommandArgument='<%# Eval("Id")%>' OnClientClick="return processConfirm();" OnClick="Destroy_Click" CssClass="delete-competition btn btn-danger btn-sm">
                                            Delete
                                            </asp:LinkButton>
                                        </li>
                                        <li><a href="#" class="edit-desc btn btn-warning btn-sm">Edit</a></li>
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
        <h1>Competitions <a href="#" class="btn btn-primary btn-lg" id="showRightPush" style="margin-left:60px">Add Competition</a></h1>
    </center>
        </div>
    </form>
    <script type="text/javascript">
        processConfirm = function () {
            var result = confirm("Are you sure you want to delete this competition?");
            if (!result) {
                return false; //cancel postback
            }
            return true; //perform postback
        }
    </script>
    <script type="text/javascript">
        $('.edit-remark').click(function () {
            alert("abc");
            $('#myModal').modal({
                keyboard: false
            })
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
            $("#<%= txtDueDate.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true
            });
        });

    </script>
</asp:Content>
