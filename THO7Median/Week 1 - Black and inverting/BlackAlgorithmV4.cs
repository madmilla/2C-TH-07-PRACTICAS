using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace THO7AlgorithmTimerApplication
{
    class BlackAlgorithmV4 : VisionAlgorithm
    {
        //  Team 10
        //
        //  Authors:  
        //  Lars Veenendaal                     1633223
        //  lars.veenendaal@student.hu.nl       TIV-2A
        //
        //  Mitchell Werensteijn                1624291
        //  mitchell.werensteijn@student.hu.nl  TIV-2A
        public BlackAlgorithmV4(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            // Bronnen:  
            // http://msdn.microsoft.com/en-us/library/5ey6h79d(v=vs.110).aspx

            Bitmap returnImage = new Bitmap(sourceImage);

            // Save the size from the bitmap in a rectangle at position 0,0.
            Rectangle bitmapRect = new Rectangle(new Point(0,0), returnImage.Size);
            
            // Lock the bits from the bitmap in system memory.
            // WriteOnly cause we dont need to read it.
            BitmapData bitmapData = returnImage.LockBits(new Rectangle(0, 0, returnImage.Width, returnImage.Height), ImageLockMode.WriteOnly, returnImage.PixelFormat);

            // Calculate the amount of pixels needed to be set.
            int bytes = Math.Abs(bitmapData.Stride) * bitmapData.Height;

            // Set unsafe context (Check out : http://msdn.microsoft.com/en-us/library/chfa2zb8.aspx)
            unsafe
            {
                // Create a pointer to go through the bitmapData.
                byte* bitmapDataPtr = (byte*)bitmapData.Scan0;

                // Check this is not a null area
                if (!bitmapRect.IsEmpty)
                {
                    // Go through the draw area and set the pixels as they should be
                    for (int counter = 0; counter < bytes; counter += 4)
                    {
                        bitmapDataPtr[counter] = 0;         // Set Blue
                        bitmapDataPtr[counter + 1] = 0;     // Set Green
                        bitmapDataPtr[counter + 2] = 0;     // Set Red
                        bitmapDataPtr[counter + 3] = 255;   // Set Alpha
                    }
                }
            }

            // Unlock the bits from the bitmap from system memory.
            returnImage.UnlockBits(bitmapData);

            return returnImage;
        }
    }
}
