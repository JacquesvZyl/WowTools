﻿using ReagentTierUpProfitEstimation.Models;
using ReagentTierUpProfitEstimation.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoWTools.Models;

namespace WoWTools.Services.Prospecting
{
    public class Prospecting : IProspecting
    {
        private readonly IUtilities _utilities;
        private readonly ProspectingSettings _settings;

        public Prospecting(IUtilities utilities) 
        {
            _utilities = utilities;
            _settings = _utilities.LoadProspectingSettings();

        }


        private double ReturnAvgPerCraft(Item reagent, List<Item> reagents)
        {

            var values = new[]
            {
                ReturnAvgRareGemPerCraft(reagents),
                ReturnAvgCrushGemstonePerCraft(reagent.Tier, reagents),
                ReturnAvgGlassPerCraft(reagents),
                ReturnAvgPebblesPerCraft(reagents),
                ReturnAvgAmberPerCraft(reagents),
            };

            return values.Sum();
        }


        private double ReturnAvgRareGemPerCraft(List<Item> reagents)
        {
            var itemsToConsiderNames = reagentMappings["rare gems"];

            var rareGems = reagents
                .Where(item => itemsToConsiderNames.Contains(item.Name.ToLower()))
                .ToList();
            var yield = _settings.Rare_Gems_Yield;
            return rareGems.Average(item => item.Price) * yield;
        }

        private double ReturnAvgCrushGemstonePerCraft(string tier, List<Item> reagents)
        {
            var gemstone = reagents.Where(c => c.Name.ToLower().Trim() == "crushed gemstones" && c.Tier == tier).FirstOrDefault();

            var yield = _settings.Crushed_GemStones_Yield;
            return gemstone?.Price * yield ?? 0.0;
        }

        private double ReturnAvgGlassPerCraft(List<Item> reagents)
        {
            var glass = reagents.Where(c => c.Name.ToLower().Trim() == "glittering glass").FirstOrDefault();

            var yield = _settings.Glittering_Glass_Yield;

            return glass?.Price * yield ?? 0.0;
        }

        private double ReturnAvgPebblesPerCraft(List<Item> reagents)
        {
            var pebbles = reagents.Where(c => c.Name.ToLower().Trim() == "handful of pebbles").FirstOrDefault();

            var yield = _settings.Handful_of_Pebbles_Yield;

            return pebbles?.Price * yield ?? 0.0;
        }

        private double ReturnAvgAmberPerCraft(List<Item> reagents)
        {
            var yield = _settings.Ambivalent_Amber_Yield;

            var amber = reagents.Where(c => c.Name.ToLower().Trim() == "ambivalent amber").FirstOrDefault();


            return amber?.Price * yield ?? 0.0;
        }

        public void SetProspectingResults(string input, DataGridView dataGrid)
        {
            var items = _utilities.ReturnItemListFromString(input);

            var results = new List<Results>();

            foreach (var item in items)
            {
                if (item.Name.Trim().ToLower() != "aqirite" && item.Name.ToLower().Trim() != "ironclaw ore")
                {
                    continue;
                }
                var craftingcost = item.Price * 5;
                var baseprofit = ReturnAvgPerCraft(item, items);

                var baseProfitIncAH = baseprofit * 0.95;

                var result = new Results
                {
                    Name = item.Name,
                    Tier = item.Tier,
                    Profit = Math.Round(baseProfitIncAH - craftingcost, 2).ToString(),
                    Percentage = _utilities.ReturnProfitMarginPercentage(craftingcost, baseprofit)

                };
                results.Add(result);

            }

            dataGrid.DataSource = results.OrderByDescending(result => _utilities.ParsePercentage(result.Percentage)).ToList();
        }

        private readonly Dictionary<string, List<string>> reagentMappings = new Dictionary<string, List<string>>
        {
            { "rare gems", new List<string> { "extravagant emerald", "ostentatious onyx", "radiant ruby", "stunning sapphire" } },
        };
    }
}
