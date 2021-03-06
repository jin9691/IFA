﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="InstutiteOfFineArt.Views.Users.New" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Create User
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSite" runat="server">
    <div class="management-main container">
        <h1>Users Management <strong><small>(Create New User)</small></strong>
            <a href="Index.aspx" class="btn btn-danger btn-lg pull-right"><span class="glyphicon glyphicon-arrow-left"></span>Back</a>
        </h1>
        <hr />
        <div style="padding: 50px">
            <form method="post" runat="server">
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th colspan="3"><span style="float:left">Create new user</span></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbFullname" Text="Full Name:" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-6">
                                <asp:TextBox runat="server" ID="txtFullname" CssClass="form-control" />
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                                <asp:Label ID="lbFullnameErr" Text="*" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbUsername" Text="Username:" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-6">
                                <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control" />
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                                <asp:Label ID="lbUsernameErr" Text="Must be between 5 and 16 characters" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbPassword" Text="Password:" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-6">
                                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" />
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                                <asp:Label ID="lbPasswordErr" Text="Must be between 6 and 10 characters" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbConfirm" Text="Confirm Password:" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-6">
                                <asp:TextBox runat="server" ID="txtConfirm" TextMode="Password" CssClass="form-control" />
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                                <asp:Label ID="lbConfirmErr" Text="" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbEmail" Text="Email Address:" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-6">
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                                <asp:Label ID="lbEmailErr" Text="*" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbGender" Text="Gender:" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td colspan="2" style="padding: 15px">
                                <asp:RadioButton ID="rdbMale" runat="server" Checked="true" GroupName="Gender" />
                                Male<span style="padding-right: 10px"></span>
                                <asp:RadioButton ID="rdbFemale" runat="server" GroupName="Gender" />
                                Female
                            </td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbBirthday" Text="Birthday:" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-6">
                                <asp:TextBox runat="server" ID="txtBirthday" CssClass="form-control" />
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                                <asp:Label ID="lbBirthdayErr" Text="*" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbAddress" Text="Address:" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-6">
                                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" />
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                                <asp:Label ID="lbAddressErr" Text="" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbPhone" Text="Phone:" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-6">
                                <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control" />
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                                <asp:Label ID="lbPhoneErr" Text="" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbPermission" Text="Permission:" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td colspan="2" style="padding: 15px" class="col-md-12">
                                <asp:RadioButton ID="rdbAdmin" runat="server" Checked="true" GroupName="Permisson" />
                                Admin<span style="padding-right: 10px"></span>
                                <asp:RadioButton ID="rdbStaff" runat="server" GroupName="Permisson" />
                                Staff<span style="padding-right: 10px"></span>
                                <asp:RadioButton ID="rdbManager" runat="server" GroupName="Permisson" />
                                Manager<span style="padding-right: 10px"></span>
                                <asp:RadioButton ID="rdbStudent" runat="server" GroupName="Permisson" />
                                Student
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
            $("#<%= txtBirthday.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true
            });
        });
    </script>
</asp:Content>
