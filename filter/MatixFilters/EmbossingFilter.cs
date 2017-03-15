using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filter
{
    class EmbossingFilter : MatrixFilter
    {
        public EmbossingFilter()
        {
            kernel = new float[3, 3] { {0, 1, 0}, {1, 0, -1}, {0, -1, 0} };
        }       
    }
}
