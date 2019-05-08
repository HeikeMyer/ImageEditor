﻿using System.Drawing;

namespace ImageProcessing
{
    public delegate void ImageProcessingEventHandler(object sender, ImageProcessingEventArgs e);

    public class ImageProcessingEventArgs
    {
        public Bitmap Image { get; set; }
        public int Val { get; set; }
        public ImageProcessingEventArgs(Bitmap bitmap)
        {
            Image = bitmap;
        }

        public ImageProcessingEventArgs() { }
    }

    public delegate Bitmap CustomFilterAdjustment(Bitmap original);

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

    public class CustomFilterEventArgs
    {
        public CustomFilterEventArgs(Bitmap input, CustomFilterAdjustment adjustment, CustomFilter filter)
        {
            Input = input;
            Adjustment = adjustment;
            Filter = filter;
        }

        public Bitmap Input { get; }

        public CustomFilterAdjustment Adjustment { get; }

        public CustomFilter Filter { get; }

    }
}
