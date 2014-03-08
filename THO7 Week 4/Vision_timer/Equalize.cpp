#include "Equalize.h"
//#define redPixel 24
//#define greenPixel 16
//#define bluePixel 8
//#define alphaPixel 0
using namespace std;
Equalize::Equalize() {
	bt = new BaseTimer();
}


Equalize::~Equalize() {
	delete bt;
}

void Equalize::CreateEqualizedImage(Image &sourceImage, Image &destinationImage) {
	bt->reset();
	bt->start();

	int height = sourceImage.GetHeight();
	int width = sourceImage.GetWidth();
	int totalPixels = height * width;
	int pixelValue = 0;

	ofstream histogramFile;
	ofstream equalized_histogramfile;
	histogramFile.open("histogram_to_be_equalized.csv", ios::out);
	equalized_histogramfile.open("Equalized_histogram.csv", ios::out);

	float alpha = 255 / float(totalPixels);
	float equalized_histogram_array[256];
	float histogram_array[256];

	//The next three for lusses are the creation of the histogram_to_be_equalized.
	for (int i = 0; i < 256; i++){
		histogram_array[i] = 0;
	}
	for (int i = 0; i < width; i++) {
		//cout << WIDTH << endl;
		for (int j = 0; j < height; j++) {
			//cout << HEIGHT << endl;
			pixelValue = sourceImage.GetPixelRed(i, j);
			histogram_array[pixelValue] ++;
		}
	}
	for (int i = 0; i < 256; i++){
		histogramFile << i << std::endl;
	}
	//Here ends the creation.

	//Equalization part.
	equalized_histogram_array[0] = histogram_array[0] * alpha;

	for (int i = 1; i < 256; i++){
		equalized_histogram_array[i] = equalized_histogram_array[i - 1] + (histogram_array[i] * alpha);
		equalized_histogramfile << equalized_histogram_array[i] << endl;
	}

	/*for (int i = 0; i < width; i++) {
		for (int j = 0; j < height; j++) {
			pixelValue = sourceImage.GetPixelRed(i,j); //FreeImage_GetPixelColor(equalized_picture, i, j, &colorr);
			colorr.rgbRed = colorr.rgbGreen = colorr.rgbBlue = equalized_histogram_array[colorr.rgbRed];
			FreeImage_SetPixelColor(equalized_picture, i, j, &colorr);
		}
	}*/

	

	for (int i = 0; i < width; i++) {
		for (int j = 0; j < height; j++) {
			pixelValue = sourceImage.GetPixelRed(i, j);
			destinationImage.SetPixel(i, j, ((int)equalized_histogram_array[pixelValue] << redPixelShift) | ((int)equalized_histogram_array[pixelValue] << greenPixelShift) | ((int)equalized_histogram_array[pixelValue] << bluePixelShift));
		}
	}

	//end of equalization part

	bt->stop();
	std::cout << "Time for the Equalize function: " << bt->elapsedMicroSeconds() << " Microseconds (" << bt->elapsedMilliSeconds() << "ms)" << std::endl;
}
