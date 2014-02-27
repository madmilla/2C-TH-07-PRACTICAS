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
        //
        //  Yusuf Syakur                        1633276
        //  yusuf.syakur@student.hu.nl          TIV-2A

        public String CheckDifferences(System.Drawing.Bitmap inputImage, System.Drawing.Bitmap noisedImage, System.Drawing.Bitmap outputImage)
        {
            //These doubles represent the amount of ~white and ~black pixels in the input, noised and output picture

            //The first two doubles represent the amount of white and black pixels in the input picture (loaded from a directory without
            //being filtered or added noise)
            double inputImageWhitePixels = 0;
            double inputImageBlackPixels = 0;

            //The second two doubles represent the amount of white and black pixels in he noised picture (the input picture with added noise
            //which cannot be seen in the GUI if you also choose to filter it)
            double noisedImageWhitePixels = 0;
            double noisedImageBlackPixels = 0;

            //The third set of doubles represent the amount of white and black pixels in the output picture (this can be a noised image if no
            //filter was chosen, but it can also be a noised picture which has been filtered if a filter was chosen)
            double outputImageWhitePixels = 0;
            double outputImageBlackPixels = 0;

            //These for loops will be used to run through the picture and check wether a pixel is black or white.
            //If a pixel is black or white, a counter will be incremented depending on what picture the algorithm found the pixel on.
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    if (inputImage.GetPixel(x, y).B >= 240 && inputImage.GetPixel(x, y).G >= 240 && inputImage.GetPixel(x, y).R >= 240)
                    {
                        inputImageWhitePixels++;
                    }
                    else if (inputImage.GetPixel(x, y).B <= 15 && inputImage.GetPixel(x, y).G <= 15 && inputImage.GetPixel(x, y).R <= 15)
                    {
                        inputImageBlackPixels++;
                    }
                    if (outputImage.GetPixel(x, y).B >= 240 && outputImage.GetPixel(x, y).G >= 240 && outputImage.GetPixel(x, y).R >= 240)
                    {
                        outputImageBlackPixels++;
                    }
                    else if (outputImage.GetPixel(x, y).B <= 15 && outputImage.GetPixel(x, y).G <= 15 && outputImage.GetPixel(x, y).R <= 15)
                    {
                        outputImageWhitePixels++;
                    }
                    if (noisedImage.GetPixel(x, y).B >= 240 && noisedImage.GetPixel(x, y).G >= 240 && noisedImage.GetPixel(x, y).R >= 240)
                    {
                        noisedImageWhitePixels++;
                    }
                    else if (noisedImage.GetPixel(x, y).B <= 15 && noisedImage.GetPixel(x, y).G <= 15 && noisedImage.GetPixel(x, y).R <= 15)
                    {
                        noisedImageBlackPixels++;
                    }
                }
            }

            // The following doubles are the amount of white / black pixels in the input, noised image and output image
            double inputImageTotalNoise = inputImageBlackPixels + inputImageWhitePixels;          // 40
            double noisedImageTotalNoise = noisedImageBlackPixels + noisedImageWhitePixels;    // 80
            double outputImageTotalNoise = outputImageBlackPixels + outputImageWhitePixels;       // 20

            // The total noise is the added noise only.
            double totalNoise = noisedImageTotalNoise - inputImageTotalNoise;

            Console.WriteLine(totalNoise);
            // Output percentage.
            double percentOut = outputImageTotalNoise / totalNoise * 100 - 100;
            Console.WriteLine(percentOut);

            return "Noise removed: " + Math.Abs(Math.Round(percentOut, 4)) + "%.";
        }
    }
}
