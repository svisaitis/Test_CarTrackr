<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage<CarListViewData>" %>

<asp:Content ID="listContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>List of cars</h2>
    <ul class="listing">
    <% foreach (var car in Model.Cars) { %>
        <li>
            <h3><%=Html.Encode(car.Make)%> <%=Html.Encode(car.Model)%> - <%=Html.Encode(car.LicensePlate)%></h3>
            
            <%=Html.ActionLink("Show details", "Details", new { licensePlate = car.LicensePlate })%> - 
            <%=Html.ActionLink("Show refuellings", "List", "Refuelling", new { licensePlate = car.LicensePlate }, null)%> - 
            <%=Html.ActionLink("Edit", "Edit", new { licensePlate = car.LicensePlate })%> - 
            <%=Ajax.ActionLink("Show statistics...", "Statistics", new { licensePlate = car.LicensePlate }, new AjaxOptions { UpdateTargetId = "statisticsFor" + Html.Encode(car.LicensePlate) })%>
            
            <div id="statisticsFor<%=Html.Encode(car.LicensePlate)%>"></div>
        </li>
    <% } %>
    </ul>
    <%=Html.ActionLink("Add new car!", "New", "Car")%>
</asp:Content>
