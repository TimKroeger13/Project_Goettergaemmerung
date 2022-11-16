using System.Collections.Generic;
using Project_Goettergaemmerung.Components.Model;

namespace Project_Goettergaemmerung.Components.CardInformationGetter;

public interface ICardInformationGetter
{
    IEnumerable<CardInformationModel> GetCardInformation();
}
