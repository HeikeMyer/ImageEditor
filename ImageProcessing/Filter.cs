using System.Drawing;
using System.Threading;

namespace ImageProcessing
{
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
            Middle?.Invoke(this, new ImageProcessingEventArgs() { Progress = val  });
        }

        

        
        public void ApplyFilter(object sender, ImageProcessingEventArgs e)
        {
            /*Thread.Sleep(5000);
            OnMiddle(1);
            Thread.Sleep(5000);
            OnMiddle(2);
            Thread.Sleep(5000);
            OnMiddle(3);*/
            KernelFilter kernel = new KernelFilter(e.ConvolutionMatrix);
            OnProcessingCompleted(kernel.ApplyKernelFilter(e.Image));
        }   
    }
}
