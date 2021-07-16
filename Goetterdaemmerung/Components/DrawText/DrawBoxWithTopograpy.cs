using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Drawing.Text;
using System.Threading.Tasks;
using Project_Goettergaemmerung.Components.Model;

namespace Project_Goettergaemmerung.Components.DrawText
{
    public interface IDrawBoxWithTopograpy
    {
        void DrawBoxOnBitmapWithTopograpy(string text, Graphics g, int fontSize, string fontName,
                    (int top, int buttom) boxhigth, (int left, int rigth) boxwidth);
    }

    public class DrawBoxWithTopograpy : IDrawBoxWithTopograpy
    {
        private readonly ISplitStringInTypography _splitStringInTypography;

        public DrawBoxWithTopograpy(ISplitStringInTypography splitStringInTypography)
        {
            _splitStringInTypography = splitStringInTypography;
        }

        public void DrawBoxOnBitmapWithTopograpy(string text, Graphics g, int fontSize, string fontName,
            (int top, int buttom) boxhigth, (int left, int rigth) boxwidth)
        {
            var splitText = _splitStringInTypography.SplitString(text).ToList();

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            g.PageUnit = GraphicsUnit.Pixel;
            g.CompositingMode = CompositingMode.SourceOver;
            g.CompositingQuality = CompositingQuality.HighQuality;

            float currentCharacterWidth = boxwidth.left;
            float currentCharacterHigth = boxhigth.top;

            foreach (var word in splitText)
            {
                switch (word.Marker)
                {
                    case Typography.Regular:
                        using (var useFont = new Font(fontName, fontSize, FontStyle.Regular))
                        {
                            if (g.MeasureString(word.Item1, useFont, 1000).Width + currentCharacterWidth > boxwidth.rigth)
                            {
                                currentCharacterHigth += g.MeasureString(word.Item1, useFont, 1000).Height;
                                currentCharacterWidth = boxwidth.left;
                            }

                            g.DrawString(word.Item1, useFont, Brushes.Black, currentCharacterWidth, currentCharacterHigth);
                            currentCharacterWidth = g.MeasureString(word.Item1, useFont, 1000).Width + currentCharacterWidth;
                        }
                        break;

                    case Typography.Bold:
                        using (var useFont = new Font(fontName, fontSize, FontStyle.Bold))
                        {
                            if (g.MeasureString(word.Item1, useFont, 1000).Width + currentCharacterWidth > boxwidth.rigth)
                            {
                                currentCharacterHigth += g.MeasureString(word.Item1, useFont, 1000).Height;
                                currentCharacterWidth = boxwidth.left;
                            }

                            g.DrawString(word.Item1, useFont, Brushes.Black, currentCharacterWidth, currentCharacterHigth);
                            currentCharacterWidth = g.MeasureString(word.Item1, useFont, 1000).Width + currentCharacterWidth;
                        }
                        break;

                    case Typography.Italic:
                        using (var useFont = new Font(fontName, fontSize, FontStyle.Italic))
                        {
                            if (g.MeasureString(word.Item1, useFont, 1000).Width + currentCharacterWidth > boxwidth.rigth)
                            {
                                currentCharacterHigth += g.MeasureString(word.Item1, useFont, 1000).Height;
                                currentCharacterWidth = boxwidth.left;
                            }

                            g.DrawString(word.Item1, useFont, Brushes.Black, currentCharacterWidth, currentCharacterHigth);
                            currentCharacterWidth = g.MeasureString(word.Item1, useFont, 1000).Width + currentCharacterWidth;
                        }
                        break;

                    case Typography.LineBreak:
                        using (var useFont = new Font(fontName, fontSize, FontStyle.Regular))
                        {
                            currentCharacterHigth += g.MeasureString(splitText[0].Word, useFont, 1000).Height;
                            currentCharacterWidth = boxwidth.left;
                        }
                        break;
                }
            }

            //using (var useFont = new Font(fontName, fontSize, FontStyle.Regular)) { currentCharacterHigth += g.MeasureString(splitText[0].Word, useFont, 1000).Height; }

            //var x = currentCharacterHigth;
            //var y = boxhigth.buttom;
        }
    }
}
