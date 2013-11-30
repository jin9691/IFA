<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="InstutiteOfFineArt.Views.Exhibitions.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Exhibition management
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSite" runat="server">
    <div class="management-main container">
        <h1>Exhibition managerment<strong><small>(<asp:Label Text="0" ID="lbCountExibition" runat="server" />)</small></strong>
            <a href="New.aspx" class="btn btn-danger btn-lg pull-right"><span class="glyphicon glyphicon-plus-sign"></span>Create new</a>
        </h1>
        <hr/>
        <div class="row">
            <form method="Post" action="Search.aspx">
                <div class="col-md-4 pull-right">
                    <div class="input-group">
                        <input type="text" name="txtSearch" class="form-control" placeholder="Insert Exhibition Name Here..."/>
                        <div class="input-group-btn">
                            <button type="submit" class="btn btn-default"><span class="glyphicon glyphicon-search"></span></button>
                        </div>
                        <!-- /btn-group -->
                    </div>
                </div>
            </form>
        </div>
        <br/>
        <div>
            <form id="frmExhibition" runat="server" method="post">
                <asp:GridView ID="gdvExhibition" runat="server" CssClass="table table-striped" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gdvExhibition_PageIndexChanging" PageSize="5">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <asp:TemplateField HeaderText="Manager">
                            <ItemTemplate>
                                <asp:Label ID="ManagerId" runat="server" Text='<%# Manager_Label(Eval("ManagerId"))%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ExhibitionName" HeaderText="ExhibitionName" />
                        <asp:BoundField DataField="StartDate" HeaderText="StartDate" DataFormatString="{0:MM/dd/yyyy}" />
                        <asp:BoundField DataField="EndDate" HeaderText="EndDate" DataFormatString="{0:MM/dd/yyyy}" />
                        <asp:BoundField DataField="ExhibitionDescription" HeaderText="ExhibitionDescription" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <div class="btn-group">
                                    <a href='Edit.aspx?ID=<%# Eval("Id")%>' class="btn btn-default"><span class="glyphicon glyphicon-pencil"></span></a>
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
            var result = confirm("Are you sure you want to delete this exhibition?");
            if (!result) {
                return false; //cancel postback
            }
            return true; //perform postback
        }
    </script>
</asp:Content>
