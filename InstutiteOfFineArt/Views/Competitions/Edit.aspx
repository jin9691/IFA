<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="InstutiteOfFineArt.Views.Competitions.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Edit competition
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSite" runat="server">
       <div class="management-main container">
        <h1>Competition Management <strong><small>(Edit Competition)</small></strong>
            <a href="Index.aspx" class="btn btn-danger btn-lg pull-right"><span class="glyphicon glyphicon-arrow-left"></span>Back</a>
        </h1>
        <hr />
        <div style="padding: 50px">
            <form id="Form1" method="post" runat="server">
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th colspan="3"><span style="float:left">Edit competition</span></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbTopic" Text="Topic:" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-6">
                                <asp:TextBox runat="server" ID="txtTopic" CssClass="form-control" />
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                                <asp:Label ID="lbTopicErr" Text="*" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbStaff" Text="Staff:" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-6" style="padding: 15px">
                                <asp:DropDownList ID="cbStaff" CssClass="form-control" runat="server" />
                            </td>
                            <td class="col-md-4" style="padding: 15px"></td>
                            
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbStartDate" Text="Start Date" CssClass="pull-right" runat="server" Font-Bold="True" />
                            </td>
                            <td class="col-md-6">
                                <asp:TextBox runat="server" ID="txtStartDate"  CssClass="form-control" />
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                              <asp:Label ID="lbStartDateErr" Text="*" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbEndDate" Text="End Date" CssClass="pull-right" runat="server" Font-Bold="True" />
                            </td>
                            <td class="col-md-6">
                                <asp:TextBox runat="server" ID="txtEndDate"  CssClass="form-control" />
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                              <asp:Label ID="lbEndDateErr" Text="*" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                   
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbConditition" Text="Conditition:" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-6">
                                <asp:TextBox runat="server" ID="txtConditition" CssClass="form-control" />
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                                <asp:Label ID="lbCondititionErr" Text="*" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                   
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbRemark" Text="Remark:" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-6">
                                <asp:TextBox runat="server" ID="txtRemark" CssClass="form-control" />
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                                <asp:Label ID="lbRemarkErr" Text="*" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                         <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbDescription" Text="Description:" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-6">
                               <CKEditor:CKEditorControl ID="txtDescription" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                                <asp:Label ID="lbDescriptionErr" Text="*" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                        
                        <tr>
                            <td class="col-md-2"></td>
                            <td colspan="2" style="padding-top: 20px; padding-bottom: 20px">
                                <asp:Button ID="btnAccept" Text="Accept" runat="server" CssClass="btn btn-danger" OnClick="btnAccept_Click" /><span style="padding-right: 5px"></span>
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
