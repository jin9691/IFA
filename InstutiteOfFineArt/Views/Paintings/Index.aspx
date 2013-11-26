<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="InstutiteOfFineArt.Views.Paintings.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Paintings management
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSite" runat="server">
    <div class="management-main container">
        <h1>Paintings management <strong><small>(<asp:Label Text="0" ID="lbCountUsers" runat="server" />)</small></strong>
            <a href="New.aspx" class="btn btn-danger btn-lg pull-right"><span class="glyphicon glyphicon-plus-sign"></span>Create new</a>
        </h1>
        <hr/>
        <div class="row">
            <form method="post" action="Search.aspx">
                <div class="col-md-4 pull-right">
                    <div class="input-group">
                        <input type="text" name="txtSearch" class="form-control" placeholder="Insert name or authors here..."/>
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
            <form id="Form1" runat="server" method="post">
                
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
