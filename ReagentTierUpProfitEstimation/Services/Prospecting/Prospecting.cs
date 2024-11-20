using ReagentTierUpProfitEstimation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWTools.Services.Prospecting
{
    public class Prospecting : IProspecting
    {

        public double ReturnAvgPerCraft(Item reagent, List<Item> reagents)
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

            return rareGems.Average(item => item.Price) * 0.566;
        }

        private double ReturnAvgCrushGemstonePerCraft(string tier, List<Item> reagents)
        {
            var gemstone = reagents.Where(c => c.Name.ToLower().Trim() == "crushed gemstones" && c.Tier == tier).FirstOrDefault();

            return gemstone?.Price * 0.116 ?? 0.0;
        }

        private double ReturnAvgGlassPerCraft(List<Item> reagents)
        {
            var glass = reagents.Where(c => c.Name.ToLower().Trim() == "glittering glass").FirstOrDefault();

            return glass?.Price * 0.387 ?? 0.0;
        }

        private double ReturnAvgPebblesPerCraft(List<Item> reagents)
        {
            var pebbles = reagents.Where(c => c.Name.ToLower().Trim() == "handful of pebbles").FirstOrDefault();

            return pebbles?.Price * 1.122 ?? 0.0;
        }

        private double ReturnAvgAmberPerCraft(List<Item> reagents)
        {
            var amber = reagents.Where(c => c.Name.ToLower().Trim() == "ambivalent amber").FirstOrDefault();

            return amber?.Price * 0.08 ?? 0.0;
        }



        private readonly Dictionary<string, List<string>> reagentMappings = new Dictionary<string, List<string>>
        {
            { "rare gems", new List<string> { "extravagant emerald", "ostentatious onyx", "radiant ruby", "stunning sapphire" } },
        };
    }
}
