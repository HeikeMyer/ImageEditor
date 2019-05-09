using System.Threading.Tasks;
using System.Drawing;

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

        protected void Apply(Bitmap input, Bitmap output)
        {
            if (!IsValid())
                return;

            bytesPerPixel = Bitmap.GetPixelFormatSize(input.PixelFormat) / (int)Bits.bitsInByte;
            gapInBytes = gap * bytesPerPixel;

            IntermediateImage intermediate = new IntermediateImage(input, gap);
            intermediate.FillIn();

            LockedBitmap lockedBitmap = new LockedBitmap(output);
            LockedBitmap lockedIntermediate = new LockedBitmap(intermediate.OutputImage);

            ImageProcessingBase.ApplyFilterToBitmap(lockedIntermediate, lockedBitmap, neighborhoodSize, gap, gapInBytes, size, bytesPerPixel, ComputeNewRgbComponentValue);

            lockedBitmap.Unlock(output);
            lockedIntermediate.Unlock(intermediate.OutputImage);
        }
    }
}
