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
            for (int x = 0; x < resultImage1.Width; x++)
            {
                worker.ReportProgress((int)((float)(resultImage1.Width * 2 + x) / (resultImage1.Width * 3) * 100));
                if (worker.CancellationPending)
                    return null;
                for (int y = 0; y < resultImage1.Height; y++)
                    resultImage1.SetPixel(x, y, GetDeltaColor(resultImage1.GetPixel(x,y), resultImage2.GetPixel(x,y)));
            }
            return resultImage1;
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
        private Color GetDeltaColor(Color a, Color b)
        {
            return Color.FromArgb
                 (Clamp(a.R - b.R, 0, 255),
                 Clamp(a.G - b.G, 0, 255),
                 Clamp(a.B - b.B, 0, 255));
        }
    }
}
