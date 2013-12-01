<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Home.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="InstutiteOfFineArt.Views.Awards.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Award List
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CssJS" runat="server">
    <link rel="Stylesheet" type="text/css" href="../../Assets/Css/award.css" />
    <link rel="Stylesheet" type="text/css" href="../../Assets/Css/stapel.css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentSite" runat="server">
    <% if (InstutiteOfFineArt.Codes.Flash.dictFlash != null) %>
    <% foreach (var key in InstutiteOfFineArt.Codes.Flash.dictFlash.Keys)
       { %>
    <center>
                        <div class="alert alert-<%= key %> alert-small" style="margin-top:30px;margin-left:60px">
                            <%= InstutiteOfFineArt.Codes.Flash.dictFlash[key] %>
                        </div>
                    </center>
    <% } %>
    <% InstutiteOfFineArt.Codes.Flash.dictFlash.Clear(); %>
    <form runat="server" method="post">
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">Set Exhibition</h4>
                    </div>
                    <div class="modal-body">
                        <asp:HiddenField ID="hdIDPaint" runat="server" />
                        <asp:DropDownList ID="cbExhibition" CssClass="form-control" runat="server"></asp:DropDownList>
                        <br />
                        <b>Price:</b>
                        <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control" />
                        <br />
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnAccept" OnClick="btnAccept_Click" runat="server" Text="Accept" CssClass="btn btn-primary" />
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
        <div class="container">


            <section class="main">

                <div class="wrapper">


                    <div class="topbar" style="margin-left: 90px">
                        <span id="close" class="back">&larr;</span>
                        <h2>Award List</h2>
                        <h3 id="name"></h3>
                    </div>

                    <ul id="tp-grid" class="tp-grid">
                        <asp:ListView ID="lvCompetitions" runat="server">
                            <ItemTemplate>
                                <li data-pile="<%# Eval("Topic") %>">
                                    <a class="a" href="#">
                                        <span class="tp-info"><span><%# Eval("AwardRank") %>
                                        </span></span>
                                        <img src="../../Assets/Images/Paintings/<%# Eval("PaintingURL") %>" />
                                    </a>
                                    <asp:LinkButton OnClick="Destroy_Click" ID="Destroy" CommandName='<%# Eval("CompetitionID")%>' CommandArgument='<%# Eval("PaintingId") %>' OnClientClick="return processConfirm();" runat="server" CssClass="delete btn btn-danger">Delete</asp:LinkButton>
                                    <span id='<%# Eval("PaintingId") %>' class="exhibition delete btn btn-success">Set Exhibition</span>
                                    <script type="text/javascript">
                                        $(".exhibition").click(function () {
                                            $("#<%= hdIDPaint.ClientID %>").val($(this).attr("id"));
                                            $('#myModal').modal({
                                                keyboard: false
                                            });
                                        });
                                    </script>
                                </li>
                            </ItemTemplate>
                        </asp:ListView>

                    </ul>
                </div>
            </section>

        </div>
        <!-- /container -->
        <script type="text/javascript">

            processConfirm = function () {
                var result = confirm("Are you sure you want to remove this painting in exhibition?");
                if (!result) {
                    return false; //cancel postback
                }
                return true; //perform postback
            }
        </script>
        <script type="text/javascript" src="../../Assets/Js/modernizr.custom.63321.js"></script>
        <script type="text/javascript" src="../../Assets/Js/jquery.stapel.js"></script>
        <script type="text/javascript">
            $(function () {

                var $grid = $('#tp-grid'),
                    $name = $('#name'),
                    $close = $('#close'),
                    $loader = $('<div class="loader"><i></i><i></i><i></i><i></i><i></i><i></i><span>Loading...</span></div>').insertBefore($grid),
                    stapel = $grid.stapel({
                        delay: 50,
                        onLoad: function () {
                            $loader.remove();
                        },
                        onBeforeOpen: function (pileName) {
                            $name.html(pileName);
                        },
                        onAfterOpen: function (pileName) {
                            $close.show();
                        }
                    });

                $close.on('click', function () {
                    $close.hide();
                    $name.empty();
                    stapel.closePile();
                });

            });
        </script>
    </form>
</asp:Content>
