﻿using ReagentTierUpProfitEstimation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoWTools.Services.Prospecting
{
    public interface IProspecting
    {
        void SetProspectingResults(string input, DataGridView dataGrid);
    }
}
