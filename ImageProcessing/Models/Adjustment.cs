using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing.Models
{
    public unsafe delegate void ApplyToPixel(byte* blue, double factor);


    public struct Adjustment
    {
        public ApplyToPixel adjustment;
        //public Action<byte*, double> adjustment;
        public double factor;

        public Adjustment(ApplyToPixel applyToPixel, double f)
        {
            adjustment = applyToPixel;
            factor = f;
        }
    }
}
