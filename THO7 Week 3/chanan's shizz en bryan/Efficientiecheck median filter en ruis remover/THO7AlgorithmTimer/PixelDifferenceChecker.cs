using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;


//Class: PixelDifferenceChecker
//
// This class is mainly for calculating the amount of salt and pepper noise in the filtered picture.
namespace THO7AlgorithmTimerApplication
{
    class PixelDifferenceChecker
    {
        //  Team 10
        //
		//  Authors:  
		//  Lars Veenendaal                     1633223
		//  lars.veenendaal@student.hu.nl       TIV-2A
		//
		//  Mitchell Werensteijn                1624291
		//  mitchell.werensteijn@student.hu.nl  TIV-2A
        //
        //  Bryan Baan                          1625054
        //  bryan.baan@student.hu.nl            TIV-2A
        //
        //  Chanan van Ooijen                   1611621
        //  chanan.vanooijen@student.hu.nl      TIV-2A

        //This is the main method that is used when the calculation has to take place.
        public String CheckDifferences(System.Drawing.Bitmap inputImage, System.Drawing.Bitmap outputImage, int noise)
        {
            String returnString = "";

            // The width of the image
            int WIDTH = inputImage.Width;

            // The height of the image
            int HEIGHT = inputImage.Height;

            // Amount of pixels we have added salt&pepper noise
            int test = (((WIDTH * HEIGHT) / 100) * noise);

            // Amount unchanged pixels after median filter
            int unChanged = 0;

            // This for loop will walk through all pixels (the pixels we added salt&pepper noise) and checks if color is still black or white
            // If yes, noise isn't gone, if no , noise is gone
            for (int i = 0; i < test; i++)
            {
                if (inputImage.GetPixel(SaltPepper.array2D[i, 0], SaltPepper.array2D[i, 1]).B <= 15 && outputImage.GetPixel(SaltPepper.array2D[i, 0]
                    , SaltPepper.array2D[i, 1]).B <= 15 && inputImage.GetPixel(SaltPepper.array2D[i, 0], SaltPepper.array2D[i, 1]).G <= 15 && outputImage.GetPixel(SaltPepper.array2D[i, 0]
                    , SaltPepper.array2D[i, 1]).G <= 15 && inputImage.GetPixel(SaltPepper.array2D[i, 0], SaltPepper.array2D[i, 1]).R <= 15 && outputImage.GetPixel(SaltPepper.array2D[i, 0]
                    , SaltPepper.array2D[i, 1]).R <= 15)
                {
                    unChanged += 1;
                }
                if (inputImage.GetPixel(SaltPepper.array2D[i, 0], SaltPepper.array2D[i, 1]).B >= 240 && outputImage.GetPixel(SaltPepper.array2D[i, 0]
                    , SaltPepper.array2D[i, 1]).B >= 240 && inputImage.GetPixel(SaltPepper.array2D[i, 0], SaltPepper.array2D[i, 1]).G >= 240 && outputImage.GetPixel(SaltPepper.array2D[i, 0]
                    , SaltPepper.array2D[i, 1]).G >= 240 && inputImage.GetPixel(SaltPepper.array2D[i, 0], SaltPepper.array2D[i, 1]).R >= 240 && outputImage.GetPixel(SaltPepper.array2D[i, 0]
                    , SaltPepper.array2D[i, 1]).R >= 240)
                {
                    unChanged += 1;
                } 
            }
            double percentOut = 0;

            // Calculate the percantage how effective the median filter is
            percentOut = ((double)unChanged / (double)test) * 100;

            returnString = "Percentage noise in new picture: " + percentOut + " percent.";

            return returnString;
        }
    }
}
