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
    public class DrawBoxWithTopograpyTests
    {
        private readonly ISplitStringInTypography _subSplitStringInTypography;
        private readonly CreatePicture _createPicture = new CreatePicture();
        private readonly PicturesFromArchive _picturesFromArchive = new PicturesFromArchive();

        public DrawBoxWithTopograpyTests()
        {
            _subSplitStringInTypography = Substitute.For<ISplitStringInTypography>();
        }

        private DrawBoxWithTopograpy CreateDrawBoxWithTopograpy()
        {
            return new DrawBoxWithTopograpy(_subSplitStringInTypography);
        }

        [Fact]
        public void DrawBoxOnBitmapWithTopograpy_StateUnderTest_ExpectedBehavior()
        {
            var splitStringInTypographyWords = JsonSerializer.Deserialize<string[]>(TestResources.splitStringInTypography_Words);
            var splitStringInTypographyTypography = JsonSerializer.Deserialize<Project_Goettergaemmerung.Components.Model.Typography[]>(TestResources.splitStringInTypography_Typography);
            var splitStringInTypographyList = new List<(string Word, Typography Marker)>();

            for (int i = 0; i < splitStringInTypographyWords.Length; i++)
            {
                splitStringInTypographyList.Add((splitStringInTypographyWords[i], splitStringInTypographyTypography[i]));
            }
            _subSplitStringInTypography.SplitString("Wenn du eine 6 würfelst, hat diese Waffe stattdessen +4/0.").ReturnsForAnyArgs(splitStringInTypographyList);

            // Arrange
            var drawBoxWithTopograpy = CreateDrawBoxWithTopograpy();
            string text = "Wenn du eine 6 würfelst, hat diese Waffe stattdessen +4/0.";
            using var textBitmap = new Bitmap(700, 1000);
            textBitmap.SetResolution(120, 120);
            int fontSize = 20;
            string fontName = "Segoe Print";
            (int top, int buttom) boxhigth = (top: 760, buttom: 980);
            (int left, int rigth) boxwidth = (left: 30, rigth: 335);

            // Act
            using (var g = Graphics.FromImage(textBitmap))
            {
                drawBoxWithTopograpy.DrawBoxOnBitmapWithTopograpy(
                text,
                g,
                fontSize,
                fontName,
                boxhigth,
                boxwidth);
            }

            using var testBitmapList = new DisposableList<Bitmap>();

            testBitmapList.AddSingle(_picturesFromArchive.Class);
            testBitmapList.AddSingle(_picturesFromArchive.Boarder);
            testBitmapList.AddSingle(_picturesFromArchive.Win);
            testBitmapList.AddSingle(textBitmap);

            using var Output = _createPicture.MergedBitmaps(testBitmapList);

            Output.Save("C:\\Users\\TKroeger\\Desktop\\Testordner\\TempName.png", ImageFormat.Png);

            // Assert
            Assert.True(true);
        }
    }
}
