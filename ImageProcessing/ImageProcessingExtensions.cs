namespace ImageProcessing
{
    internal static class ImageProcessingExtensions
    {
        public static int[] Straighten(this int[][] matrix, int size)
        {
            var array = new int[size*size];

            for (int iY = 0; iY < size; ++iY)
                for (int iX = 0; iX < size; ++iX)
                    array[iY * size + iX] = matrix[iY][iX];

            return array;
        }
    }
}
