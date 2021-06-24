using System.Collections.Generic;
using System.IO;
using Project_Goettergaemmerung.Components.Model;
using System.Diagnostics;
using System.Linq;
using System;

namespace Project_Goettergaemmerung.Components.CardInformationGetter
{
    public class CsvCardInformation : ICardInformationGetter
    {
        private string LoadCsv(string path)
        {
            return File.ReadAllText(path);
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
                model.Name = row[3];
                model.SubType = dictionaryCardSubType[row[4]];
                model.TwoHanded = row[5] == "Zweihändig";
                model.Condition = dictionaryCondition[row[6]];
                model.Modifiers = row[7];
                model.Text = row[8];
                model.FlavorText = row[9];
                model.Level = row[10];
                model.Race = dictionaryRace[row[11]];
                model.WinText = row[12];
                model.LoseText = row[13];
                model.Scrapped = row[14];
                model.Print1 = int.Parse(row[15]);
                model.Print2 = int.Parse(row[16]);
                model.Print3 = int.Parse(row[17]);
                model.Print4 = int.Parse(row[18]);

                result.Add(model);
            }
            return result;
        }
    }
}
