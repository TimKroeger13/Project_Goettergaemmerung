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
        private static IServiceCollection s_services;
        public static IServiceProvider Services { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            s_services = new ServiceCollection();
#if DEBUG
            s_services.AddTransient<ICardInformationGetter, CsvCardInformation>();
#elif DEBUGODS
            s_services.AddTransient<ICardInformationGetter, OdsCardInformation>();
#else
            s_services.AddTransient<ICardInformationGetter, OdsCardInformation>();
#endif
            s_services.AddSingleton<IGenerateCardText, GenerateCardText>();
            var createPicture = new CreatePicture();
            using var mainForm = new Form1();
            //mainForm.RenderImage(Image.FromFile("M:\\Repos\\Project_Goettergaemmerung\\Test_pictures\\Monster_Gott.png"));
            //mainForm.RenderImage(Image.FromFile("M:\\Repos\\Project_Goettergaemmerung\\Test_pictures\\Win.png"))

            using var bmp1 = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\Test_pictures\\Monster_Gott.png");
            using var bmp2 = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\Test_pictures\\Boarder_all_cards.png");
            using var bmp3 = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\Test_pictures\\Win.png");
            using var bmp4 = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\Test_pictures\\Karten_filter.png");
            mainForm.RenderImage(createPicture.MergedBitmaps(createPicture.BledingMultiply(bmp1, bmp4),
            bmp2, bmp3));

            //mainForm.RenderImage(createPicture.BledingMultiply(bmp1, bmp4));
            mainForm.SaveImage("testname");
            using var provider = s_services.BuildServiceProvider();
            Services = provider;
            var generateCardText = Services.GetService<IGenerateCardText>();
            generateCardText.PrintCards();
            Application.Run(mainForm);
        }
    }
}
