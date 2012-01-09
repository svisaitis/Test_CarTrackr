<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="changePasswordContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Change Password</h2>
    <p>
        Use the form below to change your password. 
    </p>
    <p>
        New passwords are required to be a minimum of <%=Html.Encode(ViewData["PasswordLength"])%> characters in length.
    </p>
    <%=Html.ValidationSummary()%>
    <form method="post" action="<%= Html.AttributeEncode(Url.Action("ChangePassword")) %>">
        <div>
            <table cellpadding="2" cellspacing="0" class="vertical">
                <tr>
                    <th>Current password:</th>
                    <td><%= Html.Password("currentPassword") %></td>
                </tr>
                <tr>
                    <th>New password:</th>
                    <td><%= Html.Password("newPassword") %></td>
                </tr>
                <tr>
                    <th>Confirm new password:</th>
                    <td><%= Html.Password("confirmPassword") %></td>
                </tr>
                <tr>
                    <th></th>
                    <td><input type="submit" value="Change Password" /></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
