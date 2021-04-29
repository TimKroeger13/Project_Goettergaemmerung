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

        public void PrintCards()
        {
            var CardInformationList = _cardInformation.GetCardInformation(_userData.ImportPath).ToList();
            var structure = CardInformationList[0].Structure;
            var type = CardInformationList[0].CardType;
            var race = CardInformationList[0].Race;
            var extra = CardInformationList[0].ExtraDeck;

            var Template = _templateBuilder.CardTemplate(structure, type, race, extra);

            pictureBoxCards.Image = _createPicture.MergedBitmaps(Template);

            //var imporetData = _cardInformation.GetCardInformation(_userData.ImportPath).ToList()[0].Structure;
            //var text = _cardInformation.GetCardInformation(_userData.ImportPath).First().Text;
            //MessageBox.Show(text);
        }
    }
}
