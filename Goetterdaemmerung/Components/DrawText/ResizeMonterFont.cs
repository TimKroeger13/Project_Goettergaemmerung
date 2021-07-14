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
    public interface IResizeMonterFont
    {
        (int nameFontsize, int lvlRaceFontsize, int textFontsize, int flavorTextFontsize) NewFontSize(int runnumber, int nameFontsize, int lvlRaceFontsize, int textFontsize, int flavorTextFontsize);
    }

    public class ResizeMonterFont : IResizeMonterFont
    {
        public (int nameFontsize, int lvlRaceFontsize, int textFontsize, int flavorTextFontsize) NewFontSize
               (int runnumber, int nameFontsize, int lvlRaceFontsize, int textFontsize, int flavorTextFontsize)
        {
            int[] ListOfFonts = { nameFontsize, lvlRaceFontsize, textFontsize, flavorTextFontsize };

            var BiggestFont = ListOfFonts.Max();

            nameFontsize = (int)Math.Round(((Decimal)nameFontsize / (Decimal)BiggestFont) * ((Decimal)BiggestFont - (Decimal)runnumber));
            lvlRaceFontsize = (int)Math.Round(((Decimal)lvlRaceFontsize / (Decimal)BiggestFont) * ((Decimal)BiggestFont - (Decimal)runnumber));
            textFontsize = (int)Math.Round(((Decimal)textFontsize / (Decimal)BiggestFont) * ((Decimal)BiggestFont - (Decimal)runnumber));
            flavorTextFontsize = (int)Math.Round(((Decimal)flavorTextFontsize / (Decimal)BiggestFont) * ((Decimal)BiggestFont - (Decimal)runnumber));

            return (nameFontsize, lvlRaceFontsize, textFontsize, flavorTextFontsize);
        }
    }
}
