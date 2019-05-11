using System.Drawing;
using ImageProcessing.Base;

namespace ImageProcessing
{
    public class FilterEventArgs
    {
        public FilterEventArgs(Bitmap input, ConvolutionMatrix filter)
        {
            Input = input;
            Filter = filter;
        }

        public Bitmap Input { get; }
        public ConvolutionMatrix Filter { get; }
    }
}
