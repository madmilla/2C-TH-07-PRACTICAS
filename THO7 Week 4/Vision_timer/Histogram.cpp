#include "Histogram.h"

//AUTHOR Bryan Baan & Chanan van Ooijen
using namespace std;
Histogram::Histogram() {
	bt = new BaseTimer();
}

Histogram::~Histogram() {
	delete bt;
}

//This method creates a histogram using the Y column base and counting the edges over the X rows.
void Histogram::CreateHistogramY(Image &sourceImage) {
	bt->reset();
	bt->start();

	//Removing the previous histogram so you wont get weird values.
	if (remove("histogram.csv") != 0)
		perror("Error deleting file");
	else
		puts("File successfully deleted");

	int* window;
	int imageHeight = sourceImage.GetHeight();
	int imageWidth = sourceImage.GetWidth();
	int totalPixels = imageWidth * imageHeight;

	//Opening histogramfile
	ofstream histogramFile;
	histogramFile.open("histogramY.csv", ios::out);

	window = (int *)malloc(sizeof(int)* imageHeight);
	int pixel = 0;
	int before = 0;
	int after = 0;

	//Emptying the arrayvalues
	for (int i = 0; i < imageHeight; i++){
		window[i] = 0;
	}

	//Creating the actual histogram
	for (int y = 1; y < sourceImage.GetHeight() - 1; y++) {
		for (int x = 1; x < sourceImage.GetWidth() - 1; x++) {

			before = sourceImage.GetPixelRed(x - 1, y);
			pixel = sourceImage.GetPixelRed(x, y);
			if ((before >= 0 && before <= 15) && (pixel >= 240 && pixel <= 255)) {
				window[y]++;
			}
			else if ((before >= 240 && before <= 255) && (pixel >= 0 && pixel <= 15)) {
				window[y]++;
			}
		}
	}

	//Writing the histogram to the file.
	for (int i = 0; i < imageHeight; i++){
		histogramFile << (window[i]) << endl;
	}

	bt->stop();
	std::cout << "Time for the HistogramY function: " << bt->elapsedMicroSeconds() << " Microseconds (" << bt->elapsedMilliSeconds() << "ms)" << std::endl;

}

//This method creates a histogram using the X rows base and counting the edges over the Y column.
void Histogram::CreateHistogramX(Image &sourceImage) {
	bt->reset();
	bt->start();

	//Removing the old histogram to prevent getting weird values.
	if (remove("histogramX.csv") != 0)
		perror("Error deleting file");
	else
		puts("File successfully deleted");

	int* window;
	int imageHeight = sourceImage.GetHeight();
	int imageWidth = sourceImage.GetWidth();
	int totalPixels = imageWidth * imageHeight;
	ofstream histogramFile;
	histogramFile.open("histogramX.csv", ios::out);

	window = (int *)malloc(sizeof(int)* imageWidth);
	int pixel = 0;
	int before = 0;
	int after = 0;

	//Emptying the arrayvalues
	for (int i = 0; i < imageWidth; i++){
		window[i] = 0;
	}

	//Creating the actual histogram
	for (int x = 1; x < sourceImage.GetWidth() - 1; x++) {
		for (int y = 1; y < sourceImage.GetHeight() - 1; y++) {

			before = sourceImage.GetPixelRed(x, y - 1);
			pixel = sourceImage.GetPixelRed(x, y);
			if ((before >= 0 && before <= 15) && (pixel >= 240 && pixel <= 255)) {
				window[x]++;
			}
			else if ((before >= 240 && before <= 255) && (pixel >= 0 && pixel <= 15)) {
				window[x]++;
			}
		}
	}

	//writing the histogram to the file.
	for (int i = 0; i < imageWidth; i++){
		histogramFile << (window[i]) << endl;
	}

	bt->stop();
	std::cout << "Time for the HistogramX function: " << bt->elapsedMicroSeconds() << " Microseconds (" << bt->elapsedMilliSeconds() << "ms)" << std::endl;

}
