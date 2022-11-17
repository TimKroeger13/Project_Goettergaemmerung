using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Project_Goettergaemmerung.Components.CardInformationGetter;

namespace Project_Goettergaemmerung.Components;

public interface ICardPrinter
{
    void PrintCards();

    void ExportCardInformationAsJSON(string path);
}

public class CardPrinter : ICardPrinter
{
    private readonly ITemplateBuilder _templateBuilder;
    private readonly ICardInformationGetterFactory _cardInformationGetterFactory;
    private readonly ICreatePicture _createPicture;
    private readonly IDisposableList<Bitmap> _disposableList;
    private readonly ISaveImage _saveImage;
    private readonly ICheckIfPrintIsZero _checkIfPrintIsZero;

    public CardPrinter(ITemplateBuilder templateBuilder, ICreatePicture createPicture,
        IDisposableList<Bitmap> disposableList, ISaveImage saveImage, ICheckIfPrintIsZero checkIfPrintIsZero,
        ICardInformationGetterFactory cardInformationGetterFactory)
    {
        _templateBuilder = templateBuilder;
        _createPicture = createPicture;
        _disposableList = disposableList;
        _saveImage = saveImage;
        _checkIfPrintIsZero = checkIfPrintIsZero;
        _cardInformationGetterFactory = cardInformationGetterFactory;
    }

    public void ExportCardInformationAsJSON(string path)
    {
        var cardInformation = _cardInformationGetterFactory.CreateCardInformationGetter().GetCardInformation()
            .OrderBy(c => c.Id).ToList();

        var options = new JsonSerializerOptions()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        options.Converters.Add(new JsonStringEnumConverter());
        var json = JsonSerializer.Serialize(cardInformation, options);
        File.WriteAllText(path, json);
    }

    public void PrintCards()
    {
        foreach (var card in _cardInformationGetterFactory.CreateCardInformationGetter().GetCardInformation().ToList())
        {
            var structure = card.Structure;
            var type = card.CardType;
            var race = card.Race;
            var extra = card.ExtraDeck;

            var name = card.Name;
            var subType = card.SubType;
            var twoHanded = card.TwoHanded;
            var condition = card.Condition;
            var modifier = card.Modifiers;
            var center = card.CenterText;
            var text = card.Text;
            var flavorText = card.FlavorText;
            var scrapped = card.Scrapped;

            var lvl = card.Level;
            var winText = card.WinText;
            var loseText = card.LoseText;

            var print1 = card.Print1;
            var print2 = card.Print2;
            var print3 = card.Print3;
            var print4 = card.Print4;

            if (!_checkIfPrintIsZero.PrintIsZero(print1, print2, print3, print4))
            {
                using var template = _templateBuilder.CardTemplate(structure, type, race, extra, name, subType, twoHanded, condition, modifier, center,
                    text, flavorText, scrapped, lvl, winText, loseText);

                using var finalCard = _createPicture.MergedBitmaps(template);
                _saveImage.SaveCardasImage(finalCard, name, type, print1, print2, print3, print4);
                _disposableList.Dispose();
                _createPicture.Dispose();
            }
        }
    }
}
