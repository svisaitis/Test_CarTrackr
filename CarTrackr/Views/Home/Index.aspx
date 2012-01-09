<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <img id="pagePreview" runat="server" align="right" src="~/Content/Images/CarTrackrPagePreview.jpg" />
    
    <h2>Welcome to CarTrackr!</h2>
    
    <p>
        CarTrackr is an online software application designed to help you understand and track your fuel usage and kilometers driven.
        You will have a record on when you filled up on fuel, how many kilometers you got in a given tank, how much you spent and how much liters of fuel you are using per 100 kilometer.
    </p>
    <p>
        CarTrackr will enable you to improve your fuel economy and save money as well as conserve fuel. Fuel economy and conservation is becoming an important way to control your finances with the current high price.
    </p>
 
    <% if (!Request.IsAuthenticated) { %>
    <p>
        <%=Html.ActionLink("Sign in now!", "Login", "Account", null, new{ @class = "special" })%>
        <%=Html.ActionLink("No account yet?", "Register", "Account")%>
    </p>
    <% } else { %>
        <%=Html.ActionLink("List my cars", "List", "Car", null, new{ @class = "special" })%>
    <% } %>
</asp:Content>
