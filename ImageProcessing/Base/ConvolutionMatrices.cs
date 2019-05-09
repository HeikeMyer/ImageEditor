using ImageProcessing.Models;

namespace ImageProcessing.Base
{
    public static class ConvolutionMatrices
    {
        public static int[][] InitializeMatrix(int size)
        {
            int[][] kernel = new int[size][];
            for (int i = 0; i < size; ++i)
                kernel[i] = new int[size];

            return kernel;
        }

        /*public static byte[] ConvertMatrixToKernel(ConvolutionMatrix matrix)
        {
            var size = matrix.Size;
            var kernel = new byte[size * size];

            for (int iY = 0; iY < size; ++iY)
                for (int iX = 0; iX < size; ++iX)
                    kernel[iY * size + iX] = RgbComponentCalculation.ControlOverflow(matrix.Matrix[iY][iX]);

            return kernel;
        }*/

        private static ConvolutionMatrix SetupKernel(ConvolutionMatrix matrix)
        {
            var size = matrix.Size;
            var kernelSize = size * size;
            var kernel = new byte[kernelSize];

            for (int iY = 0; iY < size; ++iY)
                for (int iX = 0; iX < size; ++iX)
                    kernel[iY * size + iX] = RgbComponentCalculation.ControlOverflow(matrix.Matrix[iY][iX]);

            matrix.Kernel = kernel;
            matrix.KernelSize = kernelSize;

            return matrix;
        }

        public static ConvolutionMatrix LightSharpenMatrix()
        {
            ConvolutionMatrix lightSharpenMatrix = new ConvolutionMatrix { Size = 3, Factor = 1 };

            int[][] matrix = InitializeMatrix(lightSharpenMatrix.Size);

            matrix[0][0] = matrix[0][2] = matrix[2][2] = matrix[2][0] = 0;
            matrix[1][0] = matrix[0][1] = matrix[1][2] = matrix[2][1] = -1;
            matrix[1][1] = 5;

            lightSharpenMatrix.Matrix = matrix;

            return SetupKernel(lightSharpenMatrix); 
        }

        public static ConvolutionMatrix SharpenMatrix()
        {
            ConvolutionMatrix sharpenMatrix = new ConvolutionMatrix { Size = 3, Factor = 1 };

            int[][] matrix = InitializeMatrix(sharpenMatrix.Size);

            matrix[0][0] = matrix[0][2] = matrix[2][2] = matrix[2][0] =
            matrix[1][0] = matrix[0][1] = matrix[1][2] = matrix[2][1] = -1;
            matrix[1][1] = 9;

            sharpenMatrix.Matrix = matrix;

            return SetupKernel(sharpenMatrix);
        }

        public static ConvolutionMatrix BoxBlur()
        {
            ConvolutionMatrix boxBlur = new ConvolutionMatrix { Size = 3, Factor = 1.0 / 9 };

            int[][] matrix = InitializeMatrix(boxBlur.Size);

            matrix[0][0] = matrix[0][2] = matrix[2][2] = matrix[2][0] =
            matrix[1][0] = matrix[0][1] = matrix[1][2] = matrix[2][1] =
            matrix[1][1] = 1;

            boxBlur.Matrix = matrix;

            return SetupKernel(boxBlur); 
        }

        public static ConvolutionMatrix EdgeDetection()
        {
            ConvolutionMatrix edgeDetection = new ConvolutionMatrix { Size = 3, Factor = 1 };

            int[][] matrix = InitializeMatrix(edgeDetection.Size);

            matrix[0][0] = matrix[0][2] = matrix[2][2] = matrix[2][0] =
            matrix[1][0] = matrix[0][1] = matrix[1][2] = matrix[2][1] = -1;
            matrix[1][1] = 8;

            edgeDetection.Matrix = matrix;

            return SetupKernel(edgeDetection);
        }

        public static ConvolutionMatrix GaussianBlur()
        {
            ConvolutionMatrix gaussianBlur = new ConvolutionMatrix { Size = 5, Factor = 0.00390625 };
            
            int[][] matrix = InitializeMatrix(gaussianBlur.Size);

            matrix[0][0] = matrix[0][4] = matrix[4][4] = matrix[4][0] = 1;
            matrix[0][1] = matrix[0][3] = matrix[1][4] = matrix[3][4] =
            matrix[4][3] = matrix[4][1] = matrix[3][0] = matrix[1][0] = 4;
            matrix[0][2] = matrix[2][4] = matrix[4][2] = matrix[2][0] = 6;
            matrix[1][1] = matrix[1][3] = matrix[3][3] = matrix[3][1] = 16;
            matrix[1][2] = matrix[2][3] = matrix[3][2] = matrix[2][1] = 24;
            matrix[2][2] = 36;

            gaussianBlur.Matrix = matrix;

            return SetupKernel(gaussianBlur);
        }

        public static ConvolutionMatrix UnsharpMasking()
        {
            ConvolutionMatrix unsharpMasking = new ConvolutionMatrix { Size = 5, Factor = -0.00390625 };
            
            int[][] matrix = InitializeMatrix(unsharpMasking.Size);

            matrix[0][0] = matrix[0][4] = matrix[4][4] = matrix[4][0] = 1;
            matrix[0][1] = matrix[0][3] = matrix[1][4] = matrix[3][4] =
            matrix[4][3] = matrix[4][1] = matrix[3][0] = matrix[1][0] = 4;
            matrix[0][2] = matrix[2][4] = matrix[4][2] = matrix[2][0] = 6;
            matrix[1][1] = matrix[1][3] = matrix[3][3] = matrix[3][1] = 16;
            matrix[1][2] = matrix[2][3] = matrix[3][2] = matrix[2][1] = 24;
            matrix[2][2] = -476;

            unsharpMasking.Matrix = matrix;

            return SetupKernel(unsharpMasking);
        }
    }
}
