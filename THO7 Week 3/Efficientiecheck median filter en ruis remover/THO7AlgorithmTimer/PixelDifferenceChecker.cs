using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

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

        public String CheckDifferences(System.Drawing.Bitmap inputImage, System.Drawing.Bitmap noisedImage, System.Drawing.Bitmap outputImage)
        {
            String returnString = "";
            double inWhite = 0;
            double inBlack = 0;
            double noiseWhite = 0;
            double noiseBlack = 0;
            double outWhite = 0;
            double outBlack = 0;

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
                    if (noisedImage.GetPixel(x, y).B >= 240 && noisedImage.GetPixel(x, y).G >= 240 && noisedImage.GetPixel(x, y).R >= 240)
                    {
                        noiseWhite++;
                    }
                    else if (noisedImage.GetPixel(x, y).B <= 15 && noisedImage.GetPixel(x, y).G <= 15 && noisedImage.GetPixel(x, y).R <= 15)
                    {
                        noiseBlack++;
                    }
                    
                }
            }

            double inputNoise = inBlack + inWhite;          // 40
            double noiseNoise = noiseBlack + noiseWhite;    // 80
            double outputNoise = outBlack + outWhite;       // 20

            double totalNoise = noiseNoise - inputNoise;    // 40

            double percentOut = outputNoise / totalNoise * 100 - 100;
            
            returnString = "Noise removed: " + Math.Abs(Math.Round(percentOut, 4)) + "%.";
            
            return returnString;
        }
    }
}
