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
        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);
        public Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int x = 0; x < sourceImage.Width; x++)
            {
                worker.ReportProgress((int)((float)x / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int y = 0; y < sourceImage.Height; y++)
                    resultImage.SetPixel(x, y, calculateNewPixelColor(sourceImage, x, y));
            }
            return resultImage;
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
