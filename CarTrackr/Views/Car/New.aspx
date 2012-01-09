<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage<CarTrackr.Domain.Car>" %>

<asp:Content ID="editContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add new car</h2>
    
    <% using (Html.BeginForm("New", "Car", FormMethod.Post)) { %>
        <%=Html.AntiForgeryToken()%>
        <table border="0" cellpadding="2" cellspacing="0" class="vertical">
            <tr>
                <th>Make</th>
                <td>
                    <%=Html.TextBox("Make", Model.Make ?? "")%>
                    <%=Html.ValidationMessage("Make")%>
                </td>
            </tr>
            <tr>
                <th>Model</th>
                <td>
                    <%=Html.TextBox("Model", Model.Model ?? "")%>
                    <%=Html.ValidationMessage("Model")%>
                </td>
            </tr>
            <tr>
                <th>Purchase price</th>
                <td>
                    <%=Html.TextBox("PurchasePrice", Model.PurchasePrice.ToString("0.00"))%>
                    <%=Html.ValidationMessage("PurchasePrice")%>
                </td>
            </tr>
            <tr>
                <th>License plate</th>
                <td>
                    <%=Html.TextBox("LicensePlate", Model.LicensePlate ?? "")%>
                    <%=Html.ValidationMessage("LicensePlate")%>
                </td>
            </tr>
            <tr>
                <th>Fuel type</th>
                <td>
                    <%=Html.TextBox("FuelType", Model.FuelType ?? "")%>
                    <%=Html.ValidationMessage("FuelType")%>
                </td>
            </tr>
            <tr>
                <th>Description</th>
                <td>
                    <%=Html.TextArea("Description", Model.Description ?? "")%>
                    <%=Html.ValidationMessage("Description")%>
                </td>
            </tr>
        </table>

        <input type="submit" value="Save" id="saveButton" />
        <%=Html.ActionLink("Cancel", "List", "Car", new { }, null)%>
    <% } %>
</asp:Content>

