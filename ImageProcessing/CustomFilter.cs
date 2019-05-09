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

      //  ComputeRgbComponentValue computeRgbComponentValue;

        protected override byte ComputeNewRgbComponentValue(byte[] neighborhood)
        {
            throw new System.Exception();
           // return computeRgbComponentValue(neighborhood, size);
        }

        /* public Bitmap Erosion(Bitmap input)
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
         }*/

        public Bitmap Erosion(Bitmap source, int size)
        {
            //computeRgbComponentValue = new ComputeRgbComponentValue(RgbComponentCalculation.Erosion);
            Bitmap output = new Bitmap(source.Width, source.Height);
            FilterAdapter filter = new FilterAdapter();
            filter.Size = size;
            filter.SquareFunction = RgbComponentCalculation.Erosion;
            filter.ComputeNewRgbComponentValue = filter.SquareAdapter;//ComputeNewRgbComponentValue;
            filter.SetUp(size);
            filter.Apply(source, output);

            return output;
        }

        public Bitmap Dilution(Bitmap source, int size)
        {
            //computeRgbComponentValue = new ComputeRgbComponentValue(RgbComponentCalculation.Dilution);
            /*Bitmap output = new Bitmap(input.Width, input.Height);
            //Apply(input, output);
            FilterAdapter filter = new FilterAdapter();
            filter.ComputeNewRgbComponentValue = ComputeNewRgbComponentValue;
            filter.SetUp(size);
            filter.Apply(input, output);
            var source = e.Input;
            var m = e.Filter;*/
            Bitmap output = new Bitmap(source.Width, source.Height);
            FilterAdapter filter = new FilterAdapter();
            filter.Size = size;
            filter.SquareFunction = RgbComponentCalculation.Dilution;
            filter.ComputeNewRgbComponentValue = filter.SquareAdapter;//ComputeNewRgbComponentValue;
            filter.SetUp(size);
            filter.Apply(source, output);
            //Apply(source, output);
            //return output;


            return output;
        }

        public Bitmap Blur(Bitmap source, int size)
        {
            Bitmap output = new Bitmap(source.Width, source.Height);
            FilterAdapter filter = new FilterAdapter();
            filter.Size = size;
            filter.SquareFunction = RgbComponentCalculation.Blur;
            filter.ComputeNewRgbComponentValue = filter.SquareAdapter;//ComputeNewRgbComponentValue;
            filter.SetUp(size);
            filter.Apply(source, output);

            return output;
        }
    }
}

