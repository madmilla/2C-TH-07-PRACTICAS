using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace THO7AlgorithmTimerApplication
{
    class Grayscale : VisionAlgorithm
    {
        //  Team 10
        //
		//  Authors:  
		//  Lars Veenendaal                     1633223
		//  lars.veenendaal@student.hu.nl       TIV-2A
		//
		//  Mitchell Werensteijn                1624291
		//  mitchell.werensteijn@student.hu.nl  TIV-2A
        public Grayscale(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            Bitmap returnImage = new Bitmap(sourceImage);

            // Grayscale image
            for (int x = 0; x < returnImage.Width; ++x)
            {
                for (int y = 0; y < returnImage.Height; ++y)
                {
                    Color a = returnImage.GetPixel(x, y);
                    int grayscale = (int) (0.299 * a.R + 0.587 * a.G + 0.114 * a.B);
                    returnImage.SetPixel(x, y, Color.FromArgb(grayscale, grayscale, grayscale));
                }
            }

            return returnImage;
        }
    }
}
