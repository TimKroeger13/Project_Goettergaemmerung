using Project_Goettergaemmerung.Components.CardInformationGetter;
using Xunit;

namespace Unittests.Components.CardInformationGetter;

public class OdsCardInformationTests
{
    public OdsCardInformationTests()
    {
    }

    private OdsCardInformation CreateOdsCardInformation()
    {
        return new OdsCardInformation();
    }

    [Fact]
    public void GetCardInformation_StateUnderTest_ExpectedBehavior()
    {
        // Arrange
        var odsCardInformation = this.CreateOdsCardInformation();

        // Act
        var result = odsCardInformation.GetCardInformation();

        // Assert
        Assert.True(false);
    }
}
