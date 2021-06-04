using NSubstitute;
using Project_Goettergaemmerung.Components;
using Project_Goettergaemmerung.Components.CardInformationGetter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using Xunit;

namespace Unittests.Components
{
    public class TestTextAsBitmapTests
    {
        private readonly List<Bitmap> _list = new List<Bitmap>();
        private readonly CreatePicture _createPicture = new CreatePicture();
        private readonly PicturesFromArchive _picturesFromArchive = new PicturesFromArchive();


        private TestTextAsBitmap CreateDrawTextAsBitmap()
        {
            return new TestTextAsBitmap(_picturesFromArchive);
        }
        //g.MeasureCharacterRanges
        [Theory]
        [InlineData("Arm ab oder arm dran",
            "\"Du wirst vor die Wahl gestellt.\nEntweder verlierst du alle bis auf 1 Ausrüstungskarte (mindestens eine) oder deinen rechten Arm.\nSolltest du deinen Arm verlieren so erhälst du \"\"Armlos\"\" (Extra Deck).\"",
            "Du solltest dir nächstes mal zweimal überlegen ob du in die Suppe der Königs...")]
        [InlineData("The Grand Tournament", "Das größte aller Tuniere  wird in 6 Tagen beginnen und ihr alle werdet in der Arena stehen.\nNutzt die Zeit weise um euch vorzubereiten.\n\nLege 5 Zählmarken auf diese Karte und entferne am Anfang jeder neuen Runde, nachdem diese Karte aufgedeckt wurde, 1 Zählmarke von dieser Karte.\n\nWenn keine Zählmarken mehr auf dieser Karte liegen startet der Kampf:\n\nAlle Spieler kämpfen gleichzeitig nach den Regeln des Mehrfachkampfes gegeneinander.\nIn jeder Runde verlässt der schächste Spieler von allen die Arena.\n\nSollte es mehere schwächste Spieler geben, kämpfen diese sofort noch einmal gegenander bis einer verliert.\n\nDiese Kämpfe werden so lange wiederholt bis es einen Sieger gibt.\n\nDer Sieger des Grand Tournaments erhält \"König der Arena\" (Extra Deck).", "")]
        [InlineData("1", @"{\rtf1\ansi <b>This is</b> in \b bold\b0.}", "3")]

        public void DrawText_StateUnderTest_ExpectedBehavior(string name, string text, string flavorText)
        {
            var drawTextAsBitmap = this.CreateDrawTextAsBitmap();
            using var textBitmap = drawTextAsBitmap.DrawText(
                name, text, flavorText);

            using var testBitmapList = new DisposableList<Bitmap>();

            testBitmapList.AddSingle(_picturesFromArchive.Class);
            testBitmapList.AddSingle(_picturesFromArchive.Boarder);
            testBitmapList.AddSingle(textBitmap);

            using var result = _createPicture.MergedBitmaps(testBitmapList);

            result.Save("C:\\Users\\TKroeger\\Desktop\\Testordner\\" + name + ".png", ImageFormat.Png);
        }
    }
}
