#ifndef MedianFilter_H
#define MedianFilter_H
#include "Image.h"
#include "exectimer.h"
#include <iostream>

class MedianFilter {
private:
	BaseTimer* bt;
public:
	MedianFilter();
	~MedianFilter();
	void CreateMedianImage(Image &sourceImage, Image &destinationImage);
};

#endif