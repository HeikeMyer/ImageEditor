using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using ImageProcessing.Models;

namespace ImageProcessing.Base
{
    public static class ImageProcessingBase
    {
        public static unsafe void Adjust(Bitmap bitmap, double factor, ApplyToPixel applyToPixel)
        {
            LockedBitmap lockedBitmap = new LockedBitmap(bitmap);

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
            LockedBitmap lockedBitmap = new LockedBitmap(bitmap);

            Parallel.For(0, lockedBitmap.HeightInPixels, iY =>
            {
                byte* pixel = lockedBitmap.FirstByte + (iY * lockedBitmap.Stride);
                for (int iX = 0; iX < lockedBitmap.WidthInBytes; iX += lockedBitmap.BytesPerPixel)
                {
                    foreach (Adjustment adjustment in adjustmentsPack)
                        adjustment.adjustment(pixel, adjustment.factor);

                    pixel += lockedBitmap.BytesPerPixel;
                }
            });

            lockedBitmap.Unlock(bitmap);
        }

        private static byte[] InitializePixelNeighborhood(int size)
        {
            byte[] neighborhood = new byte[size];
            return neighborhood;
        }

        private static unsafe byte[] GetRgbComponentNeighborhood(LockedBitmap lockedBitmapData, byte* rgbComponent, int size, int gap, int gapInBytes, int bytesPerPixel)
        {
            byte[] neighborhood = InitializePixelNeighborhood(size*size);
            byte* neighbor = rgbComponent - gap * lockedBitmapData.Stride - gapInBytes;
            int offset = lockedBitmapData.Stride - size * bytesPerPixel;

            for (int iY = 0; iY < size; ++iY)
            {
                for (int iX = 0; iX < size; ++iX)
                {
                    neighborhood[iY * size + iX] = *neighbor;
                    neighbor += bytesPerPixel;
                }

                neighbor += offset;
            }

            return neighborhood;
        }

        public static unsafe void ApplyFilterToBitmap(LockedBitmap intermediate, LockedBitmap bitmap, int nsize, Func<byte[], byte> computeNewRgbComponent, int size, int gap, int gapInBytes, int bytesPerPixel)
        {
            Parallel.For(0, bitmap.HeightInPixels, iY =>
            {
                byte* outputCurrentByte = bitmap.FirstByte + (iY * bitmap.Stride);
                byte* intermediateCurrentByte = intermediate.FirstByte + ((iY + gap) * intermediate.Stride) + gapInBytes;

                for (int i = 0; i < bitmap.WidthInBytes; i += bytesPerPixel)
                {
                    for (Rgba j = Rgba.Blue; j <= Rgba.Red; ++j)
                        *(outputCurrentByte + (byte)j) =
                        computeNewRgbComponent(GetRgbComponentNeighborhood(intermediate, intermediateCurrentByte + (byte)j, size, gap, gapInBytes, bytesPerPixel));

                    *(outputCurrentByte + (byte)Rgba.Alfa) = *(intermediateCurrentByte + (byte)Rgba.Alfa);

                    outputCurrentByte += bytesPerPixel;
                    intermediateCurrentByte += bytesPerPixel;
                }
            });
        }

        public static void Apply(Bitmap input, Bitmap output, Func<byte[], byte> computeNewRgbComponent, int size)
        {
            if (size <= 1)
                return;
            
            var gap = size / 2;
            var neighborhoodSize = size * size;
            var bytesPerPixel = Bitmap.GetPixelFormatSize(input.PixelFormat) / (int)Bits.bitsInByte;
            var gapInBytes = gap * bytesPerPixel;

            IntermediateImage intermediate = new IntermediateImage(input, gap);
            intermediate.FillIn();

            LockedBitmap lockedBitmap = new LockedBitmap(output);
            LockedBitmap lockedIntermediate = new LockedBitmap(intermediate.OutputImage);

            // ApplyFilterToBitmap(lockedIntermediate, lockedBitmap);
            ApplyFilterToBitmap(lockedIntermediate, lockedBitmap, neighborhoodSize, computeNewRgbComponent, size, gap, gapInBytes, bytesPerPixel);

            lockedBitmap.Unlock(output);
            lockedIntermediate.Unlock(intermediate.OutputImage);
        }
    }
}
