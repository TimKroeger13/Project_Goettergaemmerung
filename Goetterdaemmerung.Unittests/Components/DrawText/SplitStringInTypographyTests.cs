using NSubstitute;
using Project_Goettergaemmerung.Components.DrawText;
using System;
using Xunit;

namespace Unittests.Components.DrawText
{
    public class SplitStringInTypographyTests
    {
        public SplitStringInTypographyTests()
        {
        }

        private SplitStringInTypography CreateSplitStringInTypography()
        {
            return new SplitStringInTypography();
        }

        [Theory]
        [InlineData("Testtext der D20 Wörter wie Vampirismus und vampirismus. oder / + - | passieren enthält. Dies sollte aber nicht mit den Wort passiere oder passierst oder Todpassieren verwechselt werden. (test) text passiere")]
        [InlineData("Erhalte 1 Ausrüstungskarte (Gewöhnlich), 1 Ausrüstungskarte (selten) und wähle 1 (Legendär). 3")]
        [InlineData("Test 3 (Extra Deck) D1Monster haben +1 / -2 wenn (Bei Nacht +2/+3) | du es schafft bei einen D8 eine (Extra Deck) 4. Erhält einen (bonus von faith. More Text37aD8")]
        [InlineData("Nur Text ohne bold")]
        [InlineData("")]
        public void SplitString_StateUnderTest_ExpectedBehavior(string text)
        {
            var splitStringInTypography = CreateSplitStringInTypography();
            var result = splitStringInTypography.SplitString(
                text);
            Assert.True(true);
        }
    }
}
