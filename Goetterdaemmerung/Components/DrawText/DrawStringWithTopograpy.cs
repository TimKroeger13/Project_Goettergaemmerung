using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Drawing.Text;
using System.Threading.Tasks;
using Project_Goettergaemmerung.Components.Model;

namespace Project_Goettergaemmerung.Components.DrawText
{
    public interface IDrawStringWithTopograpy
    {
        Graphics DrawStringOnBitmapWithTopograpy(List<(string, Typography)> SplitText, Graphics bitmap, int textHigth, int fontSize,
                    (int offSet, int width) widthBoarders, string fontName, StringFormat StringFormat);
    }

    public class DrawStringWithTopograpy : IDrawStringWithTopograpy
    {
        private readonly ISplitStringInTypography _splitStringInTypography;

        public DrawStringWithTopograpy(ISplitStringInTypography splitStringInTypography)
        {
            _splitStringInTypography = splitStringInTypography;
        }

        public Graphics DrawStringOnBitmapWithTopograpy(List<(string, Typography)> SplitText, Graphics bitmap, int textHigth, int fontSize,
            (int offSet, int width) widthBoarders, string fontName, StringFormat StringFormat)
        {
            //var SplitText = _splitStringInTypography.SplitString(text);

            /*
            var textRectangle = new RectangleF();
            var spiltText = _splitStringInTypography.SplitString(text);

            using (var useFont = new Font(fontName, fontSize, FontStyle.Regular))
            {
                textRectangle.Location = new Point(widthBoarders.offSet, textHigth);
                textRectangle.Size = new Size(widthBoarders.width - (widthBoarders.offSet * 2),
                    (int)bitmap.MeasureString(text, useFont, widthBoarders.width - (widthBoarders.offSet * 2), StringFormatForBitmap).Height);
                textHigth = (int)textRectangle.Bottom;
                bitmap.DrawString(text, useFont, Brushes.Black, textRectangle, StringFormatForBitmap);
            }
            */

            return (bitmap);
        }
    }
}
