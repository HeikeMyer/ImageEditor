using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing.Models
{
    public class FilterInfo
    {
        public int Size { get; set; }
        public int Gap { get; private set; }
        public int NeighborhoodSize { get; private set; }
        //protected int bytesPerPixel;
        //protected int gapInBytes;
        //protected int neighborhoodSize;

        public FilterInfo(int size)
        {
            Size = size;
            Gap = size / 2;
            NeighborhoodSize = size * size;
        }

        /*protected bool IsValid()
        {
            return size > 1 ? true : false;
        }

        protected void SetUp(int s)
        {
            size = s;
            gap = size / 2;
            neighborhoodSize = size * size;
        }*/
    }
}
