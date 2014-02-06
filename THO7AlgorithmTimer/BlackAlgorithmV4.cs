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
        public BlackAlgorithmV4(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            // Bronnen:  
            // http://msdn.microsoft.com/en-us/library/5ey6h79d(v=vs.110).aspx

            Bitmap returnImage = new Bitmap(sourceImage);

            // Save the size from the bitmap in a rectangle at position 0,0.
            Rectangle bitmapRect = new Rectangle(new Point(0,0), returnImage.Size);
            
            // Lock the bits from the bitmap in system memory.
            BitmapData bitmapData = returnImage.LockBits(new Rectangle(0, 0, returnImage.Width, returnImage.Height), ImageLockMode.WriteOnly, returnImage.PixelFormat);

            int bytes = Math.Abs(bitmapData.Stride) * bitmapData.Height;
            // Set RGB to 0.   
            unsafe
            {
                byte* ptr = (byte*)bitmapData.Scan0;
                // Check this is not a null area
                if (!bitmapRect.IsEmpty)
                {
                    // Go through the draw area and set the pixels as they should be
                    for (int counter = 0; counter < bytes; counter += 4)
                    {
                        ptr[counter] = 0;
                        ptr[counter + 1] = 0;
                        ptr[counter + 2] = 0;
                        ptr[counter + 3] = 255;
                    }
                }
            }

            // Unlock the bits from the bitmap from system memory.
            returnImage.UnlockBits(bitmapData);

            return returnImage;
        }
    }
}
