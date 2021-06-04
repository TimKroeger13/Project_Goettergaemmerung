using NSubstitute;
using Project_Goettergaemmerung.Components.DrawText;
using System;
using System.Drawing;
using Xunit;

namespace Unittests.Components.DrawText
{
    public class DrawStringWithTopograpyTests
    {
        private ISplitStringInTypography subSplitStringInTypography;
        private readonly SplitStringInTypography _splitStringInTypography = new SplitStringInTypography();

        public DrawStringWithTopograpyTests()
        {
            subSplitStringInTypography = Substitute.For<ISplitStringInTypography>();
        }

        private DrawStringWithTopograpy CreateDrawStringWithTopograpy()
        {
            return new DrawStringWithTopograpy(
                subSplitStringInTypography);
        }

        [Fact]
        public void DrawStringOnBitmapWithTopograpy_StateUnderTest_ExpectedBehavior()
        {
            //Base
            var g = Graphics.FromImage(new Bitmap(700, 1000));
            using var formatInlined = new StringFormat()
            {
                Trimming = StringTrimming.EllipsisWord
            };
            var text = "Erhalte 1 Ausrüstungskarte (Gewöhnlich), 1 Ausrüstungskarte (selten) und wähle 1 (Legendär). 3";
            var SplitText = _splitStringInTypography.SplitString(text);

            // Arrange
            var drawStringWithTopograpy = CreateDrawStringWithTopograpy();
            var inputText = SplitText;
            Graphics bitmap = g;
            int textHigth = 200;
            int fontSize = 24;
            (int offSet, int width) widthBoarders = (offSet: 30, width: 700);
            string fontName = "Segoe Print";
            StringFormat StringFormat = formatInlined;

            // Act
            var result = drawStringWithTopograpy.DrawStringOnBitmapWithTopograpy(
                inputText,
                bitmap,
                textHigth,
                fontSize,
                widthBoarders,
                fontName,
                StringFormat);

            // Assert
            Assert.True(true);
            result.Dispose();
        }
    }
}
