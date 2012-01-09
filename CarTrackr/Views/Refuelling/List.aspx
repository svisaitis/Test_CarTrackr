<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage<RefuellingListViewData>" %>

<asp:Content ID="detailsContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Refuellings for <%=Html.Encode(Model.Car.Make)%> <%=Html.Encode(Model.Car.Model)%> - <%=Html.Encode(Model.Car.LicensePlate)%></h2>
    
    <div id="refuellingChart" style="text-align:center;"></div>
    <%=Html.Chart("refuellingchart", "Fuel usage over time", "Date", "Liters / 100 km", "dd-MM-yyyy", "0.00", 500, 300, Model.Refuellings.GenerateUsageChartData())%>
    
    <p>
        <%=Html.ActionLink("Add refuelling...", "New")%>
    </p>
    
    <table border="0" cellpadding="2" cellspacing="0">
        <tr>
            <th>&nbsp;</th>
            <th>Date</th>
            <th>Service station</th>
            <th>Kilometers</th>
            <th>Liters</th>
            <th>Price per liter</th>
            <th>Total price</th>
            <th>Usage</th>
        </tr>
        <% foreach (var refuelling in Model.Refuellings) { %>
            <tr>
                <td><%=Html.ActionLink("Remove...", "Remove", "Refuelling", new { id = refuelling.Id.ToString() }, new { onclick = "return confirm('Are you sure?');" })%></td>
                <td><%=Html.Encode(refuelling.Date.ToString("dd/MM/yyyy"))%></td>
                <td><%=Html.ServiceStationImage(refuelling.ServiceStation ?? "")%> <%=Html.Encode(refuelling.ServiceStation ?? "")%></td>
                <td><%=Html.Encode(refuelling.Kilometers.ToString("0") ?? "Unknown")%> km</td>
                <td><%=Html.Encode(refuelling.Liters.ToString("0.00") ?? "Unknown")%> l</td>
                <td><%=Html.Encode(refuelling.PricePerLiter.ToString("0.00") ?? "Unknown")%> EUR/l</td>
                <td><%=Html.Encode(refuelling.Total.ToString("0.00") ?? "Unknown")%> EUR</td>
                <td><%=Html.Encode(refuelling.Usage.ToString("0.00") ?? "Unknown")%> l / 100 km</td>
            </tr>
        <% } %>
    </table>
    
    <p>
        <%=Html.ActionLink("Add refuelling...", "New")%>
    </p>
</asp:Content>
