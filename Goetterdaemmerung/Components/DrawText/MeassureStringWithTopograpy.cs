﻿using System.Drawing.Drawing2D;
using System.Drawing.Text;
using Project_Goettergaemmerung.Components.Model;

namespace Project_Goettergaemmerung.Components.DrawText;

public interface IMeassureStringWithTopograpy
{
    float MeassureStringOnBitmapWithTopograpy(string? text, Graphics g, float textHigth, int fontSize, (int offSet, int width) widthBoarders, string fontName);
}

public class MeassureStringWithTopograpy : IMeassureStringWithTopograpy
{
    private readonly ISplitStringInTypography _splitStringInTypography;

    public MeassureStringWithTopograpy(ISplitStringInTypography splitStringInTypography)
    {
        _splitStringInTypography = splitStringInTypography;
    }

    public float MeassureStringOnBitmapWithTopograpy(string? text, Graphics g, float textHigth, int fontSize,
        (int offSet, int width) widthBoarders, string fontName)
    {
        if (text == null) { text = ""; }
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
                        if (g.MeasureString(word, useFont, 2000).Width + currentCharacterWidth > widthBoarders.width - widthBoarders.offSet)
                        {
                            currentCharacterHigth += g.MeasureString(word, useFont, 2000).Height;
                            currentCharacterWidth = widthBoarders.offSet;
                        }
                        currentCharacterWidth = g.MeasureString(word, useFont, 2000).Width + currentCharacterWidth;
                    }
                    break;

                case Typography.Bold:
                    using (var useFont = new Font(fontName, fontSize, FontStyle.Bold))
                    {
                        if (g.MeasureString(word, useFont, 2000).Width + currentCharacterWidth > widthBoarders.width - widthBoarders.offSet)
                        {
                            currentCharacterHigth += g.MeasureString(word, useFont, 2000).Height;
                            currentCharacterWidth = widthBoarders.offSet;
                        }
                        currentCharacterWidth = g.MeasureString(word, useFont, 2000).Width + currentCharacterWidth;
                    }
                    break;

                case Typography.Italic:
                    using (var useFont = new Font(fontName, fontSize, FontStyle.Italic))
                    {
                        if (g.MeasureString(word, useFont, 2000).Width + currentCharacterWidth > widthBoarders.width - widthBoarders.offSet)
                        {
                            currentCharacterHigth += g.MeasureString(word, useFont, 2000).Height;
                            currentCharacterWidth = widthBoarders.offSet;
                        }
                        currentCharacterWidth = g.MeasureString(word, useFont, 2000).Width + currentCharacterWidth;
                    }
                    break;

                case Typography.LineBreak:
                    using (var useFont = new Font(fontName, fontSize, FontStyle.Regular))
                    {
                        currentCharacterHigth += g.MeasureString(splitText[0].Word, useFont, 2000).Height;
                        currentCharacterWidth = widthBoarders.offSet;
                    }
                    break;
            }
        }
        using (var useFont = new Font(fontName, fontSize, FontStyle.Regular)) { currentCharacterHigth += g.MeasureString(splitText[0].Word, useFont, 2000).Height; }

        return currentCharacterHigth - textHigth;
    }
}
