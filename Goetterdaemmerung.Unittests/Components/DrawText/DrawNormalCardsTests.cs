using System.Drawing;
using NSubstitute;
using Project_Goettergaemmerung.Components;
using Project_Goettergaemmerung.Components.DrawText;
using Project_Goettergaemmerung.Components.Model;
using Xunit;

namespace Unittests.Components.DrawText;

public class DrawNormalCardsTests
{
    //private readonly PicturesFromArchive _picturesFromArchive = new PicturesFromArchive();
    private readonly CreatePicture<Bitmap> _createPicture = new();

    private readonly IDrawStringWithTopograpy _subDrawStringWithTopograpy;
    private readonly IPicturesFromArchive _subPicturesFromArchive;
    private readonly IMeassureStringWithTopograpy _subMeassureStringWithTopograpy;
    private readonly IMeassureDrawNormalCards _submeassureDrawNormalCards;
    private readonly IResizeFont _subresizeFont;

    public DrawNormalCardsTests()
    {
        _subDrawStringWithTopograpy = Substitute.For<IDrawStringWithTopograpy>();
        _subPicturesFromArchive = Substitute.For<IPicturesFromArchive>();
        _subMeassureStringWithTopograpy = Substitute.For<IMeassureStringWithTopograpy>();
        _submeassureDrawNormalCards = Substitute.For<IMeassureDrawNormalCards>();
        _subresizeFont = Substitute.For<IResizeFont>();
    }

    private DrawNormalCards CreateDrawNormalCards()
    {
        return new DrawNormalCards(
            _subDrawStringWithTopograpy,
            _subPicturesFromArchive,
            _subMeassureStringWithTopograpy,
            _submeassureDrawNormalCards,
            _subresizeFont);
    }

    [Fact]
    public void DrawTextForNormalCards_StateUnderTest_ExpectedBehavior()
    {
        //var testx = _picturesFromArchive.Dividingline.Height; //16
        //var testx2 = _picturesFromArchive.Scrapped.Height; //82

        // Arrange

        var drawNormalCards = CreateDrawNormalCards();
        const string Name = "Glücksklinge Deluexx";
        const CardSubType SubType = CardSubType.Weapon;
        const bool TwoHanded = true;
        const Condition Condition = Condition.OnlyBureaucratLobbyist;
        const string Modifiers = "+1 / 0";
        const string Text = "Wenn du eine 6 würfelst, hat diese Waffe stattdessen +4/0.";
        const string FlavorText = "Glückstreffer sind die Spezialität dieser Waffe. Weitere Text der Patz von der Karte wegnimmt. Die wichtige ist ob man diesen Text überhaupt noch lesen kann";
        const string Center = "";
        const string Scrapped = "Wenn du eine 6 würfelst, hat die verstärkte Waffe stattdessen +2/0.";

        //_subPicturesFromArchive.Dividingline().ReturnsForAnyArgs(TestResources.dividingline);
        //_subPicturesFromArchive.Scrapped().ReturnsForAnyArgs(TestResources.scrapped);

        _subresizeFont.NewFontSize(0, 36, 28, 28, 28, 36, 24, 24, 18, 22).Returns((36, 28, 28, 28, 36, 24, 24, 18, 22));
        _subresizeFont.NewFontSize(1, 36, 28, 28, 28, 36, 24, 24, 18, 22).Returns((35, 27, 27, 27, 35, 23, 23, 18, 21));
        _subresizeFont.NewFontSize(2, 36, 28, 28, 28, 36, 24, 24, 18, 22).Returns((34, 26, 26, 26, 34, 23, 23, 17, 21));
        _subresizeFont.NewFontSize(3, 36, 28, 28, 28, 36, 24, 24, 18, 22).Returns((33, 26, 26, 26, 33, 22, 22, 16, 20));
        _subresizeFont.NewFontSize(4, 36, 28, 28, 28, 36, 24, 24, 18, 22).Returns((32, 25, 25, 25, 32, 21, 21, 16, 20));
        _subresizeFont.NewFontSize(5, 36, 28, 28, 28, 36, 24, 24, 18, 22).Returns((31, 24, 24, 24, 31, 21, 21, 16, 19));
        _subresizeFont.NewFontSize(6, 36, 28, 28, 28, 36, 24, 24, 18, 22).Returns((30, 23, 23, 23, 30, 20, 20, 15, 18));
        _subresizeFont.NewFontSize(7, 36, 28, 28, 28, 36, 24, 24, 18, 22).Returns((29, 23, 23, 23, 29, 19, 19, 14, 18));
        _subresizeFont.NewFontSize(8, 36, 28, 28, 28, 36, 24, 24, 18, 22).Returns((28, 22, 22, 22, 28, 19, 19, 14, 17));
        _subresizeFont.NewFontSize(9, 36, 28, 28, 28, 36, 24, 24, 18, 22).Returns((27, 21, 21, 21, 27, 18, 18, 14, 16));
        _subresizeFont.NewFontSize(10, 36, 28, 28, 28, 36, 24, 24, 18, 22).Returns((26, 20, 20, 20, 26, 17, 17, 13, 16));
        _subresizeFont.NewFontSize(11, 36, 28, 28, 28, 36, 24, 24, 18, 22).Returns((25, 19, 19, 19, 25, 17, 17, 12, 15));
        _subresizeFont.NewFontSize(12, 36, 28, 28, 28, 36, 24, 24, 18, 22).Returns((24, 19, 19, 19, 24, 16, 16, 12, 15));
        _subresizeFont.NewFontSize(13, 36, 28, 28, 28, 36, 24, 24, 18, 22).Returns((23, 18, 18, 18, 23, 15, 15, 12, 14));
        _subresizeFont.NewFontSize(14, 36, 28, 28, 28, 36, 24, 24, 18, 22).Returns((22, 17, 17, 17, 22, 15, 15, 11, 13));

        _submeassureDrawNormalCards.MeassureTextForNormalCards(Arg.Any<string>(), Arg.Any<CardSubType>(), Arg.Any<bool>(),
            Arg.Any<Condition>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(),
            36, 28, 28, 28, 36, 24, 24, 18, 22).Returns(false);
        _submeassureDrawNormalCards.MeassureTextForNormalCards(Arg.Any<string>(), Arg.Any<CardSubType>(), Arg.Any<bool>(),
            Arg.Any<Condition>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(),
            35, 27, 27, 27, 35, 23, 23, 18, 21).Returns(false);
        _submeassureDrawNormalCards.MeassureTextForNormalCards(Arg.Any<string>(), Arg.Any<CardSubType>(), Arg.Any<bool>(),
            Arg.Any<Condition>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(),
            34, 26, 26, 26, 34, 23, 23, 17, 21).Returns(false);
        _submeassureDrawNormalCards.MeassureTextForNormalCards(Arg.Any<string>(), Arg.Any<CardSubType>(), Arg.Any<bool>(),
            Arg.Any<Condition>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(),
            32, 25, 25, 25, 32, 21, 21, 16, 20).Returns(false);
        _submeassureDrawNormalCards.MeassureTextForNormalCards(Arg.Any<string>(), Arg.Any<CardSubType>(), Arg.Any<bool>(),
            Arg.Any<Condition>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(),
            31, 24, 24, 24, 31, 21, 21, 16, 19).Returns(false);
        _submeassureDrawNormalCards.MeassureTextForNormalCards(Arg.Any<string>(), Arg.Any<CardSubType>(), Arg.Any<bool>(),
            Arg.Any<Condition>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(),
            30, 23, 23, 23, 30, 20, 20, 15, 18).Returns(false);
        _submeassureDrawNormalCards.MeassureTextForNormalCards(Arg.Any<string>(), Arg.Any<CardSubType>(), Arg.Any<bool>(),
            Arg.Any<Condition>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(),
            29, 23, 23, 23, 29, 19, 19, 14, 18).Returns(false);
        _submeassureDrawNormalCards.MeassureTextForNormalCards(Arg.Any<string>(), Arg.Any<CardSubType>(), Arg.Any<bool>(),
            Arg.Any<Condition>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(),
            28, 22, 22, 22, 28, 19, 19, 14, 17).Returns(false);
        _submeassureDrawNormalCards.MeassureTextForNormalCards(Arg.Any<string>(), Arg.Any<CardSubType>(), Arg.Any<bool>(),
            Arg.Any<Condition>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(),
            27, 21, 21, 21, 27, 18, 18, 14, 16).Returns(false);
        _submeassureDrawNormalCards.MeassureTextForNormalCards(Arg.Any<string>(), Arg.Any<CardSubType>(), Arg.Any<bool>(),
            Arg.Any<Condition>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(),
            26, 20, 20, 20, 26, 17, 17, 13, 16).Returns(true);
        _submeassureDrawNormalCards.MeassureTextForNormalCards(Arg.Any<string>(), Arg.Any<CardSubType>(), Arg.Any<bool>(),
            Arg.Any<Condition>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(),
            25, 19, 19, 19, 25, 17, 17, 12, 15).Returns(true);
        _submeassureDrawNormalCards.MeassureTextForNormalCards(Arg.Any<string>(), Arg.Any<CardSubType>(), Arg.Any<bool>(),
            Arg.Any<Condition>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(),
            24, 19, 19, 19, 24, 16, 16, 12, 15).Returns(true);
        _submeassureDrawNormalCards.MeassureTextForNormalCards(Arg.Any<string>(), Arg.Any<CardSubType>(), Arg.Any<bool>(),
            Arg.Any<Condition>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(),
            23, 18, 18, 18, 23, 15, 15, 12, 14).Returns(true);
        _submeassureDrawNormalCards.MeassureTextForNormalCards(Arg.Any<string>(), Arg.Any<CardSubType>(), Arg.Any<bool>(),
            Arg.Any<Condition>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(),
            22, 17, 17, 17, 22, 15, 15, 11, 13).Returns(true);

        //_subMeassureStringWithTopograpy.MeassureStringOnBitmapWithTopograpy(Arg.Any<string>(), Arg.Any<Graphics>(), Arg.Any<float>(),
        //    Arg.Any<int>(), (30, 700), Arg.Any<string>()).ReturnsForAnyArgs(150f);

        // Act
        using var result = drawNormalCards.DrawTextForNormalCards(
            Name,
            SubType,
            TwoHanded,
            Condition,
            Modifiers,
            Center,
            Text,
            FlavorText,
            Scrapped);

        // Assert

        using var testBitmapList = new DisposableList<Bitmap>();

        //testBitmapList.AddSingle(_picturesFromArchive.Class);
        //testBitmapList.AddSingle(_picturesFromArchive.Boarder);
        testBitmapList.Add(() => result);

        using var outputBitmap = _createPicture.MergedBitmaps(testBitmapList);

        //OutputBitmap.Save("C:\\Users\\TKroeger\\Desktop\\Testordner\\" + name + ".png", ImageFormat.Png);
        Assert.True(true);
    }
}