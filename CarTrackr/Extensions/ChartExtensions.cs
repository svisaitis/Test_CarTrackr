using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace CarTrackr.Extensions
{
    public static class ChartExtensions
    {
        private const string VisifireJs = "~/Content/Visifire/Visifire2.js";
        private const string VisifireXap = "~/Content/Visifire/SL.Visifire.Charts.xap";

        private static void AppendToChartXml(ref StringBuilder stringBuilder, string data) {
            stringBuilder.AppendLine(string.Format("chartXmlString += '{0}';", data));
        }

        public static string Chart(this HtmlHelper html, string renderDiv, string title, string axisXTitle, string axisYTitle, int width, int height, Dictionary<string, string> values)
        {
            return Chart(html, renderDiv, title, axisXTitle, axisYTitle, "", "", width, height, values);
        }

        public static string Chart(this HtmlHelper html, string renderDiv, string title, string axisXTitle, string axisYTitle, string axisXFormat, string axisYFormat, int width, int height, Dictionary<string, string> values)
        {
            // Chart ID
            string chartId = "chart" + Guid.NewGuid().ToString("N");

            // Stringbuilder
            StringBuilder returnValue = new StringBuilder();

            // Include JavaScript file
            returnValue.AppendLine(JavaScriptExtensions.JavaScript(html, VisifireJs));

            // Generate Visifire code
            StringBuilder visifireCode = new StringBuilder();
            visifireCode.AppendLine("var chartXmlString = '';");
            AppendToChartXml(ref visifireCode, "<vc:Chart xmlns:vc=\"clr-namespace:Visifire.Charts;assembly=SLVisifire.Charts\" Width=\"" + width.ToString() + "\" Height=\"" + height.ToString() + "\" BorderThickness=\"0\" Theme=\"Theme1\" View3D=\"True\" AnimationEnabled=\"True\" LightingEnabled=\"True\" ShadowEnabled=\"True\">");
            AppendToChartXml(ref visifireCode, "  <vc:Chart.Titles>");
            AppendToChartXml(ref visifireCode, "    <vc:Title Text=\"" + title + "\" />");
            AppendToChartXml(ref visifireCode, "  </vc:Chart.Titles>");
            AppendToChartXml(ref visifireCode, "  <vc:Chart.AxesX>");
            AppendToChartXml(ref visifireCode, "    <vc:Axis ValueFormatString=\"" + axisXFormat + "\" Title=\"" + axisXTitle + "\" />");
            AppendToChartXml(ref visifireCode, "  </vc:Chart.AxesX>");
            AppendToChartXml(ref visifireCode, "  <vc:Chart.AxesY>");
            AppendToChartXml(ref visifireCode, "    <vc:Axis ValueFormatString=\"" + axisYFormat + "\" Title=\"" + axisYTitle + "\" />");
            AppendToChartXml(ref visifireCode, "  </vc:Chart.AxesY>");
            AppendToChartXml(ref visifireCode, "  <vc:Chart.Series>");
            AppendToChartXml(ref visifireCode, "    <vc:DataSeries RenderAs=\"Line\">");
            AppendToChartXml(ref visifireCode, "      <vc:DataSeries.DataPoints>");
            foreach (var value in values) {
                AppendToChartXml(ref visifireCode, string.Format("        <vc:DataPoint AxisXLabel=\"{0}\" YValue=\"{1}\"/>", value.Key, value.Value));
            }
            AppendToChartXml(ref visifireCode, "      </vc:DataSeries.DataPoints>");
            AppendToChartXml(ref visifireCode, "    </vc:DataSeries>");
            AppendToChartXml(ref visifireCode, "  </vc:Chart.Series>");
            AppendToChartXml(ref visifireCode, "</vc:Chart>");
            
            visifireCode.AppendLine();
            visifireCode.AppendLine(string.Format("var {0} = new Visifire2(\"{1}\", {2}, {3});", chartId, VirtualPathUtility.ToAbsolute(VisifireXap), width, height));
            visifireCode.AppendLine(string.Format("{0}.setDataXml(chartXmlString);", chartId));
            visifireCode.AppendLine(string.Format("{0}.render(\"{1}\");", chartId, renderDiv));

            // Generate Visifire tag
            TagBuilder visifire = new TagBuilder("script");
            visifire.Attributes.Add("type", "text/javascript");
            visifire.InnerHtml = visifireCode.ToString();
            returnValue.AppendLine(visifire.ToString(TagRenderMode.Normal));

            // Return
            return returnValue.ToString();
        }
    }
}
