using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;
using ImageProcessing.Base;

namespace ImageProcessing
{
    public class Adjustments
    {           
        private unsafe delegate void ApplyToPixel(byte* blue, double factor);

        private unsafe void Adjust(Bitmap bitmap, double factor, ApplyToPixel applyToPixel)
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

        struct Adjustment
        {
            public ApplyToPixel adjustment;
            public double factor;

            public Adjustment(ApplyToPixel applyToPixel, double f)
            {
                adjustment = applyToPixel;
                factor = f;
            }
        }

        private unsafe void Adjust(Bitmap bitmap, List<Adjustment> adjustmentsPack)
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
     
        public unsafe void AdjustBrightnessAndContrast(Bitmap source, int brightnessFactor, int contrastFactor)
        {
            List<Adjustment> AdjustmentsPack = new List<Adjustment>();

            if (brightnessFactor != 0)
                AdjustmentsPack.Add(new Adjustment(PixelCalculation.Brightness, brightnessFactor));

            if (contrastFactor != 0)
                AdjustmentsPack.Add(new Adjustment(ApplyContrastToPixel, contrastFactor));

            if (AdjustmentsPack.Count != 0)
                Adjust(source, AdjustmentsPack);
        }

        public unsafe void AdjustExposure(Bitmap source, double exposure, double gamma)
        {
            List<Adjustment> AdjustmentsPack = new List<Adjustment>();

            if (exposure != 0)
                AdjustmentsPack.Add(new Adjustment(PixelCalculation.ExposureCompensation, exposure));

            if (gamma != 0)
                AdjustmentsPack.Add(new Adjustment(PixelCalculation.GammaCorrection, gamma));

            if (AdjustmentsPack.Count != 0)
                Adjust(source, AdjustmentsPack);
        }

        public unsafe void AdjustColorBalance(Bitmap source, int redFactor, int greenFactor, int blueFactor)
        {
           
            List<Adjustment> adjustmentsPack = new List<Adjustment>();

            if (redFactor != 0)
                adjustmentsPack.Add(new Adjustment(PixelCalculation.BrightnessR, redFactor));

            if (greenFactor != 0)
                adjustmentsPack.Add(new Adjustment(PixelCalculation.BrightnessG, greenFactor));

            if (blueFactor != 0)
                adjustmentsPack.Add(new Adjustment(PixelCalculation.BrightnessB, blueFactor));

            if (adjustmentsPack.Count != 0)
                Adjust(source, adjustmentsPack);
        }

        private unsafe void ApplyContrastToPixel(byte* blue, double factor)
        {
           for (Rgba i = Rgba.Blue; i <= Rgba.Red; ++i)
           {
               byte componentValue = *(blue + (byte)i);
               *(blue + (byte)i) = RgbComponentCalculation.ChangeContrast(componentValue, (int)factor);
           }           
        }

        public unsafe void Sepia(Bitmap source, int factor)
        {
            ApplyToPixel adjustment = new ApplyToPixel(PixelCalculation.Sepia);
            Adjust(source, factor, adjustment);
        }

        public unsafe void Invert(Bitmap source, int factor)
        {
            ApplyToPixel adjustment = new ApplyToPixel(PixelCalculation.Invert);
            Adjust(source, factor, adjustment);
        }

        public unsafe void BlackAndWhite(Bitmap source, int factor)
        {
            ApplyToPixel adjustment = new ApplyToPixel(PixelCalculation.BnW);
            Adjust(source, factor, adjustment);
        }

        public unsafe void Threshold(Bitmap source, int factor)
        {
            ApplyToPixel adjustment = new ApplyToPixel(PixelCalculation.Threshold);
            Adjust(source, factor, adjustment);
        }

        
    }
}
