<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="InstutiteOfFineArt.Views.Exhibitions.New" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
     Create Exhibition
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSite" runat="server">
    <div class="management-main container">
        <h1>Exhibition Management <strong><small>(Create New Exhibition)</small></strong>
            <a href="Index.aspx" class="btn btn-danger btn-lg pull-right"><span class="glyphicon glyphicon-arrow-left"></span>Back</a>
        </h1>
        <hr/>
        <div style="padding: 50px">
            <form id="Form1" method="post" runat="server">
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th colspan="3"><span style="float:left">Create new Exhibition</span></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbExhibitionName" Text="Exhibition Name :" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-6">
                                <asp:TextBox runat="server" ID="txtExhibitionName" CssClass="form-control" />
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                                <asp:Label ID="lbExhibitionNameErr" Text="*" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbManagerName" Text="Manager Name :" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:DropDownList ID="ddlManagerName" runat="server" CssClass="form-control"></asp:DropDownList>
                            </td>
                            <td class="col-md-2" style="padding: 15px">
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lblStartDate" Text="Start Date :" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-6">
                                <asp:TextBox runat="server" ID="txtStartDate" CssClass="form-control" />
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                                <asp:Label ID="lbStartDateErr" Text="*" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lblEndDate" Text="End Date :" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-6">
                                <asp:TextBox runat="server" ID="txtEndDate" CssClass="form-control" />
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                                <asp:Label ID="lblEndDateErr" Text="*" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lblExhibitionDescription" Text="Exhibition Description :" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-6">
                                <asp:TextBox runat="server" ID="txtExhibitionDescription" TextMode="MultiLine" Height="200px" CssClass="form-control" />
                                <%--<CKEditor:CKEditorControl ID="txtExhibitionDescription" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>--%>
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                                <asp:Label ID="lblExhibitionDescriptionErr" Text="*" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                        <tr>
                            <td class="col-md-2"></td>
                            <td colspan="2" style="padding-top: 20px; padding-bottom: 20px">
                                <asp:Button ID="btnAccept" Text="Accept" runat="server" CssClass="btn btn-danger" OnClick="btnAccept_Click"/><span style="padding-right: 5px"></span>
                                <asp:Button ID="btnReset" Text="Reset" runat="server" CssClass="btn btn-default " CausesValidation="False" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("#<%= txtStartDate.ClientID %>").datepicker();
            $("#<%= txtEndDate.ClientID %>").datepicker();
        });
    </script>
</asp:Content>
