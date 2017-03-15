using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace filter
{
    class SepiaFilter : Filters
    {
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int intensity = (int)(0.36 * sourceColor.R + 0.53 * sourceColor.G + 0.11 * sourceColor.B);
            int k = 10;
            return Color.FromArgb
                (Clamp(intensity + 2 * k, 0, 255),
                Clamp(intensity + (int)(0.5 * k), 0, 255),
                Clamp((intensity - k), 0, 255));
        }
    }
}
