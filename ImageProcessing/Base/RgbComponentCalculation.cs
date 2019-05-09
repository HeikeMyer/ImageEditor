using System;

namespace ImageProcessing.Base
{
    public static class RgbComponentCalculation
    {
        #region [Linear]

        public static byte ControlOverflow(double componentValue)
        {
            return (byte)(componentValue < 0 ? 0 : (componentValue > 255 ? 255 : componentValue));
        }

        public static byte ChangeBrightness(byte componentValue, double factor)
        {
            return ControlOverflow(componentValue + factor);
        }

        public static byte Threshold(byte red, byte green, byte blue, byte threshold)
        {
            return (byte)(0.2125 * red + 0.7154 * green + 0.0721 * blue > threshold ? 255 : 0);
        }

        public static byte BnW(byte red, byte green, byte blue)
        {
            return (byte)(0.2125 * red + 0.7154 * green + 0.0721 * blue);
        }

        public static byte Invert(byte componentValue, int factor)
        {
            return ControlOverflow(255 - componentValue);
        }

        public static byte ChangeContrast(byte componentValue, int factor)
        {
            return ControlOverflow(259.0 * (factor + 255) / (255 * (259 - factor)) * (componentValue - 128) + 128);
        }

        public static int ComputeSepiaTone(byte red, byte green, byte blue)
        {
            return (int)(0.299 * red + 0.587 * green + 0.114 * blue);
        }

        public static byte ComputeSepiaBlue(int tone)
        {
            return (byte)(tone < 56 ? 0 : tone - 56);
        }

        public static byte ComputeSepiaGreen(int tone)
        {
            return (byte)(tone < 14 ? 0 : tone - 14);
        }

        public static byte ComputeSepiaRed(int tone)
        {
            return (byte)(tone > 206 ? 255 : tone + 49);
        }

        public static byte Gamma(byte color, double gamma)
        {
            return ControlOverflow(255 * Math.Pow(color / 255.0, 1 / gamma));
        }

        public static byte Exposure(byte color, double compensation)
        {
            return ControlOverflow(color * Math.Pow(2, compensation));
        }

        #endregion

        #region [Convolution]

        public static byte Dilution(byte[] neighborhood, int neighborhoodSize)
        {
            byte minimum = neighborhood[0];

            for (int i = 0; i < neighborhoodSize; ++i)
                if (neighborhood[i] < minimum)
                    minimum = neighborhood[i];

            return minimum;
        }

        public static byte Erosion(byte[] neighborhood, int neighborhoodSize)
        {
            byte maximum = neighborhood[0];

            for (int i = 0; i < neighborhoodSize; ++i)
                if (neighborhood[i] > maximum)
                    maximum = neighborhood[i];

            return maximum;
        }

        public static byte Blur(byte[] neighborhood, int neighborhoodSize)
        {
            int sum = 0;

            for (int i = 0; i < neighborhoodSize; ++i)
                sum += neighborhood[i];

            return ControlOverflow(sum / neighborhoodSize);
        }

        #endregion

        #region [Kernel]

        public static byte ComputeNewRgbComponentValue(byte[] neighborhood, byte[] kernel, int factor)
        {
            double sum = 0;

            for (int i = 0; i < neighborhood.Length; ++i)
                sum += neighborhood[i] * kernel[i];

            sum *= factor;

            return ControlOverflow(sum);
        }

        #endregion
    }
}
