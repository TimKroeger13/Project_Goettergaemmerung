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

        public GenerateCardText(ICardInformationGetter cardInformation)
        {
            _cardInformation = cardInformation;
        }

        public void PrintCards()
        {
            var text = _cardInformation.GetCardInformation().Last().Text;
            MessageBox.Show(text);
        }
    }
}
