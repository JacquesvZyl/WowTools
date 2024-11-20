using ReagentTierUpProfitEstimation.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReagentTierUpProfitEstimation.Services.Utilities
{
    public class Utilities : IUtilities
    {
        public Item ParseLineToItem(string line)
        {
            // Split the line by commas, while keeping quotes around names
            string[] fields = line.Split(',')
                      .Select(field => field.Trim())
                      .ToArray();


            return new Item
            {
                Price = double.Parse(fields[0], CultureInfo.InvariantCulture) / 10000,
                Name = System.Text.RegularExpressions.Regex.Replace(fields[1], @"\bTier\s\d+", "").Trim('"'),
                Tier = System.Text.RegularExpressions.Regex.Match(fields[1], @"(?<=Tier\s)\d+").Value
            };
        }

        public string ReturnProfitMarginPercentage(double buyPrice, double sellPrice)
        {
            var profit = sellPrice - buyPrice;
            var profitMargin = (profit / sellPrice) * 100;

            // Round the profit margin to the nearest decimal place
            var roundedProfitMargin = Math.Round(profitMargin, 1);

            // Return the profit margin as a string, formatted to 1 decimal place
            return $"{roundedProfitMargin}%";
        }

        public double ParsePercentage(string percentageString)
        {
            if (double.TryParse(percentageString.TrimEnd('%'), NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }
            else
            {
                throw new FormatException("Invalid percentage format.");
            }
        }
    }
}
