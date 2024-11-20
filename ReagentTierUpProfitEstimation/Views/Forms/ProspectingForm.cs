using ReagentTierUpProfitEstimation.Models;
using ReagentTierUpProfitEstimation.Services.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WoWTools.Services.Prospecting;

namespace WoWTools.Views.Forms
{
    public partial class ProspectingForm : Form
    {
        private readonly IUtilities _utilities;
        public readonly IProspecting _prospecting;
        public ProspectingForm(IUtilities utilities, IProspecting prospecting)
        {
            _prospecting = prospecting;
            _utilities = utilities;
            InitializeComponent();
        }

        private void thaumaturgyInputButton_Click(object sender, EventArgs e)
        {
            // Split the input into lines
            string[] lines = ThaumaturgyInput.Text
                .Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToArray();


            // Parse each line into an Item object
            List<Item> items = lines.Select(line => _utilities.ParseLineToItem(line)).ToList();
            var results = new List<Results>();

            foreach (var item in items)
            {
                if(item.Name.Trim().ToLower() != "aqirite" && item.Name.ToLower().Trim() != "ironclaw ore")
                {
                    continue;
                }
                var craftingcost = item.Price * 5;
                var baseprofit = _prospecting.ReturnAvgPerCraft(item, items);

                var baseProfitIncAH = baseprofit * 0.95;

                var result = new Results
                {
                    Name = item.Name,
                    Tier = item.Tier,
                    Profit = Math.Round(baseProfitIncAH - craftingcost, 2).ToString(),

                };
                results.Add(result);

            }

            prospectDataGridView.DataSource = results;
            Console.WriteLine("test");
        }



        public double GetBaseReagents(string reagentName, List<Item> reagents)
        {
            // Convert reagentName to lowercase to ensure case-insensitivity
            reagentName = reagentName.ToLower();

            // Check if the reagent exists in the dictionary
            if (!baseReagentMappings.ContainsKey(reagentName))
            {
                return 0; // Return 0 or handle accordingly if reagent is not found
            }

            // Get the list of items to consider based on the reagent
            var itemsToConsiderNames = baseReagentMappings[reagentName];

            // Filter the ItemList to get the items by name
            var itemsToConsider = reagents
                .Where(item => itemsToConsiderNames.Contains(item.Name.ToLower().Trim()) && item.Tier.ToLower().Trim() == "2")
                .ToList();

            // If no matching items are found, return 0 or handle accordingly
            if (itemsToConsider.Count == 0)
            {
                return 0;
            }

            // Calculate the average price of the filtered items
            return itemsToConsider.Average(item => item.Price);
        }
        private readonly Dictionary<string, List<string>> baseReagentMappings = new Dictionary<string, List<string>>
        {
            //mercurial reagents
            { "gloom chitin", new List<string> { "aqirite", "luredrop", "orbinid", } },
            { "aqirite", new List<string> { "gloom chitin", "luredrop", "orbinid" } },
            { "luredrop", new List<string> { "gloom chitin", "aqirite", "orbinid" } },
            { "orbinid", new List<string> { "gloom chitin", "aqirite", "luredrop" } },
            //ominous reagents
            { "storm dust", new List<string> { "weavercloth", "mycobloom", "bismuth" } },
            { "weavercloth", new List<string> { "storm dust", "mycobloom", "bismuth" } },
            { "mycobloom", new List<string> { "weavercloth", "storm dust", "bismuth" } },
            { "bismuth", new List<string> { "weavercloth", "mycobloom", "storm dust" } },
            //volatile reagents.
            { "arathor's spear", new List<string> { "stormcharged leather", "blessing blossom", "ironclaw ore" } },
            { "stormcharged leather", new List<string> { "arathor's spear", "blessing blossom", "ironclaw ore" } },
            { "blessing blossom", new List<string> { "stormcharged leather", "arathor's spear", "ironclaw ore" } },
            { "ironclaw ore", new List<string> { "stormcharged leather", "blessing blossom", "arathor's spear" } },

            //volatile transmutagens
            { "volatile transmutagen", new List<string> { "weavercloth", "mycobloom", "bismuth", "storm dust" } },
            //mercurial transmutagens
            { "mercurial transmutagen", new List<string> { "stormcharged leather", "blessing blossom", "ironclaw ore", "arathor's spear" } },
            //ominous transmutagen
            { "ominoous transmutagen", new List<string> { "aqirite", "luredrop", "orbinid", "gloom chitin" } },


        };

    }
}




/*3000 gloom chitin

RESULTS:
2 x Extravagent Emeralds - 
1 x Ostentatious Onyx
8 x ambivalent amber
466 x Aqirite
447x Luredrop
554 x Orbinid

313 x Gleaming Transmutagen
485 x Mercurial
185 x Volatile

150 crafts

9.78 reagents per craft
2.1 Gleaming per craft
3.15 Mercurial per craft
1.16 Volatile per craft

MERCURIAL - 24 crafts

65 x Arathor
45 x Blessing
48 x IronClaw
58 x Stormcharged

64 x Volatile
22 x Ominous
44 x Gleaming

9 reagents per craft
1.8 gleaming
2.66 Volatile
0.9 Ominous*/
