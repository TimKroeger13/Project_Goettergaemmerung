using NSubstitute;
using Project_Goettergaemmerung.Components;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using Xunit;

namespace Unittests.Components
{
    public class DrawTextAsBitmapTests
    {
        public Bitmap White { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\class.png");
        public Bitmap Boarder { get; set; } = new Bitmap("M:\\Repos\\Project_Goettergaemmerung\\elements\\boarder.png");


        public DrawTextAsBitmapTests()
        {

        }

        private DrawTextAsBitmap CreateDrawTextAsBitmap()
        {
            return new DrawTextAsBitmap();
        }

        [Theory]
        [InlineData("Testname with more word than one line can show")]
        [InlineData("Shortname")]
        [InlineData("MegaLongNameWithNoSpacesBetweenTheWords")]
        public void DrawText_StateUnderTest_ExpectedBehavior(string name)
        {
            var drawTextAsBitmap = this.CreateDrawTextAsBitmap();
            var textBitmap = drawTextAsBitmap.DrawText(
                name);

            var result = White;
            using (var g = Graphics.FromImage(result))
            {
                g.DrawImage(Boarder, Point.Empty);
                g.DrawImage(textBitmap, Point.Empty);
            }

            result.Save("C:\\Users\\TKroeger\\Desktop\\Testordner\\" + name + ".png", ImageFormat.Png);
        }
    }
}
