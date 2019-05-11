using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace ImageProcessing.Base
{
    public enum Argb : byte
    {
        Blue,
        Green,
        Red,
        Alfa
    }

    internal unsafe delegate void AdjustPixel(byte* blue, double factor);

    internal struct Adjustment
    {
        public AdjustPixel AdjustPixel;

        public double Factor;

        public Adjustment(AdjustPixel adjustPixel, double factor)
        {
            AdjustPixel = adjustPixel;
            Factor = factor;
        }
    }

    internal static class ImageProcessingBase
    {
        public static unsafe void Adjust(Bitmap bitmap, double factor, AdjustPixel applyToPixel)
        {
            var lockedBitmap = new LockedBitmap(bitmap);

            Parallel.For(0, lockedBitmap.HeightInPixels, iY =>
            {
                byte* pixel = lockedBitmap.FirstByte + (iY * lockedBitmap.Stride);
                for (int iX = 0; iX < lockedBitmap.WidthInBytes; iX += lockedBitmap.BytesPerPixel)
                {
                    applyToPixel(pixel, factor);
                    pixel += lockedBitmap.BytesPerPixel;
                }
            });

            lockedBitmap.Unlock(bitmap);
        }

        public static unsafe void Adjust(Bitmap bitmap, List<Adjustment> adjustmentsPack)
        {
            var lockedBitmap = new LockedBitmap(bitmap);

            Parallel.For(0, lockedBitmap.HeightInPixels, iY =>
            {
                byte* pixel = lockedBitmap.FirstByte + (iY * lockedBitmap.Stride);
                for (int iX = 0; iX < lockedBitmap.WidthInBytes; iX += lockedBitmap.BytesPerPixel)
                {
                    foreach (Adjustment adjustment in adjustmentsPack)
                        adjustment.AdjustPixel(pixel, adjustment.Factor);

                    pixel += lockedBitmap.BytesPerPixel;
                }
            });

            lockedBitmap.Unlock(bitmap);
        }

        private static byte[] InitializePixelNeighborhood(int neighborhoodSize)
        {
            byte[] neighborhood = new byte[neighborhoodSize];

            return neighborhood;
        }

        private static unsafe byte[] GetRgbComponentNeighborhood(LockedBitmap lockedBitmapData, byte* rgbComponent, Filter filter)
        {
            byte[] neighborhood = InitializePixelNeighborhood(filter.NeighborhoodSize);
            byte* neighbor = rgbComponent - filter.Gap * lockedBitmapData.Stride - filter.GapInBytes;
            int offset = lockedBitmapData.Stride - filter.Size * filter.BytesPerPixel;

            for (int iY = 0; iY < filter.Size; ++iY)
            {
                for (int iX = 0; iX < filter.Size; ++iX)
                {
                    neighborhood[iY * filter.Size + iX] = *neighbor;
                    neighbor += filter.BytesPerPixel;
                }

                neighbor += offset;
            }

            return neighborhood;
        }

        public static unsafe void ApplyFilter(LockedBitmap intermediate, LockedBitmap bitmap, Filter filter, 
                                                      Func<byte[], byte> ComputeNewRgbComponentValue, Action<int> onProgress)
        {
            Parallel.For(0, bitmap.HeightInPixels, iY =>
            {
                byte* outputCurrentByte = bitmap.FirstByte + (iY * bitmap.Stride);
                byte* intermediateCurrentByte = intermediate.FirstByte + ((iY + filter.Gap) * intermediate.Stride) + filter.GapInBytes;

                for (int i = 0; i < bitmap.WidthInBytes; i += filter.BytesPerPixel)
                {
                    for (Argb j = Argb.Blue; j <= Argb.Red; ++j)
                        *(outputCurrentByte + (byte)j) =
                        ComputeNewRgbComponentValue(GetRgbComponentNeighborhood(intermediate, intermediateCurrentByte + (byte)j, filter));

                    *(outputCurrentByte + (byte)Argb.Alfa) = *(intermediateCurrentByte + (byte)Argb.Alfa);

                    outputCurrentByte += filter.BytesPerPixel;
                    intermediateCurrentByte += filter.BytesPerPixel;
                }

                if (onProgress != null && iY % 100 == 0)
                    onProgress(iY);
            });
        }
    }
}
