using NSubstitute;
using Project_Goettergaemmerung.Components;
using Project_Goettergaemmerung.Components.DrawText;
using Project_Goettergaemmerung.Components.Model;
using System.Drawing;
using System.Text.Json;
using Xunit;

namespace Unittests.Components.DrawText;

public class DrawStringWithTopograpyTests : IDisposable
{
    private readonly ISplitStringInTypography _subSplitStringInTypography;
    private readonly CreatePicture<Bitmap> _createPicture = new();
    //private readonly PicturesFromArchive _picturesFromArchive = new PicturesFromArchive();

    public DrawStringWithTopograpyTests()
    {
        _subSplitStringInTypography = Substitute.For<ISplitStringInTypography>();
    }

    private DrawStringWithTopograpy CreateDrawStringWithTopograpy()
    {
        return new DrawStringWithTopograpy(_subSplitStringInTypography);
    }

    [Fact]
    public void DrawStringOnBitmapWithTopograpy_StateUnderTest_ExpectedBehavior()
    {
        // Arrange

        var splitStringInTypographyWords = JsonSerializer.Deserialize<string[]>(TestResources.splitStringInTypography_Words);
        var splitStringInTypographyTypography = JsonSerializer.Deserialize<Project_Goettergaemmerung.Components.Model.Typography[]>(TestResources.splitStringInTypography_Typography);
        var splitStringInTypographyList = new List<(string Word, Typography Marker)>();

        for (var i = 0; i < splitStringInTypographyWords.Length; i++)
        {
            splitStringInTypographyList.Add((splitStringInTypographyWords[i], splitStringInTypographyTypography[i]));
        }
        _subSplitStringInTypography.SplitString("Wenn du eine 6 würfelst, hat diese Waffe stattdessen +4/0.").ReturnsForAnyArgs(splitStringInTypographyList);

        var drawStringWithTopograpy = CreateDrawStringWithTopograpy();
        const string Text = "Wenn du eine 6 würfelst, hat diese Waffe stattdessen +4/0.";
        using var textBitmap = new Bitmap(700, 1000);
        textBitmap.SetResolution(120, 120);
        const float TextHigth = 400;
        const int FontSize = 20;
        var widthBoarders = (offSet: 30, width: 700);
        const string FontName = "Segoe Print";

        // Act

        using (var g = Graphics.FromImage(textBitmap))
        {
            drawStringWithTopograpy.DrawStringOnBitmapWithTopograpy(
            Text,
            g,
            TextHigth,
            FontSize,
            widthBoarders,
            FontName);
        }

        // Assert

        using var testBitmapList = new DisposableList<Bitmap>();

        //testBitmapList.AddSingle(_picturesFromArchive.Class);
        //testBitmapList.AddSingle(_picturesFromArchive.Boarder);
        testBitmapList.Add(() => textBitmap);

        using var output = _createPicture.MergedBitmaps(testBitmapList);

        //Output.Save("C:\\Users\\TKroeger\\Desktop\\Testordner\\TempName.png", ImageFormat.Png);

        Assert.True(true);
    }

    public void Dispose()
    {
        _createPicture?.Dispose();
    }
}
