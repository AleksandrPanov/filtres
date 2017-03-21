using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filter 
{
    class GradFilter : MathMorphologyFilter
    {
        int[,] ar;
        public GradFilter()
        { 
            numFiters = 3;
            f = new Filters[numFiters];
            f[0] = new DilationFilter();
            f[1] = new ErosionFilter();     
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage1 = calculateOneImage(sourceImage, worker, 1);
            Bitmap resultImage2 = calculateOneImage(sourceImage, worker, 2);
            ar = new int[resultImage2.Width, resultImage2.Height];
            int xM = resultImage2.Width;
            int yM = resultImage2.Height;
            for (int x = 0; x < xM; x++)
                for (int y = 0; y < yM; y++)
                    ar[x, y] = (resultImage2.GetPixel(x, y).R + resultImage2.GetPixel(x, y).G + resultImage2.GetPixel(x, y).B)/3;
            MathMorphologyFilter.SetMask(ar);
            f[2] = new ErosionFilter();
            Bitmap res = calculateOneImage(resultImage1, worker, 3);
            return res;
        }
        private Bitmap calculateOneImage(Bitmap sourceImage, BackgroundWorker  worker, int indFilt)
        {
            Bitmap resultImage1 = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int x = 0; x < sourceImage.Width; x++)
            {
                worker.ReportProgress((int)(((float)(x + resultImage1.Width * (indFilt-1))) / (resultImage1.Width * numFiters) * 100));
                if (worker.CancellationPending)
                    return null;
                for (int y = 0; y < sourceImage.Height; y++)
                    resultImage1.SetPixel(x, y, f[indFilt-1].calculateNewPixelColor(sourceImage, x, y));
            }
            return resultImage1;
        }
    }
}
