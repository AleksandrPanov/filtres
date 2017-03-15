using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace filter
{
    class TurnFilter : Filters
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
            int k = Im.Width / 2, l = Im.Height / 2;
            float m = 3.14f / 4;
            Color sourceColor = Im.GetPixel(fx((int)((x - k)*Math.Cos(m) - (y - l)*Math.Sin(m)) + k, Im),
                                            fy((int)((x - k)*Math.Sin(m) + (y - l) * Math.Cos(m)) + l, Im));
            return Color.FromArgb
                (sourceColor.R,
                sourceColor.G,
                sourceColor.B);
        }
    }
}
