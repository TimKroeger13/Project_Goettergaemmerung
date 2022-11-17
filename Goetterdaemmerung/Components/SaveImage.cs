using System.Drawing.Imaging;
using Project_Goettergaemmerung.Components.Model;
using Project_Goettergaemmerung.ExtensionMethods;

namespace Project_Goettergaemmerung.Components;

public interface ISaveImage
{
    void SaveCardasImage(Bitmap card, string? filename, CardType type, int print1, int print2, int print3, int print4);
}

public class SaveImage : ISaveImage
{
    private readonly IUserData _userData;

    public SaveImage(IUserData userData)
    {
        _userData = userData;
    }

    private string ChangePrintNumbers(int print)
    {
        return string.Format("{0:000}", print);
    }

    private void SaveNormalFormat(Bitmap card, string filename, CardType type, int print)
    {
        var name = type.GetDescription() + "_" + ChangePrintNumbers(print) + "_" + filename;
        card.Save(_userData.ExportPath + "\\" + name + ".png", ImageFormat.Png);
    }

    private void SaveRebalenceFormat(Bitmap card)
    {
        var name = _userData.RebalenceNumber;
        card.Save(_userData.ExportPath + "\\" + name + ".png", ImageFormat.Png);
    }

    private void SaveTabeltopFormat(Bitmap card, string filename, CardType type, int print)
    {
        for (var i = 0; i < print; i++)
        {
            var name = type.GetDescription() + "_" + ChangePrintNumbers(i + 1) + "_" + filename;
            card.Save(_userData.ExportPath + "\\" + name + ".png", ImageFormat.Png);
        }
    }

    public void SaveCardasImage(Bitmap card, string? filename, CardType type,
        int print1, int print2, int print3, int print4)
    {
        if (filename == null) { filename = ""; }

        _userData.RebalenceNumber++;
        var print = _userData.Printer switch
        {
            PrintType.Print1 => print1,
            PrintType.Print2 => print2,
            PrintType.Print3 => print3,
            PrintType.Print4 => print4,
            _ => 0,
        };
        if (print != 0)
        {
            if (_userData.CurrentFormat == SaveFormat.normal)
            {
                SaveNormalFormat(card, filename, type, print);
            }
            if (_userData.CurrentFormat == SaveFormat.tabeltop)
            {
                SaveTabeltopFormat(card, filename, type, print);
            }
            if (_userData.CurrentFormat == SaveFormat.rebalence)
            {
                SaveRebalenceFormat(card);
            }
        }
    }
}
