using NSubstitute;
using Project_Goettergaemmerung.Components;
using Project_Goettergaemmerung.Components.DrawText;
using Project_Goettergaemmerung.Components.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.Json;
using Xunit;

namespace Unittests.Components.DrawText
{
    public class DrawStringWithTopograpyTests
    {
        private readonly ISplitStringInTypography _subSplitStringInTypography;
        private readonly CreatePicture _createPicture = new CreatePicture();
        private readonly PicturesFromArchive _picturesFromArchive = new PicturesFromArchive();

        public DrawStringWithTopograpyTests()
        {
            _subSplitStringInTypography = Substitute.For<ISplitStringInTypography>();
        }

        private DrawStringWithTopograpy CreateDrawStringWithTopograpy()
        {
            return new DrawStringWithTopograpy(_subSplitStringInTypography);
        }

        [Fact]
        public void DrawStringOnBitmapWithTopograpy_StateUnderTest_ExpectedBehavior()
        {
            // Arrange

            var splitStringInTypographyWords = JsonSerializer.Deserialize<string[]>(TestResources.splitStringInTypography_Words);
            var splitStringInTypographyTypography = JsonSerializer.Deserialize<Project_Goettergaemmerung.Components.Model.Typography[]>(TestResources.splitStringInTypography_Typography);
            var splitStringInTypographyList = new List<(string Word, Typography Marker)>();

            for (int i = 0; i < splitStringInTypographyWords.Length; i++)
            {
                splitStringInTypographyList.Add((splitStringInTypographyWords[i], splitStringInTypographyTypography[i]));
            }
            _subSplitStringInTypography.SplitString("Wenn du eine 6 würfelst, hat diese Waffe stattdessen +4/0.").ReturnsForAnyArgs(splitStringInTypographyList);

            var drawStringWithTopograpy = CreateDrawStringWithTopograpy();
            const string text = "Wenn du eine 6 würfelst, hat diese Waffe stattdessen +4/0.";
            using var textBitmap = new Bitmap(700, 1000);
            textBitmap.SetResolution(120, 120);
            const float textHigth = 400;
            const int fontSize = 20;
            var widthBoarders = (offSet: 30, width: 700);
            const string fontName = "Segoe Print";

            // Act

            using (var g = Graphics.FromImage(textBitmap))
            {
                var graficValue = drawStringWithTopograpy.DrawStringOnBitmapWithTopograpy(
                text,
                g,
                textHigth,
                fontSize,
                widthBoarders,
                fontName);
            }

            // Assert

            using var testBitmapList = new DisposableList<Bitmap>();

            testBitmapList.AddSingle(_picturesFromArchive.Class);
            testBitmapList.AddSingle(_picturesFromArchive.Boarder);
            testBitmapList.AddSingle(textBitmap);

            using var Output = _createPicture.MergedBitmaps(testBitmapList);

            Output.Save("C:\\Users\\TKroeger\\Desktop\\Testordner\\TempName.png", ImageFormat.Png);

            Assert.True(true);
        }
    }
}
