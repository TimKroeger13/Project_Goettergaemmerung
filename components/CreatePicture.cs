using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Project_Goettergaemmerung.Components
{
    public interface ICreatePicture
    {
        Bitmap BlendingMultiply(Bitmap bitmap1, Bitmap bitmap2);

        Bitmap MergedBitmaps(List<Bitmap> bitmapList);
    }

    public class CreatePicture : ICreatePicture
    {
        private const float RgbDivisor = 1 / 255f;

        public Bitmap MergedBitmaps(List<Bitmap> bitmapList)
        {
            var result = new Bitmap(700, 1000);
            using (var g = Graphics.FromImage(result))
            {
                foreach (var item in bitmapList)
                {
                    g.DrawImage(item, Point.Empty);
                }
            }
            return result;
        }

        private static Color BlendingMultiplyForPixel(Color pixel1, Color pixel2)
        {
            var red = Convert.ToInt32(pixel1.R / 255d * pixel2.R / 255d * 255d);
            var green = Convert.ToInt32(pixel1.G / 255d * pixel2.G / 255d * 255d);
            var blue = Convert.ToInt32(pixel1.B / 255d * pixel2.B / 255d * 255d);
            return Color.FromArgb(255, red, green, blue);
        }

        public Bitmap BlendingMultiply(Bitmap bitmap1, Bitmap bitmap2)
        {
            var result = new Bitmap(700, 1000);
            using (var g = Graphics.FromImage(result))
            {
                for (var i = 0; i < result.Width; i++)
                {
                    for (var k = 0; k < result.Height; k++)
                    {
                        result.SetPixel(i, k, BlendingMultiplyForPixel(bitmap1.GetPixel(i, k), bitmap2.GetPixel(i, k)));
                    }
                }
            }

            return result;
        }
    }
}
