using ReagentTierUpProfitEstimation.Models;
using ReagentTierUpProfitEstimation.Services.Utilities;
using ReagentTierUpProfitEstimation.Views.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private readonly IUI _ui;
        public readonly IProspecting _prospecting;
        public ProspectingForm(IUI ui, IProspecting prospecting)
        {
            _prospecting = prospecting;
            _ui = ui;
            InitializeComponent();

            prospectDataGridView.CellFormatting += _ui.ResultsView_CellFormatting;
            prospectDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            prospectDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void prospectingInputBtn_Click(object sender, EventArgs e)
        {
            _prospecting.SetProspectingResults(prospectingInput.Text, prospectDataGridView);
        }

        private void ProspectingLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://drive.google.com/file/d/1ArHZ39glpLHyXROIBC8AHIVnhETrs7aY/view?usp=drive_link";
            try
            {
                // Open the URL in the default browser
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                // Handle errors, e.g., show a message
                MessageBox.Show($"Unable to open link: {ex.Message}");
            }

        }
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
