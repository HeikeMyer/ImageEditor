using ImageProcessing.Models;

namespace ImageProcessing.Base
{
    public static class ConvolutionMatrices
    {
        public static int[][] InitializeFilterKernel(int size)
        {
            int[][] kernel = new int[size][];
            for (int i = 0; i < size; ++i)
                kernel[i] = new int[size];

            return kernel;
        }

        public static ConvolutionMatrix LightSharpenMatrix()
        {
            ConvolutionMatrix sharpenMatrix = new ConvolutionMatrix { Size = 3, Factor = 1 };

            int[][] kernel = InitializeFilterKernel(sharpenMatrix.Size);

            kernel[0][0] = kernel[0][2] = kernel[2][2] = kernel[2][0] = 0;
            kernel[1][0] = kernel[0][1] = kernel[1][2] = kernel[2][1] = -1;
            kernel[1][1] = 5;

            sharpenMatrix.Matrix = kernel;

            return sharpenMatrix;
        }

        public static ConvolutionMatrix SharpenMatrix()
        {
            ConvolutionMatrix sharpenMatrix = new ConvolutionMatrix { Size = 3, Factor = 1 };

            int[][] kernel = InitializeFilterKernel(sharpenMatrix.Size);

            kernel[0][0] = kernel[0][2] = kernel[2][2] = kernel[2][0] =
            kernel[1][0] = kernel[0][1] = kernel[1][2] = kernel[2][1] = -1;
            kernel[1][1] = 9;

            sharpenMatrix.Matrix = kernel;

            return sharpenMatrix;
        }

        public static ConvolutionMatrix BoxBlur()
        {
            ConvolutionMatrix boxBlur = new ConvolutionMatrix { Size = 3, Factor = 1.0 / 9 };

            int[][] kernel = InitializeFilterKernel(boxBlur.Size);

            kernel[0][0] = kernel[0][2] = kernel[2][2] = kernel[2][0] =
            kernel[1][0] = kernel[0][1] = kernel[1][2] = kernel[2][1] =
            kernel[1][1] = 1;

            boxBlur.Matrix = kernel;

            return boxBlur;
        }

        public static ConvolutionMatrix EdgeDetection()
        {
            ConvolutionMatrix edgeDetection = new ConvolutionMatrix { Size = 3, Factor = 1 };

            int[][] kernel = InitializeFilterKernel(edgeDetection.Size);

            kernel[0][0] = kernel[0][2] = kernel[2][2] = kernel[2][0] =
            kernel[1][0] = kernel[0][1] = kernel[1][2] = kernel[2][1] = -1;
            kernel[1][1] = 8;

            edgeDetection.Matrix = kernel;

            return edgeDetection;
        }

        public static ConvolutionMatrix GaussianBlur()
        {
            ConvolutionMatrix gaussianBlur = new ConvolutionMatrix { Size = 5, Factor = 0.00390625 };
            
            int[][] kernel = InitializeFilterKernel(gaussianBlur.Size);

            kernel[0][0] = kernel[0][4] = kernel[4][4] = kernel[4][0] = 1;
            kernel[0][1] = kernel[0][3] = kernel[1][4] = kernel[3][4] =
            kernel[4][3] = kernel[4][1] = kernel[3][0] = kernel[1][0] = 4;
            kernel[0][2] = kernel[2][4] = kernel[4][2] = kernel[2][0] = 6;
            kernel[1][1] = kernel[1][3] = kernel[3][3] = kernel[3][1] = 16;
            kernel[1][2] = kernel[2][3] = kernel[3][2] = kernel[2][1] = 24;
            kernel[2][2] = 36;

            gaussianBlur.Matrix = kernel;

            return gaussianBlur;
        }

        public static ConvolutionMatrix UnsharpMasking()
        {
            ConvolutionMatrix unsharpMasking = new ConvolutionMatrix { Size = 5, Factor = -0.00390625 };
            
            int[][] kernel = InitializeFilterKernel(unsharpMasking.Size);

            kernel[0][0] = kernel[0][4] = kernel[4][4] = kernel[4][0] = 1;
            kernel[0][1] = kernel[0][3] = kernel[1][4] = kernel[3][4] =
            kernel[4][3] = kernel[4][1] = kernel[3][0] = kernel[1][0] = 4;
            kernel[0][2] = kernel[2][4] = kernel[4][2] = kernel[2][0] = 6;
            kernel[1][1] = kernel[1][3] = kernel[3][3] = kernel[3][1] = 16;
            kernel[1][2] = kernel[2][3] = kernel[3][2] = kernel[2][1] = 24;
            kernel[2][2] = -476;

            unsharpMasking.Matrix = kernel;

            return unsharpMasking;
        }
    }
}
