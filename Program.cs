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
            var loadods = new LoadODS();
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

            Application.Run(mainForm);

            Debug.WriteLine(bmp1.GetPixel(699, 999));
            Debug.WriteLine(bmp4.GetPixel(25, 200));

            Debug.WriteLine(createPicture.BledingMultiplyForPixel(bmp1.GetPixel(25, 200),
                bmp4.GetPixel(25, 200)));
        }
    }
}