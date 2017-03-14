using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace filter
{
    class SobelFilters : MatrixFilter
    {
        public SobelFilters(){        }
        public Color GetX(Bitmap sourceImage, int x, int y)
        {
            kernel = new float[3, 3];
            for (int i = -1; i <= 1; i++)
                for (int j = 0; j < 3; j++)
                    kernel[i + 1, j] = (float)(i * (((i + 1) % 2) + 1) * ((j % 2) ^ 1));
            return calculateNewPixelColor(sourceImage, x, y);
        }
        public Color GetY(Bitmap sourceImage, int x, int y)
        {
            kernel = new float[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = - 1; j <= 1; j++)
                    kernel[i + 1, j] = (float)(i * (((i + 1) % 2) + 1) * ((j % 2) ^ 1));
            return calculateNewPixelColor(sourceImage, x, y);
        }
    }
}
