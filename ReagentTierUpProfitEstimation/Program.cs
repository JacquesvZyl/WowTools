using Microsoft.Extensions.DependencyInjection;
using ReagentTierUpProfitEstimation.Services.ReagentRefinement;
using ReagentTierUpProfitEstimation.Services.Utilities;
using ReagentTierUpProfitEstimation.Views.UI;
using WoWTools.Services.Prospecting;
using WoWTools.Views.Forms;

namespace ReagentTierUpProfitEstimation
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            services.AddTransient<IReagentRefinement, ReagentRefinement>();
            services.AddTransient<IProspecting, Prospecting>();
            services.AddTransient<IUtilities, Utilities>();
            services.AddTransient<IUI, UI>();
            services.AddTransient<RefinementForm>();
            services.AddTransient<ProspectingForm>();
            services.AddTransient<Startup>();


            using (var serviceProvider = services.BuildServiceProvider())
            {
                //var form = serviceProvider.GetRequiredService<RefinementForm>();
                var form = serviceProvider.GetRequiredService<Startup>();
                Application.Run(form);
            }
        }
    }
}