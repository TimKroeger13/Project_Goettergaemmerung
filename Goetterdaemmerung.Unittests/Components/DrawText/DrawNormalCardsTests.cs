using NSubstitute;
using Project_Goettergaemmerung.Components;
using Project_Goettergaemmerung.Components.DrawText;
using System;
using Xunit;
using Project_Goettergaemmerung.Components.Model;

namespace Unittests.Components.DrawText
{
    public class DrawNormalCardsTests
    {
        private IPicturesFromArchive subPicturesFromArchive;

        public DrawNormalCardsTests()
        {
            subPicturesFromArchive = Substitute.For<IPicturesFromArchive>();
        }

        private DrawNormalCards CreateDrawNormalCards()
        {
            return new DrawNormalCards(
                subPicturesFromArchive);
        }

        [Fact]
        public void DrawTextForNormalCards_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var drawNormalCards = CreateDrawNormalCards();
            var name = "Glücksklinge";
            var subType = CardSubType.Weapon;
            var twoHanded = false;
            var condition = Condition.Empty;
            var modifiers = "+1 / 0";
            var text = "Wenn du eine 6 würfelst, hat diese Waffe stattdessen +4/0.";
            var flavorText = "Glückstreffer sind die Spezialität dieser Waffe.";
            var scrapped = "Wenn du eine 6 würfelst, hat die verstärkte Waffe stattdessen +2/0.";

            // Act
            var result = drawNormalCards.DrawTextForNormalCards(
                name,
                subType,
                twoHanded,
                condition,
                modifiers,
                text,
                flavorText,
                scrapped);

            // Assert
            Assert.True(false);
            result.Dispose();
        }
    }
}
