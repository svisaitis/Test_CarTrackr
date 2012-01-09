<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage<CarDetailsViewData>" %>

<asp:Content ID="detailsContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Details for <%=Html.Encode(Model.Car.Make)%> <%=Html.Encode(Model.Car.Model)%> - <%=Html.Encode(Model.Car.LicensePlate)%></h2>

    <h3>General details</h3>
    <% Html.RenderPartial("GeneralCarDetails", Model.Car); %>
    <p>
        <%=Html.ActionLink("Refuellings...", "List", "Refuelling", new { licensePlate = Model.Car.LicensePlate }, null)%>
        <%=Html.ActionLink("Edit...", "Edit", new { licensePlate = Model.Car.LicensePlate })%>
    </p>
    
    <h3>Statistics</h3>
    <% Html.RenderPartial("StatisticsCarDetails", Model); %>
    
    <h3>Graphs</h3>
    
    <div id="refuellingChart" style="text-align:center; margin-bottom: 20px;"></div>
    <%=Html.Chart("refuellingchart", "Fuel usage over time", "Date", "Liters / 100 km", "dd-MM-yyyy", "0.00", 500, 300, Model.Car.Refuellings.ToList().GenerateUsageChartData())%>
        
    <div id="kilometersChart" style="text-align:center; margin-bottom: 20px;"></div>
    <%=Html.Chart("kilometersChart", "Kilometers over time", "Date", "Total kilometers", "dd-MM-yyyy", "0.00", 500, 300, Model.Car.Refuellings.ToList().GenerateTotalKilometersChartData())%>
    
    <div id="fuelPriceChart" style="text-align:center; margin-bottom: 20px;"></div>
    <%=Html.Chart("fuelPriceChart", "Fuel price over time", "Date", "Price / liter", "dd-MM-yyyy", "0.00", 500, 300, Model.Car.Refuellings.ToList().GenerateFuelPriceChartData())%>
    
</asp:Content>
