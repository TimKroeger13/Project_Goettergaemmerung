using System.Collections.Generic;

namespace Project_Goettergaemmerung.ExtensionMethods
{
    public static class SplitSting
    {
        public static List<string> StringSplitter(this string text)
        {
            var splitString = new List<string>();
            var firstLetterOfAWord = 0;

            if (text.Length > 0)
            {
                for (var i = 0; i < text.Length; i++)
                {
                    if (text[i] == ' ')
                    {
                        splitString.Add(text.Substring(firstLetterOfAWord, i - firstLetterOfAWord));
                        firstLetterOfAWord = i + 1;
                    }
                    if (text[i] == '\n')
                    {
                        if (i - firstLetterOfAWord > 1)
                        {
                            splitString.Add(text.Substring(firstLetterOfAWord, i - firstLetterOfAWord));
                        }
                        splitString.Add("<br>");
                        firstLetterOfAWord = i + 1;
                    }
                }
                splitString.Add(text[firstLetterOfAWord..]);

                return splitString;
            }

            return new List<string>(new string[] { "" });
        }
    }
}
