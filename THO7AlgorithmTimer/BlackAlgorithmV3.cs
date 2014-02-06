using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace THO7AlgorithmTimerApplication
{
    class BlackAlgorithmV3 : VisionAlgorithm
    {
        //  Authors:  
        //  Lars Veenendaal                     1633223
        //  lars.veenendaal@student.hu.nl       TIV-2A
        //
        //  Mitchell Werensteijn                1624291
        //  mitchell.werensteijn@student.hu.nl  TIV-2A
        public BlackAlgorithmV3(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            // Bronnen:  
            // http://msdn.microsoft.com/en-us/library/5ey6h79d(v=vs.110).aspx

            Bitmap returnImage = new Bitmap(sourceImage);
            
            // Save the size from the bitmap in a rectangle at position 0,0.
            Rectangle bitmapRect = new Rectangle(new Point(0,0), returnImage.Size);
            
            // Lock the bits from the bitmap in system memory.
            // Write only because we dont intent to read the bitmap.
            BitmapData bitmapData = returnImage.LockBits(new Rectangle(0, 0, returnImage.Width, returnImage.Height), ImageLockMode.WriteOnly, returnImage.PixelFormat);

            // Set unsafe context (Check out : http://msdn.microsoft.com/en-us/library/chfa2zb8.aspx)
            unsafe
            {
                // Create a pointer to go through the bitmapData.
                byte* bitmapDataPtr = (byte*)bitmapData.Scan0;

                // Check this is not a null area
                if (!bitmapRect.IsEmpty)
                {
                    // Go through the draw area and set the pixels as they should be
                    for (int y = bitmapRect.Top; y < bitmapRect.Bottom; y++)
                    {
                        for (int x = bitmapRect.Left; x < bitmapRect.Right; x++)
                        {
                            bitmapDataPtr[(x * 4) + y * bitmapData.Stride] = 0;       // Set Blue
                            bitmapDataPtr[(x * 4) + y * bitmapData.Stride + 1] = 0;   // Set Green
                            bitmapDataPtr[(x * 4) + y * bitmapData.Stride + 2] = 0;   // Set Red
                            bitmapDataPtr[(x * 4) + y * bitmapData.Stride + 3] = 255; // Set Alpha
                        }
                    }
                }
            }

            // Unlock the bits from the bitmap from system memory.
            returnImage.UnlockBits(bitmapData);

            return returnImage;
        }
    }
}
