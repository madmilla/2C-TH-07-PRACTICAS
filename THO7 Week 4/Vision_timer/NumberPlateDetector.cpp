#include "NumberPlateDetector.h"

using namespace std;
NumberPlateDetector::NumberPlateDetector() {
	bt = new BaseTimer();
}

NumberPlateDetector::~NumberPlateDetector() {
	delete bt;
}

void NumberPlateDetector::CreateNumberPlateImage(Image &sourceImage, Image &destinationImage) {
	bt->reset();
	bt->start();

	if (remove("histogram.csv") != 0)
		perror("Error deleting file");
	else
		puts("File successfully deleted");

	int* window;
	int imageHeight = sourceImage.GetHeight();
	int imageWidth = sourceImage.GetWidth();
	int totalPixels = imageWidth * imageHeight;
	int normalize = 0;
	ofstream histogramFile;
	histogramFile.open("histogram.csv", ios::out);

	window = (int *)malloc(sizeof(int)* imageHeight);
	int pixel = 0;
	int before = 0;
	int after = 0;
	std::cout << imageHeight << std::endl;
	std::cout << imageWidth << std::endl;

	for (int i = 0; i < imageHeight; i++){
		window[i] = 0;
	}

	for (int y = 1; y < sourceImage.GetHeight() - 1; y++) {
		for (int x = 1; x < sourceImage.GetWidth() - 1; x++) {
			
			before = sourceImage.GetPixelRed(x - 1, y);
			pixel = sourceImage.GetPixelRed(x, y);
			//after = sourceImage.GetPixelRed(x + 1, y);

			//std::cout << "Temp value: " << temp << std::endl;
			//std::cout << "Pixel value: " << pixel << std::endl;
			if ((before >= 0 && before <= 15) && (pixel >= 240 && pixel <= 255) /*&& (after >= 0 && after <= 15)*/) {
				window[y]++;
				//std::cout << "window[" << y << "] is plussed."<< std::endl;
			}
			else if ((before >= 240 && before <= 255) && (pixel >= 0 && pixel <= 15) /*&& (after >= 240 && after <= 255)*/) {
				window[y]++;
			}

			
			//std::cout << "x: " << x << std::endl;
			//std::cin.ignore();
		}
		
	}
	for (int i = 0; i < imageHeight; i++){
		histogramFile /*<< i << "," */<< (window[i]) << endl;
	}
	//std::cout << window << std::endl;
	//This piece of code represents the fact that you release the memory used for the array.
	//free(window);

	bt->stop();
	std::cout << "Time for the NumberPlateDetector function: " << bt->elapsedMicroSeconds() << " Microseconds (" << bt->elapsedMilliSeconds() << "ms)" << std::endl;

}
