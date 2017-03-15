using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace filter
{
    class SobelFilter : Filters
    {
        private int f(int x, int y)
            {
            return Clamp((int)Math.Sqrt(x * x + y * y), 0, 255);
            }
        public override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Filters fx = new SobelFilterX();
            Filters fy = new SobelFilterY();
            Color cx = fx.calculateNewPixelColor(sourceImage, x, y);       
            Color cy = fy.calculateNewPixelColor(sourceImage, x, y);
            return Color.FromArgb
                 (f(cx.R,cy.R),
                 f(cx.G, cy.G),
                 f(cx.B, cy.B));
        }
    }
}
