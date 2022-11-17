using System.Runtime.InteropServices;
using Project_Goettergaemmerung.ExtensionMethods;

namespace Project_Goettergaemmerung.Components;

public interface ICreatePicture
{
    Bitmap BlendingMultiply(Func<Bitmap> bitmap1, Func<Bitmap> bitmap2);

    Bitmap MergedBitmaps(DisposableList<Bitmap> bitmapList);

    void Dispose();
}

public class CreatePicture<T> : ICreatePicture, IDisposable where T : IDisposable
{
    public Bitmap MergedBitmaps(DisposableList<Bitmap> bitmapList)
    {
        var result = new Bitmap(700, 1000);
        result.SetResolution(120, 120);
        using (var g = Graphics.FromImage(result))
        {
            foreach (var item in bitmapList)
            {
                g.DrawImage(item, Point.Empty);
            }
        }
        return result;
    }

    public Bitmap BlendingMultiply(Func<Bitmap> bitmap1, Func<Bitmap> bitmap2)
    {
        var result = new Bitmap(700, 1000);
        result.SetResolution(120, 120);
        var resultBytes = result.GetArgbBytes(out var bitmapDataResult);
        var bitmap1Bytes = (_disposeBitmap1 = bitmap1.Invoke()).GetArgbBytes();
        var bitmap2Bytes = (_disposeBitmap2 = bitmap2.Invoke()).GetArgbBytes();
        Parallel.For(0, resultBytes.Length, i =>
        {
            if ((i + 1) % 4 == 0) resultBytes[i] = 255;
            else resultBytes[i] = (byte)(Math.Round(bitmap1Bytes[i] * bitmap2Bytes[i] / 255d));
        });
        Marshal.Copy(resultBytes, 0, bitmapDataResult.Scan0, resultBytes.Length);
        result.UnlockBits(bitmapDataResult);
        return result;
    }

    private Bitmap? _disposeBitmap1;
    private Bitmap? _disposeBitmap2;

    public void Dispose()
    {
        _disposeBitmap1?.Dispose();
        _disposeBitmap2?.Dispose();
    }
}
