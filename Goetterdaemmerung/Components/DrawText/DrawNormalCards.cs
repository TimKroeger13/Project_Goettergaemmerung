using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Drawing.Text;
using System.Threading.Tasks;
using Project_Goettergaemmerung.Components.Model;
using System.ComponentModel;
using Project_Goettergaemmerung.ExtensionMethods;

namespace Project_Goettergaemmerung.Components.DrawText
{
    public interface IDrawNormalCards
    {
        Bitmap DrawTextForNormalCards(string name, CardSubType subType, bool twoHanded, Condition condition, string modifiers, string text, string flavorText, string scrapped);
    }

    public class DrawNormalCards : IDrawNormalCards
    {
        private readonly IDrawStringWithTopograpy _drawStringWithTopograpy;
        private readonly IPicturesFromArchive _picturesFromArchive;
        private readonly IMeassureStringWithTopograpy _meassureStringWithTopograpy;

        public DrawNormalCards(IDrawStringWithTopograpy drawStringWithTopograpy, IPicturesFromArchive picturesFromArchive, IMeassureStringWithTopograpy meassureStringWithTopograpy)
        {
            _drawStringWithTopograpy = drawStringWithTopograpy;
            _picturesFromArchive = picturesFromArchive;
            _meassureStringWithTopograpy = meassureStringWithTopograpy;
        }

        public Bitmap DrawTextForNormalCards(string name, CardSubType subType, bool twoHanded, Condition condition, string modifiers, string text, string flavorText, string scrapped)
        {
            const int textOffset = 30;
            var textHigth = 40;
            int textHigthFromButtom;
            var textBitmap = new Bitmap(700, 1000);
            textBitmap.SetResolution(120, 120);
            var textRectangle = new RectangleF();

            //FontSize
            var nameFontsize = 36;
            var cardSubTypeFontsize = 28;
            var twoHandedFontsize = 28;
            var conditionFontsize = 28;
            var modifiersFontsize = 36;
            var textFontsize = 24;
            var flavorTextFontsize = 18;
            var scrappedFontsize = 22;

            using (var g = Graphics.FromImage(textBitmap))
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
                    Trimming = StringTrimming.EllipsisWord
                };

                using var formatInlined = new StringFormat()
                {
                    Trimming = StringTrimming.EllipsisWord
                };

                //Headline
                using (var useFont = new Font("Segoe Print", nameFontsize, FontStyle.Bold))
                {
                    textRectangle.Location = new Point(textOffset, textHigth);
                    textRectangle.Size = new Size(640, (int)g.MeasureString(name, useFont, 640, formatCentert).Height);
                    textHigth = (int)textRectangle.Bottom;
                    g.DrawString(name, useFont, Brushes.Black, textRectangle, formatCentert);
                }

                //Dividingline
                var dividingline = _picturesFromArchive.Dividingline;
                g.DrawImage(dividingline, new Point(0, textHigth));
                textHigth += _picturesFromArchive.Dividingline.Height;

                //CardSubType

                if (subType != CardSubType.Empty)
                {
                    var subTypeDescription = subType.GetDescription();

                    using (var useFont = new Font("Segoe Print", cardSubTypeFontsize, FontStyle.Bold))
                    {
                        textRectangle.Location = new Point(textOffset, textHigth);
                        textRectangle.Size = new Size(640, (int)g.MeasureString(subTypeDescription, useFont, 640, formatCentert).Height);
                        textHigth = (int)textRectangle.Bottom;
                        g.DrawString(subTypeDescription, useFont, Brushes.Black, textRectangle, formatCentert);
                    }
                }

                if (twoHanded)
                {
                    using (var useFont = new Font("Segoe Print", twoHandedFontsize, FontStyle.Bold))
                    {
                        textRectangle.Location = new Point(textOffset, textHigth);
                        textRectangle.Size = new Size(640, (int)g.MeasureString("Zweihändig", useFont, 640, formatCentert).Height);
                        textHigth = (int)textRectangle.Bottom;
                        g.DrawString("Zweihändig", useFont, Brushes.Black, textRectangle, formatCentert);
                    }
                }

                if (condition != Condition.Empty)
                {
                    var conditionDescription = condition.GetDescription();

                    using (var useFont = new Font("Segoe Print", conditionFontsize, FontStyle.Bold))
                    {
                        textRectangle.Location = new Point(textOffset, textHigth);
                        textRectangle.Size = new Size(640, (int)g.MeasureString(conditionDescription, useFont, 640, formatCentert).Height);
                        textHigth = (int)textRectangle.Bottom;
                        g.DrawString(conditionDescription, useFont, Brushes.Black, textRectangle, formatCentert);
                    }
                }

                if (modifiers != "")
                {
                    using (var useFont = new Font("Segoe Print", modifiersFontsize, FontStyle.Bold))
                    {
                        textRectangle.Location = new Point(textOffset, textHigth);
                        textRectangle.Size = new Size(640, (int)g.MeasureString(modifiers, useFont, 640, formatCentert).Height);
                        textHigth = (int)textRectangle.Bottom;
                        g.DrawString(modifiers, useFont, Brushes.Black, textRectangle, formatCentert);
                    }
                }

                if (text != "")
                {
                    //_drawStringWithTopograpy.DrawStringOnBitmapWithTopograpy(text, g, textHigth, textFontsize,
                    //     (textOffset, textBitmap.Width), "Segoe Print").g;
                }
            }

            return textBitmap;
        }
    }
}
