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
            // returnImage is a copy of sourceImage
            Bitmap returnImage = new Bitmap(sourceImage);

            // The height of the image
            int HEIGHT = returnImage.Height;

            // The width of the image
            int WIDTH = returnImage.Width;

            int i = 0;
            int j = 0;
            
            // rnd is a Random object and we can use it for our random salt&pepper noise
            Random rnd = new Random();
            int condition = 0;
            
            // WIDHT*HEIGHT/100 * noise tells us the amount of pixels we have to add salt&pepper noise on
            while (condition <= (((WIDTH * HEIGHT) / 100) * this.Noise))
            {
                // Random x-coordinate, from range 1 to WIDTH
                i = rnd.Next(1, WIDTH);

                // Random y-coordinate, from range 1 to HEIGHT
                j = rnd.Next(1, HEIGHT);

                // This if-else statment will make sure that 50% will be changed to white and 50 % will be change to black
                if (condition % 2 == 0)
                {
                    returnImage.SetPixel(i, j, Color.Black);
                }
                else
                {
                    returnImage.SetPixel(i, j, Color.White);
                }

                // Now we have changed 1 pixel, add 1 to condition and go check the while loop again
                condition++;
            }
            return returnImage;
        }
    }
}
