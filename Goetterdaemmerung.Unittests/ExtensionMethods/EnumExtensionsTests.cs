using Project_Goettergaemmerung.Components.Model;
using Project_Goettergaemmerung.ExtensionMethods;
using Xunit;
using FluentAssertions;

namespace Unittests.ExtensionMethods;

public class EnumExtensionsTests
{
    [Theory]
    [InlineData(CardSubType.Shoes, "(Ausrüstung-Schuhe)")]
    [InlineData(CardType.Equipment1, "euq1")]
    [InlineData(Condition.NotBodybuilder, "(Nicht von Bodybuildern nutzbar)")]
    [InlineData(Race.Human, "Mensch")]
    public void GetDescription_StateUnderTest_ExpectedBehavior(Enum value, string expected)
    {
        // Act
        var result = value.GetDescription();

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}
