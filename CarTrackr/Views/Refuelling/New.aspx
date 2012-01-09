<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage<NewRefuellingViewData>" %>

<asp:Content ID="newContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
    var lastRefuellingKilometers = <%=Html.Encode(Model.LastRefuelling != null ? Model.LastRefuelling.Kilometers.ToString("0") : "0") %>;
    
    function updateFormValues(formControl) {
        if (formControl != null) {
            var kilometers = formControl.Kilometers.value.replace(',', '.') * 1;
            var liters = formControl.Liters.value.replace(',', '.') * 1;
            var pricePerLiter = formControl.PricePerLiter.value.replace(',', '.') * 1;
            var total = formControl.Total.value.replace(',', '.') * 1;
            var differenceKilometers = kilometers - lastRefuellingKilometers;
            
            if (liters > 0 && pricePerLiter > 0 && total == 0) {
                total = liters * pricePerLiter;
            }
                
            if (liters > 0 && total > 0 && pricePerLiter == 0) {
                pricePerLiter = total / liters;
            }
            
            if (liters > 0) {
                formControl.Liters.value = liters;
            }
              
            if (pricePerLiter > 0) { 
                formControl.PricePerLiter.value = pricePerLiter;
            }
            
            if (total > 0) {
                formControl.Total.value = total;
            }
            
            if (differenceKilometers > 0 && kilometers > 50) {
                formControl.Usage.value = (liters / differenceKilometers) * 100;
            }
            
            // TODO: Refactor once ASP.NET MVC has globalization in place
            formControl.Kilometers.value = formControl.Kilometers.value.replace('.', ',');
            formControl.Liters.value = formControl.Liters.value.replace('.', ',');
            formControl.PricePerLiter.value = formControl.PricePerLiter.value.replace('.', ',');
            formControl.Total.value = formControl.Total.value.replace('.', ',');
            formControl.Usage.value = formControl.Usage.value.replace('.', ',');
        }
    }
    </script>
    
    <h2>New refuelling for <%=Html.Encode(Model.Car.Make)%> <%=Html.Encode(Model.Car.Model)%> - <%=Html.Encode(Model.Car.LicensePlate)%></h2>
    
    <% using (Html.BeginForm("New", "Refuelling", FormMethod.Post)) { %>
        <%=Html.AntiForgeryToken()%>
        <table border="0" cellpadding="2" cellspacing="0" class="vertical">
            <tr>
                <th>Date</th>
                <td>
                    <%=Html.TextBox("Date", Model.NewRefuelling.Date.ToString("dd/MM/yyyy") ?? "")%>
                    <%=Html.ValidationMessage("Date")%>
                </td>
            </tr>
            <tr>
                <th>Service station</th>
                <td>
                    <%=Html.TextBox("ServiceStation", Model.NewRefuelling.ServiceStation ?? "")%>
                    <%=Html.ValidationMessage("ServiceStation")%>
                </td>
            </tr>
            <tr>
                <th>Kilometers</th>
                <td>
                    <%=Html.TextBox("Kilometers", Model.NewRefuelling.Kilometers.ToString("0") ?? "0", new { onchange = "updateFormValues(this.form);" })%> km 
                    <%=Html.ValidationMessage("Kilometers")%>
                </td>
            </tr>
            <tr>
                <th>Liters</th>
                <td>
                    <%=Html.TextBox("Liters", Model.NewRefuelling.Liters.ToString("0.00") ?? "0.00", new { onchange = "updateFormValues(this.form);" })%> l
                    <%=Html.ValidationMessage("Liters")%>
                </td>
            </tr>
            <tr>
                <th>Price per liter</th>
                <td>
                    <%=Html.TextBox("PricePerLiter", Model.NewRefuelling.Liters.ToString("0.00") ?? "0.00", new { onchange = "updateFormValues(this.form);" })%> EUR/l
                    <%=Html.ValidationMessage("PricePerLiter")%>
                </td>
            </tr>
            <tr>
                <th>Total</th>
                <td>
                    <%=Html.TextBox("Total", Model.NewRefuelling.Total.ToString("0.00") ?? "0.00", new { onchange = "updateFormValues(this.form);" })%> EUR
                    <%=Html.ValidationMessage("Total")%>
                </td>
            </tr>
            <tr>
                <th>Usage</th>
                <td>
                    <%=Html.TextBox("Usage", Model.NewRefuelling.Usage.ToString("0.00") ?? "0.00", new { onchange = "updateFormValues(this.form);" })%> l / 100 km
                    <%=Html.ValidationMessage("Usage")%>
                </td>
            </tr>
        </table>

        <input type="submit" value="Save" id="saveButton" />
        <%=Html.ActionLink("Cancel", "Details", "Car", new { licensePlate = Model.Car.LicensePlate }, null)%>
    <% } %>
</asp:Content>
