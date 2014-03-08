#include "rapidxml.hpp";
#include <string.h>
#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include <vector>
class XMLReader {
private:

public:
	XMLReader();
	~XMLReader();
	void XMLReader::DisplayTestSamples();
	void XMLReader::DisplayXMLValuesFromFile(std::string file);
	std::string * XMLReader::CreateArrayOfFilenames(std::string file);
	void XMLReader::CheckFoundValuesAgainstTheXMLValues(std::string file, std::string ImageFile, int UpLeftX, int UpLeftY, int UpRightX, int UpRightY, int DownLeftX, int DownLeftY, int DownRightX, int DownRightY);
	//array XMLReader::CreateTestArray(string file);
};