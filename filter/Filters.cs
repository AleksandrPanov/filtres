using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace filter
{
    abstract class Filters
    {
        public abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);
        protected int numFiters = 1;
        protected Filters []f;
        public virtual Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    worker.ReportProgress((int)((float)x / (resultImage.Width * numFiters) * 100));
                    if (worker.CancellationPending)
                        return null;
                    for (int y = 0; y < sourceImage.Height; y++)
                        resultImage.SetPixel(x, y, calculateNewPixelColor(sourceImage, x, y));
                }
            if (numFiters == 1)
                return resultImage;
            Bitmap resultImage1 = new Bitmap(resultImage.Width, resultImage.Height); 
            for (int i = 1; i < numFiters; i++)
            {
                for (int x = 0; x < resultImage.Width; x++)
                {
                    worker.ReportProgress( (int)((float)(resultImage1.Width*i + x)/(resultImage1.Width * (i+1) ) * 100) );
                    if (worker.CancellationPending)
                        return null;
                    for (int y = 0; y < resultImage.Height; y++)
                        resultImage1.SetPixel(x, y, f[i - 1].calculateNewPixelColor(resultImage, x, y));
                }
                resultImage = new Bitmap(resultImage1);
            }
            return resultImage1;
        }
        public int Clamp(int value, int min, int max) // clamp = сцеплять
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
    }
}
