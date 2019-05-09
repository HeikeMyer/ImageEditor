﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessing.Models;
//using static ImageProcessing.Adjustments;

namespace ImageProcessing
{
    internal static class ImageProcessingBase
    {
        public static unsafe void Adjust(System.Drawing.Bitmap bitmap, double factor, AdjustPixel applyToPixel)
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

        public static unsafe byte[] GetRgbComponentNeighborhood(LockedBitmap lockedBitmapData, byte* rgbComponent,
            int neighborhoodSize, int gap, int gapInBytes, int size, int bytesPerPixel)
        {
            byte[] neighborhood = InitializePixelNeighborhood(neighborhoodSize);
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

        public static unsafe void ApplyFilterToBitmap(LockedBitmap intermediate, LockedBitmap bitmap,
            int neighborhoodSize, int gap, int gapInBytes, int size, int bytesPerPixel,
            Func<byte[], byte> ComputeNewRgbComponentValue, Action<int> onProgress
            )
        {
            Parallel.For(0, bitmap.HeightInPixels, iY =>
            {
                byte* outputCurrentByte = bitmap.FirstByte + (iY * bitmap.Stride);
                byte* intermediateCurrentByte = intermediate.FirstByte + ((iY + gap) * intermediate.Stride) + gapInBytes;

                for (int i = 0; i < bitmap.WidthInBytes; i += bytesPerPixel)
                {
                    for (Argb j = Argb.Blue; j <= Argb.Red; ++j)
                        *(outputCurrentByte + (byte)j) =
                        ComputeNewRgbComponentValue(GetRgbComponentNeighborhood(intermediate, intermediateCurrentByte + (byte)j,
                        neighborhoodSize, gap, gapInBytes, size, bytesPerPixel));

                    *(outputCurrentByte + (byte)Argb.Alfa) = *(intermediateCurrentByte + (byte)Argb.Alfa);

                    outputCurrentByte += bytesPerPixel;
                    intermediateCurrentByte += bytesPerPixel;
                }

                if (iY % 100 == 0)
                    onProgress(1);
            });
        }


    }
}
