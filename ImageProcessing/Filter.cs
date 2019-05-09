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
            KernelFilter kernel = new KernelFilter();
            OnProcessingCompleted(kernel.ApplyKernelFilter(e.Input, e.Filter));
        }   
    }
}
