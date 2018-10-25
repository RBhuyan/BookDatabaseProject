﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibraryApp
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

        [XmlAttribute(DataType = "int")] // 1 if it is library and 0 if requested
        public int InLibrary { get; set; }

        [XmlAttribute(DataType = "int")]
        public int CurrentOwner { get; set; } // Displays who currently has book checked out

        public Book() { }

        public Book(string title, string authorLastName, string authorFirstName, string genre, string publisher)
        {
            Title = title;
            AuthorLastName = authorLastName;
            AuthorFirstName = authorFirstName;
            Genre = genre;
            Publisher = publisher;
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

        internal static Book ParseFromFile(string line)
        {
            var columns = line.Split(',');

            return new Book
            {
                Title = columns[0],
                AuthorLastName = columns[1],
                AuthorFirstName = columns[2],
                Genre = columns[3],
                Publisher = columns[5],
                InLibrary = 1
            };
        }

    }
}

