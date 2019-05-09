using System.Drawing;
using System.Threading;

namespace ImageProcessing
{
    public struct ConvolutionMatrix
    {
        public int[][] Matrix;
        public double Factor;
        public int Size;
        public int[] Kernel;
    }

    public class Filter
    {
        public event ImageProcessingEventHandler ProcessingCompleted;

        public event ImageProcessingEventHandler Middle;

        protected virtual void OnProcessingCompleted(Bitmap processedImage)
        {
            ProcessingCompleted?.Invoke(this, new ImageProcessingEventArgs() { Image = processedImage });
        }

        protected virtual void OnMiddle(int val)
        {
            Middle?.Invoke(this, new ImageProcessingEventArgs() { Val = val  });
        }
  
        public void ApplyFilter(object sender, FilterEventArgs e)
        {
            var source = e.Input;
            var m = e.Filter;
            Bitmap output = new Bitmap(source.Width, source.Height);
            FilterAdapter filter = new FilterAdapter();
            filter.Factor = m.Factor;
            filter.Kernel = m.Matrix.Straighten(m.Size);
            filter.ConvolutionFunction = RgbComponentCalculation.ComputeNewRgbComponentValue;
            filter.ComputeNewRgbComponentValue = filter.ConvolutionAdapter;//ComputeNewRgbComponentValue;
            filter.SetUp(m.Size);
            filter.Apply(source, output);
            //Apply(source, output);
            //return output;
            //KernelFilter kernel = new KernelFilter();
            OnProcessingCompleted(output);//kernel.ApplyKernelFilter(e.Input, e.Filter));
        }

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
