using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace filter
{
    class SobelFilterX : MatrixFilter
    {
        public SobelFilterX()
        {
            kernel = new float[3, 3] { { -1, 0, 1 }, {-2, 0, 2 }, {-1, 0, 1} };

        }
    }
    class SobelFilterY : MatrixFilter
    {
        public SobelFilterY()
        {
            kernel = new float[3, 3] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
        }
    }
}
