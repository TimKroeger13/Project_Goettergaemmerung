using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Project_Goettergaemmerung.ExtensionMethods;

namespace Project_Goettergaemmerung.Components
{
    public interface ICreatePicture
    {
        Bitmap BlendingMultiply(Bitmap bitmap1, Bitmap bitmap2);

        Bitmap MergedBitmaps(DisposableList<Bitmap> bitmapList);

    }

    public class CreatePicture : ICreatePicture
    {
        public Bitmap MergedBitmaps(DisposableList<Bitmap> bitmapList)
        {
            var result = new Bitmap(700, 1000);
            using (var g = Graphics.FromImage(result))
            {
                foreach (var item in bitmapList)
                {
                    g.DrawImage(item, Point.Empty);
                }
            }
            return result;
        }

        public Bitmap BlendingMultiply(Bitmap bitmap1, Bitmap bitmap2)
        {
            var result = new Bitmap(700, 1000);
            var resultBytes = result.GetArgbBytes(out var bitmapDataResult);
            var bitmap1Bytes = bitmap1.GetArgbBytes();
            var bitmap2Bytes = bitmap2.GetArgbBytes();
            Parallel.For(0, resultBytes.Length, i =>
            {
                if ((i + 1) % 4 == 0) resultBytes[i] = 255;
                else resultBytes[i] = (byte)(Math.Round(bitmap1Bytes[i] * bitmap2Bytes[i] / 255d));
            });
            Marshal.Copy(resultBytes, 0, bitmapDataResult.Scan0, resultBytes.Length);
            result.UnlockBits(bitmapDataResult);
            return result;
        }
    }
}
