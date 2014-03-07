#ifndef Image_H
#define Image_H
#include <atlimage.h>
#include <string>
#include <iostream>
//Shift values
#define redPixelShift 24
#define greenPixelShift 16
#define bluePixelShift 8
#define alphaPixelShift 0

class Image {
private:
	CImage* image;
	std::string fileName;
	std::string inputLocation = "../Images/Origineel/";
	std::string outputLocation = "../Images/Nieuw/";

	int height;
	int width;
	int bpp;
	unsigned int *pixel;

	void LoadFromCImage();
public:
	//Constructor
	Image();
	Image(std::string fileName);
	Image(Image &img);
	~Image();

	//public functions
	void LoadImageFromFile(std::string fileName);
	void SaveImageToFile(std::string prefixName);
	inline int GetWidth() { return width; }
	inline int GetHeight() { return height;	}
	inline int GetBPP() { return bpp; }

	inline int GetPixel(int x, int y) { return pixel[x + (y * width)]; }
	inline int GetPixelRed(int x, int y) { return (pixel[x + (y * width)] >> 24) & 0xFF; }
	inline int GetPixelGreen(int x, int y) { return (pixel[x + (y * width)] >> 16) & 0xFF; }
	inline int GetPixelBlue(int x, int y) { return (pixel[x + (y * width)] >> 8) & 0xFF; }

	inline void SetPixel(int x, int y, int value) {	pixel[x + (y * width)] = value;	}
	inline void SetPixelRed(int x, int y, int value) { pixel[x + (y * width)] |= (value & 0xFF) << 24; }
	inline void SetPixelGreen(int x, int y, int value) { pixel[x + (y * width)] |= (value & 0xFF) << 16; }
	inline void SetPixelBlue(int x, int y, int value) { pixel[x + (y * width)] |= (value & 0xFF) << 8; }

};

#endif