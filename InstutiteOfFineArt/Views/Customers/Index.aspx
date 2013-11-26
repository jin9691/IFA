<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="InstutiteOfFineArt.Views.Customers.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Customer management
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSite" runat="server">
    <div class="management-main container">
        <h1>Customer management<strong><small>(<asp:Label Text="0" ID="lbCountCustomer" runat="server" />)</small></strong>
        </h1>
        <hr>
        <div class="row">
            <form method="Post" action="Search.aspx">
                <div class="col-md-4 pull-right">
                    <div class="input-group">
                        <input type="text" name="txtSearch" class="form-control" placeholder="Insert name or email here...">
                        <div class="input-group-btn">
                            <button type="submit" class="btn btn-default"><span class="glyphicon glyphicon-search"></span></button>
                        </div>
                        <!-- /btn-group -->
                    </div>
                </div>
            </form>
        </div>
        <br>
        <div>
            <form runat="server" method="post">
                <asp:GridView ID="gdvCustomers" runat="server" CssClass="table table-striped" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gdvCustomers_PageIndexChanging" PageSize="10">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <asp:BoundField DataField="CustomerName" HeaderText="Full Name" />
                        <asp:BoundField DataField="CustomerAddress" HeaderText="Address" />
                        <asp:BoundField DataField="CustomerEmail" HeaderText="Email" />
                        <asp:BoundField DataField="CustomerBirthday" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Birthday" />
                        <asp:TemplateField HeaderText="Gender">
                            <ItemTemplate>
                                <asp:Label ID="Gender" runat="server" Text='<%# Gender_Label(Eval("CustomerGender"))%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <div class="btn-group">
                                    <asp:LinkButton ID="Destroy" runat="server" CommandArgument='<%# Eval("Id")%>' OnClientClick="return processConfirm();" OnClick="Destroy_Click" CssClass="btn btn-default">
                                        <span class="glyphicon glyphicon-trash"></span>
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#d9534f" Font-Bold="True" ForeColor="White" />
                    <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                    <PagerStyle CssClass="gridview" BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" VerticalAlign="Middle" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        processConfirm = function () {
            var result = confirm("Are you sure you want to delete this customer?");
            if (!result) {
                return false; //cancel postback
            }
            return true; //perform postback
        }
    </script>
</asp:Content>
