using System.Drawing;

namespace Project_Goettergaemmerung.Components
{
    public interface IDrawTextInterop
    {
        Bitmap DrawString(int x, int y, string text);
        int GetHigthOfText(int x, int y, string text);
        void SetBold(int start = 0, int end = -1);
        void SetItalic(int start = 0, int end = -1);
        void SetFont(Font font);
    }

    public class rawTextInterop : IDrawTextInterop
    {
        public Bitmap DrawString(int x, int y, string text)
        {
            throw new System.NotImplementedException();
        }

        public int GetHigthOfText(int x, int y, string text)
        {
            throw new System.NotImplementedException();
        }

        public void SetBold(int start = 0, int end = -1)
        {
            throw new System.NotImplementedException();
        }

        public void SetFont(Font font)
        {
            throw new System.NotImplementedException();
        }

        public void SetItalic(int start = 0, int end = -1)
        {
            throw new System.NotImplementedException();
        }
    }


    //public class DrawTextInteropBase : IDrawTextInteropBase
    //{
    //DrawTextInteropBase.SetBold(1,4);_drawTextInteropBase(end 5, start 1);
    //}
}
