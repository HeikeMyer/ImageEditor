using System;
using System.Drawing;
using ImageProcessing.Models;

namespace ImageProcessing
{
    public delegate void ImageProcessingEventHandler(object sender, ImageProcessingEventArgs e);

    public class ImageProcessingEventArgs: EventArgs
    {
        public Bitmap Image { get; set; }
        public CustomFilter Filter { get; set; }
        public Func<Bitmap, Bitmap> Adjustment { get; set; }
        public ConvolutionMatrix ConvolutionMatrix { get; set; }
        public int Progress { get; set; }
    }
}
