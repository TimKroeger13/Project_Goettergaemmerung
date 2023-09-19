using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Project_Goettergaemmerung.Components.CardInformationGetter;

namespace Project_Goettergaemmerung.Components;

public interface ICardPrinter
{
    void PrintCards();

    void ExportCardInformationAsJSON(string path);

    Bitmap CreateBitmap(long cardId);
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

    public Bitmap CreateBitmap(long cardId)
    {
        var card = _cardInformationGetterFactory.CreateCardInformationGetter().GetCardInformation()
                                                .FirstOrDefault(c => c.Id == cardId);
        if (card == null) throw new Exception($"Card with ID: {cardId} was not found");
        using var template = _templateBuilder.CardTemplate(card.Structure, card.CardType, card.Race, card.ExtraDeck,
            card.Name, card.SubType, card.TwoHanded, card.Condition, card.Modifiers, card.CenterText,
            card.Text, card.FlavorText, card.Scrapped, card.Level, card.WinText, card.LoseText);
        var result = _createPicture.MergedBitmaps(template);
        _disposableList.Dispose();
        _createPicture.Dispose();
        return result;
    }

    public void PrintCards()
    {
        foreach (var card in _cardInformationGetterFactory.CreateCardInformationGetter().GetCardInformation().ToList())
        {
            if (!_checkIfPrintIsZero.PrintIsZero(card.Print1, card.Print2, card.Print3, card.Print4))
            {
                using var template = _templateBuilder.CardTemplate(card.Structure, card.CardType, card.Race, card.ExtraDeck,
                        card.Name, card.SubType, card.TwoHanded, card.Condition, card.Modifiers, card.CenterText,
                        card.Text, card.FlavorText, card.Scrapped, card.Level, card.WinText, card.LoseText);
                using var finalCard = _createPicture.MergedBitmaps(template);
                _saveImage.SaveCardasImage(finalCard, card.Name, card.CardType, card.ExtraDeck, card.Print1, card.Print2, card.Print3, card.Print4, card.Id);
                _disposableList.Dispose();
                _createPicture.Dispose();
            }
        }
    }
}
