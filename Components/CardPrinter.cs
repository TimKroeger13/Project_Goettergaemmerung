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

        public CardPrinter(ICardInformationGetter cardInformation, IUserData userData, ITemplateBuilder templateBuilder, ICreatePicture createPicture)
        {
            _cardInformation = cardInformation;
            _userData = userData;
            _templateBuilder = templateBuilder;
            _createPicture = createPicture;
        }

        private void SaveImage(Bitmap Card, string filename) //To Private
        {
            Card.Save(_userData.ExportPath + "\\" + filename + ".png", ImageFormat.Png);
        }

        public void PrintCards()
        {
            var CardInformationList = _cardInformation.GetCardInformation(_userData.ImportPath).ToList();

            foreach (var Card in CardInformationList)
            {
                var structure = Card.Structure;
                var type = Card.CardType;
                var race = Card.Race;
                var extra = Card.ExtraDeck;
                var name = Card.Name;

                var Template = _templateBuilder.CardTemplate(structure, type, race, extra);
                using var FinalCard = _createPicture.MergedBitmaps(Template);
                SaveImage(FinalCard, name);
            }
        }
    }
}
