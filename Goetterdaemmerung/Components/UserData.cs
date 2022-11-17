using Project_Goettergaemmerung.Components.Model;

namespace Project_Goettergaemmerung.Components;

public interface IUserData
{
    MemoryStream? GetCardData();

    CardImportType ImportType { get; set; }
    string? ExportPath { get; set; }
    string? ImportPath { get; set; }
    PrintType Printer { get; set; }
    SaveFormat CurrentFormat { get; set; }
    int RebalenceNumber { get; set; }
}

public class UserData : IUserData
{
    public CardImportType ImportType { get; set; } = CardImportType.NA;
    public string? ImportPath { get; set; }
    public string? ExportPath { get; set; }
    public PrintType Printer { get; set; } = PrintType.Print1;
    public SaveFormat CurrentFormat { get; set; } = SaveFormat.normal;
    public int RebalenceNumber { get; set; } = 1;

    public MemoryStream? GetCardData()
    {
        if (ImportPath == null) return null;
        var fileStream = File.OpenRead(ImportPath);
        var memoryStream = new MemoryStream();
        fileStream.CopyTo(memoryStream);
        memoryStream.Position = 0;
        return memoryStream;
    }
}
