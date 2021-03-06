using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using Project_Goettergaemmerung.Components.CardInformationGetter;

namespace Project_Goettergaemmerung.Components
{
    public interface ICardPrinter
    {
        void PrintCards();
    }

    public class CardPrinter : ICardPrinter
    {
        private readonly ICardInformationGetter _cardInformation;
        private readonly ITemplateBuilder _templateBuilder;
        private readonly ICreatePicture _createPicture;
        private readonly IDisposableList<Bitmap> _disposableList;
        private readonly ISaveImage _saveImage;
        private readonly ICheckIfPrintIsZero _checkIfPrintIsZero;

        public CardPrinter(ICardInformationGetter cardInformation, ITemplateBuilder templateBuilder, ICreatePicture createPicture, IDisposableList<Bitmap> disposableList, ISaveImage saveImage, ICheckIfPrintIsZero checkIfPrintIsZero)
        {
            _cardInformation = cardInformation;
            _templateBuilder = templateBuilder;
            _createPicture = createPicture;
            _disposableList = disposableList;
            _saveImage = saveImage;
            _checkIfPrintIsZero = checkIfPrintIsZero;
        }

        public void PrintCards()
        {
            var cardInformationList = _cardInformation.GetCardInformation().ToList();

            foreach (var card in cardInformationList)
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
}
