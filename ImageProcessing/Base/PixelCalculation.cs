namespace ImageProcessing.Base
{
    public static class PixelCalculation
    {
        public static unsafe void Brightness(byte* blue, double factor)
        {
            for (Rgba i = Rgba.Blue; i <= Rgba.Red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.ChangeBrightness(componentValue, factor);
            }
        }

        public static unsafe void Threshold(byte* blue, double factor)
        {
            *blue = *(blue + (byte)Rgba.Green) = *(blue + (byte)Rgba.Red) =
            RgbComponentCalculation.Threshold(*blue, *(blue + (byte)Rgba.Green), *(blue + (byte)Rgba.Red), (byte)factor);
        }

        public static unsafe void BnW(byte* blue, double factor)
        {
            *blue = *(blue + (byte)Rgba.Green) = *(blue + (byte)Rgba.Red) =
            RgbComponentCalculation.BnW(*blue, *(blue + (byte)Rgba.Green), *(blue + (byte)Rgba.Red));
        }

        public static unsafe void ExposureCompensation(byte* blue, double factor)
        {
            for (Rgba i = Rgba.Blue; i <= Rgba.Red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.Exposure(componentValue, factor);
            }
        }

        public static unsafe void GammaCorrection(byte* blue, double factor)
        {
            for (Rgba i = Rgba.Blue; i <= Rgba.Red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.Gamma(componentValue, factor);
            }
        }

        public static unsafe void BrightnessR(byte* blue, double factor)
        {
            byte componentValue = *(blue + (byte)Rgba.Red);
            *(blue + (byte)Rgba.Red) = RgbComponentCalculation.ChangeBrightness(componentValue, factor);
        }

        public static unsafe void BrightnessG(byte* blue, double factor)
        {
            byte componentValue = *(blue + (byte)Rgba.Green);
            *(blue + (byte)Rgba.Green) = RgbComponentCalculation.ChangeBrightness(componentValue, factor);
        }

        public static unsafe void BrightnessB(byte* blue, double factor)
        {
            byte componentValue = *blue;
            *blue = RgbComponentCalculation.ChangeBrightness(componentValue, factor);
        }

        public static unsafe void Sepia(byte* blue, double factor)
        {
            int tone = RgbComponentCalculation.ComputeSepiaTone(*blue, *(blue + (byte)Rgba.Green), *(blue + (byte)Rgba.Red));
            *blue = RgbComponentCalculation.ComputeSepiaBlue(tone);
            *(blue + (byte)Rgba.Green) = RgbComponentCalculation.ComputeSepiaGreen(tone);
            *(blue + (byte)Rgba.Red) = RgbComponentCalculation.ComputeSepiaRed(tone);
        }

        public static unsafe void Invert(byte* blue, double factor)
        {
            for (Rgba i = Rgba.Blue; i <= Rgba.Red; ++i)
            {
                byte componentValue = *(blue + (byte)i);
                *(blue + (byte)i) = RgbComponentCalculation.Invert(componentValue, (int)factor);
            }
        }
    }
}
