using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessing.Base;
using ImageProcessing.Models;

namespace ImageProcessing.Base
{
    internal class FilterAdapter
    {
        public Func<byte[], byte> ComputeNewRgbComponentValue { get; set; }

        public Func<byte[], int[], double, byte> ConvolutionFunction { get; set; }
        public int[] Kernel { get; set; }
        public double Factor { get; set; }

        public Func<byte[], int, byte> SquareFunction { get; set; }
        public int Size { get; set; }

        public byte ConvolutionAdapter(byte[] neighborhood)
        {
            return ConvolutionFunction(neighborhood, Kernel, Factor);
        }

        public byte SquareAdapter(byte[] neighborhood)
        {
            return SquareFunction(neighborhood, Size);
        }

        protected int size = 0;
        protected int gap;
        protected int bytesPerPixel;
        protected int gapInBytes;
        protected int neighborhoodSize;

        protected bool IsValid()
        {
            return size > 1 ? true : false;
        }

        public void SetUp(int s)
        {
            size = s;
            gap = size / 2;
            neighborhoodSize = size * size;
        }

        public void Apply(Bitmap input, Bitmap output, Action<int> onProgress)
        {
            if (!IsValid())
                return;

            bytesPerPixel = Bitmap.GetPixelFormatSize(input.PixelFormat) / (int)Bits.BitsInByte;
            gapInBytes = gap * bytesPerPixel;

            var intermediate = new IntermediateImage(input, gap);
            intermediate.FillIn();

            var lockedBitmap = new LockedBitmap(output);
            var lockedIntermediate = new LockedBitmap(intermediate.OutputImage);

            var filter = new Filter
            {
                Size = size,
                NeighborhoodSize = neighborhoodSize,
                Gap = gap,
                GapInBytes = gapInBytes, 
                BytesPerPixel = bytesPerPixel
            };

            ImageProcessingBase.ApplyFilterToBitmap(lockedIntermediate, lockedBitmap, filter, ComputeNewRgbComponentValue, onProgress);

            lockedBitmap.Unlock(output);
            lockedIntermediate.Unlock(intermediate.OutputImage);
        }
    }
}
