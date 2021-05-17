using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Project_Goettergaemmerung.Components
{
    public interface IDrawTextAsBitmap
    {
        Bitmap DrawText(string Text);
    }
    public class DrawTextAsBitmap : IDrawTextAsBitmap
    {
        private int x = 50;
        private int y = 50;
        private Font font = new Font("Georgia", 32); //new Font("Tahoma",8)
        // private Font font = new Font(FontFamily.GenericSansSerif, 32); 

        public Bitmap DrawText(string Text)
        {
            RectangleF rectf = new RectangleF(0, 100, 700, 400);
            var result = new Bitmap(700, 1000);

            using (var g = Graphics.FromImage(result))
            {

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                StringFormat format = new StringFormat()
                {
                    //Alignment = StringAlignment.Center,
                    //LineAlignment = StringAlignment.Center,
                    Trimming = StringTrimming.EllipsisWord
                };
                g.DrawString(Text, font, Brushes.Black, rectf, format);
                g.Flush();
            }

            return result;

            //var result = new Bitmap(700, 1000);
            //using (var g = Graphics.FromImage(result))
            //{
            //    g.DrawString(Text, font, blackBrush, x, y);
            //}
            //return result;
        }
    }
}
