using System;
using System.Drawing;

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
}
