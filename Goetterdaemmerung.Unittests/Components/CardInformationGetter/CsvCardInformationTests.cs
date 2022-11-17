using System.IO.Compression;
using System.Text.Encodings.Web;
using System.Text.Json;
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
        using var zip = new ZipArchive(new MemoryStream(TestResources.Götterdämmerung_Karten), ZipArchiveMode.Read);
        var memoryStream = new MemoryStream();
        var csvStream = zip.Entries[0].Open();
        csvStream.CopyTo(memoryStream);
        memoryStream.Position = 0;
        _subUserData.GetCardData().Returns(memoryStream);
        return new CsvCardInformation(_subUserData);
    }

    [Fact]
    public void GetCardInformation_CRLF_ShouldWork()
    {
        var csvCardInformation = CreateCsvCardInformation();
        var result = csvCardInformation.GetCardInformation();
        var json = JsonSerializer.Serialize(result, new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        });
        result.Count().Should().BeGreaterThan(0);
    }
}
