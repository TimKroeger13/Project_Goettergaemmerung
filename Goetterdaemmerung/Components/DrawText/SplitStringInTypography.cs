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
            var boldKeys = new Regex("[0-9]|(?i)PASSIER.*|GEWÖHNLICH|SELTEN|LEGENDÄR|VAMPIRISMUS|FAITH(?-i)|\\||\\+|\\-|/");
            var italicKeys = new Regex("(?i)EXTRA DECK|EXTRADECK(?-i)");
            var typographyMarker = new List<(string words, Typography marker)>();
            var splitString = text.Split(null);
            foreach (var item in splitString)
            {
                if (boldKeys.IsMatch(item)) { typographyMarker.Add((item, Typography.Bold)); }
                else if (italicKeys.IsMatch(item)) { typographyMarker.Add((item, Typography.Italic)); }
                else { typographyMarker.Add((item, Typography.Regular)); }
            }
            return typographyMarker;
        }
    }
}