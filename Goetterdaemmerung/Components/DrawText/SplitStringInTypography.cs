using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Goettergaemmerung.Components.DrawText
{
    interface ISplitStringInTypography
    {
        List<(string, char)> SplitString(string text);
    }

    public class SplitStringInTypography : ISplitStringInTypography
    {
        private List<string> _boldKeys = new(new string[] { "+", "-", "/", "|", "FAITH", "VAMPIRISMUS", "PASSIERST",
        "GEWÖHNLICH", "SELTEN", "LEGENDÄR"});
 
        public List<(string, char)> SplitString(string text)
        {
            var typographyMarker = new List<(int Beginning, int End, char Typography)>();

            var toUpperText = text.ToUpper();

            foreach (var key in _boldKeys)
            {
                for (var i = 0; i < toUpperText.Length - (key.Length - 1); i++)
                {
                    if (toUpperText.Substring(i, key.Length) == key)
                    {
                        typographyMarker.Add((i, i + key.Length - 1, 'b'));
                    }
                }
            }
            for (var i = 0; i < toUpperText.Length; i++)
            {
                if (int.TryParse(toUpperText.Substring(i, 1), out _))
                {
                    typographyMarker.Add((i, i, 'b'));
                }
            }
            for (var i = 0; i < toUpperText.Length - ("PASSIERE".Length - 1); i++)
            {
                if (toUpperText.Substring(i, "PASSIERE".Length) == "PASSIERE")
                {
                    if (i != toUpperText.Length - ("PASSIEREN".Length - 1))
                    {
                        if (toUpperText.Substring(i, "PASSIEREN".Length) == "PASSIEREN")
                        {
                            typographyMarker.Add((i, i + "PASSIEREN".Length - 1, 'b'));
                        }
                        else
                        {
                            typographyMarker.Add((i, i + "PASSIERE".Length - 1, 'b'));
                        }
                    }
                    else
                    {
                        typographyMarker.Add((i, i + "PASSIERE".Length - 1, 'b'));
                    }
                }
            }
            for (var i = 0; i < toUpperText.Length - ("(EXTRA DECK)".Length - 1); i++)
            {
                if (toUpperText.Substring(i, "(EXTRA DECK)".Length) == "(EXTRA DECK)")
                {
                    typographyMarker.Add((i, i + "(EXTRA DECK)".Length - 1, 'i'));
                }
            }
            for (var i = 0; i < toUpperText.Length - 1; i++)
            {
                if (toUpperText.Substring(i, "D".Length) == "D" && int.TryParse(toUpperText.Substring(i + 1, 1), out _))
                {
                    typographyMarker.Add((i, i, 'b'));
                }
            }

            return SplitStringToText((SortSplitString(typographyMarker), text));
        }
        private static List<(int, int, char)> SortSplitString(List<(int, int, char)> marker)
        {
            marker.Sort((a, b) => a.Item1.CompareTo(b.Item1));
            return marker;
        }
        private List<(string, char)> SplitStringToText((List<(int, int, char)>, string) marker)
        {
            var TypographyList = new List<(string, char)>();

            var splitString = marker.Item1;
            var text = marker.Item2;
            var textLength = marker.Item2.Length;
            var charPointer = 0;

            var k = 0;
            while (k < splitString.Count())
            {
                var beginning = splitString[k].Item1;
                var end = splitString[k].Item2;
                var typography = splitString[k].Item3;
                var charNeighbor = 0;

                if (beginning != 0 && beginning - charPointer != 0)
                {
                    TypographyList.Add((text.Substring(charPointer, beginning - charPointer), 'r'));
                }

                bool AddNoMoreChars;

                while (true)
                {
                    AddNoMoreChars = true;

                    if (end + 1 + charNeighbor == textLength) { break; }

                    if (text.Substring(end + 1 + charNeighbor, 1) == " ")
                    {
                        charNeighbor += 1;
                        AddNoMoreChars = false;
                    }

                    var j = 0;
                    while (j < splitString.Count())
                    {
                        if (end + 1 + charNeighbor == splitString[j].Item1 && typography == splitString[j].Item3)
                        {
                            charNeighbor += splitString[j].Item2 - splitString[j].Item1 + 1;
                            k += 1;
                            AddNoMoreChars = false;
                            break;
                        }
                        j++;
                    }
                    if (AddNoMoreChars) { break; }
                }

                charPointer = end + charNeighbor + 1;

                var test1 = end;
                var test2 = end - beginning + 1 + charNeighbor;

                TypographyList.Add((text.Substring(beginning, end - beginning + 1 + charNeighbor), typography));

                k++;
            }

            if (charPointer != textLength)
            {
                TypographyList.Add((text.Substring(charPointer, textLength - charPointer), 'r'));
            }

            return TypographyList;
        }
    }
}
