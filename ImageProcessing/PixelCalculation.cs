using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessing.Models;

namespace ImageProcessing
{
    public static class PixelCalculation
    {

        public static unsafe void ApplyBrightnessToPixel(byte* blue, double factor)
        {
            for (Argb i = Argb.Blue; i <= Argb.Red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.ChangeBrightness(componentValue, factor);
            }
        }


        public static unsafe void ApplyContrastToPixel(byte* blue, double factor)
        {
            for (Argb i = Argb.Blue; i <= Argb.Red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.ChangeContrast(componentValue, (int)factor);
            }
        }


        public static unsafe void ApplyThresholdToPixel(byte* blue, double factor)
        {
            *blue = *(blue + (byte)Argb.Green) = *(blue + (byte)Argb.Red) =
            RgbComponentCalculation.Threshold(*blue, *(blue + (byte)Argb.Green), *(blue + (byte)Argb.Red), (byte)factor);
        }

        public static unsafe void ApplyBlackAndWhiteToPixel(byte* blue, double factor)
        {
            *blue = *(blue + (byte)Argb.Green) = *(blue + (byte)Argb.Red) =
            RgbComponentCalculation.BnW(*blue, *(blue + (byte)Argb.Green), *(blue + (byte)Argb.Red));
        }

        public static unsafe void ApplyExposureCompensationToPixel(byte* blue, double factor)
        {
            for (Argb i = Argb.Blue; i <= Argb.Red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.Exposure(componentValue, factor);
            }
        }

        public static unsafe void ApplyGammaCorrectionToPixel(byte* blue, double factor)
        {
            for (Argb i = Argb.Blue; i <= Argb.Red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.Gamma(componentValue, factor);
            }
        }

        public static unsafe void ApplyBrightnessToPixelRed(byte* blue, double factor)
        {
            byte componentValue = *(blue + (byte)Argb.Red);
            *(blue + (byte)Argb.Red) = RgbComponentCalculation.ChangeBrightness(componentValue, factor);
        }

        public static unsafe void ApplyBrightnessToPixelGreen(byte* blue, double factor)
        {
            byte componentValue = *(blue + (byte)Argb.Green);
            *(blue + (byte)Argb.Green) = RgbComponentCalculation.ChangeBrightness(componentValue, factor);
        }

        public static unsafe void ApplyBrightnessToPixelBlue(byte* blue, double factor)
        {
            byte componentValue = *blue;
            *blue = RgbComponentCalculation.ChangeBrightness(componentValue, factor);
        }

        public static unsafe void ApplySepiaToPixel(byte* blue, double factor)
        {
            int tone = RgbComponentCalculation.ComputeSepiaTone(*blue, *(blue + (byte)Argb.Green), *(blue + (byte)Argb.Red));
            *blue = RgbComponentCalculation.ComputeSepiaBlue(tone);
            *(blue + (byte)Argb.Green) = RgbComponentCalculation.ComputeSepiaGreen(tone);
            *(blue + (byte)Argb.Red) = RgbComponentCalculation.ComputeSepiaRed(tone);
        }

        public static unsafe void ApplyInversionToPixel(byte* blue, double factor)
        {
            for (Argb i = Argb.Blue; i <= Argb.Red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.Invert(componentValue, (int)factor);
            }
        }
    }
}
