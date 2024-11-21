using ReagentTierUpProfitEstimation.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReagentTierUpProfitEstimation.Views.UI
{
    public class UI : IUI
    {
        private readonly IUtilities _utilities;
        public UI(IUtilities utilities)
        {
            _utilities = utilities;
        }

        public void ResultsView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Cast sender to DataGridView to ensure the method works for both DataGridViews
            DataGridView? dgv = sender as DataGridView;

            // Check if we're formatting the Percentage column
            if (dgv.Columns[e.ColumnIndex].Name == "Percentage")
            {
                if (e.Value is string percentageString)
                {
                    // Get the current row
                    var row = dgv.Rows[e.RowIndex];

                    var percentage = _utilities.ParsePercentage(percentageString);
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
    }
}
