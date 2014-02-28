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
            uint inputImageWhitePixels = 0;
            uint inputImageBlackPixels = 0;

            //The second two doubles represent the amount of white and black pixels in he noised picture (the input picture with added noise
            //which cannot be seen in the GUI if you also choose to filter it)
            uint noisedImageWhitePixels = 0;
            uint noisedImageBlackPixels = 0;

            //The third set of doubles represent the amount of white and black pixels in the output picture (this can be a noised image if no
            //filter was chosen, but it can also be a noised picture which has been filtered if a filter was chosen)
            uint outputImageWhitePixels = 0;
            uint outputImageBlackPixels = 0;

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
            System.Console.WriteLine("BW " + inputImageBlackPixels + " W " + inputImageWhitePixels);
            double inputImageTotalNoise = inputImageBlackPixels + inputImageWhitePixels;          // 40
            double noisedImageTotalNoise = noisedImageBlackPixels + noisedImageWhitePixels;    // 80
            double outputImageTotalNoise = outputImageBlackPixels + outputImageWhitePixels;       // 20
            double overflow = 0;

            bool WhiteInputVNoise = (noisedImageWhitePixels > inputImageWhitePixels) ? true : false;
            bool BlackInputVNoise = (noisedImageBlackPixels > inputImageBlackPixels) ? true : false;
            bool WhiteInputVOutput = (outputImageWhitePixels > inputImageWhitePixels) ? true : false;
            bool BlackInputVOutput = (outputImageBlackPixels > inputImageBlackPixels) ? true : false;

            double DifferenceWhiteInputVnoise = (noisedImageWhitePixels > inputImageWhitePixels) ? noisedImageWhitePixels - inputImageWhitePixels : inputImageWhitePixels - noisedImageWhitePixels;
            double DifferenceBlackInputVnoise = (noisedImageBlackPixels > inputImageBlackPixels) ? noisedImageBlackPixels - inputImageBlackPixels : inputImageBlackPixels - noisedImageBlackPixels;

            double DifferenceWhiteInputVOutput = (outputImageWhitePixels > inputImageWhitePixels) ? outputImageWhitePixels - inputImageWhitePixels : inputImageWhitePixels - outputImageWhitePixels;
            double DifferenceBlackInputVOutput = (outputImageBlackPixels > inputImageBlackPixels) ? outputImageBlackPixels - inputImageBlackPixels : inputImageBlackPixels - outputImageBlackPixels;
            
            
            

            if (WhiteInputVNoise == false)
            {
                System.Console.WriteLine("Te weinig wit (NA NOISE) in het plaatje");
            }
            if (BlackInputVNoise == false)
            {
                System.Console.WriteLine("Te weinig zwart (NA NOISE) in het plaatje");
            }
            if (WhiteInputVOutput == false)
            {
                System.Console.WriteLine("Te weinig wit (NA OUTPUT) in het plaatje");
            }
            if (BlackInputVOutput == false)
            {
                System.Console.WriteLine("Te weinig zwart (NA OUTPUT) in het plaatje. # " + DifferenceBlackInputVOutput + " OIBP " + outputImageBlackPixels + " IIBP " + inputImageBlackPixels);
                overflow += DifferenceBlackInputVOutput;
                inputImageTotalNoise -= DifferenceBlackInputVOutput;

            }
            System.Console.WriteLine("IWV: " + inputImageWhitePixels + " IBV: " + inputImageBlackPixels);
            System.Console.WriteLine("WIV: " + noisedImageWhitePixels + " BIV: " + noisedImageBlackPixels);
            System.Console.WriteLine("WIO: " + outputImageWhitePixels + " BIO: " + outputImageBlackPixels);



             //   System.Console.WriteLine("Op de noise filter is minder zwart dan voorheen.");
            double totalNoise = (noisedImageTotalNoise - inputImageTotalNoise);

            
            // The total noise is the added noise only.
          
            System.Console.WriteLine("totalNoise: " + totalNoise);
            System.Console.WriteLine("Overflow: " + overflow);
            System.Console.WriteLine("IITN " + inputImageTotalNoise);
            System.Console.WriteLine("NITN " + (noisedImageTotalNoise - inputImageTotalNoise));
            System.Console.WriteLine("OITN " + (outputImageTotalNoise - inputImageTotalNoise));
            double pCent = (totalNoise / noisedImageTotalNoise)*100;
            System.Console.WriteLine("LARS PERCENT:" + pCent);


            Console.WriteLine(totalNoise);
            // Output percentage.
            double percentOut = outputImageTotalNoise / totalNoise * 100 - 100;
            Console.WriteLine(percentOut);

            return "Noise removed: " + Math.Abs(Math.Round(percentOut, 4)) + "%.";
        }
    }
}
