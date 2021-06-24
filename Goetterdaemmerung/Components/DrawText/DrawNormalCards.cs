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
    public interface IDrawNormalCards
    {
        Bitmap DrawTextForNormalCards(string name, CardSubType subType, bool twoHanded, Condition condition, string modifiers, string text, string flavorText, string scrapped);
    }

    public class DrawNormalCards : IDrawNormalCards
    {
        private readonly IPicturesFromArchive _picturesFromArchive;

        public DrawNormalCards(IPicturesFromArchive picturesFromArchive)
        {
            _picturesFromArchive = picturesFromArchive;
        }

        public Bitmap DrawTextForNormalCards(string name, CardSubType subType, bool twoHanded, Condition condition, string modifiers, string text, string flavorText, string scrapped)
        {
            var textBitmap = new Bitmap(700, 1000);

            return textBitmap;
        }
    }
}
