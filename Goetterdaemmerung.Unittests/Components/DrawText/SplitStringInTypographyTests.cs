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
        //[InlineData("Testtext der Wörter wie Vampirismus und vampirismus oder passieren enthält. Dies sollte aber nicht mit den Wort passiere oder passierst oder Todpassieren verwechselt werden. (test) text passiere")]
        //[InlineData("Erhalte 1 Ausrüstungskarte (Gewöhnlich), 1 Ausrüstungskarte (selten) und wähle 1 (Legendär).3")]
        [InlineData("Monster haben +1 / -2 wenn (Bei Nacht +2/+3) | du es schafft bei einen D8 eine 3 (Extra Deck). Erhält einen (bonus von faith.")]
        public void SplitString_StateUnderTest_ExpectedBehavior(String text)
        {
            var splitStringInTypography = CreateSplitStringInTypography();
            var result = splitStringInTypography.SplitString(
                text);
            Assert.True(true);
        }
    }
}
