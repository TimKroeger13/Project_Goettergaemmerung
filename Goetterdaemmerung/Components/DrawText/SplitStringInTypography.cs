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
        ICollection<(string Word, Typography Marker)> SplitString(string text);
    }

    public class SplitStringInTypography : ISplitStringInTypography
    {
        public ICollection<(string Word, Typography Marker)> SplitString(string text)
        {
            var boldKeys = new Regex("[0-9]|(?i)PASSIER.*|GEWÖHNLICH|SELTEN|LEGENDÄR|VAMPIRISMUS|FAITH(?-i)|\\||\\+|\\-");
            var italicKeys = new Regex("(?i)EXTRADECK|\\(EXTRA|DECK\\)(?-i)");
            var brackets = new Regex("\"");
            var bracketsLock = false;
            var typographyMarker = new List<(string Word, Typography Marker)>();
            foreach (var item in (string[])text.Split(null))
            {
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
                    else { typographyMarker.Add((item, Typography.Regular)); }
                }
            }
            return typographyMarker;
        }
    }
}
