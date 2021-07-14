using System.Collections.Generic;
using System.IO;
using Project_Goettergaemmerung.Components.Model;
using System.Diagnostics;
using System.Linq;
using System;
using System.Text;

namespace Project_Goettergaemmerung.Components.CardInformationGetter
{
    public class CsvCardInformation : ICardInformationGetter
    {
        private string LoadCsv(string path)
        {
            return File.ReadAllText(path);
        }

        private string CleanStrings(string String)
        {
            if (String.Length > 0)
            {
                if (String[0] == '"')
                {
                    var outputString = new StringBuilder();
                    bool skip = false;

                    for (int i = 0; i < String.Length; i++)
                    {
                        if (String[i] != '"' || skip)
                        {
                            outputString.Append(String[i]);

                            if (skip) { skip = false; }
                        }
                        if (String[i] == '"') { skip = true; }
                    }

                    return outputString.ToString();
                }
                else
                {
                    return String;
                }
            }
            else
            {
                return String;
            }
        }

        public IEnumerable<CardInformationModel> GetCardInformation(string path)
        {
            var dictionaryCardStructure = Enum.GetValues<CardStructure>().ToDictionary(ct => Enum.GetName(ct), StringComparer.OrdinalIgnoreCase);
            var dictionaryCardType = Enum.GetValues<CardType>().ToDictionary(ct => Enum.GetName(ct), StringComparer.OrdinalIgnoreCase);
            dictionaryCardType.Add("", CardType.Empty);
            var dictionaryCardSubType = Enum.GetValues<CardSubType>().ToDictionary(ct => Enum.GetName(ct), StringComparer.OrdinalIgnoreCase);
            dictionaryCardSubType.Add("", CardSubType.Empty);
            var dictionaryCondition = Enum.GetValues<Condition>().ToDictionary(ct => Enum.GetName(ct), StringComparer.OrdinalIgnoreCase);
            dictionaryCondition.Add("", Condition.Empty);
            var dictionaryRace = Enum.GetValues<Race>().ToDictionary(ct => Enum.GetName(ct), StringComparer.OrdinalIgnoreCase);
            dictionaryRace.Add("", Race.Empty);

            var loadedCSV = LoadCsv(path);
            var newLineSplitted = loadedCSV.Split("\r\n");
            var splitMatrix = newLineSplitted.Select(line => line.Split(";"));

            var result = new List<CardInformationModel>();
            foreach (var row in splitMatrix)
            {
                if (row.Length < 18) continue;
                if (row[0] == "Struktur") continue;
                var model = new CardInformationModel();
                model.Structure = dictionaryCardStructure[row[0]];
                model.ExtraDeck = row[1] == "1";
                model.CardType = dictionaryCardType[row[2]];
                model.Name = CleanStrings(row[3]);
                model.SubType = dictionaryCardSubType[row[4]];
                model.TwoHanded = row[5] == "Zweihändig";
                model.Condition = dictionaryCondition[row[6]];
                model.Modifiers = CleanStrings(row[7]);
                model.CenterText = CleanStrings(row[8]);
                model.Text = CleanStrings(row[9]);
                model.FlavorText = CleanStrings(row[10]);
                model.Level = row[11];
                model.Race = dictionaryRace[row[12]];
                model.WinText = CleanStrings(row[13]);
                model.LoseText = CleanStrings(row[14]);
                model.Scrapped = CleanStrings(row[15]);
                model.Print1 = int.Parse(row[16]);
                model.Print2 = int.Parse(row[17]);
                model.Print3 = int.Parse(row[18]);
                model.Print4 = int.Parse(row[19]);

                result.Add(model);
            }
            return result;
        }
    }
}
