using NSubstitute;
using Project_Goettergaemmerung.Components;
using Project_Goettergaemmerung.Components.DrawText;
using Project_Goettergaemmerung.Components.Model;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using Xunit;
using Project_Goettergaemmerung.ExtensionMethods;

namespace Unittests.Components.DrawText
{
    public class DrawNormalCardsTests
    {
        private readonly PicturesFromArchive _picturesFromArchive = new PicturesFromArchive();
        private readonly CreatePicture _createPicture = new CreatePicture();

        private readonly IDrawStringWithTopograpy _subDrawStringWithTopograpy;
        private readonly IPicturesFromArchive _subPicturesFromArchive;
        private readonly IMeassureStringWithTopograpy _subMeassureStringWithTopograpy;

        public DrawNormalCardsTests()
        {
            _subDrawStringWithTopograpy = Substitute.For<IDrawStringWithTopograpy>();
            _subPicturesFromArchive = Substitute.For<IPicturesFromArchive>();
            _subMeassureStringWithTopograpy = Substitute.For<IMeassureStringWithTopograpy>();
        }

        private DrawNormalCards CreateDrawNormalCards()
        {
            return new DrawNormalCards(
                _subDrawStringWithTopograpy,
                _subPicturesFromArchive,
                _subMeassureStringWithTopograpy);
        }

        [Fact]
        public void DrawTextForNormalCards_StateUnderTest_ExpectedBehavior()
        {
            //var testx = _picturesFromArchive.Dividingline.Height; //16
            //var testx2 = _picturesFromArchive.Scrapped.Height; //82

            // Arrange

            var drawNormalCards = CreateDrawNormalCards();
            const string name = "Glücksklinge";
            const CardSubType subType = CardSubType.Weapon;
            const bool twoHanded = false;
            const Condition condition = Condition.Empty;
            const string modifiers = "+1 / 0";
            const string text = "Wenn du eine 6 würfelst, hat diese Waffe stattdessen +4/0.";
            const string flavorText = "Glückstreffer sind die Spezialität dieser Waffe.";
            const string scrapped = "Wenn du eine 6 würfelst, hat die verstärkte Waffe stattdessen +2/0.";

            _subPicturesFromArchive.Dividingline.ReturnsForAnyArgs(TestResources.dividingline);

            _subMeassureStringWithTopograpy.MeassureStringOnBitmapWithTopograpy(Arg.Any<string>(), Arg.Any<Graphics>(), Arg.Any<float>(),
                Arg.Any<int>(), (30, 700), Arg.Any<string>()).ReturnsForAnyArgs(200f);

            _subDrawStringWithTopograpy.DrawStringOnBitmapWithTopograpy(Arg.Any<string>(), Arg.Any<Graphics>(), Arg.Any<float>(),
                Arg.Any<int>(), (30, 700), Arg.Any<string>()).ReturnsForAnyArgs(Graphics.FromImage(TestResources.TextBitmap2));

            var x = Graphics.FromImage(TestResources.TextBitmap2);
            var x2 = new Bitmap(700, 1000, x);
            var x3 = TestResources.TextBitmap2;
            x2.Save("C:\\Users\\TKroeger\\Desktop\\Testordner\\UnitTest_TempName.png", ImageFormat.Png);
            x3.Save("C:\\Users\\TKroeger\\Desktop\\Testordner\\NoGraphics_UnitTest_TempName.png", ImageFormat.Png);

            // Act
            using var result = drawNormalCards.DrawTextForNormalCards(
                name,
                subType,
                twoHanded,
                condition,
                modifiers,
                text,
                flavorText,
                scrapped);

            // Assert

            using var testBitmapList = new DisposableList<Bitmap>();

            testBitmapList.AddSingle(_picturesFromArchive.Class);
            testBitmapList.AddSingle(_picturesFromArchive.Boarder);
            testBitmapList.AddSingle(result);

            using var OutputBitmap = _createPicture.MergedBitmaps(testBitmapList);

            OutputBitmap.Save("C:\\Users\\TKroeger\\Desktop\\Testordner\\" + name + ".png", ImageFormat.Png);

            Assert.True(true);
        }
    }
}
