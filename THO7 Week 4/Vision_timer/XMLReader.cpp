#include "XMLReader.h";



using namespace rapidxml;
using namespace std;

XMLReader::XMLReader() {

}


XMLReader::~XMLReader() {

}

std::string * XMLReader::CreateArrayOfFilenames(string file){

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

	int FileNameCounter = 0;
	for (xml_node<> * test_node = root_node->first_node("image"); test_node; test_node = test_node->next_sibling())
	{
	//	printf("Results for: %s - %d \n", test_node->first_attribute("filename")->value(), FileNameCounter);
		FileNameCounter++;
	}
	// Make the array
	string * d = new string[FileNameCounter];
	cout << "aantal: " << FileNameCounter << endl;
	//d[0] = "hahaha";
	//d[1] = "hoi";
	int temp = 0;
	for (xml_node<> * test_node = root_node->first_node("image"); test_node; test_node = test_node->next_sibling())
	{
		d[temp] = test_node->first_attribute("filename")->value();
	//	char * newArray = new char[std::strlen(oldArray) + std::strlen(test_node->first_attribute("filename")->value()) + 1];
	//	strncpy_s(newArray, (size_t)(std::strlen(oldArray) + std::strlen(test_node->first_attribute("filename")->value()) + 1), (const char *)test_node->first_attribute("filename")->value(), (size_t)std::strlen(test_node->first_attribute("filename")->value()));
	
		//	std::strcat(newArray, test_node->first_attribute("filename")->value());
		//std::cout << newArray << std::endl;
		//delete[] oldArray;
	//	char * oldArray = new char[std::strlen(newArray)];
		//strncpy_s(oldArray, (size_t)(std::strlen(oldArray) + std::strlen(newArray) + 1), newArray, (size_t)std::strlen(newArray));

	//	delete[] newArray;

		//printf("Results for: %s - %d \n", test_node->first_attribute("filename")->value(), FileNameCounter);
		//printf("BBTS - %s", newArray[temp]);
		temp++;
	}
	return d;

}

void XMLReader::CheckFoundValuesAgainstTheXMLValues(string file, string ImageFile, int UpLeftX, int UpLeftY, int UpRightX, int UpRightY, int DownLeftX, int DownLeftY, int DownRightX, int DownRightY){
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
		if (test_node->first_attribute("filename")->value() == ImageFile){
			printf("Results for: %s\n", test_node->first_attribute("filename")->value());

			for (xml_node<> * license_plate_node = test_node->first_node("license_plate"); license_plate_node; license_plate_node = license_plate_node->next_sibling())
			{
				xml_node<> * location_node = license_plate_node->first_node("location");
				//for (xml_node<> * location_node = license_plate_node->first_node("location"); location_node; location_node = location_node->next_sibling())
				//{
				//	location_node->
				
				//Compare difference
				int node_UpLeftX = atoi(location_node->first_node("upperleft")->first_attribute("x")->value());
				int node_UpLeftY = atoi(location_node->first_node("upperleft")->first_attribute("y")->value());

				int node_UpRightX = atoi(location_node->first_node("upperright")->first_attribute("x")->value());
				int node_UpRightY = atoi(location_node->first_node("upperright")->first_attribute("y")->value());

				int node_DownLeftX = atoi(location_node->first_node("lowerleft")->first_attribute("x")->value());
				int node_DownLeftY = atoi(location_node->first_node("lowerleft")->first_attribute("y")->value());

				int node_DownRightX = atoi(location_node->first_node("lowerright")->first_attribute("x")->value());
				int node_DownRightY = atoi(location_node->first_node("lowerright")->first_attribute("y")->value());

				
				printf(" \t\tULX\tULY\tURX\tURY\tDLX\tDLY\tDRX\tDRY\n");
				printf("Goal:	\t%d\t%d\t%d\t%d\t%d\t%d\t%d\t%d\n", node_UpLeftX, node_UpLeftY, node_UpRightX, node_UpRightY, node_DownLeftX, node_DownLeftY, node_DownRightX, node_DownRightY);
				printf("Input:  \t%d\t%d\t%d\t%d\t%d\t%d\t%d\t%d\n", UpLeftX, UpLeftY, UpRightX, UpRightY, DownLeftX, DownLeftY, DownRightX, DownRightY);
				printf("==============================================================================\n");
				printf("Result: \t%d\t%d\t%d\t%d\t%d\t%d\t%d\t%d\n", node_UpLeftX - UpLeftX, node_UpLeftY - UpLeftY, node_UpRightX - UpRightX, node_UpRightY - UpRightY, node_DownLeftX - DownLeftX, node_DownLeftY - DownLeftY, node_DownRightX - DownRightX, node_DownRightY - DownRightY);

				//printf("Het nummerbord is: %s \n\n", license_plate_node->first_node("text")->value());

			}
		}
	}
	cout << endl;
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