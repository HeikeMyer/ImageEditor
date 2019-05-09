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
        #region [Convolution]

        public class ConvolutionAdapterParameters
        {
            public Func<byte[], int[], double, byte> Function { get; set; }
            public int[] Kernel { get; set; }
            public double Factor { get; set; }
        }

        public ConvolutionAdapterParameters ConvolutionAdapterArgs { get; set; }

        public byte ConvolutionAdapter(byte[] neighborhood)
        {
            return ConvolutionAdapterArgs.Function(neighborhood, ConvolutionAdapterArgs.Kernel, ConvolutionAdapterArgs.Factor);
        }

        #endregion

        #region [Square]

        public class SquareAdapterParameters
        {
            public Func<byte[], int, byte> Function { get; set; }
            public int Size { get; set; }
        }
     
        public SquareAdapterParameters SquareAdapterArgs { get; set; }

        public byte SquareAdapter(byte[] neighborhood)
        {
            return SquareAdapterArgs.Function(neighborhood, SquareAdapterArgs.Size);
        }

        #endregion

        public Func<byte[], byte> ComputeRgbComponentValue { get; set; }

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

            ImageProcessingBase.ApplyFilterToBitmap(lockedIntermediate, lockedBitmap, filter, ComputeRgbComponentValue, onProgress);

            lockedBitmap.Unlock(output);
            lockedIntermediate.Unlock(intermediate.OutputImage);
        }
    }
}
