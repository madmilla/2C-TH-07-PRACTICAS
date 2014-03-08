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

int main(int argc, char** argv) {
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
	std::string inputName = "license_plate_ex_4.png";

	bool grayOn = true;
	

	/*=========================     Program parameters     =========================*/

	/*
	Read the chosen file
	*/
	if(argv[1] != nullptr) {
		inputName = argv[1];
		std::cout << "File is: " << inputName << "\n\n";
	} else {
		std::cout << "File is: " << inputName << "\n\n";
	}

	//Load the image in the Image class
	Image originalImage(inputName);

	//Filter image with grayscale
	if(grayOn) {
		Image grayImage(originalImage);
		GrayScale gray;
		gray.CreateGrayScaleImage(originalImage, grayImage);
		grayImage.SaveImageToFile("GRAY_");
		std::cout << std::endl;

		Image medianImage(originalImage);
		MedianFilter median;
		median.CreateMedianFilterImage(grayImage, medianImage, 21);
		medianImage.SaveImageToFile("MEDIAN_");
		std::cout << std::endl;

		//Equalize seems to add more noise (white pixels) to the thresholded image.
		//This is why we did not add this algorithm. But it might be usefull at a later stage.
		/*Image equalizeImage(originalImage);
		Equalize equal;
		equal.CreateEqualizedImage(medianImage, equalizeImage);
		equalizeImage.SaveImageToFile("EQUAL_");
		std::cout << std::endl;*/

		Image thresholdImage(originalImage);
		Threshold thresh;
		thresh.CreateThresholdImage(medianImage, thresholdImage);
		thresholdImage.SaveImageToFile("THRESHOLD_");
		std::cout << std::endl;

		//Sobel image did not seem to do its work.
		/*Image sobelImage(originalImage);
		SobelFilter sobel;
		sobel.CreateSobelImage(thresholdImage, sobelImage);
		sobelImage.SaveImageToFile("SOBEL_");
		std::cout << std::endl;*/

		Histogram histogram;
		histogram.CreateHistogramY(thresholdImage);
		histogram.CreateHistogramX(thresholdImage);
		std::cout << std::endl;

		
	}

	//Save the original image
	originalImage.SaveImageToFile("ORIGINAL_");
	std::cout << std::endl;

	//End program
	std::cout << "Program ended, Press a key to continue\n";
	std::cin.ignore();
	return 0;
}


