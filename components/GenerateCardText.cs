using System.Linq;
using System.Windows.Forms;
using Project_Goettergaemmerung.Components.CardInformationGetter;

namespace Project_Goettergaemmerung.Components
{
    public interface IGenerateCardText
    {
        void PrintCards();
    }

    public class GenerateCardText : IGenerateCardText
    {
        private readonly ICardInformationGetter _cardInformation;
        private readonly IUserData _userData;

        public GenerateCardText(ICardInformationGetter cardInformation, IUserData userData)
        {
            _cardInformation = cardInformation;
            _userData = userData;
        }

        public void PrintCards()
        {
            var text = _cardInformation.GetCardInformation(_userData.ImportPath).Last().Text;
            MessageBox.Show(text);
        }
    }
}
