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
        private List<string> _boldKeys = new List<string>(new string[] { "+", "-", "/", "|", "FAITH", "VAMPIRISMUS", "PASSIERST",
        "GEWÖHNLICH", "SELTEN", "LEGENDÄR"});
 
        public List<(string, char)> SplitString(string text)
        {
            var tupleList = new List<(string, char)>();
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
                if (toUpperText.Substring(i, "D".Length - 1) == "D" && int.TryParse(toUpperText.Substring(i + 1, 1), out _))
                {
                    typographyMarker.Add((i, i, 'b'));
                }
            }

            //var x = SortSplitString(typographyMarker);
            var z2 = SplitStringToText((SortSplitString(typographyMarker), text));

            return tupleList;
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

            for (var i = 0; i < splitString.Count(); i++)
            {//WHILE LOOP
                var beginning = splitString[i].Item1;
                var end = splitString[i].Item2;
                var typography = splitString[i].Item3;
                var charPointer = 0;

                var charNeighbor = 0;

                if (beginning != 0)
                {
                }
                var x = text.Substring(charPointer, beginning - charPointer);
                if (text.Substring(beginning, end - beginning + 1 + charNeighbor) == "")
                {
                    charNeighbor += 1;
                }
                if (end + 1 + charNeighbor == splitString[i].Item1)//Das hier an die While Loop anpassen
                {


                }

                var x2 = text.Substring(beginning, end - beginning + 1);



            }
            //Find string Part / Solo string / Connect between spaces



            TypographyList.Add(new Tuple<string, char>("sdsd", 'b').ToValueTuple());

            return TypographyList;
        }


    }
}
