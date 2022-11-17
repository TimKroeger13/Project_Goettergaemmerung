﻿using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
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
        var options = new JsonSerializerOptions();
        options.Converters.Add(new JsonStringEnumConverter());
        var cardInformation = JsonSerializer.Deserialize<List<CardInformationModel>>(TestResources.Karten_Version1, options);
        for (var i = 0; i < cardInformation.Count; i++)
        {
            if (cardInformation[i].Id == 0) cardInformation[i].Id = i + 1;
            modelBuilder.Entity<CardInformationModel>().HasData(cardInformation[i]);
        }
        base.OnModelCreating(modelBuilder);
    }
}
