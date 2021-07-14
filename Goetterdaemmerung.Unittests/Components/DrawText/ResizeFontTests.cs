using FluentAssertions;
using NSubstitute;
using Project_Goettergaemmerung.Components.DrawText;
using System;
using Xunit;

namespace Unittests.Components.DrawText
{
    public class ResizeFontTests
    {
        public ResizeFontTests()
        {
        }

        private ResizeFont CreateResizeFont()
        {
            return new ResizeFont();
        }

        [Theory]
        [InlineData(0, 36, 28, 28, 28, 36, 24, 24, 18, 22)]
        [InlineData(1, 35, 27, 27, 27, 35, 23, 23, 18, 21)]
        [InlineData(2, 34, 26, 26, 26, 34, 23, 23, 17, 21)]
        [InlineData(3, 33, 26, 26, 26, 33, 22, 22, 16, 20)]
        [InlineData(4, 32, 25, 25, 25, 32, 21, 21, 16, 20)]
        [InlineData(5, 31, 24, 24, 24, 31, 21, 21, 16, 19)]
        [InlineData(6, 30, 23, 23, 23, 30, 20, 20, 15, 18)]
        [InlineData(7, 29, 23, 23, 23, 29, 19, 19, 14, 18)]
        [InlineData(8, 28, 22, 22, 22, 28, 19, 19, 14, 17)]
        [InlineData(9, 27, 21, 21, 21, 27, 18, 18, 14, 16)]
        [InlineData(10, 26, 20, 20, 20, 26, 17, 17, 13, 16)]
        [InlineData(11, 25, 19, 19, 19, 25, 17, 17, 12, 15)]
        [InlineData(12, 24, 19, 19, 19, 24, 16, 16, 12, 15)]
        [InlineData(13, 23, 18, 18, 18, 23, 15, 15, 12, 14)]
        [InlineData(14, 22, 17, 17, 17, 22, 15, 15, 11, 13)]
        public void NewFontSize_StateUnderTest_ExpectedBehavior(int TheoryRunnumber, int expectednameFontsize, int expectedcardSubTypeFontsize, int expectedtwoHandedFontsize,
            int expectedconditionFontsize, int expectedmodifiersFontsize, int expectedcenterFontsize, int expectedtextFontsize, int expectedflavorTextFontsize, int expectedscrappedFontsize)
        {
            // Arrange
            var resizeFont = CreateResizeFont();
            int Runnumber = TheoryRunnumber;
            var nameFontsize = 36;
            var cardSubTypeFontsize = 28;
            var twoHandedFontsize = 28;
            var conditionFontsize = 28;
            var modifiersFontsize = 36;
            var cenerFontsize = 24;
            var textFontsize = 24;
            var flavorTextFontsize = 18;
            var scrappedFontsize = 22;

            // Act
            var result = resizeFont.NewFontSize(
                Runnumber,
                nameFontsize,
                cardSubTypeFontsize,
                twoHandedFontsize,
                conditionFontsize,
                modifiersFontsize,
                expectedcenterFontsize,
                textFontsize,
                flavorTextFontsize,
                scrappedFontsize);

            // Assert

            result.nameFontsize.Should().Be(expectednameFontsize);
            result.cardSubTypeFontsize.Should().Be(expectedcardSubTypeFontsize);
            result.twoHandedFontsize.Should().Be(expectedtwoHandedFontsize);
            result.conditionFontsize.Should().Be(expectedconditionFontsize);
            result.modifiersFontsize.Should().Be(expectedmodifiersFontsize);
            result.textFontsize.Should().Be(expectedtextFontsize);
            result.flavorTextFontsize.Should().Be(expectedflavorTextFontsize);
            result.scrappedFontsize.Should().Be(expectedscrappedFontsize);

            Assert.True(true);
        }
    }
}
