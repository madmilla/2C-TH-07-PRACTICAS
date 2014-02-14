using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace THO7AlgorithmTimerApplication
{
    class MedianFilterAlgorithmV2 : VisionAlgorithm
    {
        int maskSize; // Size of the mask

        //  Authors:  
        //  Mitchell Werensteijn                1624291
        //  mitchell.werensteijn@student.hu.nl  TIV-2A
        public MedianFilterAlgorithmV2(String name, int m) : base(name) { maskSize = m; }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            Bitmap returnImage = new Bitmap(sourceImage);

            // Save the size from the bitmap in a rectangle at position 0,0.
            Rectangle bitmapRect = new Rectangle(new Point(0, 0), returnImage.Size);

            // Lock the bits from the bitmap in system memory.
            BitmapData bitmapData = returnImage.LockBits(bitmapRect, System.Drawing.Imaging.ImageLockMode.WriteOnly, returnImage.PixelFormat);

            // Calculate the amount of pixels needed to be set.
            int bytes = Math.Abs(bitmapData.Stride) * bitmapData.Height;

            byte[] oldValues = new byte[bytes];
            byte[] newValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, oldValues, 0, bytes);
            System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, newValues, 0, bytes);

            // Set unsafe context (Check out : http://msdn.microsoft.com/en-us/library/chfa2zb8.aspx)
            unsafe
            {
                // Create a pointer to go through the bitmapData.
                byte* bitmapDataPtr = (byte*)bitmapData.Scan0;

                // Source: http://www.gutgames.com/post/Noise-Reduction-of-an-Image-in-C-using-Median-Filters.aspx
                int maskMin = -(maskSize / 2); // Minimum pixel index of the mask
                int maskMax = (maskSize / 2);  // Maximum pixel index of the mask

                // For each pixel in the bitmap.
                for (int x = 0; x < returnImage.Width; ++x)
                {
                    for (int y = 0; y < returnImage.Height; ++y)
                    {
                        // All red values from the mask.
                        List<int> redValues = new List<int>();
                        // All green values from the mask.
                        List<int> greenValues = new List<int>();
                        // All blue values from the mask.
                        List<int> blueValues = new List<int>();

                        // For each row in the mask.
                        for (int maskX = maskMin; maskX < maskMax; ++maskX)
                        {
                            // Index of the pixel.
                            int TempX = x + maskX;

                            // Don't change the pixels in the edges.
                            if (TempX >= 0 && TempX < returnImage.Width)
                            {
                                // For each pixel in the row.
                                for (int maskY = maskMin; maskY < maskMax; ++maskY)
                                {
                                    // Index of the pixel.
                                    int TempY = y + maskY;

                                    // Don't change the pixels in the edges.
                                    if (TempY >= 0 && TempY < returnImage.Height)
                                    {
                                        int position = TempY * bitmapData.Stride + (TempX * 4);

                                        // Add the colors to the lists.
                                        redValues.Add(oldValues[position]);
                                        greenValues.Add(oldValues[position + 1]);
                                        blueValues.Add(oldValues[position + 2]);
                                    }
                                }
                            }
                        }

                        // Sort the list with a built-in function.
                        redValues.Sort();
                        greenValues.Sort();
                        blueValues.Sort();
                        // --------------------------------------------------------------------
                        int pos = y * bitmapData.Stride + (x * 4);
                        newValues[pos] = (byte) redValues[redValues.Count / 2];
                        newValues[pos + 1] = (byte)greenValues[redValues.Count / 2];
                        newValues[pos + 2] = (byte)blueValues[redValues.Count / 2];
                    }
                }
            }

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(newValues, 0, bitmapData.Scan0, bytes);

            returnImage.UnlockBits(bitmapData);

            return returnImage;
        }
    }
}
