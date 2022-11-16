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
using System.Drawing.Imaging;

namespace Project_Goettergaemmerung.Components.DrawText;

public interface IMeassureDrawMonsterCards
{
    bool MeassureTextForMonsterCards(string? name, string? level, Race race, string? text, string? flavorText, int nameFontsize, int lvlRaceFontsize, int textFontsize, int flavorTextFontsize);
}

public class MeassureDrawMonsterCards : IMeassureDrawMonsterCards
{
    private readonly IPicturesFromArchive _picturesFromArchive;
    private readonly IMeassureStringWithTopograpy _meassureStringWithTopograpy;

    public MeassureDrawMonsterCards(IPicturesFromArchive picturesFromArchive, IMeassureStringWithTopograpy meassureStringWithTopograpy)
    {
        _picturesFromArchive = picturesFromArchive;
        _meassureStringWithTopograpy = meassureStringWithTopograpy;
    }

    public bool MeassureTextForMonsterCards(string? name, string? level, Race race, string? text, string? flavorText,
        int nameFontsize, int lvlRaceFontsize, int textFontsize, int flavorTextFontsize)
    {
        const int TextOffset = 30;
        var textHigth = 20;
        var textHigthFromButtom = 1000 - textHigth - 280;
        using var textBitmap = new Bitmap(700, 1000);
        textBitmap.SetResolution(120, 120);
        var textRectangle = new RectangleF();

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
            }

            //Lvl + Race

            using (var useFont = new Font("Segoe Print", lvlRaceFontsize, FontStyle.Bold))
            {
                var lvlRace = "(Stufe " + level + "-" + race.GetDescription() + ")";

                textRectangle.Location = new Point(TextOffset, textHigth);
                textRectangle.Size = new Size(640, (int)g.MeasureString(lvlRace, useFont, 640, formatCentert).Height);
                textHigth = (int)textRectangle.Bottom;
            }

            //Dividingline
            using var dividingline = _picturesFromArchive.Dividingline();
            textHigth += dividingline.Height;

            //Text
            if (text != "")
            {
                textHigth += (int)Math.Round(_meassureStringWithTopograpy.MeassureStringOnBitmapWithTopograpy(text, g, textHigth, textFontsize,
                     (TextOffset, textBitmap.Width), "Segoe Print"));
            }

            //Falvor Text
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
