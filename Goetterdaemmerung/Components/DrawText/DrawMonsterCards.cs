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

namespace Project_Goettergaemmerung.Components.DrawText
{
    public interface IDrawMonsterCards
    {
        Bitmap DrawTextForMonsterCards(string? name, string? level, Race race, string? winText, string? loseText, string? text, string? flavorText);
    }

    public class DrawMonsterCards : IDrawMonsterCards
    {
        private readonly IDrawStringWithTopograpy _drawStringWithTopograpy;
        private readonly IDrawBoxWithTopograpy _drawBoxWithTopograpy;
        private readonly IPicturesFromArchive _picturesFromArchive;
        private readonly IMeassureStringWithTopograpy _meassureStringWithTopograpy;
        private readonly IMeassureBoxWithTopograpy _meassureBoxWithTopograpy;
        private readonly IResizeMonterFont _resizeMonterFont;
        private readonly IMeassureDrawMonsterCards _meassureDrawMonsterCards;

        public DrawMonsterCards(IDrawStringWithTopograpy drawStringWithTopograpy, IPicturesFromArchive picturesFromArchive, IMeassureStringWithTopograpy meassureStringWithTopograpy, IMeassureBoxWithTopograpy meassureBoxWithTopograpy, IDrawBoxWithTopograpy drawBoxWithTopograpy, IResizeMonterFont resizeMonterFont, IMeassureDrawMonsterCards meassureDrawMonsterCards)
        {
            _drawStringWithTopograpy = drawStringWithTopograpy;
            _picturesFromArchive = picturesFromArchive;
            _meassureStringWithTopograpy = meassureStringWithTopograpy;
            _meassureBoxWithTopograpy = meassureBoxWithTopograpy;
            _drawBoxWithTopograpy = drawBoxWithTopograpy;
            _resizeMonterFont = resizeMonterFont;
            _meassureDrawMonsterCards = meassureDrawMonsterCards;
        }

        public Bitmap DrawTextForMonsterCards(string? name, string? level, Race race, string? winText, string? loseText, string? text, string? flavorText)
        {
            const int TextOffset = 30;
            var textHigth = 20;
            var textHigthFromButtom = 1000 - textHigth - 280;
            var textBitmap = new Bitmap(700, 1000);
            textBitmap.SetResolution(120, 120);
            var textRectangle = new RectangleF();

            const int WinLoseBoxHigth = 760;
            const int WinLoseBoxHigthCardEnd = 980;
            const int WinLeftBoarder = 30;
            const int WinRigthBoarder = 340;
            const int LoseLeftBoarder = 360;
            const int LoseRigthBoarder = 670;

            //FontSize
            var nameFontsize = 36;
            var lvlRaceFontsize = 28;
            var textFontsize = 24;
            var flavorTextFontsize = 18;
            var winTextFontsize = 20;
            var loseTextFontsize = 20;

            //MainFointSize
            var fontsizeIsCorrect = false;
            var run = 0;
            while (!fontsizeIsCorrect)
            {
                var resizedFontsizes = _resizeMonterFont.NewFontSize(run, nameFontsize, lvlRaceFontsize, textFontsize,
                    flavorTextFontsize);

                fontsizeIsCorrect = _meassureDrawMonsterCards.MeassureTextForMonsterCards(name, level, race, text, flavorText,
                    resizedFontsizes.nameFontsize, resizedFontsizes.lvlRaceFontsize, resizedFontsizes.textFontsize, resizedFontsizes.flavorTextFontsize);

                if (fontsizeIsCorrect)
                {
                    nameFontsize = resizedFontsizes.nameFontsize;
                    lvlRaceFontsize = resizedFontsizes.lvlRaceFontsize;
                    textFontsize = resizedFontsizes.textFontsize;
                    flavorTextFontsize = resizedFontsizes.flavorTextFontsize;
                }

                run++;
            }

            //WinFontsize
            var winFontsizeIsCorrect = false;
            run = 0;
            while (!winFontsizeIsCorrect)
            {
                winFontsizeIsCorrect = _meassureBoxWithTopograpy.MeassureBoxOnBitmapWithTopograpy(winText, winTextFontsize - run, "Segoe Print",
                    (WinLoseBoxHigth, WinLoseBoxHigthCardEnd), (WinLeftBoarder, WinRigthBoarder));

                if (winFontsizeIsCorrect)
                {
                    winTextFontsize -= run;
                }

                run++;
            }

            //LoseFontsize
            var loseFontsizeIsCorrect = false;
            run = 0;
            while (!loseFontsizeIsCorrect)
            {
                loseFontsizeIsCorrect = _meassureBoxWithTopograpy.MeassureBoxOnBitmapWithTopograpy(loseText, loseTextFontsize - run, "Segoe Print",
                    (WinLoseBoxHigth, WinLoseBoxHigthCardEnd), (LoseLeftBoarder, LoseRigthBoarder));

                if (loseFontsizeIsCorrect)
                {
                    loseTextFontsize -= run;
                }

                run++;
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

                //Lvl + Race

                using (var useFont = new Font("Segoe Print", lvlRaceFontsize, FontStyle.Bold))
                {
                    var lvlRace = "(Stufe " + level + "-" + race.GetDescription() + ")";

                    textRectangle.Location = new Point(TextOffset, textHigth);
                    textRectangle.Size = new Size(640, (int)g.MeasureString(lvlRace, useFont, 640, formatCentert).Height);
                    textHigth = (int)textRectangle.Bottom;
                    g.DrawString(lvlRace, useFont, Brushes.Black, textRectangle, formatCentert);
                }

                //Dividingline
                using var dividingline = _picturesFromArchive.Dividingline();
                g.DrawImage(dividingline, new Point(0, textHigth));
                textHigth += dividingline.Height;

                //Text
                if (text != "")
                {
                    _drawStringWithTopograpy.DrawStringOnBitmapWithTopograpy(text, g, textHigth, textFontsize,
                    (TextOffset, textBitmap.Width), "Segoe Print");

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
                    g.DrawString(flavorText, useFont, Brushes.Black, textRectangle, formatInlined);
                }

                //Win
                if (winText != "")
                {
                    _drawBoxWithTopograpy.DrawBoxOnBitmapWithTopograpy(winText, g, winTextFontsize, "Segoe Print",
                        (WinLoseBoxHigth, WinLoseBoxHigthCardEnd), (WinLeftBoarder, WinRigthBoarder));
                }

                //Lose
                if (loseText != "")
                {
                    _drawBoxWithTopograpy.DrawBoxOnBitmapWithTopograpy(loseText, g, loseTextFontsize, "Segoe Print",
                        (WinLoseBoxHigth, WinLoseBoxHigthCardEnd), (LoseLeftBoarder, LoseRigthBoarder));
                }
            }

            return textBitmap;
        }
    }
}
