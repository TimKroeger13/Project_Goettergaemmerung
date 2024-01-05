using NSubstitute;
using Project_Goettergaemmerung.Components;
using Project_Goettergaemmerung.Components.DrawText;
using Project_Goettergaemmerung.Components.Model;
using System.Drawing;
using System.Text.Json;
using Xunit;

namespace Unittests.Components.DrawText;

public class DrawBoxWithTopograpyTests
{
    private readonly ISplitStringInTypography _subSplitStringInTypography;
    private readonly CreatePicture<Bitmap> _createPicture = new();
    //private readonly PicturesFromArchive _picturesFromArchive = new PicturesFromArchive();

    public DrawBoxWithTopograpyTests()
    {
        _subSplitStringInTypography = Substitute.For<ISplitStringInTypography>();
    }

    private DrawBoxWithTopograpy CreateDrawBoxWithTopograpy()
    {
        return new DrawBoxWithTopograpy(_subSplitStringInTypography);
    }

    [Fact]
    public void DrawBoxOnBitmapWithTopograpy_StateUnderTest_ExpectedBehavior()
    {
        var splitStringInTypographyWords = JsonSerializer.Deserialize<string[]>(TestResources.splitStringInTypography_Words);
        var splitStringInTypographyTypography = JsonSerializer.Deserialize<Project_Goettergaemmerung.Components.Model.Typography[]>(TestResources.splitStringInTypography_Typography);
        var splitStringInTypographyList = new List<(string Word, Typography Marker)>();

        for (var i = 0; i < splitStringInTypographyWords.Length; i++)
        {
            splitStringInTypographyList.Add((splitStringInTypographyWords[i], splitStringInTypographyTypography[i]));
        }
        _subSplitStringInTypography.SplitString("Wenn du eine 6 würfelst, hat diese Waffe stattdessen +4/0.").ReturnsForAnyArgs(splitStringInTypographyList);

        // Arrange
        var drawBoxWithTopograpy = CreateDrawBoxWithTopograpy();
        const string Text = "Wenn du eine 6 würfelst, hat diese Waffe stattdessen +4/0.";
        using var textBitmap = new Bitmap(1400, 2000);
        textBitmap.SetResolution(120, 120);
        const int FontSize = 20;
        const string FontName = "Segoe Print";
        var boxhigth = (top: 1520, buttom: 1960);
        var boxwidth = (left: 60, rigth: 670);

        // Act
        using (var g = Graphics.FromImage(textBitmap))
        {
            drawBoxWithTopograpy.DrawBoxOnBitmapWithTopograpy(
            Text,
            g,
            FontSize,
            FontName,
            boxhigth,
            boxwidth);
        }

        using var testBitmapList = new DisposableList<Bitmap>();

        //testBitmapList.AddSingle(_picturesFromArchive.Class);
        //testBitmapList.AddSingle(_picturesFromArchive.Boarder);
        //testBitmapList.AddSingle(_picturesFromArchive.Win);
        testBitmapList.Add(() => textBitmap);

        using var output = _createPicture.MergedBitmaps(testBitmapList);

        //Output.Save("C:\\Users\\TKroeger\\Desktop\\Testordner\\TempName.png", ImageFormat.Png);

        // Assert
        Assert.True(true);
    }
}
