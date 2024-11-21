using ReagentTierUpProfitEstimation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoWTools.Models;

namespace ReagentTierUpProfitEstimation.Services.Utilities
{
    public interface IUtilities
    {
        Item ParseLineToItem(string line);
        string ReturnProfitMarginPercentage(double buyPrice, double sellPrice);
        double ParsePercentage(string percentageString);
        ProspectingSettings LoadProspectingSettings();
        List<Item> ReturnItemListFromString(string inputString);
    }
}
