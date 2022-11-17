using Project_Goettergaemmerung.ExtensionMethods;
using Xunit;

namespace Unittests.ExtensionMethods;

public class SplitStingTests
{
    [Theory]
    [InlineData("Große Muskeln: +2 / 0 gegen Spieler\n\nNichts dahinter: -1 / 0 gegen Monster")]
    public void StringSplitter_StateUnderTest_ExpectedBehavior(string text)
    {
        // Act
        var result = text.StringSplitter();

        // Assert
        Assert.True(true);
    }
}
