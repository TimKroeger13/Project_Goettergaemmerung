using System.Drawing.Drawing2D;
using System.Drawing.Text;
using Project_Goettergaemmerung.Components.Model;
using Project_Goettergaemmerung.ExtensionMethods;

namespace Project_Goettergaemmerung.Components.DrawText;

public interface IMeassureDrawNormalCards
{
    bool MeassureTextForNormalCards(string? name, CardSubType subType, bool twoHanded, Condition condition, string? modifiers, string? center, string? text, string? flavorText, string? scrapped,
        int nameFontsize, int cardSubTypeFontsize, int twoHandedFontsize, int conditionFontsize, int modifiersFontsize, int centerFontsize, int textFontsize,
        int flavorTextFontsize, int scrappedFontsize);
}

public class MeassureDrawNormalCards : IMeassureDrawNormalCards
{
    private readonly IPicturesFromArchive _picturesFromArchive;
    private readonly IMeassureStringWithTopograpy _meassureStringWithTopograpy;

    public MeassureDrawNormalCards(IPicturesFromArchive picturesFromArchive, IMeassureStringWithTopograpy meassureStringWithTopograpy)
    {
        _picturesFromArchive = picturesFromArchive;
        _meassureStringWithTopograpy = meassureStringWithTopograpy;
    }

    public bool MeassureTextForNormalCards(string? name, CardSubType subType, bool twoHanded, Condition condition, string? modifiers, string? center, string? text, string? flavorText, string? scrapped,
        int nameFontsize, int cardSubTypeFontsize, int twoHandedFontsize, int conditionFontsize, int modifiersFontsize, int centerFontsize,
        int textFontsize, int flavorTextFontsize, int scrappedFontsize)
    {
        const int TextOffset = 30;
        var textHigth = 20;
        var textHigthFromButtom = 2000 - textHigth;
        using var textBitmap = new Bitmap(1400, 2000);
        textBitmap.SetResolution(120, 120);
        var textRectangle = new RectangleF();

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
                if ((int)g.MeasureString(name, useFont, 640, formatCentert).Width > (640 - TextOffset))
                {
                    return false;
                }

                textRectangle.Location = new Point(TextOffset, textHigth);
                textRectangle.Size = new Size(640, (int)g.MeasureString(name, useFont, 640, formatCentert).Height);
                textHigth = (int)textRectangle.Bottom;
            }

            //Dividingline
            using var dividingline = _picturesFromArchive.Dividingline();
            textHigth += dividingline.Height;

            //CardSubType

            if (subType != CardSubType.Empty)
            {
                var subTypeDescription = subType.GetDescription();

                using var useFont = new Font("Segoe Print", cardSubTypeFontsize, FontStyle.Bold);
                textRectangle.Location = new Point(TextOffset, textHigth);
                textRectangle.Size = new Size(640, (int)g.MeasureString(subTypeDescription, useFont, 640, formatCentert).Height);
                textHigth = (int)textRectangle.Bottom;
            }

            if (twoHanded)
            {
                using var useFont = new Font("Segoe Print", twoHandedFontsize, FontStyle.Bold);
                textRectangle.Location = new Point(TextOffset, textHigth);
                textRectangle.Size = new Size(640, (int)g.MeasureString("Zweihändig", useFont, 640, formatCentert).Height);
                textHigth = (int)textRectangle.Bottom;
            }

            if (condition != Condition.Empty)
            {
                var conditionDescription = condition.GetDescription();

                using var useFont = new Font("Segoe Print", conditionFontsize, FontStyle.Bold);
                textRectangle.Location = new Point(TextOffset, textHigth);
                textRectangle.Size = new Size(640, (int)g.MeasureString(conditionDescription, useFont, 640, formatCentert).Height);
                textHigth = (int)textRectangle.Bottom;
            }

            if (modifiers != "")
            {
                using var useFont = new Font("Segoe Print", modifiersFontsize, FontStyle.Bold);
                textRectangle.Location = new Point(TextOffset, textHigth);
                textRectangle.Size = new Size(640, (int)g.MeasureString(modifiers, useFont, 640, formatCentert).Height);
                textHigth = (int)textRectangle.Bottom;
            }

            if (center != "")
            {
                using var useFont = new Font("Segoe Print", centerFontsize, FontStyle.Bold);
                textRectangle.Location = new Point(TextOffset, textHigth);
                textRectangle.Size = new Size(640, (int)g.MeasureString(center, useFont, 640, formatCentert).Height);
                textHigth = (int)textRectangle.Bottom;
            }

            if (text != "")
            {
                if (text == null) { text = ""; }
                textHigth += (int)Math.Round(_meassureStringWithTopograpy.MeassureStringOnBitmapWithTopograpy(text, g, textHigth, textFontsize,
                     (TextOffset, textBitmap.Width), "Segoe Print"));
            }

            if (scrapped != "")
            {
                if (scrapped == null) { scrapped = ""; }
                textHigthFromButtom -= (int)Math.Round(_meassureStringWithTopograpy.MeassureStringOnBitmapWithTopograpy(scrapped, g, textHigth, scrappedFontsize,
                                        (TextOffset, textBitmap.Width), "Segoe Print"));

                //ScappedLine
                using var scappedLine = _picturesFromArchive.Scrapped();
                textHigthFromButtom -= scappedLine.Height;
            }

            if (flavorText != "")
            {
                using var useFont = new Font("Segoe Print", flavorTextFontsize, FontStyle.Italic);
                textRectangle.Size = new Size(640, (int)g.MeasureString(flavorText, useFont, 640, formatInlined).Height);
                var textBoxHigth = (int)textRectangle.Bottom - (int)textRectangle.Top;
                textHigthFromButtom -= textBoxHigth;
                textRectangle.Location = new Point(TextOffset, textHigthFromButtom);
            }
        }

        return textHigth < textHigthFromButtom;
    }
}
