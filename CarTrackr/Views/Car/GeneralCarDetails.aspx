<%@ Page Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage<CarTrackr.Domain.Car>" %>

<table border="0" cellpadding="2" cellspacing="0" class="vertical">
    <tr>
        <th>Make</th>
        <td><%=Html.Encode(Model.Make ?? "Unknown")%></td>
    </tr>
    <tr>
        <th>Model</th>
        <td><%=Html.Encode(Model.Model ?? "Unknown")%></td>
    </tr>
    <tr>
        <th>Purchase price</th>
        <td><%=Html.Encode(Model.PurchasePrice.ToString("0.00"))%> EUR</td>
    </tr>
    <tr>
        <th>License plate</th>
        <td><%=Html.Encode(Model.LicensePlate ?? "Unknown")%></td>
    </tr>
    <tr>
        <th>Fuel type</th>
        <td><%=Html.Encode(Model.FuelType ?? "Unknown")%></td>
    </tr>
    <tr>
        <th>Description</th>
        <td><%=Html.Encode(Model.Description ?? "Unknown")%></td>
    </tr>
</table>