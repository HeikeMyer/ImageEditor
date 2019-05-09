namespace ImageProcessing.Models
{
    public enum Argb : byte
    {
        Blue,
        Green,
        Red,
        Alfa
    }

    internal unsafe delegate void AdjustPixel(byte* blue, double factor);

    internal struct Adjustment
    {
        public AdjustPixel AdjustPixel;

        public double Factor;

        public Adjustment(AdjustPixel adjustPixel, double factor)
        {
            AdjustPixel = adjustPixel;
            Factor = factor;
        }
    }
}
