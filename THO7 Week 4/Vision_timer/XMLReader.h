#include "rapidxml.hpp";
#include <string>
#include <iostream>
#include <stdio.h>
#include <fstream>
#include <vector>
class XMLReader {
private:

public:
	XMLReader();
	~XMLReader();
	void XMLReader::DisplayTestSamples();
	void XMLReader::DisplayXMLValuesFromFile(std::string file);
	//array XMLReader::CreateTestArray(string file);
};