using ReagentTierUpProfitEstimation.Models;
using ReagentTierUpProfitEstimation.Services.ReagentRefinement;
using ReagentTierUpProfitEstimation.Views.UI;
using System.Globalization;
using System.Windows.Forms;
using static ReagentTierUpProfitEstimation.Form1;

namespace ReagentTierUpProfitEstimation
{
    public partial class Form1 : Form
    {
        private readonly IReagentRefinement _refinement;
        private readonly IUI _ui;
        public Form1(IReagentRefinement reagentRefinement,IUI uI)
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
    }
}
