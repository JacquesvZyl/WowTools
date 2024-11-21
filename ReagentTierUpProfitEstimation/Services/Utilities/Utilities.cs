using ReagentTierUpProfitEstimation.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WoWTools.Models;

namespace ReagentTierUpProfitEstimation.Services.Utilities
{
    public class Utilities : IUtilities
    {
        private static readonly string SettingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");
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

        public ProspectingSettings LoadProspectingSettings()
        {
            //private static readonly string SettingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");

            if (!File.Exists(SettingsFilePath)) 
            {
                throw new FileNotFoundException(SettingsFilePath);
            }

            string json = File.ReadAllText(SettingsFilePath);

            // Parse the JSON to get the "Prospecting" part
            using (JsonDocument doc = JsonDocument.Parse(json))
            {
                var prospectingJson = doc.RootElement.GetProperty("Prospecting");
                // Deserialize just the "Prospecting" part into the ProspectingSettings class
                return JsonSerializer.Deserialize<ProspectingSettings>(prospectingJson.GetRawText());
            }
            
        }

        public List<Item> ReturnItemListFromString(string inputString)
        {
            // Split the input into lines
            string[] lines = inputString
                .Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToArray();


            // Parse each line into an Item object
            List<Item> items = lines.Select(line => ParseLineToItem(line)).ToList();
            return items;
        }


    }
}

