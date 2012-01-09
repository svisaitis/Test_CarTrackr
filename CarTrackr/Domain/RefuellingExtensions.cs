using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace CarTrackr.Domain
{
    public static class RefuellingExtensions
    {
        public static Dictionary<string, string> GenerateUsageChartData(this List<Refuelling> refuellings)
        {
            Dictionary<string, string> chartValues = new Dictionary<string, string>();
            foreach (var refuelling in refuellings.OrderBy(r => r.Date))
            {
                if (refuelling.Usage > 0)
                {
                    chartValues.Add(refuelling.Date.ToString("dd-MM-yyyy"), refuelling.Usage.ToString("0.00", CultureInfo.GetCultureInfo("en-US").NumberFormat));
                }
            }
            return chartValues;
        }

        public static Dictionary<string, string> GenerateTotalKilometersChartData(this List<Refuelling> refuellings)
        {
            Dictionary<string, string> chartValues = new Dictionary<string, string>();

            foreach (var refuelling in refuellings.OrderBy(r => r.Date))
            {
                if (refuelling.Kilometers > 0)
                {
                    chartValues.Add(refuelling.Date.ToString("dd-MM-yyyy"), refuelling.Kilometers.ToString("0.00", CultureInfo.GetCultureInfo("en-US").NumberFormat));
                }
            }
            return chartValues;
        }

        public static Dictionary<string, string> GenerateFuelPriceChartData(this List<Refuelling> refuellings)
        {
            Dictionary<string, string> chartValues = new Dictionary<string, string>();

            foreach (var refuelling in refuellings.OrderBy(r => r.Date))
            {
                if (refuelling.PricePerLiter > 0)
                {
                    chartValues.Add(refuelling.Date.ToString("dd-MM-yyyy"), refuelling.PricePerLiter.ToString("0.00", CultureInfo.GetCultureInfo("en-US").NumberFormat));
                }
            }
            return chartValues;
        }
    }
}
