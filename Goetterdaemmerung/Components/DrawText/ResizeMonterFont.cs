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
            int[] listOfFonts = { nameFontsize, lvlRaceFontsize, textFontsize, flavorTextFontsize };

            var biggestFont = listOfFonts.Max();

            nameFontsize = (int)Math.Round(((decimal)nameFontsize / (decimal)biggestFont) * ((decimal)biggestFont - (decimal)runnumber));
            lvlRaceFontsize = (int)Math.Round(((decimal)lvlRaceFontsize / (decimal)biggestFont) * ((decimal)biggestFont - (decimal)runnumber));
            textFontsize = (int)Math.Round(((decimal)textFontsize / (decimal)biggestFont) * ((decimal)biggestFont - (decimal)runnumber));
            flavorTextFontsize = (int)Math.Round(((decimal)flavorTextFontsize / (decimal)biggestFont) * ((decimal)biggestFont - (decimal)runnumber));

            return (nameFontsize, lvlRaceFontsize, textFontsize, flavorTextFontsize);
        }
    }
}
