#include "exectimer.h"
#include <iostream>
#include <stdio.h>
#include <string>
#include "Image.h"
#include "GrayScale.h"
#include "MedianFilter.h"
#include "SobelFilter.h"
#include "Threshold.h"
#include "NumberPlateDetector.h"
#include "Equalize.h"
#include "Histogram.h"
#include "XMLReader.h"
#include "BinaryYellow.h"
#include "LineDetection.h"


//AUTHOR Bryan Baan, Chanan van Ooijen, Yusuf Syakur, Lars Veenendaal & Mitchell Werensteijn
int main(int argc, char** argv) {


	XMLReader xml;
	//xml.DisplayTestSamples();
	std::string testxml("../Images/THO7_wk4_testset/testsamples.xml");
	std::string testxml_ex("../Images/THO7_wk4_testset_EX/testsamples_ex.xml");
	std::string testImage("license_plate_1.jpg");
	std::string currentlySelectedXML = testxml;
	std::string * testArray = xml.CreateArrayOfFilenames(currentlySelectedXML);


	/*=========================     Program parameters     =========================*/

//	std::string inputName = "LenaNoise.jpg";
//	std::string inputName = "Lena.bmp";
//	std::string inputName = "flower.jpg";
//	std::string inputName = "Knikker.bmp";
//	std::string inputName = "TestImage.bmp";
//	std::string inputName = "Busjes.jpg";
//	std::string inputName = "BusjesGroot.jpg";
//	std::string inputName = "Waterfall.jpg";
//	std::string inputName = "license_plate_11.jpg";
//	std::string inputName = "license_plate_ex_4.png";


	/*=========================     Program parameters     =========================*/

	/* RUN THE TESTS */
	int len = 0;
	while (testArray[len] != "\0") {
		len++;
	}

	for (int i = 0; i < len; i++){

		/* =============================================================
							BINARY YELLOW ALGORITHM

					Replace everything in this loop to have it
					applied to all the images in the xml.
		================================================================*/

		// 1. Input of original RGB image
		// 2. Yellow Regions
		// 3. Edge Detections
		// 4. Morphological operation
		// 5. Extraction of the plate region 

		std::string inputName = testArray[i];

		
		//Read the chosen file
		
		if (argv[1] != nullptr) {
			inputName = argv[1];
			std::cout << "File is: " << inputName << "\n\n";
		}
		else {
			std::cout << "File is: " << inputName << "\n\n";
		}


		//Load the image in the Image class
		Image originalImage(inputName);

		Image BinaryYellowImage(originalImage);
		BinaryYellow yellow;
		yellow.CreateBinaryImage(originalImage, BinaryYellowImage);
		BinaryYellowImage.SaveImageToFile("BY_");
		std::cout << std::endl;

		Image MedianImage(originalImage);
		MedianFilter median;
		median.CreateMedianFilterImage(BinaryYellowImage, MedianImage, 11);
		MedianImage.SaveImageToFile("MEDIAN_");
		std::cout << std::endl;

		Histogram histogram;
		histogram.CreateHistogramX(MedianImage);
		histogram.CreateHistogramY(MedianImage);
		std::cout << std::endl;

		Image LineImage(MedianImage);
		LineDetection line;
		line.CreateLineDetectionImage(MedianImage, LineImage);
		LineImage.SaveImageToFile("LINE_");
		std::cout << std::endl;

		histogram.CreateHistogramX(LineImage);
		histogram.CreateHistogramY(LineImage);
		std::cout << std::endl;

		//This data will overwrite the "LINE_" image.
		int result_array[4][2];
		line.DetermineCornerPoints(LineImage, result_array);
		std::cout << " ======= CHECKING =============  " << std::endl;
		//	XMLReader results;
		xml.CheckFoundValuesAgainstTheXMLValues(currentlySelectedXML, inputName, result_array[0][0], result_array[0][1], result_array[1][0], result_array[1][1], result_array[2][0], result_array[2][1], result_array[3][0], result_array[3][1]);
		std::cout << " ======= END CHECKING ========= " << std::endl;

		//Save the original image
		originalImage.SaveImageToFile("ORIGINAL_");
		std::cout << std::endl;

	}

		//for (int i = 0; i < len; i++){

		/* =============================================================
		Not named ALGORITHM

		Note: How do we want to change algorithmes?

		Replace everything in this loop to have it
		applied to all the images in the xml.
		================================================================*/

		// 1. Input of original RGB image
		// 2. Filter noise
		// 3. Threshold the image
		// 4. Edge detection
		// 5. Extraction of the plate region 

		/*std::string inputName = testArray[i];

		
		//Read the chosen file
		
		if (argv[1] != nullptr) {
			inputName = argv[1];
			std::cout << "File is: " << inputName << "\n\n";
		}
		else {
			std::cout << "File is: " << inputName << "\n\n";
		}


		//Load the image in the Image class
		Image originalImage(inputName);


		Image grayImage(originalImage);
		GrayScale gray;
		gray.CreateGrayScaleImage(originalImage, grayImage);
		grayImage.SaveImageToFile("GRAY_");
		std::cout << std::endl;

		Image medianImage(originalImage);
		MedianFilter median;
		median.CreateMedianFilterImage(grayImage, medianImage, 9);
		medianImage.SaveImageToFile("MEDIAN_");
		std::cout << std::endl;

		Image thresholdImage(originalImage);
		Threshold thresh;
		thresh.CreateThresholdImage(medianImage, thresholdImage);
		thresholdImage.SaveImageToFile("THRESHOLD_");
		std::cout << std::endl;

		Image sobelImage(originalImage);
		SobelFilter sobel;
		sobel.CreateSobelImage(thresholdImage, sobelImage);
		sobelImage.SaveImageToFile("SOBEL_");
		std::cout << std::endl;

		Histogram histogram;
		histogram.CreateHistogramX(sobelImage);
		histogram.CreateHistogramY(sobelImage);
		std::cout << std::endl;

		//Save the original image
		originalImage.SaveImageToFile("ORIGINAL_");
		std::cout << std::endl;
		*/
	delete[] testArray;

	std::cout << "Program ended, Press a key to continue\n";
	std::cin.ignore();
	return 0;
}


