<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Login</h2>
    
    <%=Html.ValidationSummary()%>
    
    <h3>Login via credentials</h3>
    <p>
        Please enter your username and password below. If you don't have an account,
        please <%= Html.ActionLink("register", "Register") %>.
    </p>
    <form method="post" action="<%= Html.AttributeEncode(Url.Action("Login")) %>">
        <div>
            <table cellpadding="2" cellspacing="0" class="vertical">
                <tr>
                    <th>Username:</th>
                    <td><%= Html.TextBox("username") %></td>
                </tr>
                <tr>
                    <th>Password:</th>
                    <td><%= Html.Password("password") %></td>
                </tr>
                <tr>
                    <th></th>
                    <td><input type="checkbox" name="rememberMe" value="true" /> Remember me?</td>
                </tr>
                <tr>
                    <th></th>
                    <td><input type="submit" value="Login" /></td>
                </tr>
            </table>
        </div>
    </form>
    
    <h3>Login via OpenID</h3>
    <p>
        Please enter your OpenID URL below.
    </p>
    <form method="post" action="<%= Html.AttributeEncode(Url.Action("OpenIdLogin")) %>">
        <div>
            <table cellpadding="2" cellspacing="0" class="vertical">
                <tr>
                    <th>OpenID url:</th>
                    <td><%= Html.TextBox("openid_identifier")%></td>
                </tr>
                <tr>
                    <th></th>
                    <td><input type="submit" value="Login" /></td>
                </tr>
            </table>
        </div>
    </form>

    <!-- BEGIN ID SELECTOR -->
    <script type="text/javascript" id="__openidselector" src="https://www.idselector.com/selector/c403cd6b5a0abd62f505335e33d01ce1d6df0bd4" charset="utf-8"></script>
    <!-- END ID SELECTOR -->
</asp:Content>
