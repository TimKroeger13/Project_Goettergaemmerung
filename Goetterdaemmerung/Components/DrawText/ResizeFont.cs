using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Drawing.Text;
using System.Threading.Tasks;
using Project_Goettergaemmerung.Components.Model;
using System.ComponentModel;
using Project_Goettergaemmerung.ExtensionMethods;
using System.Drawing.Imaging;

namespace Project_Goettergaemmerung.Components.DrawText
{
    public interface IResizeFont
    {
        (int nameFontsize, int cardSubTypeFontsize, int twoHandedFontsize, int conditionFontsize, int modifiersFontsize, int centerFontsize, int textFontsize, int flavorTextFontsize, int scrappedFontsize) NewFontSize(int Runnumber, int nameFontsize, int cardSubTypeFontsize, int twoHandedFontsize, int conditionFontsize, int modifiersFontsize, int centerFontsize, int textFontsize, int flavorTextFontsize, int scrappedFontsize);
    }

    public class ResizeFont : IResizeFont
    {
        public (int nameFontsize, int cardSubTypeFontsize, int twoHandedFontsize, int conditionFontsize, int modifiersFontsize, int centerFontsize, int textFontsize, int flavorTextFontsize, int scrappedFontsize) NewFontSize
               (int Runnumber, int nameFontsize, int cardSubTypeFontsize, int twoHandedFontsize, int conditionFontsize, int modifiersFontsize, int centerFontsize, int textFontsize, int flavorTextFontsize, int scrappedFontsize)
        {
            int[] ListOfFonts = { nameFontsize, cardSubTypeFontsize, twoHandedFontsize, conditionFontsize, modifiersFontsize, textFontsize, flavorTextFontsize, scrappedFontsize };

            var BiggestFont = ListOfFonts.Max();

            nameFontsize = (int)Math.Round(((Decimal)nameFontsize / (Decimal)BiggestFont) * ((Decimal)BiggestFont - (Decimal)Runnumber));
            cardSubTypeFontsize = (int)Math.Round(((Decimal)cardSubTypeFontsize / (Decimal)BiggestFont) * ((Decimal)BiggestFont - (Decimal)Runnumber));
            twoHandedFontsize = (int)Math.Round(((Decimal)twoHandedFontsize / (Decimal)BiggestFont) * ((Decimal)BiggestFont - (Decimal)Runnumber));
            conditionFontsize = (int)Math.Round(((Decimal)conditionFontsize / (Decimal)BiggestFont) * ((Decimal)BiggestFont - (Decimal)Runnumber));
            modifiersFontsize = (int)Math.Round(((Decimal)modifiersFontsize / (Decimal)BiggestFont) * ((Decimal)BiggestFont - (Decimal)Runnumber));
            centerFontsize = (int)Math.Round(((Decimal)centerFontsize / (Decimal)BiggestFont) * ((Decimal)BiggestFont - (Decimal)Runnumber));
            textFontsize = (int)Math.Round(((Decimal)textFontsize / (Decimal)BiggestFont) * ((Decimal)BiggestFont - (Decimal)Runnumber));
            flavorTextFontsize = (int)Math.Round(((Decimal)flavorTextFontsize / (Decimal)BiggestFont) * ((Decimal)BiggestFont - (Decimal)Runnumber));
            scrappedFontsize = (int)Math.Round(((Decimal)scrappedFontsize / (Decimal)BiggestFont) * ((Decimal)BiggestFont - (Decimal)Runnumber));

            return (nameFontsize, cardSubTypeFontsize, twoHandedFontsize, conditionFontsize, modifiersFontsize, centerFontsize, textFontsize, flavorTextFontsize, scrappedFontsize);
        }
    }
}
