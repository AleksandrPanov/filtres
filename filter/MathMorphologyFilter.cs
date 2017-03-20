using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filter
{
    class MathMorphologyFilter : Filters
    {
        protected int[,] mask = null;
        protected delegate bool comparison(int a, int b);
        comparison[] comp = new comparison[2];

        protected int m;
        int index;

        protected MathMorphologyFilter() { }
        protected MathMorphologyFilter(int size, int ind)
        {
            mask = new int [size, size];
            index = ind;
            if (index == 0)
                m = 0;
            if (index == 1)
                m = 255 * 3;
            comp[0] = Dilation;
            comp[1] = Erosion;
        }
        private  bool Dilation(int a, int b)
        {
            return (a > b);
        }
        private bool Erosion(int a, int b)
        {
            return (a < b);
        }
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = mask.GetLength(0) / 2;
            int radiusY = mask.GetLength(1) / 2;
            int mb = m;
            Color resColor = sourceImage.GetPixel(x, y); 
            for (int j = -radiusY; y <= radiusY; j++)
                for (int i = -radiusX; i <= radiusX; i++)
                {
                    int local = 255*3 - resColor.R + resColor.G + resColor.B;
                    if (mask[i, j] != 0 && comp[index](local, mb))
                    {
                        resColor = sourceImage.GetPixel(i, j);
                        mb = local;
                    }
                }
            return resColor;
        }
    }
}
