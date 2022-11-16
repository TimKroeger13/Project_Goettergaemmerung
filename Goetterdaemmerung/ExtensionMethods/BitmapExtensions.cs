using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Project_Goettergaemmerung.ExtensionMethods;

public static class BitmapExtensions
{
    /// <summary>
    /// Locks Bits for Retrieving the Byte-Array in managed Memory. UnlockBits must be called on the bitmap afterwards.
    /// </summary>
    /// <param name="bitmap"></param>
    /// <param name="bitmapData"></param>
    /// <returns></returns>
    public static byte[] GetArgbBytes(this Bitmap bitmap, out BitmapData bitmapData)
    {
        bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        var size = Math.Abs(bitmapData.Stride) * bitmapData.Height;
        var resultBytes = new byte[size];
        Marshal.Copy(bitmapData.Scan0, resultBytes, 0, size);
        return resultBytes;
    }

    public static byte[] GetArgbBytes(this Bitmap bitmap)
    {
        var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        var size = Math.Abs(bitmapData.Stride) * bitmapData.Height;
        var resultBytes = new byte[size];
        Marshal.Copy(bitmapData.Scan0, resultBytes, 0, size);
        bitmap.UnlockBits(bitmapData);
        return resultBytes;
    }
}
