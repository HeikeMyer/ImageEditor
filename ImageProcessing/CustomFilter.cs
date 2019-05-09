using System.Drawing;

namespace ImageProcessing
{
    public class CustomFilter: ImageFilter
    {
        public delegate byte ComputeRgbComponentValue(byte[] neighborhood, int size);

        public new void SetUp(int size)
        {
            base.SetUp(size);
        }

        ComputeRgbComponentValue computeRgbComponentValue;

        protected override byte ComputeNewRgbComponentValue(byte[] neighborhood)
        {
            return computeRgbComponentValue(neighborhood, size);
        }

        public Bitmap Erosion(Bitmap input)
        {
            computeRgbComponentValue = new ComputeRgbComponentValue(RgbComponentCalculation.Erosion);
            Bitmap output = new Bitmap(input.Width, input.Height);
            Apply(input, output);
            return output;
        }

        public Bitmap Dilution(Bitmap input)
        {
            computeRgbComponentValue = new ComputeRgbComponentValue(RgbComponentCalculation.Dilution);
            Bitmap output = new Bitmap(input.Width, input.Height);
            Apply(input, output);
            return output;
        }

        public Bitmap Blur(Bitmap input)
        {
            computeRgbComponentValue = new ComputeRgbComponentValue(RgbComponentCalculation.Blur);
            Bitmap output = new Bitmap(input.Width, input.Height);
            Apply(input, output);
            return output;
        }
    }
}
