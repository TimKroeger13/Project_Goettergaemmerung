using System.Drawing;

namespace Project_Goettergaemmerung.Components
{
    public interface IDrawTextInteropBase
    {
        int DrawString(int x, int y, string text);

        void SetBold(int start = 0, int end = -1);

        void SetItalic(int start = 0, int end = -1);

        void SetFont(Font font, int start = 0, int end = -1);
    }

    //public class DrawTextInteropBase : IDrawTextInteropBase
    //{
    //DrawTextInteropBase.SetBold(1,4);_drawTextInteropBase(end 5, start 1);
    //}
}
