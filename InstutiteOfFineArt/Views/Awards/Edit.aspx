<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master"
    AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="InstutiteOfFineArt.Views.Awards.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Create Award
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSite" runat="server">
    <div class="management-main container">
        <h1>
            Award Management <strong><small>(Edit Award)</small></strong> <a href="/awards"
                class="btn btn-danger btn-lg pull-right"><span class="glyphicon glyphicon-arrow-left">
                </span>Back</a>
        </h1>
        <hr />
        <div style="padding: 50px">
            <form id="Form1" method="post" runat="server">
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th colspan="3">
                            <span style="float: left">Create new award</span>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="col-md-2" style="padding: 15px">
                            <asp:Label ID="lbAwardName" Text="Award Name:" CssClass="pull-right" runat="server"
                                Font-Bold="true" />
                        </td>
                        <td class="col-md-6">
                            <asp:TextBox runat="server" ID="txtAwardName" CssClass="form-control" />
                        </td>
                        <td class="col-md-4" style="padding: 15px">
                            <asp:Label ID="lbAwardNameErr" Text="*" runat="server" ForeColor="#A73333" />
                        </td>
                    </tr>
                    <tr>
                        <td class="col-md-2" style="padding: 15px">
                            <asp:Label ID="Label1" Text="Award Rank:" CssClass="pull-right" runat="server" Font-Bold="true" />
                        </td>
                       <td colspan="2" style="padding: 15px" class="col-md-12">
                            <asp:RadioButton ID="rdb1st" runat="server" Checked="true" GroupName="Rank" />
                            1st<span style="padding-right: 10px"></span>
                            <asp:RadioButton ID="rdb2nd" runat="server" GroupName="Rank" />
                            2nd<span style="padding-right: 10px"></span>
                            <asp:RadioButton ID="rdb3rd" runat="server" GroupName="Rank" />
                            3rd
                        </td>
                    </tr>
                    <tr>
                        <td class="col-md-2" style="padding: 15px">
                            <asp:Label ID="Label4" Text="Competition:" CssClass="pull-right" runat="server" Font-Bold="true" />
                        </td>
                        <td class="col-md-6">
                            <asp:DropDownList ID="drlCompetitionId" runat="server" CssClass="form-control" OnSelectedIndexChanged="drlCompetitionId_SelectedIndexChanged"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td class="col-md-4" style="padding: 15px">
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="col-md-2" style="padding: 15px">
                            <asp:Label ID="Label2" Text="Picture:" CssClass="pull-right" runat="server" Font-Bold="true" />
                        </td>
                        <td class="col-md-6">
                            <button class="btn btn-primary" data-toggle="modal" data-target="#myModal">
                                Choice
                            </button>
                            <asp:Image ID="previewImage" runat="server" CssClass="awr-preview-mage"  />
                            <asp:Label ID="lbPatingIDErr" Text="" runat="server" ForeColor="#A73333" />
                            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                                aria-hidden="true">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                &times;</button>
                                            <h4 class="modal-title" id="myModalLabel">
                                                Painting list</h4>
                                        </div>
                                        <div class="modal-body">
                                            <asp:Label ID="lbChoiceImgErr" Text="" runat="server" ForeColor="#A73333" />
                                            <asp:ListView ID="ListView1" runat="server">
                                                <LayoutTemplate>
                                                    <table border="0" cellpadding="1">
                                                        <tr id="itemPlaceholder" runat="server">
                                                        </tr>
                                                    </table>
                                                </LayoutTemplate>
                                                <ItemTemplate>
                                                    <tr class="TableData">
                                                        <img id='img_<%# Eval("Id")%>' src='../../Assets/Images/Paintings/<%# Eval("PaintingURL")%>'
                                                            class='select-image' />
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:ListView>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                                Close</button>
                                            <button type="button" class="btn btn-primary" id="btn-save-change-image">
                                                Save changes</button>
                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                            </div>
                            <!-- /.modal -->
                            <script type="text/javascript">
                                $('#myModal').modal(options);
                            </script>
                        </td>
                        <td class="col-md-4" style="padding: 15px">
                            <asp:HiddenField ID="txtPatingID" runat="server" />                            
                        </td>
                    </tr>
                    <tr>
                        <td class="col-md-2" style="padding: 15px">
                            <asp:Label ID="Label3" Text="Award Description:" CssClass="pull-right" runat="server"
                                Font-Bold="true" />
                        </td>
                        <td class="col-md-6">
                            <asp:TextBox runat="server" ID="txtAwardDess" CssClass="form-control" TextMode="MultiLine" />
                        </td>
                    </tr>
                    <tr>
                        <td class="col-md-2">
                        </td>
                        <td colspan="2" style="padding-top: 20px; padding-bottom: 20px">
                            <asp:Button ID="btnAccept" Text="Accept" runat="server" 
                                CssClass="btn btn-primary btn-lg" onclick="btnAccept_Click"/><span style="padding-right: 5px"></span>
                            <asp:Button ID="btnReset" Text="Reset" runat="server" CssClass="btn btn-default btn-lg"
                                CausesValidation="False" />
                        </td>
                    </tr>
                </tbody>
            </table>
            </form>
        </div>
    </div>
        <script type="text/javascript">
            $(document).ready(function () {
                var PatingID = $('#<%=txtPatingID.ClientID %>').val();
                if (PatingID.length > 0) {
                    console.log(PatingID);
                    $("#img_" + PatingID).addClass('selected');
                    var img_src = $("#img_" + PatingID).attr('src');
                    $('#<%=previewImage.ClientID %>').attr('src', img_src);
                }
                $(".select-image").click(function () {
                    $('.select-image').each(function () {
                        $("#" + this.id).removeClass('selected');
                    });
                    var elm = (this.id).split("_");
                    $("#" + this.id).addClass('selected');
                    $('#<%=txtPatingID.ClientID %>').val(elm[1]);
                    var img_src = $("#" + this.id).attr('src');
                    $('#<%=previewImage.ClientID %>').attr('src', img_src);
                });
                $("#btn-save-change-image").click(function () {
                    if ($('#<%=txtPatingID.ClientID %>').val() == "") {
                        $('#<%=lbChoiceImgErr.ClientID %>').text("You must choice image !!!");
                    } else {
                        $('#<%=lbChoiceImgErr.ClientID %>').text("");
                        $('#myModal').modal('hide');
                    }
                });
            });
    </script>
</asp:Content>
