using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace filter
{
    class ErosionFilter : MathMorphologyFilter
    {
        public ErosionFilter() : base(mask, 1) {}
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return base.calculateNewPixelColor(sourceImage, x, y);
        }
    }
}
