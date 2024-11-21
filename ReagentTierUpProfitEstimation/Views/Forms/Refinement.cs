using ReagentTierUpProfitEstimation.Models;
using ReagentTierUpProfitEstimation.Services.ReagentRefinement;
using ReagentTierUpProfitEstimation.Views.UI;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using static ReagentTierUpProfitEstimation.RefinementForm;

namespace ReagentTierUpProfitEstimation
{
    public partial class RefinementForm : Form
    {
        private readonly IReagentRefinement _refinement;
        private readonly IUI _ui;
        public RefinementForm(IReagentRefinement reagentRefinement, IUI uI)
        {
            _refinement = reagentRefinement;
            _ui = uI;
            InitializeComponent();

            resultsViewAfter.CellFormatting += _ui.ResultsView_CellFormatting;
            resultsViewAfter.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            resultsViewAfter.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            resultViewBefore.CellFormatting += _ui.ResultsView_CellFormatting;
            resultViewBefore.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            resultViewBefore.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _refinement.ReturnRefinementResults(MainInputTextbox, resultViewBefore, resultsViewAfter);

        }

        private void MainInputTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Results_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://docs.google.com/document/d/19zSgumJOo6Qfk_4DK8b1cnQ9lRQTpHkIR5GZJkx5nzI/edit?usp=drive_link";
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
