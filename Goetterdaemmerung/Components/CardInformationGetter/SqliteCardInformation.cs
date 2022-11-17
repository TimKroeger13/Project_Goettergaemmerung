using Microsoft.EntityFrameworkCore;
using Project_Goettergaemmerung.Components.Model;

namespace Project_Goettergaemmerung.Components.CardInformationGetter;

public class SqliteCardInformation : ICardInformationGetter
{
    private readonly IUserData _userData;

    public SqliteCardInformation(IUserData userData)
    {
        _userData = userData;
    }

    public IEnumerable<CardInformationModel> GetCardInformation()
    {
        var builder = new DbContextOptionsBuilder();
        builder.UseSqlite($"Data Source={_userData.ImportPath}");
        var dataContext = new DataContext(builder.Options);
        return dataContext.CardInformation.ToList();
    }
}
