using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibraryApp
{
    public class XMLHandler
    {
        public static XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Book>));

        public static ObservableCollection<Book> ReadStudentsFromMemory(ObservableCollection<Book> inventory)
        {
            string path = "books.xml";

            if (File.Exists(path))
            {
                using (FileStream readStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    inventory = serializer.Deserialize(readStream) as ObservableCollection<Book>;
                    return inventory;
                }
            }
            else
                return inventory;
        }

        public static void WriteToXML(ObservableCollection<Book> books)
        {
            
                string path = "books.xml";

                //If the book collection is empty and the file is empty we delete it
                if (books.Count == 0 && File.Exists(path))
                {
                    File.Delete(path);
                }
                using (FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    //Creates a new "books.xml" file and populates it with the contents in the ObservableCollection
                    serializer.Serialize(filestream, books);
                }
            
        }

        private static List<Book> ProcessBookFile(string path)
        {
            return
            File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(Book.ParseFromFile).ToList();
        }

    }
}
