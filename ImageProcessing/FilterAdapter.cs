using System;
using ImageProcessing.Models;

namespace ImageProcessing
{
    public class FilterAdapter
    {
        public int Size { get; set; }

        public ConvolutionMatrix ConvolutionMatrix {get; set;}

        public Func<byte[], ConvolutionMatrix, byte> ConvolutionFunction { get; set; }

        public Func<byte[], int, byte> SquareFunction { get; set; }

        public byte ConvolutionFilter(byte[] neighborhood)
        {
            return ConvolutionFunction(neighborhood, ConvolutionMatrix);
        }

        public byte SquareFilter(byte[] neighborhood)
        {
            return SquareFunction(neighborhood, Size);
        }
    }
}
