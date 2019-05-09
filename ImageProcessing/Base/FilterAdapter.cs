using System;
using System.Drawing;
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

        public void Apply(Bitmap input, Bitmap output, int size, Action<int> onProgress)
        {
            if (size <= 1)
                return;

            int gap = size / 2;
            int bytesPerPixel = Image.GetPixelFormatSize(input.PixelFormat) / (int)Bits.BitsInByte;
            var intermediate = new IntermediateImage(input, gap);

            intermediate.FillIn();

            var lockedBitmap = new LockedBitmap(output);
            var lockedIntermediate = new LockedBitmap(intermediate.OutputImage);

            var filter = new Filter
            {
                Size = size,
                NeighborhoodSize = size * size,
                Gap = gap,
                GapInBytes = gap * bytesPerPixel, 
                BytesPerPixel = bytesPerPixel
            };

            ImageProcessingBase.ApplyFilterToBitmap(lockedIntermediate, lockedBitmap, filter, ComputeRgbComponentValue, onProgress);

            lockedBitmap.Unlock(output);
            lockedIntermediate.Unlock(intermediate.OutputImage);
        }
    }
}
