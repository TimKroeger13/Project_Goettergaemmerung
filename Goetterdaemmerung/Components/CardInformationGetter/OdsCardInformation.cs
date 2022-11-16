using Project_Goettergaemmerung.Components.Model;

namespace Project_Goettergaemmerung.Components.CardInformationGetter;

public class OdsCardInformation : ICardInformationGetter
{
    public IEnumerable<CardInformationModel> GetCardInformation()
    {
        return new List<CardInformationModel>() { new CardInformationModel() };
    }

    public IEnumerable<CardInformationModel> GetCardInformation(string path)
    {
        throw new System.NotImplementedException();
    }
}
