<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="InstutiteOfFineArt.Views.Sessions.New" %>

<%@ Import Namespace="InstutiteOfFineArt.Codes" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign In - IFA
    </title>
    <link rel="Stylesheet" type="text/css" href="../../Assets/Css/bootstrap.css" />
    <link rel="Stylesheet" type="text/css" href="../../Assets/Css/custom.css" />
    <link rel="Stylesheet" type="text/css" href="../../Assets/Css/docs.css" />
    <link rel="Stylesheet" type="text/css" href="../../Assets/Css/jquery-ui.css" />
    <script type="text/javascript" src="../../Assets/Js/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="../../Assets/Js/jquery-ui.js"></script>
    <script type="text/javascript" src="../../Assets/Js/bootstrap.js"></script>
    <script type="text/javascript" src="../../Assets/Js/bootstrap.min.js"></script>
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="account-wall">
                    <a href="../StaticPages/Home.aspx">
                        <img class="profile-img" src="../../Assets/Images/Pages/logo_2.png"
                            alt=""></a>
                    <br />
                    <% if (Flash.dictFlash != null) %>
                    <% foreach (var key in Flash.dictFlash.Keys)
                       { %>
                    <center>
                        <div class="alert alert-<%= key %>">
                            <%= Flash.dictFlash[key] %>
                        </div>
                    </center>
                    <% } %>
                    <% Flash.dictFlash.Clear(); %>
                    <form class="form-signin" runat="server" method="post">
                        <asp:TextBox ID="txtUsername" placeholder="Username" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtPassword" placeholder="Pasword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button OnClick="SignIn_Click" CssClass="btn btn-lg btn-danger btn-block" ID="SignIn" runat="server" Text="Sign In" />
                        <br />
                        <label class="checkbox pull-left">
                            <input type="checkbox" value="remember-me">
                            Remember me
                        </label>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
