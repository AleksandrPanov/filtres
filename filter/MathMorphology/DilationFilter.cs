using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filter
{
    class DilationFilter : MathMorphologyFilter
    {
        public DilationFilter() : base(3, 0) { }
       /* public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return base.calculateNewPixelColor(sourceImage, x, y);
        }*/
    }
}
