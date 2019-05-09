using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ImageProcessing.Adjustments;

namespace ImageProcessing
{
    public static class ImageProcessingBase
    {
        public static unsafe void Adjust(System.Drawing.Bitmap bitmap, double factor, ApplyToPixel applyToPixel)
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

    }
}
