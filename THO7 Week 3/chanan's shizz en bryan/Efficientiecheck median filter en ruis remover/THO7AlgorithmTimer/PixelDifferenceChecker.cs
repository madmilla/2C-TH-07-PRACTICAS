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
        public String CheckDifferences(System.Drawing.Bitmap inputImage, System.Drawing.Bitmap outputImage)
        {
            String returnString = "";
            
            //These doubles represent the amount of ~white and ~black pixels in the new and old picture
            double inWhite = 0;
            double inBlack = 0;
            double outWhite = 0;
            double outBlack = 0;

            //These for loops will be used to run through the picture and check wether a pixel is black or white.
            //If a pixel is black or white, a counter will be incremented depending on what picture the algorithm found the pixel on.
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    if (inputImage.GetPixel(x, y).B >= 240 && inputImage.GetPixel(x, y).G >= 240 && inputImage.GetPixel(x, y).R >= 240)
                    {
                        inWhite++; 
                    } 
                    else if (inputImage.GetPixel(x, y).B <= 15 && inputImage.GetPixel(x, y).G <= 15 && inputImage.GetPixel(x, y).R <= 15)
                    {
                        inBlack++;
                    }
                    if (outputImage.GetPixel(x, y).B >= 240 && outputImage.GetPixel(x, y).G >= 240 && outputImage.GetPixel(x, y).R >= 240)
                    {
                        outWhite++;
                    } 
                    else if (outputImage.GetPixel(x, y).B <= 15 && outputImage.GetPixel(x, y).G <= 15 && outputImage.GetPixel(x, y).R <= 15)
                    {
                        outBlack++;
                    }
                    
                }
            }
            //The following two doubles are the amount of white / black pixels in the input and output image
            double pixelOutput = outWhite + outBlack;
            double pixelInput = inWhite + inBlack;
            
            double percentOut = 0;

            //In this if statement the percentOut will be the percentage of noise (salt & pepper) left in the pixel after going through a filter
            if (pixelOutput != 0 || pixelInput != 0)
            {
                percentOut = pixelOutput / pixelInput * 100;
            }

            returnString = "Percentage noise in new picture: " + percentOut + " percent.";

            return returnString;
        }
    }
}
