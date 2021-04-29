using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Project_Goettergaemmerung.Components;
using Project_Goettergaemmerung.Components.CardInformationGetter;

namespace Project_Goettergaemmerung
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
#if DEBUG
            services.AddTransient<ICardInformationGetter, CsvCardInformation>();
#elif DEBUGODS
            services.AddTransient<ICardInformationGetter, OdsCardInformation>();
#else
            services.AddTransient<ICardInformationGetter, OdsCardInformation>();
#endif
            services.AddTransient<IGenerateCardText, GenerateCardText>();
            services.AddTransient<ICreatePicture, CreatePicture>();
            services.AddSingleton<IUserData, UserData>();

            services.AddSingleton<Form1>();
            using var provider = services.BuildServiceProvider();
            using var mainForm = provider.GetRequiredService<Form1>();
            Application.Run(mainForm);
        }
    }
}
