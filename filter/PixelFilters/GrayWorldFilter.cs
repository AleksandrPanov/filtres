using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace filter
{
    class GrayWorldFilter : Filters
    {
        float coef;
        float coefR ;
        float coefG;
        float coefB ;
        public GrayWorldFilter(ref Bitmap sourceImage)
        {
            coef = 0;
            coefR = 0;
            coefG = 0;
            coefB = 0;
            float n = sourceImage.Width * sourceImage.Height;
            for (int x = 0; x < sourceImage.Width; x++)
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    coefR += sourceImage.GetPixel(x, y).R/n;
                    coefG += sourceImage.GetPixel(x, y).G/n;
                    coefB += sourceImage.GetPixel(x, y).B / n;
                }
            coef = (coefR + coefG + coefB) / 3;
        }
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            return Color.FromArgb
                 (Clamp((int)(coef / coefR * sourceColor.R), 0, 255),
                 Clamp((int)(coef / coefG * sourceColor.G),0,255),
                 Clamp((int)(coef / coefB * sourceColor.B),0,255));
        }
    }
}
