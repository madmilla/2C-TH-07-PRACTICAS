using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace THO7AlgorithmTimerApplication
{
    class MedianFilterAlgorithmV1 : VisionAlgorithm
    {
        //  Team 10
        //
		//  Authors:  
		//  Lars Veenendaal                     1633223
		//  lars.veenendaal@student.hu.nl       TIV-2A
		//
		//  Mitchell Werensteijn                1624291
		//  mitchell.werensteijn@student.hu.nl  TIV-2A
        public MedianFilterAlgorithmV1(String name) : base(name) { }
        public override System.Drawing.Bitmap DoAlgorithm(System.Drawing.Bitmap sourceImage)
        {
            Bitmap returnImage = new Bitmap(sourceImage);

            // Size of the median filter
            int maskSize = 3;

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
                                    // Get the pixel color.
                                    Color TempColor = sourceImage.GetPixel(TempX, TempY);

                                    // Add the colors to the lists.
                                    redValues.Add(TempColor.R);
                                    greenValues.Add(TempColor.G);
                                    blueValues.Add(TempColor.B);
                                }
                            }
                        }
                    }

                    // Sort the list with a built-in function.
                    redValues.Sort();
                    greenValues.Sort();
                    blueValues.Sort();

                    // Create the new pixel.
                    Color MedianPixel = Color.FromArgb(redValues[redValues.Count / 2],
                                                     greenValues[greenValues.Count / 2],
                                                      blueValues[blueValues.Count / 2]);
                    returnImage.SetPixel(x, y, MedianPixel);
                }
            }

            return returnImage;
        }
    }
}
