using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using filter.Instuments;

namespace filter
{
    class MedianFilter : Filters
    {
        int radiusX = 1;
        int radiusY = 1;
        ColorAndValue[] ar;

        public MedianFilter()
        {
            ar = new ColorAndValue[(2*radiusX + 1)* (2*radiusY + 1)];
        }
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int count = 0;
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    ar[count++] = new ColorAndValue(neighborColor);
                }
            Array.Sort(ar);
            return ar[ar.Length / 2 + (ar.Length % 2)].GetColor();      
        }
    }
}
