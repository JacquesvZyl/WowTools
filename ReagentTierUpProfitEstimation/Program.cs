using Microsoft.Extensions.DependencyInjection;
using ReagentTierUpProfitEstimation.Services.ReagentRefinement;
using ReagentTierUpProfitEstimation.Services.Utilities;
using ReagentTierUpProfitEstimation.Views.UI;

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
            services.AddTransient<IUtilities, Utilities>();
            services.AddTransient<IUI, UI>();
            services.AddTransient<RefinementForm>();


            using (var serviceProvider = services.BuildServiceProvider())
            {
                var form = serviceProvider.GetRequiredService<RefinementForm>();
                Application.Run(form);
            }
        }
    }
}