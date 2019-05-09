using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public static class PixelCalculation
    {

        public static unsafe void ApplyBrightnessToPixel(byte* blue, double factor)
        {
            for (Argb i = Argb.blue; i <= Argb.red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.ChangeBrightness(componentValue, factor);
            }
        }


        public static unsafe void ApplyContrastToPixel(byte* blue, double factor)
        {
            for (Argb i = Argb.blue; i <= Argb.red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.ChangeContrast(componentValue, (int)factor);
            }
        }


        public static unsafe void ApplyThresholdToPixel(byte* blue, double factor)
        {
            *blue = *(blue + (byte)Argb.green) = *(blue + (byte)Argb.red) =
            RgbComponentCalculation.Threshold(*blue, *(blue + (byte)Argb.green), *(blue + (byte)Argb.red), (byte)factor);
        }

        public static unsafe void ApplyBlackAndWhiteToPixel(byte* blue, double factor)
        {
            *blue = *(blue + (byte)Argb.green) = *(blue + (byte)Argb.red) =
            RgbComponentCalculation.BnW(*blue, *(blue + (byte)Argb.green), *(blue + (byte)Argb.red));
        }

        public static unsafe void ApplyExposureCompensationToPixel(byte* blue, double factor)
        {
            for (Argb i = Argb.blue; i <= Argb.red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.Exposure(componentValue, factor);
            }
        }

        public static unsafe void ApplyGammaCorrectionToPixel(byte* blue, double factor)
        {
            for (Argb i = Argb.blue; i <= Argb.red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.Gamma(componentValue, factor);
            }
        }

        public static unsafe void ApplyBrightnessToPixelRed(byte* blue, double factor)
        {
            byte componentValue = *(blue + (byte)Argb.red);
            *(blue + (byte)Argb.red) = RgbComponentCalculation.ChangeBrightness(componentValue, factor);
        }

        public static unsafe void ApplyBrightnessToPixelGreen(byte* blue, double factor)
        {
            byte componentValue = *(blue + (byte)Argb.green);
            *(blue + (byte)Argb.green) = RgbComponentCalculation.ChangeBrightness(componentValue, factor);
        }

        public static unsafe void ApplyBrightnessToPixelBlue(byte* blue, double factor)
        {
            byte componentValue = *blue;
            *blue = RgbComponentCalculation.ChangeBrightness(componentValue, factor);
        }

        public static unsafe void ApplySepiaToPixel(byte* blue, double factor)
        {
            int tone = RgbComponentCalculation.ComputeSepiaTone(*blue, *(blue + (byte)Argb.green), *(blue + (byte)Argb.red));
            *blue = RgbComponentCalculation.ComputeSepiaBlue(tone);
            *(blue + (byte)Argb.green) = RgbComponentCalculation.ComputeSepiaGreen(tone);
            *(blue + (byte)Argb.red) = RgbComponentCalculation.ComputeSepiaRed(tone);
        }

        public static unsafe void ApplyInversionToPixel(byte* blue, double factor)
        {
            for (Argb i = Argb.blue; i <= Argb.red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.Invert(componentValue, (int)factor);
            }
        }
    }
}
