namespace ImageProcessing.Models
{
    internal struct Filter
    {
        public int Size;
        public int NeighborhoodSize;
        public int Gap;
        public int GapInBytes;
        public int BytesPerPixel;
    }
}
