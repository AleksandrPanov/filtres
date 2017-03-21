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
        protected static int[,] mask = new int[3, 3] { {0,1,0 }, { 1,1,1}, {0,1,0 } };
        protected delegate bool comparison(int a, int b);
        comparison[] comp = new comparison[2];

        protected int m;
        protected int index;

        public static void SetMask(int[,] ar1)
        {
            mask = ar1;
        }

        protected MathMorphologyFilter()
        {
            comp[0] = Dilation;
            comp[1] = Erosion;
        }
        protected MathMorphologyFilter(int[,] _mask, int ind)
        {
            mask = _mask;
            index = ind;
            if (index == 0)
                m = 255*3;
            if (index == 1)
                m = 0;
            comp[1] = Dilation;
            comp[0] = Erosion;
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
            Color curColor = sourceImage.GetPixel(x, y);
            Color resColor = Color.FromArgb(255 - m/3,255- m/3,255 - m/3); 

            for (int j = -radiusY; j < radiusY; j++)
                for (int i = -radiusX; i < radiusX; i++)
                {
                    int idX = Clamp(x + i, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + j, 0, sourceImage.Height - 1);
                    curColor = sourceImage.GetPixel(idX, idY);

                    int local = 255*3 - curColor.R - curColor.G - curColor.B;
                    if (mask[i + radiusX, j + radiusY] != 0 && comp[index](local, mb))
                    {                       
                        resColor = sourceImage.GetPixel(idX, idY);
                        mb = local;
                    }
                }
            return resColor;
        }
    }
}
