<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>My Account</h2>
    <p>Your current username is <em><%=Html.Encode(!Page.User.Identity.Name.StartsWith("http") ? Page.User.Identity.Name : "")%></em>.</p>
    <p><%=Html.ActionLink("Change password", "ChangePassword", "Account", null, new{ @class = "special" })%></p>
</asp:Content>
