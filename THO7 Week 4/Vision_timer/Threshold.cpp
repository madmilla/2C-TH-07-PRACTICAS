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

	int thresh = 125;

	int srcHeight = sourceImage.GetHeight();
	int srcWidth = sourceImage.GetWidth();

	int dstHeight = destinationImage.GetHeight();
	int dstWidth = destinationImage.GetWidth();

	if (srcWidth != dstWidth && srcHeight != dstHeight) {
		std::cout << "Error images are not the same size" << std::endl;
		return;
	}

	//THRESHOLD CODE
	for (int x = 0; x < dstWidth; x++){
		for (int y = 0; y < dstHeight; y++){
			if (sourceImage.GetPixel(x, y) < thresh) {
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