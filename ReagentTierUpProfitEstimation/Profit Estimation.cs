using System.Globalization;
using System.Windows.Forms;
using static ReagentTierUpProfitEstimation.Form1;

namespace ReagentTierUpProfitEstimation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            resultsViewAfter.CellFormatting += ResultsView_CellFormatting;
            resultsViewAfter.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            resultsViewAfter.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            resultViewBefore.CellFormatting += ResultsView_CellFormatting;
            resultViewBefore.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            resultViewBefore.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Split the input into lines
            string[] lines = MainInputTextbox.Text
                .Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToArray();


            // Parse each line into an Item object
            List<Item> items = lines.Select(line => ParseLineToItem(line)).ToList();

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


                var tier1PriceValue = (tier1Price?.Price ?? 0) / 10000;
                var tier2PriceValue = (tier2Price?.Price ?? 0) / 10000;
                var tier3PriceValue = (tier3Price?.Price ?? 0) / 10000;

                var tier1to2before = (tier2PriceValue - (tier1PriceValue * 5)).ToString("0.00");
                var tier2to3before = (tier3PriceValue - (tier2PriceValue * 5)).ToString("0.00");

                var tier1to2after = ((tier2PriceValue * 0.95) - (tier1PriceValue * 5 )).ToString("0.00");
                var tier2to3after = ((tier3PriceValue * 0.95) - (tier2PriceValue * 5 )).ToString("0.00");

                var tier2resultBefore = new Results
                {
                    Name = group.ItemList[0].Name,
                    Tier = "Tier 1 -> Tier 2",
                    Profit = $"{tier1to2before.Replace(".", "g")}s",
                    Percentage = ReturnProfitMarginPercentage((tier1PriceValue * 5), tier2PriceValue)

                };
                var tier3resultBefore = new Results
                {
                    Name = group.ItemList[0].Name,
                    Tier = "Tier 2 -> Tier 3",
                    Profit = $"{tier2to3before.Replace(".", "g")}s",
                    Percentage = ReturnProfitMarginPercentage((tier2PriceValue * 5), tier3PriceValue)


                };

                var tier2resultAfter = new Results
                {
                    Name = group.ItemList[0].Name,
                    Tier = "Tier 1 -> Tier 2",
                    Profit = $"{tier1to2after.Replace(".", "g")}s",
                    Percentage = ReturnProfitMarginPercentage((tier1PriceValue * 5), (tier2PriceValue * 0.95))

                };
                var tier3resultAfter = new Results
                {
                    Name = group.ItemList[0].Name,
                    Tier = "Tier 2 -> Tier 3",
                    Profit = $"{tier2to3after.Replace(".", "g")}s",
                    Percentage = ReturnProfitMarginPercentage((tier2PriceValue * 5), (tier3PriceValue * 0.95))


                };
                resultsListBefore.Add(tier2resultBefore);
                resultsListBefore.Add(tier3resultBefore);
                resultsListAfter.Add(tier3resultAfter);
                resultsListAfter.Add(tier2resultAfter);
            }

            resultsListBefore = resultsListBefore.OrderByDescending(result => ParsePercentage(result.Percentage)).ToList();
            resultsListAfter = resultsListAfter.OrderByDescending(result => ParsePercentage(result.Percentage)).ToList();
            //resultsViewAfter.AutoGenerateColumns = false;
            //NameColumn.DataPropertyName = "Name";
            //RefineColumn.DataPropertyName = "Tier";
            //ProfitColumn.DataPropertyName = "Profit";
            //PercentageColumn.DataPropertyName = "Percentage";
            resultViewBefore.DataSource = resultsListBefore;
            resultsViewAfter.DataSource = resultsListAfter;
            //MessageBox.Show(message);
        }

        private void MainInputTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        public class ItemGroups
        {
            public List<Items>? AllItems { get; set; }
        }

        public class Items
        {
            public List<Item>? ItemList { get; set; }
        }
        public class Item
        {
            public double Price { get; set; }
            public string Name { get; set; }
            public string Tier { get; set; }

            public static implicit operator int(Item? v)
            {
                throw new NotImplementedException();
            }
        }

        public class Results
        {
            public string Name { get; set; }
            public string Tier { get; set; }
            public string Profit { get; set; }
            public string Percentage { get; set; }
        }

        // Method to parse a line of CSV to an Item object
        private Item ParseLineToItem(string line)
        {
            // Split the line by commas, while keeping quotes around names
            string[] fields = line.Split(',');


            return new Item
            {
                Price = double.Parse(fields[0], CultureInfo.InvariantCulture),
                Name = System.Text.RegularExpressions.Regex.Replace(fields[1], @"\bTier\s\d+", "").Trim('"'),
                Tier = System.Text.RegularExpressions.Regex.Match(fields[1], @"(?<=Tier\s)\d+").Value
            };
        }

        static double ParsePercentage(string percentageString)
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

        private void Results_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void ResultsView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Cast sender to DataGridView to ensure the method works for both DataGridViews
            DataGridView dgv = sender as DataGridView;

            // Check if we're formatting the Percentage column
            if (dgv.Columns[e.ColumnIndex].Name == "Percentage")
            {
                if (e.Value is string percentageString)
                {
                    // Get the current row
                    var row = dgv.Rows[e.RowIndex];

                    var percentage = ParsePercentage(percentageString);
                    // Set row color based on the percentage value
                    if (percentage > 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                    }
                    else if (percentage < 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    else
                    {
                        // Optional: set neutral colors for zero percentage
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private string ReturnProfitMarginPercentage(double buyPrice, double sellPrice)
        {
            var profit = sellPrice - buyPrice;
            var profitMargin = (profit / sellPrice) * 100;

            // Round the profit margin to the nearest decimal place
            var roundedProfitMargin = Math.Round(profitMargin, 1);

            // Return the profit margin as a string, formatted to 1 decimal place
            return $"{roundedProfitMargin}%";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
