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
        Bitmap DrawTextForMonsterCards(string name, string level, Race race, string winText, string loseText, string text, string flavorText);
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

        //private readonly IMeassureDrawNormalCards _meassureDrawNormalCards;

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

        public Bitmap DrawTextForMonsterCards(string name, string level, Race race, string winText, string loseText, string text, string flavorText)
        {
            const int textOffset = 30;
            var textHigth = 20;
            int textHigthFromButtom = 1000 - textHigth - 280;
            var textBitmap = new Bitmap(700, 1000);
            textBitmap.SetResolution(120, 120);
            var textRectangle = new RectangleF();

            int winLoseBoxHigth = 760;
            int winLoseBoxHigthCardEnd = 980;
            int winLeftBoarder = 30;
            int winRigthBoarder = 340;
            int loseLeftBoarder = 360;
            int loseRigthBoarder = 670;

            //FontSize
            var nameFontsize = 36;
            var lvlRaceFontsize = 28;
            var textFontsize = 24;
            var flavorTextFontsize = 18;
            var winTextFontsize = 20;
            var loseTextFontsize = 20;

            //MainFointSize
            var FontsizeIsCorrect = false;
            var run = 0;
            while (!FontsizeIsCorrect)
            {
                var ResizedFontsizes = _resizeMonterFont.NewFontSize(run, nameFontsize, lvlRaceFontsize, textFontsize,
                    flavorTextFontsize);

                FontsizeIsCorrect = _meassureDrawMonsterCards.MeassureTextForMonsterCards(name, level, race, text, flavorText,
                    ResizedFontsizes.nameFontsize, ResizedFontsizes.lvlRaceFontsize, ResizedFontsizes.textFontsize, ResizedFontsizes.flavorTextFontsize);

                if (FontsizeIsCorrect)
                {
                    nameFontsize = ResizedFontsizes.nameFontsize;
                    lvlRaceFontsize = ResizedFontsizes.lvlRaceFontsize;
                    textFontsize = ResizedFontsizes.textFontsize;
                    flavorTextFontsize = ResizedFontsizes.flavorTextFontsize;
                }

                run++;
            }

            //WinFontsize
            var winFontsizeIsCorrect = false;
            run = 0;
            while (!winFontsizeIsCorrect)
            {
                winFontsizeIsCorrect = _meassureBoxWithTopograpy.MeassureBoxOnBitmapWithTopograpy(winText, winTextFontsize - run, "Segoe Print",
                    (winLoseBoxHigth, winLoseBoxHigthCardEnd), (winLeftBoarder, winRigthBoarder));

                if (winFontsizeIsCorrect)
                {
                    winTextFontsize = winTextFontsize - run;
                }

                run++;
            }

            //LoseFontsize
            var loseFontsizeIsCorrect = false;
            run = 0;
            while (!loseFontsizeIsCorrect)
            {
                loseFontsizeIsCorrect = _meassureBoxWithTopograpy.MeassureBoxOnBitmapWithTopograpy(loseText, loseTextFontsize - run, "Segoe Print",
                    (winLoseBoxHigth, winLoseBoxHigthCardEnd), (loseLeftBoarder, loseRigthBoarder));

                if (loseFontsizeIsCorrect)
                {
                    loseTextFontsize = loseTextFontsize - run;
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
                    textRectangle.Location = new Point(textOffset, textHigth);
                    textRectangle.Size = new Size(640, (int)g.MeasureString(name, useFont, 640, formatCentert).Height);
                    textHigth = (int)textRectangle.Bottom;
                    g.DrawString(name, useFont, Brushes.Black, textRectangle, formatCentert);
                }

                //Lvl + Race

                using (var useFont = new Font("Segoe Print", lvlRaceFontsize, FontStyle.Bold))
                {
                    var lvlRace = "(Stufe " + level + "-" + race.GetDescription() + ")";

                    textRectangle.Location = new Point(textOffset, textHigth);
                    textRectangle.Size = new Size(640, (int)g.MeasureString(lvlRace, useFont, 640, formatCentert).Height);
                    textHigth = (int)textRectangle.Bottom;
                    g.DrawString(lvlRace, useFont, Brushes.Black, textRectangle, formatCentert);
                }

                //Dividingline
                var dividingline = _picturesFromArchive.Dividingline;
                g.DrawImage(dividingline, new Point(0, textHigth));
                textHigth += dividingline.Height;

                //Text
                if (text != "")
                {
                    _drawStringWithTopograpy.DrawStringOnBitmapWithTopograpy(text, g, textHigth, textFontsize,
                    (textOffset, textBitmap.Width), "Segoe Print");

                    textHigth += (int)Math.Round(_meassureStringWithTopograpy.MeassureStringOnBitmapWithTopograpy(text, g, textHigth, textFontsize,
                         (textOffset, textBitmap.Width), "Segoe Print"));
                }

                //Falvor Text
                if (flavorText != "")
                {
                    using (var useFont = new Font("Segoe Print", flavorTextFontsize, FontStyle.Italic))
                    {
                        textRectangle.Size = new Size(640, (int)g.MeasureString(flavorText, useFont, 640, formatInlined).Height);
                        var textBoxHigth = (int)textRectangle.Bottom - (int)textRectangle.Top;
                        textHigthFromButtom -= textBoxHigth;
                        textRectangle.Location = new Point(textOffset, textHigthFromButtom);
                        g.DrawString(flavorText, useFont, Brushes.Black, textRectangle, formatInlined);
                    }
                }

                //Win
                if (winText != "")
                {
                    _drawBoxWithTopograpy.DrawBoxOnBitmapWithTopograpy(winText, g, winTextFontsize, "Segoe Print",
                        (winLoseBoxHigth, winLoseBoxHigthCardEnd), (winLeftBoarder, winRigthBoarder));
                }

                //Lose
                if (loseText != "")
                {
                    _drawBoxWithTopograpy.DrawBoxOnBitmapWithTopograpy(loseText, g, loseTextFontsize, "Segoe Print",
                        (winLoseBoxHigth, winLoseBoxHigthCardEnd), (loseLeftBoarder, loseRigthBoarder));
                }
            }

            return textBitmap;
        }
    }
}
