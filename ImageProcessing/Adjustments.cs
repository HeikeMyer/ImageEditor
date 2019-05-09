using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageProcessing
{
    enum Argb : byte
    {
        blue, green, red, alfa
    }

    public unsafe delegate void ApplyToPixel(byte* blue, double factor);

    public struct Adjustment
    {
        public ApplyToPixel adjustment;
        public double factor;

        public Adjustment(ApplyToPixel applyToPixel, double f)
        {
            adjustment = applyToPixel;
            factor = f;
        }
    }

    /*
    public class Adjustments
    {           
        

    }*/
}
