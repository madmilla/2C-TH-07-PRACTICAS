#include "Threshold.h"


Threshold::Threshold(){
	bt = new BaseTimer();
}


Threshold::~Threshold(){
	delete bt;
}

void Threshold::CreateThresholdImage(Image &sourceImage, Image &destinationImage) {
	bt->reset();
	bt->start();

	int srcHeight = sourceImage.GetHeight();
	int srcWidth = sourceImage.GetWidth();

	int dstHeight = destinationImage.GetHeight();
	int dstWidth = destinationImage.GetWidth();

	if (srcWidth != dstWidth && srcHeight != dstHeight) {
		std::cout << "Error images are not the same size" << std::endl;
		return;
	}

	//OTSU METHOD
	
	//Create histogram(Must be grayscaled!)
	float histogram[256];
	for (int i = 0; i < 256; i++) {
		histogram[i] = 0;
	}
	for (int yh = 0; yh < srcHeight; yh++) {
		for (int xh = 0; xh < srcWidth; xh++){
			histogram[sourceImage.GetPixelRed(xh, yh)] += 1.00f;
		}
	}

	//Normalize histogram values
	int maxHistogramIndex = 255;
	float histNormalized[256];
	int imageSize = srcHeight * srcWidth;
	for (int i = 1; i <= maxHistogramIndex; i++) {
		histNormalized[i - 1] = histogram[i - 1] / (float)imageSize;
	}

	//Calculate total mean level
	float totalMeanLevel = 0;
	for (int i = 1; i <= maxHistogramIndex; i++) {
		totalMeanLevel += i*histNormalized[i - 1];
	}

	//Find optimal threshold value
	float firstOrderCumulative = 0;
	float secondOrderCumulative = 0;
	float temp1, temp2;
	double temp3 = 0.0;
	for (int i = 1; i <= maxHistogramIndex; i++) {
		firstOrderCumulative += histNormalized[i - 1];
		secondOrderCumulative += i*histNormalized[i - 1];
		temp1 = (totalMeanLevel * firstOrderCumulative - secondOrderCumulative);
		temp2 = (temp1*temp1) / (firstOrderCumulative*(1.0f - firstOrderCumulative));
		if (temp2 > temp3) {
			temp3 = temp2;
		}
	}

	int threshold = (int)sqrt(temp3);
	std::cout << threshold << std::endl;
	
	//OTSU METHOD

	//THRESHOLD CODE
	for (int x = 0; x < dstWidth; x++){
		for (int y = 0; y < dstHeight; y++){
			if (sourceImage.GetPixelRed(x, y) > threshold) {
				destinationImage.SetPixel(x, y, 255 << redPixelShift | 255 << greenPixelShift | 255 << bluePixelShift);
			}
			else {
				destinationImage.SetPixel(x, y, 0 << redPixelShift | 0 << greenPixelShift | 0 << bluePixelShift);
			}
		}
	}
	//THRESHOLD CODE

	bt->stop();
	std::cout << "Time for the Threshold function: " << bt->elapsedMicroSeconds() << " Microseconds (" << bt->elapsedMilliSeconds() << "ms)" << std::endl;
}