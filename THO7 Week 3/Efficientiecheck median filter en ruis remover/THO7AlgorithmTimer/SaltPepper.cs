using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace THO7AlgorithmTimerApplication
{
    class SaltPepper : VisionAlgorithm
    {
        public SaltPepper(String name, int noise) : base(name, noise) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            Bitmap returnImage = new Bitmap(sourceImage);
            int HEIGHT = returnImage.Height;
            int WIDTH = returnImage.Width;
            int i;
            int j;
            Random rnd = new Random();
            int condition = 0;
            while (condition <= (((WIDTH * HEIGHT) / 100) * this.Noise))
            {
                i = rnd.Next(1, WIDTH);
                j = rnd.Next(1, HEIGHT);
                returnImage.GetPixel(i, j);
                if (condition % 2 == 0)
                {
                    returnImage.SetPixel(i, j, Color.Black);
                }
                else
                {
                    returnImage.SetPixel(i, j, Color.White);
                }
                condition++;
            }
            return returnImage;
        }
    }
}
