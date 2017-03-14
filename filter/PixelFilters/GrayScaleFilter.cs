using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace filter
{
    class GrayScaleFilter : Filters
    {
        public GrayScaleFilter() { }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            int intensity =(int)(0.36*sourceColor.R + 0.53*sourceColor.G + 0.11*sourceColor.B);
           return Color.FromArgb
                (intensity,
                intensity,
                intensity);
        }
    }
}
