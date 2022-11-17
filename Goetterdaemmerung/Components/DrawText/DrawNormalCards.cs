using System.Drawing.Drawing2D;
using System.Drawing.Text;
using Project_Goettergaemmerung.Components.Model;
using Project_Goettergaemmerung.ExtensionMethods;

namespace Project_Goettergaemmerung.Components.DrawText;

public interface IDrawNormalCards
{
    Bitmap DrawTextForNormalCards(string? name, CardSubType subType, bool twoHanded, Condition condition, string? modifiers, string? center, string? text, string? flavorText, string? scrapped);
}

public class DrawNormalCards : IDrawNormalCards
{
    private readonly IDrawStringWithTopograpy _drawStringWithTopograpy;
    private readonly IPicturesFromArchive _picturesFromArchive;
    private readonly IMeassureStringWithTopograpy _meassureStringWithTopograpy;
    private readonly IMeassureDrawNormalCards _meassureDrawNormalCards;
    private readonly IResizeFont _resizeFont;

    public DrawNormalCards(IDrawStringWithTopograpy drawStringWithTopograpy, IPicturesFromArchive picturesFromArchive, IMeassureStringWithTopograpy meassureStringWithTopograpy,
        IMeassureDrawNormalCards meassureDrawNormalCards, IResizeFont resizeFont)
    {
        _drawStringWithTopograpy = drawStringWithTopograpy;
        _picturesFromArchive = picturesFromArchive;
        _meassureStringWithTopograpy = meassureStringWithTopograpy;
        _meassureDrawNormalCards = meassureDrawNormalCards;
        _resizeFont = resizeFont;
    }

    public Bitmap DrawTextForNormalCards(string? name, CardSubType subType, bool twoHanded, Condition condition, string? modifiers, string? center, string? text, string? flavorText, string? scrapped)
    {
        const int TextOffset = 30;
        var textHigth = 20;
        var textHigthFromButtom = 1000 - textHigth;
        var textBitmap = new Bitmap(700, 1000);
        textBitmap.SetResolution(120, 120);
        var textRectangle = new RectangleF();

        //FontSize
        var nameFontsize = 36;
        var cardSubTypeFontsize = 28;
        var twoHandedFontsize = 28;
        var conditionFontsize = 28;
        var modifiersFontsize = 36;
        var centerFontsize = 28;
        var textFontsize = 24;
        var flavorTextFontsize = 18;
        var scrappedFontsize = 22;

        var fontsizeIsCorrect = false;
        for (var run = 0; !fontsizeIsCorrect; run++)
        {
            var resizedFontsizes = _resizeFont.NewFontSize(run, nameFontsize, cardSubTypeFontsize, twoHandedFontsize, conditionFontsize,
                modifiersFontsize, centerFontsize, textFontsize, flavorTextFontsize, scrappedFontsize);

            fontsizeIsCorrect = _meassureDrawNormalCards.MeassureTextForNormalCards(name, subType, twoHanded, condition, modifiers, center, text, flavorText, scrapped,
            resizedFontsizes.nameFontsize, resizedFontsizes.cardSubTypeFontsize, resizedFontsizes.twoHandedFontsize,
            resizedFontsizes.conditionFontsize, resizedFontsizes.modifiersFontsize, resizedFontsizes.centerFontsize, resizedFontsizes.textFontsize,
            resizedFontsizes.flavorTextFontsize, resizedFontsizes.scrappedFontsize);

            if (fontsizeIsCorrect)
            {
                nameFontsize = resizedFontsizes.nameFontsize;
                cardSubTypeFontsize = resizedFontsizes.cardSubTypeFontsize;
                twoHandedFontsize = resizedFontsizes.twoHandedFontsize;
                conditionFontsize = resizedFontsizes.conditionFontsize;
                modifiersFontsize = resizedFontsizes.modifiersFontsize;
                centerFontsize = resizedFontsizes.centerFontsize;
                textFontsize = resizedFontsizes.textFontsize;
                flavorTextFontsize = resizedFontsizes.flavorTextFontsize;
                scrappedFontsize = resizedFontsizes.scrappedFontsize;
            }
        }

        //Graphic
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
                textRectangle.Location = new Point(TextOffset, textHigth);
                textRectangle.Size = new Size(640, (int)g.MeasureString(name, useFont, 640, formatCentert).Height);
                textHigth = (int)textRectangle.Bottom;
                g.DrawString(name, useFont, Brushes.Black, textRectangle, formatCentert);
            }

            //Dividingline
            using var dividingline = _picturesFromArchive.Dividingline();
            g.DrawImage(dividingline, new Point(0, textHigth));
            textHigth += dividingline.Height;

            //CardSubType
            if (subType != CardSubType.Empty)
            {
                var subTypeDescription = subType.GetDescription();

                using var useFont = new Font("Segoe Print", cardSubTypeFontsize, FontStyle.Bold);
                textRectangle.Location = new Point(TextOffset, textHigth);
                textRectangle.Size = new Size(640, (int)g.MeasureString(subTypeDescription, useFont, 640, formatCentert).Height);
                textHigth = (int)textRectangle.Bottom;
                g.DrawString(subTypeDescription, useFont, Brushes.Black, textRectangle, formatCentert);
            }

            if (twoHanded)
            {
                using var useFont = new Font("Segoe Print", twoHandedFontsize, FontStyle.Bold);
                textRectangle.Location = new Point(TextOffset, textHigth);
                textRectangle.Size = new Size(640, (int)g.MeasureString("Zweihändig", useFont, 640, formatCentert).Height);
                textHigth = (int)textRectangle.Bottom;
                g.DrawString("Zweihändig", useFont, Brushes.Black, textRectangle, formatCentert);
            }

            if (condition != Condition.Empty)
            {
                var conditionDescription = condition.GetDescription();

                using var useFont = new Font("Segoe Print", conditionFontsize, FontStyle.Bold);
                textRectangle.Location = new Point(TextOffset, textHigth);
                textRectangle.Size = new Size(640, (int)g.MeasureString(conditionDescription, useFont, 640, formatCentert).Height);
                textHigth = (int)textRectangle.Bottom;
                g.DrawString(conditionDescription, useFont, Brushes.Black, textRectangle, formatCentert);
            }

            if (modifiers != "")
            {
                using var useFont = new Font("Segoe Print", modifiersFontsize, FontStyle.Bold);
                textRectangle.Location = new Point(TextOffset, textHigth);
                textRectangle.Size = new Size(640, (int)g.MeasureString(modifiers, useFont, 640, formatCentert).Height);
                textHigth = (int)textRectangle.Bottom;
                g.DrawString(modifiers, useFont, Brushes.Black, textRectangle, formatCentert);
            }

            if (center != "")
            {
                using var useFont = new Font("Segoe Print", centerFontsize, FontStyle.Bold);
                textRectangle.Location = new Point(TextOffset, textHigth);
                textRectangle.Size = new Size(640, (int)g.MeasureString(center, useFont, 640, formatCentert).Height);
                textHigth = (int)textRectangle.Bottom;
                g.DrawString(center, useFont, Brushes.Black, textRectangle, formatCentert);
            }

            if (text != "")
            {
                if (text == null) { text = ""; }
                _drawStringWithTopograpy.DrawStringOnBitmapWithTopograpy(text, g, textHigth, textFontsize,
                (TextOffset, textBitmap.Width), "Segoe Print");

                textHigth += (int)Math.Round(_meassureStringWithTopograpy.MeassureStringOnBitmapWithTopograpy(text, g, textHigth, textFontsize,
                     (TextOffset, textBitmap.Width), "Segoe Print"));
            }

            if (scrapped != "")
            {
                if (scrapped == null) { scrapped = ""; }
                textHigthFromButtom -= (int)Math.Round(_meassureStringWithTopograpy.MeassureStringOnBitmapWithTopograpy(scrapped, g, textHigth, textFontsize,
                                        (TextOffset, textBitmap.Width), "Segoe Print"));

                _drawStringWithTopograpy.DrawStringOnBitmapWithTopograpy(scrapped, g, textHigthFromButtom, scrappedFontsize,
                (TextOffset, textBitmap.Width), "Segoe Print");

                //ScappedLine
                using var scappedLine = _picturesFromArchive.Scrapped();
                textHigthFromButtom -= scappedLine.Height;
                g.DrawImage(scappedLine, new Point(0, textHigthFromButtom));
            }

            if (flavorText != "")
            {
                using var useFont = new Font("Segoe Print", flavorTextFontsize, FontStyle.Italic);
                textRectangle.Size = new Size(640, (int)g.MeasureString(flavorText, useFont, 640, formatInlined).Height);
                var textBoxHigth = (int)textRectangle.Bottom - (int)textRectangle.Top;
                textHigthFromButtom -= textBoxHigth;
                textRectangle.Location = new Point(TextOffset, textHigthFromButtom);
                g.DrawString(flavorText, useFont, Brushes.Black, textRectangle, formatInlined);
            }
        }

        return textBitmap;
    }
}
