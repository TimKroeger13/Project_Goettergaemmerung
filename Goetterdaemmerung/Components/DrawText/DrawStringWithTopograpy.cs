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
    public interface IDrawStringWithTopograpy
    {
        void DrawStringOnBitmapWithTopograpy(string? text, Graphics g, float textHigth, int fontSize,
                    (int offSet, int width) widthBoarders, string? fontName);
    }

    public class DrawStringWithTopograpy : IDrawStringWithTopograpy
    {
        private readonly ISplitStringInTypography _splitStringInTypography;

        public DrawStringWithTopograpy(ISplitStringInTypography splitStringInTypography)
        {
            _splitStringInTypography = splitStringInTypography;
        }

        public void DrawStringOnBitmapWithTopograpy(string? text, Graphics g, float textHigth, int fontSize,
            (int offSet, int width) widthBoarders, string? fontName)
        {
            if (text == null) { text = ""; }
            if (fontName == null) { fontName = ""; }
            var splitText = _splitStringInTypography.SplitString(text).ToList();

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            g.PageUnit = GraphicsUnit.Pixel;
            g.CompositingMode = CompositingMode.SourceOver;
            g.CompositingQuality = CompositingQuality.HighQuality;

            float currentCharacterWidth = widthBoarders.offSet;
            var currentCharacterHigth = textHigth;

            foreach (var (word, marker) in splitText)
            {
                switch (marker)
                {
                    case Typography.Regular:
                        using (var useFont = new Font(fontName, fontSize, FontStyle.Regular))
                        {
                            if (g.MeasureString(word, useFont, 1000).Width + currentCharacterWidth > widthBoarders.width - widthBoarders.offSet)
                            {
                                currentCharacterHigth += g.MeasureString(word, useFont, 1000).Height;
                                currentCharacterWidth = widthBoarders.offSet;
                            }

                            g.DrawString(word, useFont, Brushes.Black, currentCharacterWidth, currentCharacterHigth);
                            currentCharacterWidth = g.MeasureString(word, useFont, 1000).Width + currentCharacterWidth;
                        }
                        break;

                    case Typography.Bold:
                        using (var useFont = new Font(fontName, fontSize, FontStyle.Bold))
                        {
                            if (g.MeasureString(word, useFont, 1000).Width + currentCharacterWidth > widthBoarders.width - widthBoarders.offSet)
                            {
                                currentCharacterHigth += g.MeasureString(word, useFont, 1000).Height;
                                currentCharacterWidth = widthBoarders.offSet;
                            }

                            g.DrawString(word, useFont, Brushes.Black, currentCharacterWidth, currentCharacterHigth);
                            currentCharacterWidth = g.MeasureString(word, useFont, 1000).Width + currentCharacterWidth;
                        }
                        break;

                    case Typography.Italic:
                        using (var useFont = new Font(fontName, fontSize, FontStyle.Italic))
                        {
                            if (g.MeasureString(word, useFont, 1000).Width + currentCharacterWidth > widthBoarders.width - widthBoarders.offSet)
                            {
                                currentCharacterHigth += g.MeasureString(word, useFont, 1000).Height;
                                currentCharacterWidth = widthBoarders.offSet;
                            }

                            g.DrawString(word, useFont, Brushes.Black, currentCharacterWidth, currentCharacterHigth);
                            currentCharacterWidth = g.MeasureString(word, useFont, 1000).Width + currentCharacterWidth;
                        }
                        break;

                    case Typography.LineBreak:
                        using (var useFont = new Font(fontName, fontSize, FontStyle.Regular))
                        {
                            currentCharacterHigth += g.MeasureString(splitText[0].Word, useFont, 1000).Height;
                            currentCharacterWidth = widthBoarders.offSet;
                        }
                        break;
                }
            }
        }
    }
}
