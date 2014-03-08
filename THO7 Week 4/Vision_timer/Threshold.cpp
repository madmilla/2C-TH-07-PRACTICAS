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

	//Threshold determination
	int imageSize = srcHeight * srcWidth;
	int temp = 0;
	int* window;
	int index = 0;
	window = (int *)malloc(sizeof(int)* imageSize);
	for (int u = 0; u < imageSize; u++) {
		window[u] = 0;
	}
	//Putting data of picture (grayvalues) into an array to take the median which will become the threshold.
	for (int i = 0; i < srcWidth; i++) {
		for (int j = 0; j < srcHeight; j++) {
			window[index] = sourceImage.GetPixelRed(i, j);
			/*if (index > 0) {
			for (int counter = 0; counter < sizeof(window); counter++) {
			if (window[index] < window[index - 1]){
			temp = window[index - 1];
			window[index - 1] = window[index];
			window[index] = temp;
			}
			}
			}*/
			index++;
		}
	}
	for (int i = 0; i < imageSize; i++) {
		temp += window[i];
	}
	temp = temp / imageSize;


	int threshold = temp;//window[imageSize / 2];
	std::cout << threshold << std::endl;

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



/*//OTSU METHOD

// NOTE: Creation of histogram[256] not shown
int size = srcHeight * srcWidth;
float histogram[256];
for (int i = 0; i < 256; i++) {
histogram[i] = 0;
}
for (int yh = 0; yh < srcHeight; yh++) {
for (int xh = 0; xh < srcWidth; xh++){
histogram[sourceImage.GetPixelRed(xh, yh)] += 1.00f;
}
}

float  w = 0;                // first order cumulative
float  u = 0;                // second order cumulative
float  uT = 0;               // total mean level

int    k = 255;              // maximum histogram index
int    threshold = 0;        // optimal threshold value

float  histNormalized[256];  // normalized histogram values

float  work1, work2;		// working variables
double work3 = 0.0;


// Create normalised histogram values
// (size=image width * image height)
for (int I = 1; I <= k; I++)
histNormalized[I - 1] = histogram[I - 1] / (float)size;


// Calculate total mean level
for (int I = 1; I <= k; I++)
uT += (I*histNormalized[I - 1]);


// Find optimal threshold value
for (int I = 1; I<k; I++) {
w += histNormalized[I - 1];
u += (I*histNormalized[I - 1]);
work1 = (uT * w - u);
work2 = (work1 * work1) / (w * (1.0f - w));
if (work2>work3) work3 = work2;
}

// Convert the final value to an integer
threshold = (int)sqrt(work3);
std::cout << threshold << std::endl;

//OTSU METHOD*/



/*//Create histogram(Must be grayscaled!)
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
}*/

/* OLD  - 2AM versie samenvoeging.
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
*/