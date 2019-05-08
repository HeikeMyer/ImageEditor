﻿using System.Drawing;
using System.Threading;

namespace ImageProcessing
{
    public struct ConvolutionMatrix
    {
        public int[][] matrix;
        public double convolutionFactor;
        public int size;
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




        public static int[][] InitializeFilterKernel(int size)
        {
            int[][] kernel = new int[size][];
            for (int i = 0; i < size; ++i)
                kernel[i] = new int[size];

            return kernel;
        }


        public static ConvolutionMatrix LightSharpenMatrix()
        {
            ConvolutionMatrix sharpenMatrix = new ConvolutionMatrix();
            sharpenMatrix.size = 3;
            sharpenMatrix.convolutionFactor = 1;

            int[][] kernel = InitializeFilterKernel(sharpenMatrix.size);

            kernel[0][0] = kernel[0][2] = kernel[2][2] = kernel[2][0] = 0;
            kernel[1][0] = kernel[0][1] = kernel[1][2] = kernel[2][1] = -1;
            kernel[1][1] = 5;

            sharpenMatrix.matrix = kernel;

            return sharpenMatrix;
        }


        public static ConvolutionMatrix SharpenMatrix()
        {
            ConvolutionMatrix sharpenMatrix = new ConvolutionMatrix();
            sharpenMatrix.size = 3;
            sharpenMatrix.convolutionFactor = 1;

            int[][] kernel = InitializeFilterKernel(sharpenMatrix.size);

            kernel[0][0] = kernel[0][2] = kernel[2][2] = kernel[2][0] =
            kernel[1][0] = kernel[0][1] = kernel[1][2] = kernel[2][1] = -1;
            kernel[1][1] = 9;

            sharpenMatrix.matrix = kernel;

            return sharpenMatrix;
        }


        public static ConvolutionMatrix BoxBlur()
        {
            ConvolutionMatrix boxBlur = new ConvolutionMatrix();
            boxBlur.size = 3;
            boxBlur.convolutionFactor = 1.0/9;

            int[][] kernel = InitializeFilterKernel(boxBlur.size);

            kernel[0][0] = kernel[0][2] = kernel[2][2] = kernel[2][0] =
            kernel[1][0] = kernel[0][1] = kernel[1][2] = kernel[2][1] =
            kernel[1][1] = 1;

            boxBlur.matrix = kernel;

            return boxBlur;
        }


        public static ConvolutionMatrix EdgeDetection()
        {
            ConvolutionMatrix edgeDetection = new ConvolutionMatrix();
            edgeDetection.size = 3;
            edgeDetection.convolutionFactor = 1;

            int[][] kernel = InitializeFilterKernel(edgeDetection.size);

            kernel[0][0] = kernel[0][2] = kernel[2][2] = kernel[2][0] =
            kernel[1][0] = kernel[0][1] = kernel[1][2] = kernel[2][1] = -1;
            kernel[1][1] = 8;

            edgeDetection.matrix = kernel;

            return edgeDetection;
        }


        public static ConvolutionMatrix GaussianBlur()
        {
            ConvolutionMatrix gaussianBlur = new ConvolutionMatrix();
            gaussianBlur.size = 5;
            gaussianBlur.convolutionFactor = 0.00390625;

            int[][] kernel = InitializeFilterKernel(gaussianBlur.size);

            kernel[0][0] = kernel[0][4] = kernel[4][4] = kernel[4][0] = 1;
            kernel[0][1] = kernel[0][3] = kernel[1][4] = kernel[3][4] =
            kernel[4][3] = kernel[4][1] = kernel[3][0] = kernel[1][0] = 4;
            kernel[0][2] = kernel[2][4] = kernel[4][2] = kernel[2][0] = 6;
            kernel[1][1] = kernel[1][3] = kernel[3][3] = kernel[3][1] = 16;
            kernel[1][2] = kernel[2][3] = kernel[3][2] = kernel[2][1] = 24;
            kernel[2][2] = 36;

            gaussianBlur.matrix = kernel;

            return gaussianBlur;
        }


        public static ConvolutionMatrix UnsharpMasking()
        {
            ConvolutionMatrix unsharpMasking = new ConvolutionMatrix();
            unsharpMasking.size = 5;
            unsharpMasking.convolutionFactor = -0.00390625;

            int[][] kernel = InitializeFilterKernel(unsharpMasking.size);

            kernel[0][0] = kernel[0][4] = kernel[4][4] = kernel[4][0] = 1;
            kernel[0][1] = kernel[0][3] = kernel[1][4] = kernel[3][4] =
            kernel[4][3] = kernel[4][1] = kernel[3][0] = kernel[1][0] = 4;
            kernel[0][2] = kernel[2][4] = kernel[4][2] = kernel[2][0] = 6;
            kernel[1][1] = kernel[1][3] = kernel[3][3] = kernel[3][1] = 16;
            kernel[1][2] = kernel[2][3] = kernel[3][2] = kernel[2][1] = 24;
            kernel[2][2] = -476;

            unsharpMasking.matrix = kernel;

            return unsharpMasking;
        }


        public void ApplyFilter(object sender, FilterEventArgs e)
        {
            Thread.Sleep(5000);
            OnMiddle(1);
            Thread.Sleep(5000);
            OnMiddle(2);
            Thread.Sleep(5000);
            OnMiddle(3);
            KernelFilter kernel = new KernelFilter(e.Filter);
            OnProcessingCompleted(kernel.ApplyKernelFilter(e.Input));
        }   
    }
}