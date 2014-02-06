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
        public BlackAlgorithmV3(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            // Bronnen:  
            // http://msdn.microsoft.com/en-us/library/5ey6h79d(v=vs.110).aspx

            Bitmap returnImage = new Bitmap(sourceImage);
            
            // Save the size from the bitmap in a rectangle at position 0,0.
            Rectangle bitmapRect = new Rectangle(new Point(0,0), returnImage.Size);
            
            // Lock the bits from the bitmap in system memory.
            BitmapData bitmapData = returnImage.LockBits(new Rectangle(0, 0, returnImage.Width, returnImage.Height), ImageLockMode.WriteOnly, returnImage.PixelFormat);

            // Set RGB to 0.   
            unsafe
            {
                byte* ptr = (byte*)bitmapData.Scan0;
                // Check this is not a null area
                if (!bitmapRect.IsEmpty)
                {
                    // Go through the draw area and set the pixels as they should be
                    for (int y = bitmapRect.Top; y < bitmapRect.Bottom; y++)
                    {
                        for (int x = bitmapRect.Left; x < bitmapRect.Right; x++)
                        {
                            // layer.GetBitmap().SetPixel(x, y, m_colour);
                            ptr[(x * 4) + y * bitmapData.Stride] = 0;
                            ptr[(x * 4) + y * bitmapData.Stride + 1] = 0;
                            ptr[(x * 4) + y * bitmapData.Stride + 2] = 0;
                            ptr[(x * 4) + y * bitmapData.Stride + 3] = 255;
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
