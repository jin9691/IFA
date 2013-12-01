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
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"></h4>
                    </div>
                    <div class="modal-body">
                        <asp:HiddenField ID="hdEdit" runat="server" />
                        <asp:HiddenField ID="hdID" runat="server" />
                        <asp:TextBox ID="txtEdit" runat="server" TextMode="MultiLine" CssClass="form-control" Height="100px"></asp:TextBox>
                        <br />
                        <div id="edit-desc" style="display: none">
                            <b>Conditition:</b>
                            <asp:TextBox ID="txtEditCon" runat="server" TextMode="MultiLine" CssClass="form-control" Height="100px"></asp:TextBox>
                            <br />
                            <b>Start Date:</b>
                            <asp:TextBox runat="server" ID="txtEditStart" CssClass="form-control"></asp:TextBox>
                            <br />
                            <b>Due Date:</b>
                            <asp:TextBox runat="server" ID="txtEditDue" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="Save Changes" CssClass="btn btn-primary" />
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
                        <b>Start Date:</b>
                        <asp:TextBox runat="server" ID="txtStartDate" CssClass="control form-control"></asp:TextBox>
                        <b>Due Date:</b>
                        <asp:TextBox runat="server" ID="txtDueDate" CssClass="control form-control"></asp:TextBox>
                        <center>
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Accept" CssClass="btn btn-success btn-lg"  />
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
                                    <span><%# Eval("Condition") %></span><br />
                                    <span><b>Start Date:</b> <%# String.Format("{0: dd/MM/yyyy}",Eval("StartDate")) %></span>
                                    <span><b>Due Date:</b> <%# String.Format("{0: dd/MM/yyyy}",Eval("DueDate")) %></span>
                                </h4>
                                <a href="#" class="ca-more">more...</a>
                            </div>
                            <div class="ca-content-wrapper">
                                <div class="ca-content">
                                    <h6><%# Eval("Topic") %></h6>
                                    <a href="#" class="ca-close">close</a>
                                    <div class="ca-content-text">
                                        <p class="desc"><%# Eval("CompetitionDescription") %>.</p>
                                        <b>Remark:</b><br>
                                        <div class="remark">
                                            <%# Eval("Remark") %>
                                        </div>
                                    </div>
                                    <ul>
                                        <p id="desc" style="display: none"><%# Eval("CompetitionDescription") %></p>
                                        <p id="condition" style="display: none"><%# Eval("Condition") %></p>
                                        <p id="remark" style="display: none"><%# Eval("Remark") %></p>
                                        <p id="id-com" style="display: none"><%# Eval("Id") %></p>
                                        <p id="start" style="display: none"><%# String.Format("{0:dd/MM/yyyy}",Eval("StartDate")) %></p>
                                        <p id="due" style="display: none"><%# String.Format("{0:dd/MM/yyyy}",Eval("DueDate")) %></p>
                                        <li><a href="Show.aspx?ID=<%# Eval("Id") %>" class="btn btn-primary btn-sm">All images</a></li>
                                        <li><a href="#" class="edit-remark btn btn-success btn-sm" >Remark</a></li>
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
                <div class="col-md-5">
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
                </div>
                <div class="col-md-6">
                    <h1>Competition List <a href="#" class="btn btn-primary btn-lg" id="showRightPush" style="margin-left:60px">Add Competition</a></h1>
                </div>
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
            $('#myModal').modal({
                keyboard: false
            })

            $(".modal-title").html("Remark")
            $("#<%= txtEdit.ClientID %>").html($(this).parent().siblings("#remark").html())
            $("#<%= hdID.ClientID %>").val($(this).parent().siblings("#id-com").html())
            $("#edit-desc").css("display", "none");
            $("#<%= hdEdit.ClientID %>").val("remark")
            $("#<%= txtEditCon.ClientID %>").val($(this).parent().siblings("#condition").html())
            $("#<%= txtEditStart.ClientID %>").val($(this).parent().siblings("#start").html())
            $("#<%= txtEditDue.ClientID %>").val($(this).parent().siblings("#due").html())
        })
        $('.edit-desc').click(function () {
            $('#myModal').modal({
                keyboard: false
            })
            $(".modal-title").html("Edit Description")
            $("#<%= txtEdit.ClientID %>").html($(this).parent().siblings("#desc").html())
            $("#<%= hdID.ClientID %>").val($(this).parent().siblings("#id-com").html())
            $("#edit-desc").css("display", "inline");
            $("#<%= txtEditStart.ClientID %>").val($(this).parent().siblings("#start").html())
            $("#<%= txtEditDue.ClientID %>").val($(this).parent().siblings("#due").html())
            $("#<%= txtEditCon.ClientID %>").val($(this).parent().siblings("#condition").html())
            $("#<%= hdEdit.ClientID %>").val("desc")
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
                changeYear: true,
                dateFormat: "dd/mm/yy"
            });
            $("#<%= txtStartDate.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy"
            });
            $("#<%= txtEditDue.ClientID %>").datepicker({
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
