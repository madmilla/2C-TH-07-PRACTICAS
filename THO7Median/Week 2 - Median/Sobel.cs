using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace THO7AlgorithmTimerApplication
{
    class Sobel : VisionAlgorithm
    {
        //  Team 10
        //
		//  Authors:  
		//  Lars Veenendaal                     1633223
		//  lars.veenendaal@student.hu.nl       TIV-2A
		//
		//  Mitchell Werensteijn                1624291
		//  mitchell.werensteijn@student.hu.nl  TIV-2A
        public Sobel(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            Bitmap returnImage = new Bitmap(sourceImage);


            // x-direction kernel
            double[,] kernelX = new double[3, 3] {{-1, 0, 1}, 
                                                 {-2, 0, 2}, 
                                                 {-1, 0, 1}};

            // x-direction kernel
            double[,] kernelY = new double[3, 3] {{-1, -2, -1}, 
                                                  {0,  0,  0}, 
                                                  {1,  2,  1}};
            
            // For each pixel in the bitmap.
            for (int x = 1; x < returnImage.Width - 1; ++x) 
            {
                for (int y = 1; y < returnImage.Height - 1; ++y)
                {
                    double magX = 0.0; // this is your magnitude
                    double magY = 0.0;

                    for (int a = 0; a < 3; a++)
                    {
                        for (int b = 0; b < 3; b++)
                        {
                            int xn = x + a - 1;
                            int yn = y + b - 1;

                            magX += sourceImage.GetPixel(xn, yn).R * kernelX[a, b];
                            magY += sourceImage.GetPixel(xn, yn).R * kernelY[a, b];
                        }
                    }

                    if (magX < 0) { magX = 0; } else if (magX > 255) { magX = 255; }
                    if (magY < 0) { magY = 0; } else if (magY > 255) { magY = 255; }


                    double mag = Math.Sqrt(magX * magX + magY * magY);

                    if (mag < 0) { mag = 0; } else if (mag > 255) { mag = 255; }

                    int mg = (int) mag;
                    returnImage.SetPixel(x, y, Color.FromArgb(mg, mg, mg));
                }
            }

            return returnImage;
        }
    }
}
