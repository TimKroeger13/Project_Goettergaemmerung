using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Project_Goettergaemmerung.ExtensionMethods
{
    public static class BitmapExtensions
    {
        public static byte[] GetBytes(this Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var size = Math.Abs(bitmapData.Stride) * bitmapData.Height;
            var resultBytes = new byte[size];
            Marshal.Copy(bitmapData.Scan0, resultBytes, 0, size);
            return resultBytes;
        }
    }
}
