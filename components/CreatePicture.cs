using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Project_Goettergaemmerung.components
{
    public class CreatePicture
    {
        public CreatePicture()
        {
            Bitmap testBitmap = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\Test_pictures\\Boarder_all_cards.png");
        }

        public void Loadimage()
        {
            Debug.WriteLine("test");
        }

        public Bitmap CreateBitmap()
        {
            Bitmap testBitmap = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\Test_pictures\\Boarder_all_cards.png");
            return testBitmap;
        }

        public Bitmap MergedBitmaps(Bitmap bmp1, Bitmap bmp2, Bitmap bmp3)
        {
            Bitmap result = new Bitmap(700, 1000);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp1, Point.Empty);
                g.DrawImage(bmp2, Point.Empty);
                g.DrawImage(bmp3, Point.Empty);
            }
            return result;
        }
    }
}