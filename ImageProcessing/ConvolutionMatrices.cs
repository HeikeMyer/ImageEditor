namespace ImageProcessing
{
    public static class ConvolutionMatrices
    {
        public static int[][] InitializeMatrix(int size)
        {
            int[][] matrix = new int[size][];
            for (int i = 0; i < size; ++i)
                matrix[i] = new int[size];

            return matrix;
        }

        public static ConvolutionMatrix LightSharpenMatrix()
        {
            ConvolutionMatrix sharpenMatrix = new ConvolutionMatrix { Size = 3, Factor = 1 };

            int[][] matrix = InitializeMatrix(sharpenMatrix.Size);

            matrix[0][0] = matrix[0][2] = matrix[2][2] = matrix[2][0] = 0;
            matrix[1][0] = matrix[0][1] = matrix[1][2] = matrix[2][1] = -1;
            matrix[1][1] = 5;

            sharpenMatrix.Matrix = matrix;

            return sharpenMatrix;
        }

        public static ConvolutionMatrix SharpenMatrix()
        {
            ConvolutionMatrix sharpenMatrix = new ConvolutionMatrix { Size = 3, Factor = 1 };

            int[][] matrix = InitializeMatrix(sharpenMatrix.Size);

            matrix[0][0] = matrix[0][2] = matrix[2][2] = matrix[2][0] =
            matrix[1][0] = matrix[0][1] = matrix[1][2] = matrix[2][1] = -1;
            matrix[1][1] = 9;

            sharpenMatrix.Matrix = matrix;

            return sharpenMatrix;
        }

        public static ConvolutionMatrix BoxBlur()
        {
            ConvolutionMatrix boxBlur = new ConvolutionMatrix { Size = 3, Factor = 1.0 / 9 };

            int[][] matrix = InitializeMatrix(boxBlur.Size);

            matrix[0][0] = matrix[0][2] = matrix[2][2] = matrix[2][0] =
            matrix[1][0] = matrix[0][1] = matrix[1][2] = matrix[2][1] =
            matrix[1][1] = 1;

            boxBlur.Matrix = matrix;

            return boxBlur;
        }

        public static ConvolutionMatrix EdgeDetection()
        {
            ConvolutionMatrix edgeDetection = new ConvolutionMatrix { Size = 3, Factor = 1 };

            int[][] matrix = InitializeMatrix(edgeDetection.Size);

            matrix[0][0] = matrix[0][2] = matrix[2][2] = matrix[2][0] =
            matrix[1][0] = matrix[0][1] = matrix[1][2] = matrix[2][1] = -1;
            matrix[1][1] = 8;

            edgeDetection.Matrix = matrix;

            return edgeDetection;
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

            return gaussianBlur;
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

            return unsharpMasking;
        }
    }
}
