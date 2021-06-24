using NSubstitute;
using Project_Goettergaemmerung.Components;
using Project_Goettergaemmerung.Components.DrawText;
using Project_Goettergaemmerung.Components.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Text.Json;
using Xunit;

namespace Unittests.Components.DrawText
{
    public class DrawStringWithTopograpyTests
    {
        private ISplitStringInTypography subSplitStringInTypography;
        private readonly SplitStringInTypography _splitStringInTypography = new SplitStringInTypography();
        private readonly CreatePicture _createPicture = new CreatePicture();
        private readonly PicturesFromArchive _picturesFromArchive = new PicturesFromArchive();
        private readonly MeassureStringWithTopograpy _meassureStringWithTopograpy = new MeassureStringWithTopograpy();

        public DrawStringWithTopograpyTests()
        {
            var subSplitStringInTypography = Substitute.For<ISplitStringInTypography>();

            var splitStringInTypographyWords = JsonSerializer.Deserialize<string[]>(TestResources.splitStringInTypography_Words);
            var splitStringInTypographyTypography = JsonSerializer.Deserialize<Project_Goettergaemmerung.Components.Model.Typography[]>(TestResources.splitStringInTypography_Typography);

            var splitStringInTypographyList = new List<(string Word, Typography Marker)>();

            for (int i = 0; i < splitStringInTypographyWords.Length; i++)
            {
                splitStringInTypographyList.Add((splitStringInTypographyWords[i], splitStringInTypographyTypography[i]));
            }

            //subSplitStringInTypography.Returns(splitStringInTypographyList);
        }

        private DrawStringWithTopograpy CreateDrawStringWithTopograpy()
        {
            return new DrawStringWithTopograpy(
                subSplitStringInTypography);
        }

        private string CleanStrings(string String)
        {
            var outputString = new StringBuilder();
            bool skip = false;

            for (int i = 0; i < String.Length; i++)
            {
            }

            return outputString.ToString();
        }

        [Fact]
        public void DrawStringOnBitmapWithTopograpy_StateUnderTest_ExpectedBehavior()
        {
            var textBitmap = new Bitmap(700, 1000);
            textBitmap.SetResolution(120, 120);
            var text = "Du wirst vor die Wahl gestellt.\nEntweder verlierst du alle bis auf 1 Ausrüstungskarte (mindestens eine) oder deinen rechten Arm.\nSolltest du deinen Arm verlieren so erhälst du \"Armlos test test\" (Extra Deck).";
            //var SplitText = _splitStringInTypography.SplitString(text);

            var drawStringWithTopograpy = CreateDrawStringWithTopograpy();
            var inputText = text;
            float textHigth = 100;
            int fontSize = 20;
            (int offSet, int width) widthBoarders = (offSet: 30, width: 700);
            string fontName = "Segoe Print";

            // Act
            var result = drawStringWithTopograpy.DrawStringOnBitmapWithTopograpy(
                inputText,
                textBitmap,
                textHigth,
                fontSize,
                widthBoarders,
                fontName);

            var result2 = drawStringWithTopograpy.DrawStringOnBitmapWithTopograpy(
                inputText,
                textBitmap,
                result.texthigth,
                fontSize,
                widthBoarders,
                fontName);

            /*
            var x1 = _meassureStringWithTopograpy.MeassureStringOnBitmapWithTopograpy(inputText,
                textBitmap,
                textHigth,
                fontSize,
                widthBoarders,
                fontName);

            var x2 = _meassureStringWithTopograpy.MeassureStringOnBitmapWithTopograpy(inputText,
                textBitmap,
                result.texthigth,
                fontSize,
                widthBoarders,
                fontName);
            */

            // Assert

            using var testBitmapList = new DisposableList<Bitmap>();

            testBitmapList.AddSingle(_picturesFromArchive.Class);
            testBitmapList.AddSingle(_picturesFromArchive.Boarder);
            testBitmapList.AddSingle(result.bitmap);

            using var Output = _createPicture.MergedBitmaps(testBitmapList);

            Output.Save("C:\\Users\\TKroeger\\Desktop\\Testordner\\TempName.png", ImageFormat.Png);

            Assert.True(true);
        }
    }
}
