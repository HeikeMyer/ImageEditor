﻿using System.Drawing;
using System.Threading;

namespace ImageProcessing
{
    public struct ConvolutionMatrix
    {
        public int[][] Matrix;
        public double Factor;
        public int Size;
        public int[] Kernel;
    }

    public class Filter
    {
        public event ImageProcessingEventHandler ProcessingCompleted;

        public event ImageProcessingEventHandler Middle;

        protected virtual void OnProcessingCompleted(Bitmap processedImage)
        {
            ProcessingCompleted?.Invoke(this, new ImageProcessingEventArgs() { Image = processedImage });
        }

        protected virtual void OnMiddle(int val)
        {
            Middle?.Invoke(this, new ImageProcessingEventArgs() { Val = val  });
        }
  
        public void ApplyFilter(object sender, FilterEventArgs e)
        {
            var source = e.Input;
            var m = e.Filter;
            Bitmap output = new Bitmap(source.Width, source.Height);
            FilterAdapter filter = new FilterAdapter();
            filter.Factor = m.Factor;
            filter.Kernel = m.Matrix.Straighten(m.Size);
            filter.ConvolutionFunction = RgbComponentCalculation.ComputeNewRgbComponentValue;
            filter.ComputeNewRgbComponentValue = filter.ConvolutionAdapter;//ComputeNewRgbComponentValue;
            filter.SetUp(m.Size);
            filter.Apply(source, output);
            //Apply(source, output);
            //return output;
            //KernelFilter kernel = new KernelFilter();
            OnProcessingCompleted(output);//kernel.ApplyKernelFilter(e.Input, e.Filter));
        }   


    }
}
