using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using Project_Goettergaemmerung.Components.CardInformationGetter;
using Project_Goettergaemmerung.Components.Model;

namespace Project_Goettergaemmerung.Components
{
    public interface ICheckIfPrintIsZero
    {
        bool PrintIsZero(int print1, int print2, int print3, int print4);
    }

    public class CheckIfPrintIsZero : ICheckIfPrintIsZero
    {
        private readonly IUserData _userData;

        public CheckIfPrintIsZero(IUserData userData)
        {
            _userData = userData;
        }

        public bool PrintIsZero(int print1, int print2, int print3, int print4)
        {
            var print = _userData.Printer switch
            {
                PrintType.Print1 => print1,
                PrintType.Print2 => print2,
                PrintType.Print3 => print3,
                PrintType.Print4 => print4,
                _ => 0,
            };
            return print == 0;
        }
    }
}
