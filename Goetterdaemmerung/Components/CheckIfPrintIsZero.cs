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
            int print;
            switch (_userData.Printer)
            {
                case PrintType.Print1:
                    print = print1;
                    break;

                case PrintType.Print2:
                    print = print2;
                    break;

                case PrintType.Print3:
                    print = print3;
                    break;

                case PrintType.Print4:
                    print = print4;
                    break;

                default:
                    print = 0;
                    break;
            }

            if (print != 0)
            {
                return false;
            }
            return true;
        }
    }
}
