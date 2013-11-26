<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master"
    AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="InstutiteOfFineArt.Views.Award.New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Create Award
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSite" runat="server">
    <div class="management-main container">
        <h1>
            Award Management <strong><small>(Create New Award)</small></strong> <a href="Index.aspx"
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
                            <asp:RadioButton ID="rdbClass1" runat="server" Checked="true" GroupName="Ranking" />
                            Class 1<span style="padding-right: 10px"></span>
                            <asp:RadioButton ID="rdbClass2" runat="server" GroupName="Ranking" />
                            Class 2<span style="padding-right: 10px"></span>
                            <asp:RadioButton ID="rdbClass3" runat="server" GroupName="Ranking" />
                            Class 3<span style="padding-right: 10px"></span>
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
                            <asp:Label ID="Label5" Text="*" runat="server" ForeColor="#A73333" />
                        </td>
                    </tr>
                    <tr>
                        <td class="col-md-2" style="padding: 15px">
                            <asp:Label ID="Label2" Text="Picture:" CssClass="pull-right" runat="server" Font-Bold="true" />
                        </td>
                        <td class="col-md-6">
                            <asp:ListView ID="ListView1" runat="server">
                                <LayoutTemplate>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr class="TableData">
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id")%>'>  
                                            </asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("PaintingURL")%>'>  
                                            </asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </td>
                        <td class="col-md-4" style="padding: 15px">
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
                        </td>
                    </tr>
                </tbody>
            </table>
            </form>
        </div>
    </div>
</asp:Content>
