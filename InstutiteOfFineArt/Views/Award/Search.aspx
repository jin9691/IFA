<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master"
    AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="InstutiteOfFineArt.Views.Award.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSite" runat="server">
    <div class="management-main container">
        <div class="row">
            <form method="Post" action="Search.aspx">
            <div class="col-md-8 pull-left">
                <div class="input-group">
                    <input type="text" name="txtSearch" class="form-control input-lg" placeholder="Insert award name here...">
                    <div class="input-group-btn">
                        <button type="submit" class="btn btn-default btn-lg">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </div>
                    <!-- /btn-group -->
                </div>
            </div>
            </form>
            <a href="Index.aspx" class="btn btn-danger btn-lg pull-right"><span class="glyphicon glyphicon-arrow-left">
            </span>Back</a>
        </div>
        <hr>
        <br>
        <div>
            <form id="Form1" runat="server" method="post">
            <asp:GridView ID="gdvAward" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                CellPadding="4" CssClass="table table-striped" ForeColor="#333333" GridLines="None"
                OnPageIndexChanging="gdvAward_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="AwardName" HeaderText="Award Name" />
                    <asp:BoundField DataField="AwardRank" HeaderText="Award Rank" />
                    <asp:BoundField DataField="AwardDescription" HeaderText="Award Description" />
                    <asp:BoundField DataField="PaintingId" HeaderText="Painting Id" />
                    <asp:BoundField DataField="CompetitionId" HeaderText="Competition Id" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <div class="btn-group">
                                <a href='Edit.aspx?ID=<%# Eval("Id")%>' class="btn btn-default"><span class="glyphicon glyphicon-pencil">
                                </span></a>
                                <asp:LinkButton ID="Destroy" runat="server" CommandArgument='<%# Eval("Id")%>' OnClientClick="return processConfirm();"
                                    OnClick="Destroy_Click" CssClass="btn btn-default">
                                    <span class="glyphicon glyphicon-trash"></span>
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#D9534F" Font-Bold="True" ForeColor="White" />
                <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                <PagerStyle BackColor="#FFCC66" CssClass="gridview" ForeColor="#333333" HorizontalAlign="Center" />
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
            var result = confirm("Are you sure you want to delete this award?");
            if (!result) {
                return false; //cancel postback
            }
            return true; //perform postback
        }
    </script>
</asp:Content>
