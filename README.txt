												Code Overview
*** I edited the csv to be able to parse through easily, it can be found in bin/debug/books.csv	***
*** The xml file can also be found in that same folder ***

XMLHandler.cs:	Contains 2 functions, ReadStudentsFromMemory() and WritetoXML()
		
		ReadStudentsFromMemory():  if "Boox.xml" exists, will populate an observable collection with the contents of the xml file 				             and then return it
					   
					   if "Boox.xml" does not exist, it will call Book.ReadCSV() which creates the xml file and fills 					     it with contents of csv file, then return that new Collection filled with the csv content
		
		WriteToXML(Collection):	   if the length of collection is 0 and xml file exists it will delete xml file. This should never                                            happen unless there's an error, but it's there in case it an error does happen.
					   it then fills the xml with the contents of the paased Observable Collection

Book.cs:	Book Declaration:          Standard book class declaration with generic parameters from csv file, last parameter is an int                                            which is 0 if in library database or 1 if requested. 
					   ** I wanted to use a bool but that's not a bindable data type apparently. **
		
		ReadCSV(): 		   Returns an observable collection populated with xml content. You should not have to use this 					   yourself, the XMLHandler ReadStudentsFromMemory() will take care of that for you

The rest of the files are just what I've been working on for my own part of the project, but if you want me to explain the implementation of these functions in my code just ask.
		
	 	
