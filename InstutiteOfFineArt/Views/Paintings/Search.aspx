﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="InstutiteOfFineArt.Views.Paintings.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSite" runat="server">
    <div class="management-main container">
        <div class="row">
            <form method="post" action="Search.aspx">
                <div class="col-md-8 pull-left">
                    <div class="input-group">
                        <input type="text" name="txtSearchPainting" class="form-control input-lg" placeholder="Insert painting 's authors here..."/>
                        <div class="input-group-btn">
                            <button type="submit" class="btn btn-default btn-lg"><span class="glyphicon glyphicon-search"></span></button>
                        </div>
                        <!-- /btn-group -->
                    </div>
                </div>
            </form>
            <a href="Index.aspx" class="btn btn-danger btn-lg pull-right"><span class="glyphicon glyphicon-arrow-left"></span>Back</a>
        </div>
        <hr/>
        <br/>
        <div>
            <form id="Form1" runat="server" method="post">
               <asp:GridView ID="gdvPaintings" runat="server" CssClass="table table-striped" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gdvPaintings_PageIndexChanging" PageSize="10">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <%--<asp:BoundField DataField="Name" HeaderText="Name" />--%>
                        <asp:TemplateField HeaderText="Student Name">
                            <ItemTemplate>
                                <asp:Label ID="UserName" runat="server" Text='<%# Student_Name(Eval("StudentID")).Username %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Competition Name">
                            <ItemTemplate>
                                <asp:Label ID="CompetitionName" runat="server" Text='<%# Competition_Name(Eval("CompetitionID")).Topic%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="UploadDate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Upload Date" />
                        <asp:BoundField DataField="LastModify" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Last modify" />
                        <asp:TemplateField HeaderText="Painting">
                            <ItemTemplate>
                                <asp:Image ID="image" Height="32px" Width="32px" ImageUrl='<%# Painting_show(Eval("PaintingURL"))%>' runat="server" /> 
                            </ItemTemplate>
                        </asp:TemplateField>
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
            var result = confirm("Are you sure you want to delete this user?");
            if (!result) {
                return false; //cancel postback
            }
            return true; //perform postback
        }
    </script>
</asp:Content>
