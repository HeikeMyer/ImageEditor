using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;
using ImageProcessing.Base;
using ImageProcessing.Models;

namespace ImageProcessing
{
    public class Adjustments
    {           
        public unsafe void AdjustBrightnessAndContrast(Bitmap source, int brightnessFactor, int contrastFactor)
        {
            List<Adjustment> AdjustmentsPack = new List<Adjustment>();

            if (brightnessFactor != 0)
                AdjustmentsPack.Add(new Adjustment(PixelCalculation.Brightness, brightnessFactor));

            if (contrastFactor != 0)
                AdjustmentsPack.Add(new Adjustment(PixelCalculation.Contrast, contrastFactor));

            if (AdjustmentsPack.Count != 0)
                ImageProcessingBase.Adjust(source, AdjustmentsPack);
        }

        public unsafe void AdjustExposure(Bitmap source, double exposure, double gamma)
        {
            List<Adjustment> AdjustmentsPack = new List<Adjustment>();

            if (exposure != 0)
                AdjustmentsPack.Add(new Adjustment(PixelCalculation.ExposureCompensation, exposure));

            if (gamma != 0)
                AdjustmentsPack.Add(new Adjustment(PixelCalculation.GammaCorrection, gamma));

            if (AdjustmentsPack.Count != 0)
                ImageProcessingBase.Adjust(source, AdjustmentsPack);
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
                ImageProcessingBase.Adjust(source, adjustmentsPack);
        }

        
        public unsafe void Sepia(Bitmap source, int factor)
        {
            ApplyToPixel adjustment = new ApplyToPixel(PixelCalculation.Sepia);
            ImageProcessingBase.Adjust(source, factor, adjustment);
        }

        public unsafe void Invert(Bitmap source, int factor)
        {
            ApplyToPixel adjustment = new ApplyToPixel(PixelCalculation.Invert);
            ImageProcessingBase.Adjust(source, factor, adjustment);
        }

        public unsafe void BlackAndWhite(Bitmap source, int factor)
        {
            ApplyToPixel adjustment = new ApplyToPixel(PixelCalculation.BnW);
            ImageProcessingBase.Adjust(source, factor, adjustment);
        }

        public unsafe void Threshold(Bitmap source, int factor)
        {
            ApplyToPixel adjustment = new ApplyToPixel(PixelCalculation.Threshold);
            ImageProcessingBase.Adjust(source, factor, adjustment);
        }

        
    }
}
