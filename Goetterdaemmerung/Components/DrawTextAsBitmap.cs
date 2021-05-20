using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Project_Goettergaemmerung.Components
{

    public interface IDrawTextAsBitmap
    {
        Bitmap DrawText(string name, string text, string flavorText);
    }

    public class DrawTextAsBitmap : IDrawTextAsBitmap
    {
        private readonly IPicturesFromArchive _picturesFromArchive;

        public DrawTextAsBitmap(IPicturesFromArchive picturesFromArchive)
        {
            _picturesFromArchive = picturesFromArchive;
        }


        public Bitmap DrawText(string name, string text, string flavorText)
        {
            var textHigth = 40;
            int textHigthFromButtom;
            var result = new Bitmap(700, 1000);

            using (var g = Graphics.FromImage(result))
            {

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                g.PageUnit = GraphicsUnit.Pixel;
                g.CompositingMode = CompositingMode.SourceOver;
                g.CompositingQuality = CompositingQuality.HighQuality;

                using var formatCentert = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    //LineAlignment = StringAlignment.Center,
                    Trimming = StringTrimming.EllipsisWord
                };

                using var formatInlined = new StringFormat()
                {
                    Trimming = StringTrimming.EllipsisWord
                };

                var textRectangle = new RectangleF();
                using (var useFont = new Font("Segoe Print", 36, FontStyle.Bold))
                {
                    textRectangle.Location = new Point(30, textHigth);
                    textRectangle.Size = new Size(640, (int)g.MeasureString(name, useFont, 640, formatCentert).Height);
                    textHigth = (int)textRectangle.Bottom;
                    g.DrawString(name, useFont, Brushes.Black, textRectangle, formatCentert);
                }

                var dividingline = _picturesFromArchive.Dividingline;
                g.DrawImage(dividingline, new Point(0, textHigth));
                textHigth += 16;

                using (var useFont = new Font("Segoe Print", 24, FontStyle.Regular))
                {
                    textRectangle.Location = new Point(30, textHigth);
                    textRectangle.Size = new Size(640, (int)g.MeasureString(text, useFont, 640, formatInlined).Height);
                    textHigth = (int)textRectangle.Bottom;
                    g.DrawString(text, useFont, Brushes.Black, textRectangle, formatInlined);
                }

                using (var useFont = new Font("Segoe Print", 19, FontStyle.Italic))
                {
                    textRectangle.Size = new Size(640, (int)g.MeasureString(flavorText, useFont, 640, formatInlined).Height);
                    textHigthFromButtom = (int)textRectangle.Bottom - (int)textRectangle.Top;
                    textRectangle.Location = new Point(30, 1000 - textHigthFromButtom - 40);
                    g.DrawString(flavorText, useFont, Brushes.Black, textRectangle, formatInlined);
                }

                //g.Flush();


            }

            return result;

        }
    }
}
