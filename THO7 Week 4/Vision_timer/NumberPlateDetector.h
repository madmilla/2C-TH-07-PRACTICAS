#ifndef NumberPlateDetector_H
#define NumberPlateDetector_H
#include "Image.h"
#include "exectimer.h"
#include <iostream>
#include <fstream>

class NumberPlateDetector{
private:
	BaseTimer* bt;
public:
	NumberPlateDetector();
	~NumberPlateDetector();
	void CreateNumberPlateImage(Image &sourceImage, Image &destinationImage);
};

#endif