using System;
using System.Collections.Generic;
using System.Drawing;
using ImageProcessing.Base;

namespace ImageProcessing
{
    public class ImageProcessingApi
    {
        public event ImageProcessingEventHandler ProcessingCompleted;

        public event ImageProcessingEventHandler Progress;

        protected virtual void OnProcessingCompleted(Bitmap processedImage)
        {
            ProcessingCompleted?.Invoke(this, new ImageProcessingEventArgs() { Image = processedImage });
        }

        protected virtual void OnProgress(int val)
        {
            Progress?.Invoke(this, new ImageProcessingEventArgs() { Val = val  });
        }

        #region [Convolution]

        public void ApplyFilter(object sender, FilterEventArgs e)
        {
            var source = e.Input;
            var m = e.Filter;
            var output = ApplyConvolutionFilter(source, m, RgbComponentCalculation.ComputeRgbComponentValue);
            OnProcessingCompleted(output);
        }

        protected Bitmap ApplyConvolutionFilter(Bitmap source, ConvolutionMatrix matrix, Func<byte[], int[], double, byte> function)
        {
            Bitmap output = new Bitmap(source.Width, source.Height);

            var parameters = new FilterAdapter.ConvolutionAdapterParameters
            {
                Factor = matrix.Factor,
                Kernel = matrix.Matrix.Straighten(matrix.Size),
                Function = function
            };

            var filter = new FilterAdapter { ConvolutionAdapterArgs = parameters };
            filter.ComputeRgbComponentValue = filter.ConvolutionAdapter;
            filter.Apply(source, output, matrix.Size, OnProgress);

            return output;
        }

        #endregion

        #region [Square]

        protected Bitmap ApplySquareFilter(Bitmap source, int size, Func<byte[], int, byte> function)
        {
            Bitmap output = new Bitmap(source.Width, source.Height);
        
            var parameters = new FilterAdapter.FactorAdapterParameters
            {
                Size = size,
                Function = function
            };

            var filter = new FilterAdapter { FactorAdapterArgs = parameters };
            filter.ComputeRgbComponentValue = filter.FactorAdapter;
            filter.Apply(source, output, size, null);

            return output;
        }

        public Bitmap Erosion(Bitmap source, int size)
        {
            return ApplySquareFilter(source, size, RgbComponentCalculation.Erosion);
        }

        public Bitmap Dilution(Bitmap source, int size)
        {
            return ApplySquareFilter(source, size, RgbComponentCalculation.Dilution);
        }

        public Bitmap Blur(Bitmap source, int size)
        {
            return ApplySquareFilter(source, size, RgbComponentCalculation.Blur);
        }

        #endregion

        #region [Adjustments]

        public unsafe void BrightnessContrast(Bitmap source, int brightnessFactor, int contrastFactor)
        {
            List<Adjustment> AdjustmentsPack = new List<Adjustment>();

            if (brightnessFactor != 0)
                AdjustmentsPack.Add(new Adjustment(PixelCalculation.Brightness, brightnessFactor));

            if (contrastFactor != 0)
                AdjustmentsPack.Add(new Adjustment(PixelCalculation.Contrast, contrastFactor));

            if (AdjustmentsPack.Count != 0)
                ImageProcessingBase.Adjust(source, AdjustmentsPack);
        }

        public unsafe void Exposure(Bitmap source, double exposure, double gamma)
        {
            List<Adjustment> AdjustmentsPack = new List<Adjustment>();

            if (exposure != 0)
                AdjustmentsPack.Add(new Adjustment(PixelCalculation.ExposureCompensation, exposure));

            if (gamma != 0)
                AdjustmentsPack.Add(new Adjustment(PixelCalculation.GammaCorrection, gamma));

            if (AdjustmentsPack.Count != 0)
                ImageProcessingBase.Adjust(source, AdjustmentsPack);
        }

        public unsafe void ColorBalance(Bitmap source, int redFactor, int greenFactor, int blueFactor)
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
            ImageProcessingBase.Adjust(source, factor, PixelCalculation.Sepia);
        }

        public unsafe void Invert(Bitmap source, int factor)
        {
            ImageProcessingBase.Adjust(source, factor, PixelCalculation.Invert);
        }

        public unsafe void BnW(Bitmap source, int factor)
        {
            ImageProcessingBase.Adjust(source, factor, PixelCalculation.BnW);
        }

        public unsafe void Threshold(Bitmap source, int factor)
        {
            ImageProcessingBase.Adjust(source, factor, PixelCalculation.Threshold);
        }

        #endregion
    }
}
