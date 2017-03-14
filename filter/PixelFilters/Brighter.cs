using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace filter
{
    class Brighter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int delta = 10;
            return Color.FromArgb
                (Clamp(sourceColor.R+ delta, 0, 255),
                Clamp(sourceColor.G + delta, 0, 255),
                Clamp(sourceColor.B + delta, 0, 255));
        }
    }
}
