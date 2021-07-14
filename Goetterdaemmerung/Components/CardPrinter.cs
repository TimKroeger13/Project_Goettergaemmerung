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
        private readonly IUserData _userData;
        private readonly ITemplateBuilder _templateBuilder;
        private readonly ICreatePicture _createPicture;
        private readonly IDisposableList<Bitmap> _disposableList;

        public CardPrinter(ICardInformationGetter cardInformation, IUserData userData, ITemplateBuilder templateBuilder, ICreatePicture createPicture, IDisposableList<Bitmap> disposableList)
        {
            _cardInformation = cardInformation;
            _userData = userData;
            _templateBuilder = templateBuilder;
            _createPicture = createPicture;
            _disposableList = disposableList;
        }

        private void SaveImage(Bitmap Card, string filename) //To Private
        {
            Card.Save(_userData.ExportPath + "\\" + filename + ".png", ImageFormat.Png);
        }

        public void PrintCards()
        {
            var CardInformationList = _cardInformation.GetCardInformation(_userData.ImportPath).ToList();

            foreach (var card in CardInformationList)
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

                var Template = _templateBuilder.CardTemplate(structure, type, race, extra, name, subType, twoHanded, condition, modifier, center,
                    text, flavorText, scrapped, lvl, winText, loseText);

                using var finalCard = _createPicture.MergedBitmaps(Template);
                SaveImage(finalCard, name);
                //Template.Dispose();
                _disposableList.Dispose();
            }
        }
    }
}
