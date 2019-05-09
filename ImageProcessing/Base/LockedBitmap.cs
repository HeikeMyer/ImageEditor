using System.Drawing;
using System.Drawing.Imaging;

namespace ImageProcessing.Base
{
    enum Bits: byte
    {
        BitsInByte = 8
    }

    internal class LockedBitmap
    {
        public BitmapData Data { get; }

        public int BytesPerPixel { get; }

        public int HeightInPixels { get; }

        public int WidthInBytes { get; }

        public int Stride { get; }

        public unsafe byte* FirstByte { get; }

        public unsafe LockedBitmap(Bitmap source, Rectangle lockedArea)
        {
            Data = source.LockBits(lockedArea, ImageLockMode.ReadWrite, source.PixelFormat);

            BytesPerPixel = Image.GetPixelFormatSize(source.PixelFormat) / (int)Bits.BitsInByte;
            HeightInPixels = Data.Height;
            WidthInBytes = Data.Width * BytesPerPixel;
            FirstByte = (byte*)Data.Scan0;
            Stride = Data.Stride;
        }

        public unsafe LockedBitmap(Bitmap source)
        {
            Data = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), 
                                         ImageLockMode.ReadWrite, source.PixelFormat);

            BytesPerPixel = Image.GetPixelFormatSize(source.PixelFormat) / (int)Bits.BitsInByte;
            HeightInPixels = Data.Height;
            WidthInBytes = Data.Width * BytesPerPixel;
            FirstByte = (byte*)Data.Scan0;
            Stride = Data.Stride;
        }

        public void Unlock(Bitmap source)
        {
            source.UnlockBits(Data);
        }
    }
}
