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
    public interface IMeassureStringWithTopograpy
    {
        float MeassureStringOnBitmapWithTopograpy(string text, Graphics g, float textHigth, int fontSize, (int offSet, int width) widthBoarders, string fontName);
    }

    public class MeassureStringWithTopograpy : IMeassureStringWithTopograpy
    {
        private readonly ISplitStringInTypography _splitStringInTypography;

        public MeassureStringWithTopograpy(ISplitStringInTypography splitStringInTypography)
        {
            _splitStringInTypography = splitStringInTypography;
        }

        public float MeassureStringOnBitmapWithTopograpy(string text, Graphics g, float textHigth, int fontSize,
            (int offSet, int width) widthBoarders, string fontName)
        {
            var splitText = _splitStringInTypography.SplitString(text).ToList();

            float currentCharacterWidth = widthBoarders.offSet;
            float currentCharacterHigth = textHigth;

            foreach (var word in splitText)
            {
                switch (word.Item2)
                {
                    case Typography.Regular:
                        using (var useFont = new Font(fontName, fontSize, FontStyle.Regular))
                        {
                            if (g.MeasureString(word.Item1, useFont, 1000).Width + currentCharacterWidth > widthBoarders.width - widthBoarders.offSet)
                            {
                                currentCharacterHigth += g.MeasureString(word.Item1, useFont, 1000).Height;
                                currentCharacterWidth = widthBoarders.offSet;
                            }
                            currentCharacterWidth = g.MeasureString(word.Item1, useFont, 1000).Width + currentCharacterWidth;
                        }
                        break;

                    case Typography.Bold:
                        using (var useFont = new Font(fontName, fontSize, FontStyle.Bold))
                        {
                            if (g.MeasureString(word.Item1, useFont, 1000).Width + currentCharacterWidth > widthBoarders.width - widthBoarders.offSet)
                            {
                                currentCharacterHigth += g.MeasureString(word.Item1, useFont, 1000).Height;
                                currentCharacterWidth = widthBoarders.offSet;
                            }
                            currentCharacterWidth = g.MeasureString(word.Item1, useFont, 1000).Width + currentCharacterWidth;
                        }
                        break;

                    case Typography.Italic:
                        using (var useFont = new Font(fontName, fontSize, FontStyle.Italic))
                        {
                            if (g.MeasureString(word.Item1, useFont, 1000).Width + currentCharacterWidth > widthBoarders.width - widthBoarders.offSet)
                            {
                                currentCharacterHigth += g.MeasureString(word.Item1, useFont, 1000).Height;
                                currentCharacterWidth = widthBoarders.offSet;
                            }
                            currentCharacterWidth = g.MeasureString(word.Item1, useFont, 1000).Width + currentCharacterWidth;
                        }
                        break;
                }
            }
            using (var useFont = new Font(fontName, fontSize, FontStyle.Regular)) { currentCharacterHigth += g.MeasureString(splitText[0].Word, useFont, 1000).Height; }

            return currentCharacterHigth;
        }
    }
}
