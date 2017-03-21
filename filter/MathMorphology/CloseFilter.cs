using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filter
{
    class CloseFilter : DilationFilter
    {
        public CloseFilter(): base()
        {
            numFiters = 2;         
            f = new ErosionFilter[numFiters - 1];
            f[0] = new ErosionFilter();
        }
    }
}
