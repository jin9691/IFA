<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="InstutiteOfFineArt.Views.Paintings.New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Paintings Management (Create New Paintings)
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSite" runat="server">
    <div class="management-main container">
        <h1>Paintings Management <strong><small>(Create New Paintings)</small></strong>
            <a href="Index.aspx" class="btn btn-danger btn-lg pull-right"><span class="glyphicon glyphicon-arrow-left"></span>Back</a>
        </h1>
        <hr />
        <div style="padding: 50px">
            <form method="post" runat="server">
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th colspan="3"><span style="float: left">Create new paintings</span></th>
                        </tr>
                    </thead>
                    <tbody>
                        
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbImage" Text="Images:" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-6" style="padding: 15px; margin-left: 40px;">
                                <asp:FileUpload ID="flImage" runat="server" CssClass="form-control" />
                            </td>
                            <td  style="padding: 15px;">
                                
                                <asp:Image ID="previewImage" runat="server" CssClass="form-control" Width="200px" Height="200px" />
                                <asp:Label ID="lbImageErr" Text="" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                        <script type="text/javascript">
                            function readURL(input) {
                               
                                    
                                if (input.files && input.files[0]) {
                                    //alert(input.files[0].type);
                                    
                                    var reader = new FileReader();
                                    
                                    reader.onload = function (e) {
                                        if (!input.files[0].type.match('image.*')) {
                                            alert('no image');
                                            $('#<%= previewImage.ClientID %>').attr('src', '');
                                        } else
                                        $('#<%= previewImage.ClientID %>').attr('src', e.target.result);
                                    }

                                    reader.readAsDataURL(input.files[0]);
                                }
                            }

                            $('#<%=flImage.ClientID %>').change(function () {
                                
                                readURL(this);
                            });
                           
                        </script>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbMark" Text="Mark:" CssClass="pull-right" runat="server" Font-Bold="True" />
                            </td>
                            <td class="col-md-6">
                                <asp:TextBox runat="server" ID="txtMark" CssClass="form-control" />
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                                <asp:Label ID="lbMarkErr" Text="" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbCompetition" Text="Competition:" CssClass="pull-right" runat="server" Font-Bold="True" />
                            </td>
                            <td class="col-md-6" style="padding: 15px">
                                <asp:DropDownList ID="cbCompetition" CssClass="form-control" runat="server" />
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbStudent" Text="Student:" CssClass="pull-right" runat="server" Font-Bold="True" />
                            </td>
                            <td class="col-md-6" style="padding: 15px">
                                <asp:DropDownList ID="cbStudent" CssClass="form-control" runat="server" />
                            </td>
                            <td class="col-md-4" style="padding: 15px"></td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbExhibition" Text="Exhibition:" CssClass="pull-right" runat="server" Font-Bold="True" />
                            </td>
                            <td class="col-md-4" style="padding: 15px">

                                <asp:DropDownList ID="cbExhibition" CssClass="form-control" runat="server" />
                            </td>
                            <td class="col-md-4" style="padding: 15px"></td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbCustomers" Text="Customers:" CssClass="pull-right" runat="server" Font-Bold="True" />
                            </td>
                            <td class="col-md-6" style="padding: 15px">
                                <asp:DropDownList ID="cbCustomer" CssClass="form-control" runat="server" />
                            </td>
                            <td class="col-md-4" style="padding: 15px"></td>
                        </tr>

                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbIsEhibition" Text="Is Exhibition:" CssClass="pull-right" runat="server" Font-Bold="True" />
                            </td>
                            <td colspan="2" style="padding: 15px" class="col-md-12">
                                <asp:RadioButton ID="rdExhibitions" runat="server" Checked="true" GroupName="isExhibition" />
                                Exhibitioned<span style="padding-right: 10px"></span>
                                <asp:RadioButton ID="rdbNotExhibition" runat="server" GroupName="isExhibition" />
                                Not Exhibition <span style="padding-right: 10px"></span>

                            </td>

                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbIsPaid" Text="Is Paid:" CssClass="pull-right" runat="server" Font-Bold="True" />
                            </td>
                            <td colspan="2" style="padding: 15px" class="col-md-12">
                                <asp:RadioButton ID="rbdPaid" runat="server" Checked="true" GroupName="isPaid" />
                                Paid<span style="padding-right: 10px"></span>
                                <asp:RadioButton ID="rbdNotPaid" runat="server" GroupName="isPaid" />
                                Not Paid <span style="padding-right: 10px"></span>

                            </td>

                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="lbPrice" Text="Price:" CssClass="pull-right" runat="server" Font-Bold="True" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtPrice" CssClass="form-control" runat="server" />
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                                <asp:Label ID="lbPriceErr" Text="" runat="server" ForeColor="#A73333" />
                            </td>

                        </tr>

                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbPaintingDescription" Text="Description:" CssClass="pull-right" runat="server" Font-Bold="true" />
                            </td>
                            <td class="col-md-6">
                                <%--<asp:TextBox runat="server" ID="txtDescription" CssClass="form-control" TextMode="MultiLine" />--%>
                                <CKEditor:CKEditorControl ID="txtDescription" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                            </td>
                            <td class="col-md-4" style="padding: 15px">
                                <asp:Label ID="lbDescriptionErr" Text="*" runat="server" ForeColor="#A73333" />
                            </td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px">
                                <asp:Label ID="lbComment" Text="Comment:" CssClass="pull-right" runat="server" Font-Bold="True" />
                            </td>
                            <td class="col-md-6">
                                <%--<asp:TextBox runat="server" ID="txtComment" CssClass="form-control" />--%>
                                <CKEditor:CKEditorControl ID="txtComent" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                            </td>
                            <td class="col-md-4" style="padding: 15px"></td>
                        </tr>
                        <tr>
                            <td class="col-md-2" style="padding: 15px; top: -334px;"></td>
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
</asp:Content>

