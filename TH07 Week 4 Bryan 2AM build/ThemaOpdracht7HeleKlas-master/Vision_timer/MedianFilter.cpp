#include "MedianFilter.h"

MedianFilter::MedianFilter() {
	bt = new BaseTimer();
}
MedianFilter::~MedianFilter() {
	delete bt;
}
void MedianFilter::CreateMedianFilterImage(Image &sourceImage, Image &destinationImage, int size) {
	bt->reset();
	bt->start();

	int medianSize = size;
	int doubleSize = size*size;
	int halfSize = size / 2;

	//Initializing the primary array, where all the pixelvalues will be stored.
	BYTE** window = new BYTE*[doubleSize];
	for (int i = 0; i < doubleSize; i++) {
		//This new integer has 3 values (R,G,B)
		window[i] = new BYTE[3];
	} 
	for (int i = 0; i < doubleSize; i++) {
		for (int j = 0; j < 3; j++) {
			window[i][j] = 0;
		}
	}
	//We can now use the window array like this: window[1][3].

	//int window[3][3];
	//int sortArray[9][3];

	//Two for lusses for the coordinates of the pixels.
	int k = 0;
	for (int x = halfSize; x < sourceImage.GetWidth() - halfSize; x++) {
		for (int y = halfSize; y < sourceImage.GetHeight() - halfSize; y++) {
			//std::cout << "asdf" << std::endl;
			//Now we create another two for lusses for the dimensions of the array
			for (int l = -halfSize; l < halfSize+1; l++) {
				for (int m = -halfSize; m < halfSize + 1; m++) {
					window[k][0] = sourceImage.GetPixelRed(x + l, y + m);
					window[k][1] = sourceImage.GetPixelGreen(x + l, y + m);
					window[k][2] = sourceImage.GetPixelBlue(x + l, y + m);
					k++;
				}
			}
			k = 0;
			
			BYTE temp[3];
			for (int index = 0; index < doubleSize; index++) {
				temp[0] = window[index][0];
				temp[1] = window[index][1];
				temp[2] = window[index][2];
				if (index - 1 >= 0) {
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
			}
			destinationImage.SetPixel(x, y, window[doubleSize / 2][0] << redPixelShift | window[doubleSize / 2][1] << greenPixelShift | window[doubleSize / 2][2] << bluePixelShift);
		}
	}
	bt->stop();
	std::cout << "Time for the Median filter function: " << bt->elapsedMicroSeconds() << " Microseconds (" << bt->elapsedMilliSeconds() << "ms)" << std::endl;
}


/*window[0][0] = sourceImage.GetPixelRed(x - 1, y - 1);
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
window[8][2] = sourceImage.GetPixelBlue(x + 1, y + 1);*/