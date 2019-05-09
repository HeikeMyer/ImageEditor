using ImageProcessing.Base;
using ImageProcessing.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    public class ImageProcessingApi
    {
        public event ImageProcessingEventHandler ProcessingCompleted;

        public event ImageProcessingEventHandler Progress;

        protected virtual void OnProcessingCompleted(Bitmap bitmap)
        {
            var args = new ImageProcessingEventArgs() { Image = bitmap };
            ProcessingCompleted?.Invoke(this, args);
        }

        protected virtual void OnProgress(int progress)
        {
            var args = new ImageProcessingEventArgs() { Progress = progress };
            Progress?.Invoke(this, args);
        }

        #region [Adjustments]

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
                adjustmentsPack.Add(new Adjustment(PixelCalculation.BrightnessB, blueFactor));

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


        public void ApplyFilter(object sender, ImageProcessingEventArgs e)
        {
            /*Thread.Sleep(5000);
            OnMiddle(1);
            Thread.Sleep(5000);
            OnMiddle(2);
            Thread.Sleep(5000);
            OnMiddle(3);*/
            KernelFilter kernel = new KernelFilter(e.ConvolutionMatrix);
            OnProcessingCompleted(kernel.ApplyKernelFilter(e.Image));
        }
    }
}
