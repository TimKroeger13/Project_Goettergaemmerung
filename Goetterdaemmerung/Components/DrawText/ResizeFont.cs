namespace Project_Goettergaemmerung.Components.DrawText;

public interface IResizeFont
{
    (int nameFontsize, int cardSubTypeFontsize, int twoHandedFontsize, int conditionFontsize, int modifiersFontsize, int centerFontsize, int textFontsize, int flavorTextFontsize, int scrappedFontsize) NewFontSize(int runnumber, int nameFontsize, int cardSubTypeFontsize, int twoHandedFontsize, int conditionFontsize, int modifiersFontsize, int centerFontsize, int textFontsize, int flavorTextFontsize, int scrappedFontsize);
}

public class ResizeFont : IResizeFont
{
    public (int nameFontsize, int cardSubTypeFontsize, int twoHandedFontsize, int conditionFontsize, int modifiersFontsize, int centerFontsize, int textFontsize, int flavorTextFontsize, int scrappedFontsize) NewFontSize
           (int runnumber, int nameFontsize, int cardSubTypeFontsize, int twoHandedFontsize, int conditionFontsize, int modifiersFontsize, int centerFontsize, int textFontsize, int flavorTextFontsize, int scrappedFontsize)
    {
        int[] listOfFonts = { nameFontsize, cardSubTypeFontsize, twoHandedFontsize, conditionFontsize, modifiersFontsize, textFontsize, flavorTextFontsize, scrappedFontsize };

        var biggestFont = listOfFonts.Max();

        nameFontsize = (int)Math.Round(((decimal)nameFontsize / (decimal)biggestFont) * ((decimal)biggestFont - (decimal)runnumber));
        cardSubTypeFontsize = (int)Math.Round(((decimal)cardSubTypeFontsize / (decimal)biggestFont) * ((decimal)biggestFont - (decimal)runnumber));
        twoHandedFontsize = (int)Math.Round(((decimal)twoHandedFontsize / (decimal)biggestFont) * ((decimal)biggestFont - (decimal)runnumber));
        conditionFontsize = (int)Math.Round(((decimal)conditionFontsize / (decimal)biggestFont) * ((decimal)biggestFont - (decimal)runnumber));
        modifiersFontsize = (int)Math.Round(((decimal)modifiersFontsize / (decimal)biggestFont) * ((decimal)biggestFont - (decimal)runnumber));
        centerFontsize = (int)Math.Round(((decimal)centerFontsize / (decimal)biggestFont) * ((decimal)biggestFont - (decimal)runnumber));
        textFontsize = (int)Math.Round(((decimal)textFontsize / (decimal)biggestFont) * ((decimal)biggestFont - (decimal)runnumber));
        flavorTextFontsize = (int)Math.Round(((decimal)flavorTextFontsize / (decimal)biggestFont) * ((decimal)biggestFont - (decimal)runnumber));
        scrappedFontsize = (int)Math.Round(((decimal)scrappedFontsize / (decimal)biggestFont) * ((decimal)biggestFont - (decimal)runnumber));

        return (nameFontsize, cardSubTypeFontsize, twoHandedFontsize, conditionFontsize, modifiersFontsize, centerFontsize, textFontsize, flavorTextFontsize, scrappedFontsize);
    }
}
