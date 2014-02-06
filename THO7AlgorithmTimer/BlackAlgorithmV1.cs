using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace THO7AlgorithmTimerApplication
{
    class BlackAlgorithmV1 : VisionAlgorithm
    {
        //  Authors:  
        //  Lars Veenendaal                     1633223
        //  lars.veenendaal@student.hu.nl       TIV-2A
        //
        //  Mitchell Werensteijn                1624291
        //  mitchell.werensteijn@student.hu.nl  TIV-2A
        public BlackAlgorithmV1(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            Bitmap returnImage = new Bitmap(sourceImage);

            int bitmapWidth = returnImage.Width;      // Width of the bitmap.
            int bitmapHeight = returnImage.Height;    // Height of the bitmap.

            for (int pixelY = 0; pixelY < bitmapHeight; pixelY++)           // For every row.
            {
                for (int pixelX = 0; pixelX < bitmapWidth; pixelX++)        // For every pixel in a row.
                {
                    returnImage.SetPixel(pixelX, pixelY, Color.Black);      // Change color to black.
                }
            }

            return returnImage;
        }
    }
}
