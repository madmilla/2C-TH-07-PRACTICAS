#include "MedianFilter.h"

MedianFilter::MedianFilter() {
	bt = new BaseTimer();
}


MedianFilter::~MedianFilter() {
	delete bt;
}
/* OLD  - 2AM versie samenvoeging.

*/
void MedianFilter::CreateMedianImage(Image &sourceImage, Image &destinationImage) {
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
	/*
	int grayValue;

	for (int y = sourceImage.GetHeight() - 1; y >= 0; y--) {
	for (int x = sourceImage.GetWidth() - 1; x >= 0; x--) {
	grayValue = (int)((sourceImage.GetPixelRed(x, y) * 0.30) + (sourceImage.GetPixelGreen(x, y) * 0.59) + (sourceImage.GetPixelBlue(x, y) * 0.11));
	destinationImage.SetPixel(x, y, (grayValue << redPixelShift) | (grayValue << greenPixelShift) | (grayValue << bluePixelShift));
	}
	}
	*/

	//int k;
	BYTE window[9][3];
	BYTE sortArray[9][3];
	for (int y = 1; y < srcHeight - 1; y++) {
		for (int x = 1; x < srcWidth - 1; x++) {
			window[0][0] = sourceImage.GetPixelRed(x - 1, y - 1);
			window[0][1] = sourceImage.GetPixelGreen(x - 1, y - 1);
			window[0][2] = sourceImage.GetPixelBlue(x - 1, y - 1);

			window[1][0] = sourceImage.GetPixelRed(x, y - 1);
			window[1][1] = sourceImage.GetPixelGreen(x, y - 1);
			window[1][2] = sourceImage.GetPixelBlue(x, y - 1);

			window[2][0] = sourceImage.GetPixelRed(x + 1, y - 1);
			window[2][1] = sourceImage.GetPixelGreen(x + 1, y - 1);
			window[2][2] = sourceImage.GetPixelBlue(x + 1, y - 1);

			window[3][0] = sourceImage.GetPixelRed(x - 1, y);
			window[3][1] = sourceImage.GetPixelGreen(x - 1, y);
			window[3][2] = sourceImage.GetPixelBlue(x - 1, y);

			window[4][0] = sourceImage.GetPixelRed(x, y);
			window[4][1] = sourceImage.GetPixelGreen(x, y);
			window[4][2] = sourceImage.GetPixelBlue(x, y);

			window[5][0] = sourceImage.GetPixelRed(x + 1, y);
			window[5][1] = sourceImage.GetPixelGreen(x + 1, y);
			window[5][2] = sourceImage.GetPixelBlue(x + 1, y);

			window[6][0] = sourceImage.GetPixelRed(x - 1, y + 1);
			window[6][1] = sourceImage.GetPixelGreen(x - 1, y + 1);
			window[6][2] = sourceImage.GetPixelBlue(x - 1, y + 1);

			window[7][0] = sourceImage.GetPixelRed(x, y + 1);
			window[7][1] = sourceImage.GetPixelGreen(x, y + 1);
			window[7][2] = sourceImage.GetPixelBlue(x, y + 1);

			window[8][0] = sourceImage.GetPixelRed(x + 1, y + 1);
			window[8][1] = sourceImage.GetPixelGreen(x + 1, y + 1);
			window[8][2] = sourceImage.GetPixelBlue(x + 1, y + 1);

			BYTE temp[3];
			for (int index = 0; index < 9; index++) {
				temp[0] = window[index][0];
				temp[1] = window[index][1];
				temp[2] = window[index][2];
				BYTE tempAlles = temp[0] + temp[1] + temp[2];
				BYTE windowAlles = window[index - 1][0] + window[index - 1][1] + window[index - 1][2];
				while ((index - 1 >= 0) && (tempAlles < windowAlles)) {
					window[index][0] = window[index - 1][0];
					window[index][1] = window[index - 1][1];
					window[index][2] = window[index - 1][2];
					index--;
				}
				window[index][0] = temp[0];
				window[index][1] = temp[1];
				window[index][2] = temp[2];
			}

			//window[4][0] + window[4][1] + window[4][2] is wat je moet hebben.
			destinationImage.SetPixel(x, y, window[4][0] << redPixelShift | window[4][1] << greenPixelShift | window[4][2] << bluePixelShift);
			//FreeImage_SetPixelColor(filtered, i, j, &color);

		}
	}

	bt->stop();
	std::cout << "Time for the Median filter function: " << bt->elapsedMicroSeconds() << " Microseconds (" << bt->elapsedMilliSeconds() << "ms)" << std::endl;
}

void MedianFilter::CreateMedianFilterImage(Image &sourceImage, Image &destinationImage, int size) {
	bt->reset();
	bt->start();

	int medianSize = size;
	int doubleSize = size*size;
	int halfSize = size / 2;

	int median = 0;
	int temp = 0;

	//Initializing the primary array, where all the pixelvalues will be stored.
	int* window;
	window = (int *)malloc(sizeof(int)* doubleSize);

	//Two for lusses for the coordinates of the pixels.
	int k = 0;
	for (int x = halfSize; x < sourceImage.GetWidth() - halfSize; x++) {
		for (int y = halfSize; y < sourceImage.GetHeight() - halfSize; y++) {
			//std::cout << "asdf" << std::endl;
			//Now we create another two for lusses for the dimensions of the array
			for (int newX = (x - halfSize); newX < (x + halfSize); newX++) {
				for (int newY = (y - halfSize); newY < (y + halfSize); newY++) {
					window[k] = sourceImage.GetPixelRed(newX, newY);
					k++;
				}
			}
			

			for (int index = 0; index < doubleSize; index++) {
				temp = window[index];
				//Grootste waarde wordt de hoogste waarde in de array
				while ((index - 1 >= 0) && (temp < window[index - 1])) {
					window[index] = window[index - 1];
					index--;
				}
				window[index] = temp;
			}
			median = window[doubleSize / 2];
			destinationImage.SetPixel(x, y, median << redPixelShift | median << greenPixelShift | median << bluePixelShift);

			k = 0;
			temp = 0;
		}
	}
	bt->stop();
	std::cout << "Time for the Median filter function: " << bt->elapsedMicroSeconds() << " Microseconds (" << bt->elapsedMilliSeconds() << "ms)" << std::endl;
}


//Double array creator (variable size)
/*int** window = new int*[doubleSize];
	for (int i = 0; i < doubleSize; i++) {
		//This new integer has 3 values (R,G,B)
		window[i] = new int[3];
	}
	for (int i = 0; i < doubleSize; i++) {
		for (int j = 0; j < 3; j++) {
			window[i][j] = 0;
		}
		}*/