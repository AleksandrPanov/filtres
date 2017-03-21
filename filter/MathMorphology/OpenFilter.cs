using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filter
{
    class OpenFilter : ErosionFilter
    {
        public OpenFilter(): base()
        {
            numFiters = 2;
            f = new DilationFilter[numFiters - 1];
            f[0] = new DilationFilter();       
        }
    }
}
