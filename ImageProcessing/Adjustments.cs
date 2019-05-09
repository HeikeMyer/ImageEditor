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
                AdjustmentsPack.Add(new Adjustment(ApplyBrightnessToPixel, brightnessFactor));

            if (contrastFactor != 0)
                AdjustmentsPack.Add(new Adjustment(ApplyContrastToPixel, contrastFactor));

            if (AdjustmentsPack.Count != 0)
                ImageProcessingBase.Adjust(source, AdjustmentsPack);
        }

        public unsafe void AdjustExposure(Bitmap source, double exposure, double gamma)
        {
            List<Adjustment> AdjustmentsPack = new List<Adjustment>();

            if (exposure != 0)
                AdjustmentsPack.Add(new Adjustment(ApplyExposureCompensationToPixel, exposure));

            if (gamma != 0)
                AdjustmentsPack.Add(new Adjustment(ApplyGammaCorrectionToPixel, gamma));

            if (AdjustmentsPack.Count != 0)
                ImageProcessingBase.Adjust(source, AdjustmentsPack);
        }

        public unsafe void AdjustColorBalance(Bitmap source, int redFactor, int greenFactor, int blueFactor)
        {
           
            List<Adjustment> adjustmentsPack = new List<Adjustment>();

            if (redFactor != 0)
                adjustmentsPack.Add(new Adjustment(ApplyBrightnessToPixelRed, redFactor));

            if (greenFactor != 0)
                adjustmentsPack.Add(new Adjustment(ApplyBrightnessToPixelGreen, greenFactor));

            if (blueFactor != 0)
                adjustmentsPack.Add(new Adjustment(ApplyBrightnessToPixelBlue, blueFactor));

            if (adjustmentsPack.Count != 0)
                ImageProcessingBase.Adjust(source, adjustmentsPack);
        }

        private unsafe void ApplyContrastToPixel(byte* blue, double factor)
        {
           for (Argb i = Argb.blue; i <= Argb.red; ++i)
           {
               byte componentValue = *(blue + (byte)i);
               *(blue + (byte)i) = RgbComponentCalculation.ChangeContrast(componentValue, (int)factor);
           }           
        }

        public unsafe void Sepia(Bitmap source, int factor)
        {
            ApplyToPixel adjustment = new ApplyToPixel(ApplySepiaToPixel);
            ImageProcessingBase.Adjust(source, factor, adjustment);
        }

        public unsafe void Invert(Bitmap source, int factor)
        {
            ApplyToPixel adjustment = new ApplyToPixel(ApplyInversionToPixel);
            ImageProcessingBase.Adjust(source, factor, adjustment);
        }

        public unsafe void BlackAndWhite(Bitmap source, int factor)
        {
            ApplyToPixel adjustment = new ApplyToPixel(ApplyBlackAndWhiteToPixel);
            ImageProcessingBase.Adjust(source, factor, adjustment);
        }

        public unsafe void Threshold(Bitmap source, int factor)
        {
            ApplyToPixel adjustment = new ApplyToPixel(ApplyThresholdToPixel);
            ImageProcessingBase.Adjust(source, factor, adjustment);
        }

        private unsafe void ApplyBrightnessToPixel(byte* blue, double factor)
        {         
            for (Argb i = Argb.blue; i <= Argb.red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.ChangeBrightness(componentValue, factor);
            }
        }

        private unsafe void ApplyThresholdToPixel(byte* blue, double factor)
        {
            *blue = *(blue + (byte)Argb.green) = *(blue + (byte)Argb.red) =
            RgbComponentCalculation.Threshold(*blue, *(blue + (byte)Argb.green), *(blue + (byte)Argb.red), (byte)factor);
        }
      
        private unsafe void ApplyBlackAndWhiteToPixel(byte* blue, double factor)
        {
            *blue = *(blue + (byte)Argb.green) = *(blue + (byte)Argb.red) =
            RgbComponentCalculation.BnW(*blue, *(blue + (byte)Argb.green), *(blue + (byte)Argb.red));
        }

        private unsafe void ApplyExposureCompensationToPixel(byte* blue, double factor)
        {
            for (Argb i = Argb.blue; i <= Argb.red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.Exposure(componentValue, factor);
            }
        }

        private unsafe void ApplyGammaCorrectionToPixel(byte* blue, double factor)
        {
            for (Argb i = Argb.blue; i <= Argb.red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.Gamma(componentValue, factor);
            }
        }

        private unsafe void ApplyBrightnessToPixelRed(byte* blue, double factor)
        {
            byte componentValue = *(blue + (byte)Argb.red);
            *(blue + (byte)Argb.red) = RgbComponentCalculation.ChangeBrightness(componentValue, factor);
        }

        private unsafe void ApplyBrightnessToPixelGreen(byte* blue, double factor)
        {
            byte componentValue = *(blue + (byte)Argb.green);
            *(blue + (byte)Argb.green) = RgbComponentCalculation.ChangeBrightness(componentValue, factor);
        }

        private unsafe void ApplyBrightnessToPixelBlue(byte* blue, double factor)
        {
            byte componentValue = *blue;
            *blue = RgbComponentCalculation.ChangeBrightness(componentValue, factor);
        }

        private unsafe void ApplySepiaToPixel(byte* blue, double factor)
        {
            int tone = RgbComponentCalculation.ComputeSepiaTone(*blue, *(blue + (byte)Argb.green), *(blue + (byte)Argb.red));
            *blue = RgbComponentCalculation.ComputeSepiaBlue(tone);
            *(blue + (byte)Argb.green) = RgbComponentCalculation.ComputeSepiaGreen(tone);
            *(blue + (byte)Argb.red) = RgbComponentCalculation.ComputeSepiaRed(tone);
        }

        private unsafe void ApplyInversionToPixel(byte* blue, double factor)
        {
            for (Argb i = Argb.blue; i <= Argb.red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.Invert(componentValue, (int)factor);
            }
        }
    }
}
