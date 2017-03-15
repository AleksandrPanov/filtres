using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace filter
{
    class ShiftFilter : Filters
    {
        private int fx(int x, Bitmap sourceImage)
        {
            return Clamp(x, 0, sourceImage.Width - 1);
        }
        private int fy(int y, Bitmap sourceImage)
        {
            return Clamp(y, 0, sourceImage.Height - 1);
        }
        public override Color calculateNewPixelColor(Bitmap Im, int x, int y)
        {
            int k = 100, l = 0;
            Color sourceColor = Im.GetPixel(fx(x + k, Im), fy(y + l, Im));
            return Color.FromArgb
                (sourceColor.R,
                sourceColor.G,
                sourceColor.B);
        }
    }
}
