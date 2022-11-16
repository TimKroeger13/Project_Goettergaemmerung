using System.Text;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Project_Goettergaemmerung.Components;
using Project_Goettergaemmerung.Components.CardInformationGetter;
using Project_Goettergaemmerung.Components.Model;
using Unittests.Components;
using Xunit;

namespace Unittests;

public class CreateDataContext
{
    [Fact]
    public void CreateDatabase()
    {
        var builder = new DbContextOptionsBuilder();
        builder.UseSqlite("Data Source=../../../Version1.sqlite3;");
        var dataContext = new TestDataContext(builder.Options);
    }
}

public class TestDataContext : DbContext
{
    public DbSet<CardInformationModel> CardInformation { get; set; }

    public TestDataContext(DbContextOptions options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CardInformationModel>().ToTable(nameof(CardInformation));
        modelBuilder.Entity<CardInformationModel>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
        modelBuilder.Entity<CardInformationModel>().Property(p => p.SubType).HasConversion<string>();
        modelBuilder.Entity<CardInformationModel>().Property(p => p.Structure).HasConversion<string>();
        modelBuilder.Entity<CardInformationModel>().Property(p => p.CardType).HasConversion<string>();
        modelBuilder.Entity<CardInformationModel>().Property(p => p.Condition).HasConversion<string>();
        modelBuilder.Entity<CardInformationModel>().Property(p => p.Race).HasConversion<string>();
        var userData = Substitute.For<IUserData>();
        userData.GetCardData().Returns(new MemoryStream(Encoding.UTF8.GetBytes(TestResources.Götterdämmerung_Karten)));
        var cardInformation = new CsvCardInformation(userData).GetCardInformation().ToList();
        for (var i = 1; i < cardInformation.Count; i++)
        {
            cardInformation[i].Id = i;
            modelBuilder.Entity<CardInformationModel>().HasData(cardInformation[i]);
        }
        base.OnModelCreating(modelBuilder);
    }
}
