using System;
using System.Drawing;
using ImageProcessing.Models;

namespace ImageProcessing
{
    public delegate void ImageProcessingEventHandler(object sender, ImageProcessingEventArgs e);

    public class ImageProcessingEventArgs
    {
        public Bitmap Image { get; set; }
        public Func<Bitmap, int, Bitmap> Adjustment { get; set; }
        public ImageProcessingApi Filter { get; set; }
        public int Intensity { get; set; }

        public int Val { get; set; }
    }
    
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
