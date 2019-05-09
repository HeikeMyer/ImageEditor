using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using ImageProcessing.Models;
using ImageProcessing.Base;

namespace ImageProcessing
{
    public class ImageProcessingApi
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
            filter.ConvolutionFunction = RgbComponentCalculation.ComputeRgbComponentValue;
            filter.ComputeNewRgbComponentValue = filter.ConvolutionAdapter;//ComputeNewRgbComponentValue;
            filter.SetUp(m.Size);
            filter.Apply(source, output, OnMiddle);
            //Apply(source, output);
            //return output;
            //KernelFilter kernel = new KernelFilter();
            OnProcessingCompleted(output);//kernel.ApplyKernelFilter(e.Input, e.Filter));
        }

        public Bitmap Erosion(Bitmap source, int size)
        {
            //computeRgbComponentValue = new ComputeRgbComponentValue(RgbComponentCalculation.Erosion);
            Bitmap output = new Bitmap(source.Width, source.Height);
            FilterAdapter filter = new FilterAdapter();
            filter.Size = size;
            filter.SquareFunction = RgbComponentCalculation.Erosion;
            filter.ComputeNewRgbComponentValue = filter.SquareAdapter;//ComputeNewRgbComponentValue;
            filter.SetUp(size);
            filter.Apply(source, output, OnMiddle);

            return output;
        }

        public Bitmap Dilution(Bitmap source, int size)
        {
            //computeRgbComponentValue = new ComputeRgbComponentValue(RgbComponentCalculation.Dilution);
            /*Bitmap output = new Bitmap(input.Width, input.Height);
            //Apply(input, output);
            FilterAdapter filter = new FilterAdapter();
            filter.ComputeNewRgbComponentValue = ComputeNewRgbComponentValue;
            filter.SetUp(size);
            filter.Apply(input, output);
            var source = e.Input;
            var m = e.Filter;*/
            Bitmap output = new Bitmap(source.Width, source.Height);
            FilterAdapter filter = new FilterAdapter();
            filter.Size = size;
            filter.SquareFunction = RgbComponentCalculation.Dilution;
            filter.ComputeNewRgbComponentValue = filter.SquareAdapter;//ComputeNewRgbComponentValue;
            filter.SetUp(size);
            filter.Apply(source, output, OnMiddle);
            //Apply(source, output);
            //return output;


            return output;
        }

        public Bitmap Blur(Bitmap source, int size)
        {
            Bitmap output = new Bitmap(source.Width, source.Height);
            FilterAdapter filter = new FilterAdapter();
            filter.Size = size;
            filter.SquareFunction = RgbComponentCalculation.Blur;
            filter.ComputeNewRgbComponentValue = filter.SquareAdapter;//ComputeNewRgbComponentValue;
            filter.SetUp(size);
            filter.Apply(source, output, OnMiddle);

            return output;
        }




        public unsafe void AdjustBrightnessAndContrast(Bitmap source, int brightnessFactor, int contrastFactor)
        {
            List<Adjustment> AdjustmentsPack = new List<Adjustment>();

            if (brightnessFactor != 0)
                AdjustmentsPack.Add(new Adjustment(PixelCalculation.Brightness, brightnessFactor));

            if (contrastFactor != 0)
                AdjustmentsPack.Add(new Adjustment(PixelCalculation.Contrast, contrastFactor));

            if (AdjustmentsPack.Count != 0)
                ImageProcessingBase.Adjust(source, AdjustmentsPack);
        }

        public unsafe void AdjustExposure(Bitmap source, double exposure, double gamma)
        {
            List<Adjustment> AdjustmentsPack = new List<Adjustment>();

            if (exposure != 0)
                AdjustmentsPack.Add(new Adjustment(PixelCalculation.ExposureCompensation, exposure));

            if (gamma != 0)
                AdjustmentsPack.Add(new Adjustment(PixelCalculation.GammaCorrection, gamma));

            if (AdjustmentsPack.Count != 0)
                ImageProcessingBase.Adjust(source, AdjustmentsPack);
        }

        public unsafe void AdjustColorBalance(Bitmap source, int redFactor, int greenFactor, int blueFactor)
        {

            List<Adjustment> adjustmentsPack = new List<Adjustment>();

            if (redFactor != 0)
                adjustmentsPack.Add(new Adjustment(PixelCalculation.BrightnessR, redFactor));

            if (greenFactor != 0)
                adjustmentsPack.Add(new Adjustment(PixelCalculation.BrightnessG, greenFactor));

            if (blueFactor != 0)
                adjustmentsPack.Add(new Adjustment(PixelCalculation.BrighhtnessB, blueFactor));

            if (adjustmentsPack.Count != 0)
                ImageProcessingBase.Adjust(source, adjustmentsPack);
        }

        public unsafe void Sepia(Bitmap source, int factor)
        {
            AdjustPixel adjustment = new AdjustPixel(PixelCalculation.Sepia);
            ImageProcessingBase.Adjust(source, factor, adjustment);
        }

        public unsafe void Invert(Bitmap source, int factor)
        {
            AdjustPixel adjustment = new AdjustPixel(PixelCalculation.Invert);
            ImageProcessingBase.Adjust(source, factor, adjustment);
        }

        public unsafe void BlackAndWhite(Bitmap source, int factor)
        {
            AdjustPixel adjustment = new AdjustPixel(PixelCalculation.BnW);
            ImageProcessingBase.Adjust(source, factor, adjustment);
        }

        public unsafe void Threshold(Bitmap source, int factor)
        {
            AdjustPixel adjustment = new AdjustPixel(PixelCalculation.Threshold);
            ImageProcessingBase.Adjust(source, factor, adjustment);
        }
    }
}
