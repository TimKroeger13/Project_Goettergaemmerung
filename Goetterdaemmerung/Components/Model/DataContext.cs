using Microsoft.EntityFrameworkCore;

namespace Project_Goettergaemmerung.Components.Model;

public class DataContext : DbContext
{
    public DbSet<CardInformationModel> CardInformation { get; set; }

    public DataContext(DbContextOptions options) : base(options)
    {
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
        base.OnModelCreating(modelBuilder);
    }
}
