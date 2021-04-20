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

        public Color BledingMultiplyForPixel(Color pixel1, Color pixel2)
        {
            int red = Convert.ToInt32(pixel1.R / 255d * pixel2.R / 255d * 255d);
            int green = Convert.ToInt32(pixel1.G / 255d * pixel2.G / 255d * 255d);
            int blue = Convert.ToInt32(pixel1.B / 255d * pixel2.B / 255d * 255d);

            return Color.FromArgb(
                255,
                red,
                green,
                blue);
        }

        public Bitmap BledingMultiply(Bitmap bitmap1, Bitmap bitmap2)
        {
            Bitmap result = new Bitmap(700, 1000);
            using (Graphics g = Graphics.FromImage(result))
                for (int i = 0; i < 699; i++)
                {
                    for (int k = 0; k < 999; k++)
                    {
                        result.SetPixel(i, k, BledingMultiplyForPixel(bitmap1.GetPixel(i, k),
                            bitmap2.GetPixel(i, k)));
                    }
                }

            return result;
        }
    }
}