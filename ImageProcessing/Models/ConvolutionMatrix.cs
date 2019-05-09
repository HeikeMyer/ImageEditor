namespace ImageProcessing.Models
{
    public struct ConvolutionMatrix
    {
        public int[][] Matrix;
        public double Factor;
        public int Size;
        public byte[] Kernel;
        public int KernelSize;
    }
}
