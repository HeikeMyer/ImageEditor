using System.Drawing;

namespace ImageProcessing
{
    class KernelFilter: ImageFilter
    {
        private double factor;

        private int[] kernel;
        private int kernelSize;

        private void SetUpKernel(ConvolutionMatrix filterKernel)
        {
            kernel = new int[kernelSize];

            for (int iY = 0; iY < size; ++iY)       
                for (int iX = 0; iX < size; ++iX)              
                    kernel[iY * size + iX] = filterKernel.Matrix[iY][iX];                        
        }

        public KernelFilter(ConvolutionMatrix filterKernel)
        {
            SetUp(filterKernel.Size);
            kernelSize = size * size;       
            factor = filterKernel.Factor;
            SetUpKernel(filterKernel);
        }

        protected override byte ComputeNewRgbComponentValue(byte[] neighborhood)
        {
            /*   double sum = 0;

               for (int i = 0; i < neighborhood.Length; ++i)
                   sum += neighborhood[i] * kernel[i];

               sum *= factor;

               return RgbComponentCalculation.ControlOverflow(sum);*/
            throw new System.Exception();
        }

        public Bitmap ApplyKernelFilter(Bitmap source, ConvolutionMatrix m)
        {
            Bitmap output = new Bitmap(source.Width, source.Height);
            FilterAdapter filter = new FilterAdapter();
            filter.Factor = m.Factor;
            filter.Kernel = m.Matrix.Straighten(m.Size);
            filter.ConvolutionFunction = RgbComponentCalculation.ComputeNewRgbComponentValue;
            filter.ComputeNewRgbComponentValue = filter.ConvolutionAdapter;//ComputeNewRgbComponentValue;
            filter.SetUp(m.Size);
            filter.Apply(source, output);
            //Apply(source, output);
            return output;
        }
    }
}
