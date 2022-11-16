using System.Text;
using FluentAssertions;
using NSubstitute;
using Project_Goettergaemmerung.Components;
using Project_Goettergaemmerung.Components.CardInformationGetter;
using Xunit;

namespace Unittests.Components.CardInformationGetter;

public class CsvCardInformationTests
{
    private readonly IUserData _subUserData = Substitute.For<IUserData>();

    private CsvCardInformation CreateCsvCardInformation()
    {
        _subUserData.GetCardData().Returns(new MemoryStream(Encoding.UTF8.GetBytes(TestResources.Götterdämmerung_Karten)));
        return new CsvCardInformation(_subUserData);
    }

    [Fact]
    public void GetCardInformation_CRLF_ShouldWork()
    {
        var csvCardInformation = CreateCsvCardInformation();
        var result = csvCardInformation.GetCardInformation();
        result.Count().Should().BeGreaterThan(0);
    }
}
