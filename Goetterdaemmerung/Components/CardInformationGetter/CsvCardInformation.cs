using System.Collections.Generic;
using System.IO;
using Project_Goettergaemmerung.Components.Model;
using System.Diagnostics;
using System.Linq;
using System;
using System.Text;
using Project_Goettergaemmerung.Components;

namespace Project_Goettergaemmerung.Components.CardInformationGetter
{
    public class CsvCardInformation : ICardInformationGetter
    {
        private readonly IUserData _userData;

        public CsvCardInformation(IUserData userData)
        {
            _userData = userData;
        }

        private string LoadCsv(string path)
        {
            return File.ReadAllText(path);
        }

        private string CleanStrings(string rawString)
        {
            if (rawString.Length > 0)
            {
                if (rawString[0] == '"')
                {
                    var outputString = new StringBuilder();
                    var skip = false;

                    for (var i = 0; i < rawString.Length; i++)
                    {
                        if (rawString[i] != '"' || skip)
                        {
                            outputString.Append(rawString[i]);

                            if (skip) { skip = false; }
                        }
                        if (rawString[i] == '"') { skip = true; }
                    }

                    if (outputString[outputString.Length - 1] == '"' && outputString[outputString.Length - 2] == '"')
                    {
                        outputString.Remove(outputString.Length - 1, 1);
                    }

                    if (outputString[0] == '"' && outputString[1] == '"')
                    {
                        outputString.Remove(0, 1);
                    }

                    return outputString.ToString();
                }
                else
                {
                    return rawString;
                }
            }
            else
            {
                return rawString;
            }
        }

        private string CheckIfNull(string print)
        {
            if (print.Length == 0)
            {
                return "0";
            }
            return print;
        }

        public IEnumerable<CardInformationModel> GetCardInformation()
        {
            var dictionaryCardStructure = Enum.GetValues<CardStructure>().ToDictionary(i =>
            { var enumName = Enum.GetName(i); return (enumName != null) ? enumName.ToUpper() : ""; });

            var dictionaryCardType = Enum.GetValues<CardType>().ToDictionary(i =>
            { var enumName = Enum.GetName(i); return (enumName != null) ? enumName.ToUpper() : ""; });
            dictionaryCardType.Add("", CardType.Empty);

            var dictionaryCardSubType = Enum.GetValues<CardSubType>().ToDictionary(i =>
            { var enumName = Enum.GetName(i); return (enumName != null) ? enumName.ToUpper() : ""; });
            dictionaryCardSubType.Add("", CardSubType.Empty);

            var dictionaryCondition = Enum.GetValues<Condition>().ToDictionary(i =>
            { var enumName = Enum.GetName(i); return (enumName != null) ? enumName.ToUpper() : ""; });
            dictionaryCondition.Add("", Condition.Empty);

            var dictionaryRace = Enum.GetValues<Race>().ToDictionary(i =>
            { var enumName = Enum.GetName(i); return (enumName != null) ? enumName.ToUpper() : ""; });
            dictionaryRace.Add("", Race.Empty);

            var path = _userData.ImportPath;
            if (path == null) { path = ""; }
            var loadedCSV = LoadCsv(path);
            var newLineSplitted = loadedCSV.Split("\r\n");
            var splitMatrix = newLineSplitted.Select(line => line.Split(";"));

            var result = new List<CardInformationModel>();
            foreach (var row in splitMatrix)
            {
                if (row.Length < 18) continue;
                if (row[0] == "Struktur") continue;
                var model = new CardInformationModel
                {
                    Structure = dictionaryCardStructure[row[0].ToUpper()],
                    ExtraDeck = row[1] == "1",
                    CardType = dictionaryCardType[row[2].ToUpper()],
                    Name = CleanStrings(row[3]),
                    SubType = dictionaryCardSubType[row[4].ToUpper()],
                    TwoHanded = row[5] == "Zweihändig",
                    Condition = dictionaryCondition[row[6].ToUpper()],
                    Modifiers = CleanStrings(row[7]),
                    CenterText = CleanStrings(row[8]),
                    Text = CleanStrings(row[9]),
                    FlavorText = CleanStrings(row[10]),
                    Level = row[11],
                    Race = dictionaryRace[row[12].ToUpper()],
                    WinText = CleanStrings(row[13]),
                    LoseText = CleanStrings(row[14]),
                    Scrapped = CleanStrings(row[15]),
                    Print1 = int.Parse(CheckIfNull(row[16])),
                    Print2 = int.Parse(CheckIfNull(row[17])),
                    Print3 = int.Parse(CheckIfNull(row[18])),
                    Print4 = int.Parse(CheckIfNull(row[19]))
                };

                result.Add(model);
            }
            return result;
        }
    }
}
