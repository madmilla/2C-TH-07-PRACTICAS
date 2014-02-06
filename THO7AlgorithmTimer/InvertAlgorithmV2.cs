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

            int bytes = Math.Abs(bitmapData.Stride) * bitmapData.Height;

            int stride = bitmapData.Stride;
            // Set RGB to 0.   
            unsafe
            {
                byte* ptr = (byte*)bitmapData.Scan0;
                // Check this is not a null area
               
                // Go through the draw area and set the pixels as they should be
                for (int counter = 0; counter < bytes; counter += 4)
                {
                    ptr[counter] = (byte) (255 - ptr[counter]);
                    ptr[counter + 1] = (byte)(255 - ptr[counter + 1]);
                    ptr[counter + 2] = (byte)(255 - ptr[counter + 2]);
                }
            }
            
            // Unlock the bits from the bitmap from system memory.
            returnImage.UnlockBits(bitmapData);

            return returnImage;
        }
    }
}
