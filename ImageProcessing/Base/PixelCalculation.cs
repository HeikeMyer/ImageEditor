namespace ImageProcessing.Base
{
    internal static class PixelCalculation
    {
        public static unsafe void Brightness(byte* blue, double factor)
        {
            for (Argb i = Argb.Blue; i <= Argb.Red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.Brightness(componentValue, factor);
            }
        }

        public static unsafe void Contrast(byte* blue, double factor)
        {
            for (Argb i = Argb.Blue; i <= Argb.Red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.Contrast(componentValue, (int)factor);
            }
        }

        public static unsafe void Threshold(byte* blue, double factor)
        {
            *blue = *(blue + (byte)Argb.Green) = *(blue + (byte)Argb.Red) =
            RgbComponentCalculation.Threshold(*blue, *(blue + (byte)Argb.Green), *(blue + (byte)Argb.Red), (byte)factor);
        }

        public static unsafe void BnW(byte* blue, double factor)
        {
            *blue = *(blue + (byte)Argb.Green) = *(blue + (byte)Argb.Red) =
            RgbComponentCalculation.BnW(*blue, *(blue + (byte)Argb.Green), *(blue + (byte)Argb.Red));
        }

        public static unsafe void ExposureCompensation(byte* blue, double factor)
        {
            for (Argb i = Argb.Blue; i <= Argb.Red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.Exposure(componentValue, factor);
            }
        }

        public static unsafe void GammaCorrection(byte* blue, double factor)
        {
            for (Argb i = Argb.Blue; i <= Argb.Red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.Gamma(componentValue, factor);
            }
        }

        public static unsafe void BrightnessR(byte* blue, double factor)
        {
            byte componentValue = *(blue + (byte)Argb.Red);
            *(blue + (byte)Argb.Red) = RgbComponentCalculation.Brightness(componentValue, factor);
        }

        public static unsafe void BrightnessG(byte* blue, double factor)
        {
            byte componentValue = *(blue + (byte)Argb.Green);
            *(blue + (byte)Argb.Green) = RgbComponentCalculation.Brightness(componentValue, factor);
        }

        public static unsafe void BrighhtnessB(byte* blue, double factor)
        {
            byte componentValue = *blue;
            *blue = RgbComponentCalculation.Brightness(componentValue, factor);
        }

        public static unsafe void Sepia(byte* blue, double factor)
        {
            int tone = RgbComponentCalculation.Sepia(*blue, *(blue + (byte)Argb.Green), *(blue + (byte)Argb.Red));
            *blue = RgbComponentCalculation.SepiaB(tone);
            *(blue + (byte)Argb.Green) = RgbComponentCalculation.SepiaG(tone);
            *(blue + (byte)Argb.Red) = RgbComponentCalculation.SepiaR(tone);
        }

        public static unsafe void Invert(byte* blue, double factor)
        {
            for (Argb i = Argb.Blue; i <= Argb.Red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.Invert(componentValue, (int)factor);
            }
        }
    }
}
