using NSubstitute;
using Project_Goettergaemmerung.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using Xunit;

namespace Unittests.Components
{
    public class DrawTextAsBitmapTests
    {
        private readonly List<Bitmap> _list = new List<Bitmap>();
        private readonly CreatePicture _createPicture = new CreatePicture();
        private readonly PicturesFromArchive _picturesFromArchive = new PicturesFromArchive();

        public DrawTextAsBitmapTests()
        {
        }

        private DrawTextAsBitmap CreateDrawTextAsBitmap()
        {
            return new DrawTextAsBitmap(_picturesFromArchive);
        }

        [Theory]
        [InlineData("Arm ab oder Arm dran",
            "Du wirst vor die Wahl gestellt. Entweder verlierst du alle bis auf 1 Ausrüstungskarte (mindestens eine) oder deinen rechten Arm. Solltest du deinen Arm verlieren so erhälst du Armlos (Extra Deck).",
            "Du solltest dir nächstes mal zweimal überlegen ob du in die Suppe der Königs...")]

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
