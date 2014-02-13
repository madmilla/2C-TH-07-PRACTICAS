using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace THO7AlgorithmTimerApplication
{
    class InvertAlgorithmV2 : VisionAlgorithm
    {
        //  Authors:  
        //  Lars Veenendaal                     1633223
        //  lars.veenendaal@student.hu.nl       TIV-2A
        //
        //  Mitchell Werensteijn                1624291
        //  mitchell.werensteijn@student.hu.nl  TIV-2A
        public InvertAlgorithmV2(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            // Bronnen:  
            // http://msdn.microsoft.com/en-us/library/5ey6h79d(v=vs.110).aspx
            Bitmap returnImage = new Bitmap(sourceImage);

            // Save the size from the bitmap in a rectangle at position 0,0.
            Rectangle bitmapRect = new Rectangle(new Point(0,0), returnImage.Size);
            
            // Lock the bits from the bitmap in system memory.
            BitmapData bitmapData = returnImage.LockBits(bitmapRect, System.Drawing.Imaging.ImageLockMode.WriteOnly, returnImage.PixelFormat);

            // Calculate the amount of pixels needed to be set.
            int bytes = Math.Abs(bitmapData.Stride) * bitmapData.Height;

            // Set unsafe context (Check out : http://msdn.microsoft.com/en-us/library/chfa2zb8.aspx)
            unsafe
            {
                // Create a pointer to go through the bitmapData.
                byte* bitmapDataPtr = (byte*)bitmapData.Scan0;

                // Loop through the rgbValues and invert the color by taking 255 of the orginal value.
                for (int counter = 0; counter < bytes; counter += 4)
                {
                    bitmapDataPtr[counter] = (byte)(255 - bitmapDataPtr[counter]);          
                    bitmapDataPtr[counter + 1] = (byte)(255 - bitmapDataPtr[counter + 1]);
                    bitmapDataPtr[counter + 2] = (byte)(255 - bitmapDataPtr[counter + 2]);
                }
            }
            
            // Unlock the bits from the bitmap from system memory.
            returnImage.UnlockBits(bitmapData);

            return returnImage;
        }
    }
}
