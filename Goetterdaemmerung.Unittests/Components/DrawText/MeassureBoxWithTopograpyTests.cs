using NSubstitute;
using Project_Goettergaemmerung.Components.DrawText;
using Project_Goettergaemmerung.Components.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json;
using Xunit;

namespace Unittests.Components.DrawText
{
    public class MeassureBoxWithTopograpyTests
    {
        private ISplitStringInTypography _subSplitStringInTypography;

        public MeassureBoxWithTopograpyTests()
        {
            _subSplitStringInTypography = Substitute.For<ISplitStringInTypography>();
        }

        private MeassureBoxWithTopograpy CreateMeassureBoxWithTopograpy()
        {
            return new MeassureBoxWithTopograpy(
                _subSplitStringInTypography);
        }

        [Fact]
        public void MeassureBoxOnBitmapWithTopograpy_StateUnderTest_ExpectedBehavior()
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

            /*
            // Arrange
            var meassureBoxWithTopograpy = CreateMeassureBoxWithTopograpy();
            string text = "Wenn du eine 6 würfelst, hat diese Waffe stattdessen +4/0.";
            using var textBitmap = new Bitmap(700, 1000);
            textBitmap.SetResolution(120, 120);
            int fontSize = 17;
            string fontName = "Segoe Print";
            (int top, int buttom) boxhigth = (top: 760, buttom: 980);
            (int left, int rigth) boxwidth = (left: 30, rigth: 335);

            using var g = Graphics.FromImage(textBitmap);

            */

            // Act
            /*
            var x = meassureBoxWithTopograpy.MeassureBoxOnBitmapWithTopograpy(
            text,
            g,
            fontSize,
            fontName,
            boxhigth,
            boxwidth);
            */

            // Assert
            Assert.True(true);
        }
    }
}
