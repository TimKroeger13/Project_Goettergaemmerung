using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Project_Goettergaemmerung.components;
using System.Drawing;

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

            var createPicture = new CreatePicture();
            using var mainForm = new Form1();
            //mainForm.RenderImage(Image.FromFile("M:\\Repos\\Project_Goettergaemmerung\\Test_pictures\\Monster_Gott.png"));
            //mainForm.RenderImage(Image.FromFile("M:\\Repos\\Project_Goettergaemmerung\\Test_pictures\\Win.png"))

            using Bitmap bmp1 = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\Test_pictures\\Monster_Gott.png");
            using Bitmap bmp2 = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\Test_pictures\\Boarder_all_cards.png");
            using Bitmap bmp3 = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\Test_pictures\\Win.png");

            mainForm.RenderImage(createPicture.MergedBitmaps(bmp1, bmp2, bmp3));

            mainForm.SaveImage("testname");

            Application.Run(mainForm);
        }
    }
}