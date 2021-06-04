using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Project_Goettergaemmerung.Components.Model;

namespace Project_Goettergaemmerung.Components.DrawText
{
    public interface ISplitStringInTypography
    {
        List<(string, Typography)> SplitString(string text);
    }

    public class SplitStringInTypography : ISplitStringInTypography
    {
        public List<(string, Typography)> SplitString(string text)
        {
            var boldKeys = new Regex("[0-9]|PASSIER.*|GEWÖHNLICH|SELTEN|LEGENDÄR|VAMPIRISMUS|FAITH|\\||\\+|\\-|/");
            var italicKeys = new Regex("EXTRA DECK|EXTRADECK");
            var typographyMarker = new List<(string words, Typography marker)>();
            var toUpperText = text.ToUpper();
            var splitString = text.Split(null);
            var toUpperSplitString = toUpperText.Split(null);
            var i = 0;
            foreach (var item in toUpperSplitString)
            {
                if (boldKeys.IsMatch(item)) { typographyMarker.Add((splitString[i], Typography.Bold)); }
                else if (italicKeys.IsMatch(item)) { typographyMarker.Add((splitString[i], Typography.Italic)); }
                else { typographyMarker.Add((splitString[i], Typography.Regular)); }
                i++;
            }
            return typographyMarker;
        }
    }
}
