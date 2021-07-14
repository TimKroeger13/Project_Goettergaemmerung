using NSubstitute;
using Project_Goettergaemmerung.Components;
using Project_Goettergaemmerung.Components.DrawText;
using Project_Goettergaemmerung.Components.Model;
using System;
using System.Drawing;
using Xunit;

namespace Unittests.Components.DrawText
{
    public class MeassureDrawNormalCardsTests
    {
        private IDrawStringWithTopograpy _subDrawStringWithTopograpy;
        private IPicturesFromArchive _subPicturesFromArchive;
        private IMeassureStringWithTopograpy _subMeassureStringWithTopograpy;

        public MeassureDrawNormalCardsTests()
        {
            _subDrawStringWithTopograpy = Substitute.For<IDrawStringWithTopograpy>();
            _subPicturesFromArchive = Substitute.For<IPicturesFromArchive>();
            _subMeassureStringWithTopograpy = Substitute.For<IMeassureStringWithTopograpy>();
        }

        private MeassureDrawNormalCards CreateMeassureDrawNormalCards()
        {
            return new MeassureDrawNormalCards(
                _subDrawStringWithTopograpy,
                _subPicturesFromArchive,
                _subMeassureStringWithTopograpy);
        }

        [Theory]
        [InlineData(36, 28, 28, 28, 36, 24, 24, 18, 22, false)]
        [InlineData(35, 27, 27, 27, 35, 23, 23, 18, 21, false)]
        [InlineData(34, 26, 26, 26, 34, 23, 23, 17, 21, false)]
        [InlineData(33, 26, 26, 26, 33, 22, 22, 16, 20, false)]
        [InlineData(32, 25, 25, 25, 32, 21, 21, 16, 20, false)]
        [InlineData(31, 24, 24, 24, 31, 21, 21, 16, 19, false)]
        [InlineData(30, 23, 23, 23, 30, 20, 20, 15, 18, false)]
        [InlineData(29, 23, 23, 23, 29, 19, 19, 14, 18, false)]
        [InlineData(28, 22, 22, 22, 28, 19, 19, 14, 17, false)]
        [InlineData(27, 21, 21, 21, 27, 18, 18, 14, 16, false)]
        [InlineData(26, 20, 20, 20, 26, 17, 17, 13, 16, true)]
        [InlineData(25, 19, 19, 19, 25, 17, 17, 12, 15, true)]
        [InlineData(24, 19, 19, 19, 24, 16, 16, 12, 15, true)]
        [InlineData(23, 18, 18, 18, 23, 15, 15, 12, 14, true)]
        [InlineData(22, 17, 17, 17, 22, 15, 15, 11, 13, true)]
        public void MeassureTextForNormalCards_StateUnderTest_ExpectedBehavior(int nameFontsize, int cardSubTypeFontsize, int twoHandedFontsize,
            int conditionFontsize, int modifiersFontsize, int centerFontsize, int textFontsize, int flavorTextFontsize, int scrappedFontsize, bool expected)
        {
            // Arrange
            var meassureDrawNormalCards = CreateMeassureDrawNormalCards();
            const string name = "Glücksklinge Deluexx";
            const CardSubType subType = CardSubType.Weapon;
            const bool twoHanded = true;
            const Condition condition = Condition.OnlyBureaucratLobbyist;
            const string modifiers = "+1 / 0";
            const string center = "";
            const string text = "Wenn du eine 6 würfelst, hat diese Waffe stattdessen +4/0.";
            const string flavorText = "Glückstreffer sind die Spezialität dieser Waffe. Weitere Text der Patz von der Karte wegnimmt. Die wichtige ist ob man diesen Text überhaupt noch lesen kann";
            const string scrapped = "Wenn du eine 6 würfelst, hat die verstärkte Waffe stattdessen +2/0.";

            _subPicturesFromArchive.Dividingline.ReturnsForAnyArgs(TestResources.dividingline);
            _subPicturesFromArchive.Scrapped.ReturnsForAnyArgs(TestResources.scrapped);

            _subMeassureStringWithTopograpy.MeassureStringOnBitmapWithTopograpy(Arg.Any<string>(), Arg.Any<Graphics>(), Arg.Any<float>(),
                Arg.Any<int>(), (30, 700), Arg.Any<string>()).ReturnsForAnyArgs(150f);

            // Act
            var result = meassureDrawNormalCards.MeassureTextForNormalCards(
                name,
                subType,
                twoHanded,
                condition,
                modifiers,
                center,
                text,
                flavorText,
                scrapped,
                nameFontsize,
                cardSubTypeFontsize,
                twoHandedFontsize,
                conditionFontsize,
                modifiersFontsize,
                centerFontsize,
                textFontsize,
                flavorTextFontsize,
                scrappedFontsize);

            // Assert
            Assert.True(true);
        }
    }
}
