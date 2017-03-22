using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace filter
{
    class LinearStretching : Filters
    {
        float min = 1.0f;
        float max = 0.0f;
        public LinearStretching(ref Bitmap sourceImage)
        {
            for (int x = 0; x < sourceImage.Width; x++)
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    float cur = sourceImage.GetPixel(x, y).GetBrightness();
                    if (cur < min)
                        min = cur;
                    if (cur > max)
                        max = cur;
                }
        }

        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color res = sourceImage.GetPixel(x, y);
            float b = res.GetBrightness();
            float resB = (b - min) / (max - min);
            b = resB / b;
            return Color.FromArgb
                  (Clamp((int)(b * res.R), 0, 255),
                   Clamp((int)(b * res.G), 0, 255),
                   Clamp((int)(b * res.B), 0, 255));
        }
    }
}
