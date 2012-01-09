<%@ Page Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage<CarDetailsViewData>" %>

<table border="0" cellpadding="2" cellspacing="0" class="vertical">
    <tr>
        <th>Total kilometers</th>
        <td><%=Html.Encode(Model.TotalKilometers.ToString("0"))%> km</td>
    </tr>
    <tr>
        <th>Average usage</th>
        <td><%=Html.Encode(Model.AverageUsage.ToString("0.00"))%> liters / 100 km</td>
    </tr>
    <tr>
        <th>Total costs</th>
        <td><%=Html.Encode(Model.TotalCosts.ToString("0.00"))%> EUR</td>
    </tr>
    <tr>
        <th>Average costs per kilometer</th>
        <td><%=Html.Encode(Model.AverageCosts.ToString("0.00"))%> EUR / km</td>
    </tr>
</table>