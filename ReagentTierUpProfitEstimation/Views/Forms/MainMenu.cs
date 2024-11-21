using ReagentTierUpProfitEstimation;
using ReagentTierUpProfitEstimation.Services.ReagentRefinement;
using ReagentTierUpProfitEstimation.Services.Utilities;
using ReagentTierUpProfitEstimation.Views.UI;
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
    public partial class Startup : Form
    {
        private readonly IReagentRefinement _refinementService;
        private readonly IUI _uiService;
        private readonly IUtilities _utilities;
        private readonly IProspecting _prospecting;
        public Startup(IReagentRefinement refinementService, IUI uiService, IUtilities utilities, IProspecting prospecting)
        {

            _utilities = utilities;
            _prospecting = prospecting;
            _refinementService = refinementService;
            _uiService = uiService;
            InitializeComponent();
        }

        private void thaumaturgyBtn_Click(object sender, EventArgs e)
        {
            ProspectingForm thaumaturgyForm = new ProspectingForm(_uiService,_prospecting);
            thaumaturgyForm.Show();

        }


        private void refinementbtn_Click(object sender, EventArgs e)
        {
            // Pass the required services to the RefinementForm
            RefinementForm refinementForm = new RefinementForm(_refinementService, _uiService);

            // Show the form
            refinementForm.Show();
        }
    }
}
