#include "XMLReader.h";

using namespace rapidxml;
using namespace std;

XMLReader::XMLReader() {

}


XMLReader::~XMLReader() {

}

void XMLReader::DisplayTestSamples() {
	
	xml_document<> doc;    // character type defaults to char
	xml_node<> * root_node;

	// Read the xml file into a vector
	ifstream theFile("../Images/THO7_wk4_testset/testsamples.xml");
	vector<char> buffer((istreambuf_iterator<char>(theFile)), istreambuf_iterator<char>());

	buffer.push_back('\0');
	// Parse the buffer using the xml file parsing library into doc 
	doc.parse<0>(&buffer[0]);
	// Find our root node
	root_node = doc.first_node("testsamples");

	for (xml_node<> * test_node = root_node->first_node("image"); test_node; test_node = test_node->next_sibling())
	{
		printf("Image found %s. \n",
		test_node->first_attribute("filename")->value());
			//test_node->first_attribute("location")->value());
		// Interate over the beers
		for (xml_node<> * license_plate_node = test_node->first_node("license_plate"); license_plate_node; license_plate_node = license_plate_node->next_sibling())
		{
			xml_node<> * location_node = license_plate_node->first_node("location");
			//for (xml_node<> * location_node = license_plate_node->first_node("location"); location_node; location_node = location_node->next_sibling())
			//{
			//	location_node->
				printf("Upperleft : \tX[%s], \ty[%s] \n", location_node->first_node("upperleft")->first_attribute("x")->value(), location_node->first_node("upperleft")->first_attribute("y")->value());
				printf("upperright: \tX[%s], \ty[%s] \n", location_node->first_node("upperright")->first_attribute("x")->value(), location_node->first_node("upperright")->first_attribute("y")->value());
				printf("lowerleft : \tX[%s], \ty[%s] \n", location_node->first_node("lowerleft")->first_attribute("x")->value(), location_node->first_node("lowerleft")->first_attribute("y")->value());
				printf("lowerright: \tX[%s], \ty[%s] \n", location_node->first_node("lowerright")->first_attribute("x")->value(), location_node->first_node("lowerright")->first_attribute("y")->value());

			//}
			//printf("On %s, I tried their %s which is a %s. ",license_plate_node->first_attribute("description")->value());
			printf("Het nummerbord is: %s", license_plate_node->first_node("text")->value());
			
		}
		cout << endl;
	}
}

void XMLReader::DisplayXMLValuesFromFile(string file) {

		xml_document<> doc;    // character type defaults to char
		xml_node<> * root_node;

		// Read the xml file into a vector
		ifstream theFile(file);
		vector<char> buffer((istreambuf_iterator<char>(theFile)), istreambuf_iterator<char>());

		buffer.push_back('\0');
		// Parse the buffer using the xml file parsing library into doc 
		doc.parse<0>(&buffer[0]);
		// Find our root node
		root_node = doc.first_node("testsamples");

		for (xml_node<> * test_node = root_node->first_node("image"); test_node; test_node = test_node->next_sibling())
		{
			printf("Image found %s. \n",
				test_node->first_attribute("filename")->value());
			//test_node->first_attribute("location")->value());
			// Interate over the beers
			for (xml_node<> * license_plate_node = test_node->first_node("license_plate"); license_plate_node; license_plate_node = license_plate_node->next_sibling())
			{
				xml_node<> * location_node = license_plate_node->first_node("location");
				//for (xml_node<> * location_node = license_plate_node->first_node("location"); location_node; location_node = location_node->next_sibling())
				//{
				//	location_node->
				printf("Upperleft : \tX[%s], \ty[%s] \n", location_node->first_node("upperleft")->first_attribute("x")->value(), location_node->first_node("upperleft")->first_attribute("y")->value());
				printf("upperright: \tX[%s], \ty[%s] \n", location_node->first_node("upperright")->first_attribute("x")->value(), location_node->first_node("upperright")->first_attribute("y")->value());
				printf("lowerleft : \tX[%s], \ty[%s] \n", location_node->first_node("lowerleft")->first_attribute("x")->value(), location_node->first_node("lowerleft")->first_attribute("y")->value());
				printf("lowerright: \tX[%s], \ty[%s] \n", location_node->first_node("lowerright")->first_attribute("x")->value(), location_node->first_node("lowerright")->first_attribute("y")->value());

				//}
				//printf("On %s, I tried their %s which is a %s. ",license_plate_node->first_attribute("description")->value());
				printf("Het nummerbord is: %s \n\n", license_plate_node->first_node("text")->value());

			}
			cout << endl;
		}
	}