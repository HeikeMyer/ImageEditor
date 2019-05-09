using System.Threading.Tasks;
using System.Drawing;
using ImageProcessing.Base;

namespace ImageProcessing
{
    public abstract class ImageFilter
    {
        protected abstract byte ComputeNewRgbComponentValue(byte[] neighborhood);

        protected int size = 0;
        protected int gap;
        protected int bytesPerPixel;
        protected int gapInBytes;
        protected int neighborhoodSize;

        protected bool IsValid()
        {
            return size > 1 ? true : false;
        }

        protected void SetUp(int s)
        {
            size = s;
            gap = size / 2;
            neighborhoodSize = size * size;
        }

        
    }
}
