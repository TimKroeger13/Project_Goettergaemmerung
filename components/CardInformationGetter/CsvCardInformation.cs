using System.Collections.Generic;
using Project_Goettergaemmerung.Components.Model;

namespace Project_Goettergaemmerung.Components.CardInformationGetter
{
    public class CsvCardInformation : ICardInformationGetter
    {
        public IEnumerable<CardInformationModel> GetCardInformation()
        {
            return new List<CardInformationModel>() { new CardInformationModel() { Text = "Hello from Csv" } };
        }
    }
}
