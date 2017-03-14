using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace filter
{
    class SobelFilte : Filters
    {
        private int f(int x, int y)
        {
            return Clamp((int)Math.Sqrt((x * x + y * y)), 0, 255);
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            SobelFilters s = new SobelFilters();
            Color sx = s.GetX(sourceImage, x, y);
            Color sy = s.GetY(sourceImage, x, y);
            return Color.FromArgb
                (f(sx.R, sy.R),
                 f(sx.G, sy.G),
                 f(sx.B, sy.B));
        }
    }
}
