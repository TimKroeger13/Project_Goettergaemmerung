using System.Text.RegularExpressions;
using Project_Goettergaemmerung.Components.Model;
using Project_Goettergaemmerung.ExtensionMethods;

namespace Project_Goettergaemmerung.Components.DrawText;

public interface ISplitStringInTypography
{
    ICollection<(string Word, Typography Marker)> SplitString(string text);
}

public class SplitStringInTypography : ISplitStringInTypography
{
    public ICollection<(string Word, Typography Marker)> SplitString(string text)
    {
        var boldKeys = new Regex("[0-9]|(?i)PASSIER.*|GEWÖHNLICH|EHRE|SELTEN|LEGENDÄR|VAMPIRISMUS|GLAUBE|KRIT|\\(FÄHIGKEIT\\)|\\||\\+|\\-(?-i)");
        var italicKeys = new Regex("(?i)EXTRADECK|\\(EXTRA|DECK\\)(?-i)");
        var brackets = new Regex("\"");
        var punctuated = new Regex(":");
        var bracketsLock = false;
        var typographyMarker = new List<(string Word, Typography Marker)>();
        var punctuationMarker = 0;
        var punktuationCounter = 0;
        foreach (var item in text.StringSplitter())
        {
            punktuationCounter++;
            if (brackets.IsMatch(item) || bracketsLock)
            {
                typographyMarker.Add((item, Typography.Bold));
                if (brackets.IsMatch(item) && !bracketsLock && brackets.Matches(item).Count == 1)
                {
                    bracketsLock = true;
                }
                else if (brackets.IsMatch(item) && bracketsLock)
                {
                    bracketsLock = false;
                }
            }
            else
            {
                if (boldKeys.IsMatch(item)) { typographyMarker.Add((item, Typography.Bold)); }
                else if (italicKeys.IsMatch(item)) { typographyMarker.Add((item, Typography.Italic)); }
                else if (item == "<br>")
                {
                    typographyMarker.Add((item, Typography.LineBreak));
                    punctuationMarker = punktuationCounter;
                }
                else { typographyMarker.Add((item, Typography.Regular)); }
            }
            if (punctuated.IsMatch(item))
            {
                for (var i = punctuationMarker; i < punktuationCounter; i++)
                {
                    typographyMarker[i] = (typographyMarker[i].Word, Typography.Bold);
                }
            }
        }
        return typographyMarker;
    }
}
