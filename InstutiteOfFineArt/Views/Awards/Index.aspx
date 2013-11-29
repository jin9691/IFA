<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master"
    AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="InstutiteOfFineArt.Views.Awards.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Award management
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSite" runat="server">
    <div class="management-main container">
        <h1>
            Awad managerment<strong><small>(<asp:Label Text="0" ID="lbCountAward" runat="server" />)</small></strong>
            <a href="/awards/new" class="btn btn-danger btn-lg pull-right"><span class="glyphicon glyphicon-plus-sign">
            </span>Create new</a>
        </h1>
        <hr>
        <div class="row">
            <form method="Post" action="/awards/search">
            <div class="col-md-4 pull-right">
                <div class="input-group">
                    <input type="text" name="txtSearch" class="form-control" placeholder="Insert award name here...">
                    <div class="input-group-btn">
                        <button type="submit" class="btn btn-default">
                            <span class="glyphicon glyphicon-search"></span>
                        </button>
                    </div>
                    <!-- /btn-group -->
                </div>
            </div>
            </form>
        </div>
        <br>
        <div>
            <form id="Form1" runat="server" method="post">
            <asp:GridView ID="gdvAward" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                CellPadding="4" CssClass="table table-striped" ForeColor="#333333" GridLines="None"
                OnPageIndexChanging="gdvAward_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="IDRow" runat="server" Text='<%# Container.DataItemIndex + 1 %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="AwardName" HeaderText="Award Name" />
                    <asp:BoundField DataField="AwardRank" HeaderText="Award Rank" />
                    <asp:BoundField DataField="AwardDescription" HeaderText="Award Description" />
                    <asp:TemplateField HeaderText="Painting">
                        <ItemTemplate>
                            <img id='img_<%# Eval("Id")%>' src='../../Assets/Images/Paintings/<%# Painting_Image(Eval("PaintingId"))%>'
                                                            style=" width: 50px;"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Competition">
                        <ItemTemplate>
                            <asp:Label ID="CompetitionTopic" runat="server" Text='<%# Competition_Topic(Eval("CompetitionId"))%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <div class="btn-group">
                                <a href='/award/<%# Eval("Id")%>/edit' class="btn btn-default"><span class="glyphicon glyphicon-pencil">
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
