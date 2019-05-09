using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageProcessing
{
    enum Argb : byte
    {
        blue, green, red, alfa
    }

    public class Adjustments
    {           
        public unsafe delegate void ApplyToPixel(byte* blue, double factor);


        public struct Adjustment
        {
            public ApplyToPixel adjustment;
            public double factor;

            public Adjustment(ApplyToPixel applyToPixel, double f)
            {
                adjustment = applyToPixel;
                factor = f;
            }
        }

        public unsafe void AdjustBrightnessAndContrast(Bitmap source, int brightnessFactor, int contrastFactor)
        {
            List<Adjustment> AdjustmentsPack = new List<Adjustment>();

            if (brightnessFactor != 0)
                AdjustmentsPack.Add(new Adjustment(PixelCalculation.ApplyBrightnessToPixel, brightnessFactor));

            if (contrastFactor != 0)
                AdjustmentsPack.Add(new Adjustment(PixelCalculation.ApplyContrastToPixel, contrastFactor));

            if (AdjustmentsPack.Count != 0)
                ImageProcessingBase.Adjust(source, AdjustmentsPack);
        }

        public unsafe void AdjustExposure(Bitmap source, double exposure, double gamma)
        {
            List<Adjustment> AdjustmentsPack = new List<Adjustment>();

            if (exposure != 0)
                AdjustmentsPack.Add(new Adjustment(PixelCalculation.ApplyExposureCompensationToPixel, exposure));

            if (gamma != 0)
                AdjustmentsPack.Add(new Adjustment(PixelCalculation.ApplyGammaCorrectionToPixel, gamma));

            if (AdjustmentsPack.Count != 0)
                ImageProcessingBase.Adjust(source, AdjustmentsPack);
        }

        public unsafe void AdjustColorBalance(Bitmap source, int redFactor, int greenFactor, int blueFactor)
        {
           
            List<Adjustment> adjustmentsPack = new List<Adjustment>();

            if (redFactor != 0)
                adjustmentsPack.Add(new Adjustment(PixelCalculation.ApplyBrightnessToPixelRed, redFactor));

            if (greenFactor != 0)
                adjustmentsPack.Add(new Adjustment(PixelCalculation.ApplyBrightnessToPixelGreen, greenFactor));

            if (blueFactor != 0)
                adjustmentsPack.Add(new Adjustment(PixelCalculation.ApplyBrightnessToPixelBlue, blueFactor));

            if (adjustmentsPack.Count != 0)
                ImageProcessingBase.Adjust(source, adjustmentsPack);
        }

        public unsafe void Sepia(Bitmap source, int factor)
        {
            ApplyToPixel adjustment = new ApplyToPixel(PixelCalculation.ApplySepiaToPixel);
            ImageProcessingBase.Adjust(source, factor, adjustment);
        }

        public unsafe void Invert(Bitmap source, int factor)
        {
            ApplyToPixel adjustment = new ApplyToPixel(PixelCalculation.ApplyInversionToPixel);
            ImageProcessingBase.Adjust(source, factor, adjustment);
        }

        public unsafe void BlackAndWhite(Bitmap source, int factor)
        {
            ApplyToPixel adjustment = new ApplyToPixel(PixelCalculation.ApplyBlackAndWhiteToPixel);
            ImageProcessingBase.Adjust(source, factor, adjustment);
        }

        public unsafe void Threshold(Bitmap source, int factor)
        {
            ApplyToPixel adjustment = new ApplyToPixel(PixelCalculation.ApplyThresholdToPixel);
            ImageProcessingBase.Adjust(source, factor, adjustment);
        }

    }
}
