using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReagentTierUpProfitEstimation.Services.ReagentRefinement
{
    public interface IReagentRefinement
    {
        void ReturnRefinementResults(RichTextBox richTextBox, DataGridView resultViewBefore, DataGridView resultViewAfter);
    }
}
