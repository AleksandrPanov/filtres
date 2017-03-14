using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filter
{
    class GaussianFilter : MatrixFilter
    {
        public void createGaussianKernal(int radius, float sigma)
        {          
            int size = 2 * radius + 1; //size kernal
            kernel = new float[size, size];
            float norm = 0; //coeff normal kernel
            for (int i = -radius; i <=radius; i++)
                for (int j = -radius; j <= radius; j++)
                {
                    kernel[i + radius, j + radius] = (float)(Math.Exp(-(i * i + j * j) / (sigma * sigma)));
                    norm += kernel[i + radius, j + radius];
                }
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    kernel[i, j] /= norm;
        }
        public GaussianFilter()
        {
            createGaussianKernal(3, 2);
        }
    }
}
