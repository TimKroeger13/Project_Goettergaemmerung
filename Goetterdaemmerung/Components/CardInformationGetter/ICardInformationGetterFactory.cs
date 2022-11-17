using Project_Goettergaemmerung.Components.Model;

namespace Project_Goettergaemmerung.Components.CardInformationGetter;

public interface ICardInformationGetterFactory
{
    ICardInformationGetter CreateCardInformationGetter();
}

public class CardInformationGetterFactory : ICardInformationGetterFactory
{
    private readonly IUserData _userData;

    public CardInformationGetterFactory(IUserData userData)
    {
        _userData = userData;
    }

    public ICardInformationGetter CreateCardInformationGetter()
    {
        return _userData.ImportType switch
        {
            CardImportType.CSV => new CsvCardInformation(_userData),
            CardImportType.Sqlite => new SqliteCardInformation(_userData),
            _ => throw new Exception("No Cardinformationgetter registered"),
        };
    }
}
