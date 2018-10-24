using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp2
{
    [XmlRoot(ElementName = "Book")]
    public class Book
    {
        [XmlAttribute(DataType = "string")]
        public string Title { get; set; }

        [XmlAttribute(DataType = "string")]
        public string AuthorLastName { get; set; }

        [XmlAttribute(DataType = "string")]
        public string AuthorFirstName { get; set; }

        [XmlAttribute(DataType = "string")]
        public string Genre { get; set; }


        [XmlAttribute(DataType = "string")]
        public string Publisher { get; set; }

        [XmlAttribute(DataType = "string")]
        public string CheckedOut { get; set; }

        [XmlAttribute(DataType = "int")] //For some reason it doesn't accept Datatype=bool, will have to look into it later. For now we keep value 1 if it is library and 0 if requested
        public int InLibrary { get; set; }

        public Book() { }

        public Book(string title, string authorLastName, string authorFirstName, string genre, string publisher, string checkedOut, int inLibrary)
        {
            Title = title;
            AuthorLastName = authorLastName;
            AuthorFirstName = authorFirstName;
            Genre = genre;
            Publisher = publisher;
            CheckedOut = CheckedOut;
            InLibrary = inLibrary;
        }

        public override string ToString()
        {
            if (AuthorLastName != "N/A")
            {
                return $"{Title}\nby {AuthorFirstName} {AuthorLastName}\n{Genre}";
            }
            else
                return $"{Title}\nby {AuthorFirstName}\n{Genre}";
        }

        public static ObservableCollection<Book> ReadCSV()  //Reads the csv into an xml file
        {
            ObservableCollection<Book> temp = new ObservableCollection<Book>();
            string[] lines = File.ReadAllLines(@".\books.csv");

            foreach(string line in lines)
            {
                try      //Some books in the csv file are not formatted correctly but we have enough of a sample size where we can just throw these anomalies out instead of handling each edge case
                {
                    string[] data = line.Split(',');
                    //string[] author = data[1].Split(','); //In the csv author is displayed as: lastName, firstName so by splitting the string by ", " we get author[0] = lastName and author[1] = firstName
                    //string authorLastName = author[0];
                    //string authorFirstName = author[1];
                    //Console.Write(authorLastName);
                    //Console.Write(authorFirstName);
                        
                    Book b = new Book(data[0], data[1], data[2], data[3], data[6], "", 1); //We set the bool value to true because by reading in the books for the library database we know these books are in the library
                    temp.Add(b);
                }
                catch (Exception ex)
                {
                    Console.Write("Error in parsing through CSV file, Eception: " + ex);
                    //Just ignore this
                }
            }
            return temp;
        }
    }
}
