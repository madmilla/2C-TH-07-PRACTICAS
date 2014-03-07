#include "SobelFilter.h"


SobelFilter::SobelFilter(){
	bt = new BaseTimer();
}


SobelFilter::~SobelFilter(){
	delete bt;
}

void SobelFilter::CreateSobelImage(Image &sourceImage, Image &destinationImage) {
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

	double kernelX[3][3] = { { -1, 0, 1 },
							{ -2, 0, 2 },
							{ -1, 0, 1 } };

	double kernelY[3][3] = { { -1, -2, -1 },
							{ 0, 0, 0 },
							{ 1, 2, 1 } };

	for (int x = 1; x < dstWidth - 1; ++x){
		for (int y = 1; y < dstHeight - 1; ++y){
			double magX = 0.0;
			double magY = 0.0;

			for (int a = 0; a < 3; a++)
			{
				for (int b = 0; b < 3; b++)
				{
					int xn = x + a - 1;
					int yn = y + b - 1;

					magX += sourceImage.GetPixelRed(xn, yn) * kernelX[a][b];
					magY += sourceImage.GetPixelRed(xn, yn) * kernelY[a][b];
				}
			}

			if (magX < 0) { magX = 0; }
			else if (magX > 255) { magX = 255; }
			if (magY < 0) { magY = 0; }
			else if (magY > 255) { magY = 255; }

			double mag = sqrt(magX * magX + magY * magY);

			if (mag < 0) { mag = 0; }
			else if (mag > 255) { mag = 255; }

			int mg = (int)mag;
			destinationImage.SetPixel(x, y, mg << redPixelShift | mg << greenPixelShift | mg << bluePixelShift);
		}
	}

	bt->stop();
	std::cout << "Time for the Median filter function: " << bt->elapsedMicroSeconds() << " Microseconds (" << bt->elapsedMilliSeconds() << "ms)" << std::endl;
}

