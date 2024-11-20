using ReagentTierUpProfitEstimation.Models;
using ReagentTierUpProfitEstimation.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReagentTierUpProfitEstimation.Services.ReagentRefinement
{
    public class ReagentRefinement : IReagentRefinement
    {
        private readonly IUtilities utilities;
        public ReagentRefinement(IUtilities utilities)
        {
            this.utilities = utilities;
        }

        public void ReturnRefinementResults (RichTextBox richTextBox, DataGridView resultViewBefore, DataGridView resultViewAfter)
        {
            // Split the input into lines
            string[] lines = richTextBox.Text
                .Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToArray();


            // Parse each line into an Item object
            List<Item> items = lines.Select(line => utilities.ParseLineToItem(line)).ToList();

            //var itemGroups = new itemGroups();

            // Initialize AllItems in itemGroups
            var itemGroups = new ItemGroups { AllItems = new List<Items>() };

            // Group items by Name and add to itemGroups
            foreach (var group in items.GroupBy(item => item.Name))
            {
                var itemList = new Items
                {
                    ItemList = group.ToList()
                };

                itemGroups.AllItems.Add(itemList);
            }

            List<Results> resultsListBefore = new List<Results>();
            List<Results> resultsListAfter = new List<Results>();


            foreach (var group in itemGroups.AllItems)
            {

                var tier1Price = group.ItemList.Where(c => c.Tier == "1").FirstOrDefault();
                var tier2Price = group.ItemList.Where(c => c.Tier == "2").FirstOrDefault();
                var tier3Price = group.ItemList.Where(c => c.Tier == "3").FirstOrDefault();


                var tier1PriceValue = (tier1Price?.Price ?? 0);
                var tier2PriceValue = (tier2Price?.Price ?? 0);
                var tier3PriceValue = (tier3Price?.Price ?? 0);

                var tier1to2before = (tier2PriceValue - (tier1PriceValue * 5)).ToString("0.00");
                var tier2to3before = (tier3PriceValue - (tier2PriceValue * 5)).ToString("0.00");

                var tier1to2after = ((tier2PriceValue * 0.95) - (tier1PriceValue * 5)).ToString("0.00");
                var tier2to3after = ((tier3PriceValue * 0.95) - (tier2PriceValue * 5)).ToString("0.00");

                var tier2resultBefore = new Results
                {
                    Name = group.ItemList[0].Name,
                    Tier = "Tier 1 -> Tier 2",
                    Profit = $"{tier1to2before.Replace(".", "g")}s",
                    Percentage = utilities.ReturnProfitMarginPercentage((tier1PriceValue * 5), tier2PriceValue)

                };
                var tier3resultBefore = new Results
                {
                    Name = group.ItemList[0].Name,
                    Tier = "Tier 2 -> Tier 3",
                    Profit = $"{tier2to3before.Replace(".", "g")}s",
                    Percentage = utilities.ReturnProfitMarginPercentage((tier2PriceValue * 5), tier3PriceValue)


                };

                var tier2resultAfter = new Results
                {
                    Name = group.ItemList[0].Name,
                    Tier = "Tier 1 -> Tier 2",
                    Profit = $"{tier1to2after.Replace(".", "g")}s",
                    Percentage = utilities.ReturnProfitMarginPercentage((tier1PriceValue * 5), (tier2PriceValue * 0.95))

                };
                var tier3resultAfter = new Results
                {
                    Name = group.ItemList[0].Name,
                    Tier = "Tier 2 -> Tier 3",
                    Profit = $"{tier2to3after.Replace(".", "g")}s",
                    Percentage = utilities.ReturnProfitMarginPercentage((tier2PriceValue * 5), (tier3PriceValue * 0.95))


                };
                resultsListBefore.Add(tier2resultBefore);
                resultsListBefore.Add(tier3resultBefore);
                resultsListAfter.Add(tier3resultAfter);
                resultsListAfter.Add(tier2resultAfter);
            }

            resultsListBefore = resultsListBefore.OrderByDescending(result => utilities.ParsePercentage(result.Percentage)).ToList();
            resultsListAfter = resultsListAfter.OrderByDescending(result => utilities.ParsePercentage(result.Percentage)).ToList();
            resultViewBefore.DataSource = resultsListBefore;
            resultViewAfter.DataSource = resultsListAfter;
        }
    }
}
