<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Account Creation</h2>
    <p>
        Use the form below to create a new account. 
    </p>
    <p>
        Passwords are required to be a minimum of <%=Html.Encode(ViewData["PasswordLength"])%> characters in length.
    </p>
    <%=Html.ValidationSummary()%>
    <form method="post" action="<%= Html.AttributeEncode(Url.Action("Register")) %>">
        <div>
            <table cellpadding="2" cellspacing="0" class="vertical">
                <tr>
                    <th>Username:</th>
                    <td><%= Html.TextBox("username") %></td>
                </tr>
                <tr>
                    <th>Email:</th>
                    <td><%= Html.TextBox("email") %></td>
                </tr>
                <tr>
                    <th>Password:</th>
                    <td><%= Html.Password("password") %></td>
                </tr>
                <tr>
                    <th>Confirm password:</th>
                    <td><%= Html.Password("confirmPassword") %></td>
                </tr>
                <tr>
                    <th></th>
                    <td><input type="submit" value="Register" /></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
