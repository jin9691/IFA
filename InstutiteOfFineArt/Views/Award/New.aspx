<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master"
    AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="InstutiteOfFineArt.Views.Award.New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Create Award
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSite" runat="server">
    <div class="management-main container">
        <h1>
            Award Management <strong><small>(Create New Award)</small></strong> <a href="/awards"
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
                            <asp:RadioButtonList ID="rbtListRank" runat="server">
                                <asp:ListItem value="Class 1" Selected="True">Class 1</asp:ListItem>
                                <asp:ListItem value="Class 2">Class 2</asp:ListItem>
                                <asp:ListItem value="Class 3">Class 3</asp:ListItem>
                            </asp:RadioButtonList>
                           
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
                            <asp:ListView ID="ListView1" runat="server">
                                <LayoutTemplate>
                                    <table border="0" cellpadding="1">
                                        <tr id="itemPlaceholder" runat="server">
                                        </tr>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr class="TableData">
                                        <img id='img_<%# Eval("Id")%>' src='../../<%# Eval("PaintingURL")%>' class='select-image' />
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
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
                                CssClass="btn btn-danger" onclick="btnAccept_Click"/><span style="padding-right: 5px"></span>
                            <asp:Button ID="btnReset" Text="Reset" runat="server" CssClass="btn btn-default "
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
            $(".select-image").click(function () {
                $('.select-image').each(function () {
                    $("#" + this.id).removeClass('selected');
                });
                var elm = (this.id).split("_");
                $("#" + this.id).addClass('selected');
                $('#ContentSite_txtPatingID').val(elm[1]);
            });
        });
    </script>
</asp:Content>
