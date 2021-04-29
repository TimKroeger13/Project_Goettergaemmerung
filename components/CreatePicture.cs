using System;
using System.Collections.Generic;
using System.Drawing;

namespace Project_Goettergaemmerung.Components
{
    public interface ICreatePicture
    {
        Bitmap BledingMultiply(Bitmap bitmap1, Bitmap bitmap2);

        Bitmap MergedBitmaps(List<Bitmap> bitmapList);
    }

    public class CreatePicture : ICreatePicture
    {
        public Bitmap MergedBitmaps(List<Bitmap> bitmapList)
        {
            Bitmap result = new Bitmap(700, 1000);
            using (Graphics g = Graphics.FromImage(result))
            {
                foreach (var item in bitmapList)
                {
                    g.DrawImage(item, Point.Empty);
                }
            }
            return result;
        }

        private Color BlendingMultiplyForPixel(Color pixel1, Color pixel2)
        {
            var red = Convert.ToInt32(pixel1.R / 255d * pixel2.R / 255d * 255d);
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
            {
                for (int i = 0; i < 699; i++)
                {
                    for (int k = 0; k < 999; k++)
                    {
                        result.SetPixel(i, k, BlendingMultiplyForPixel(bitmap1.GetPixel(i, k),
                            bitmap2.GetPixel(i, k)));
                    }
                }
            }

            return result;
        }
    }
}
