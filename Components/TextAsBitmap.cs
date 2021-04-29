using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Project_Goettergaemmerung.Components
{
    public interface ITextAsBitmap
    {
        Bitmap DrawTestOnBitmap(string text, int x, int y);
    }

    public class TextAsBitmap : ITextAsBitmap
    {
        public Bitmap DrawTestOnBitmap(string text, int x, int y)
        {
            Bitmap result = new Bitmap(700, 1000);
            RectangleF rectf = new RectangleF(70, 90, 90, 50);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawString("yourText", new Font("Tahoma", 8), Brushes.Black, rectf);
                //g.MeasureString
            }
            return result;
        }
    }
}
