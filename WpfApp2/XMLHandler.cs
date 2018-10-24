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
    public class XMLHandler
    {
        public static XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Book>));
        public static XmlSerializer serializerUser = new XmlSerializer(typeof(ObservableCollection<User>));

        public static ObservableCollection<Book> ReadFromMemory(string garbagepath)
        {
            string path = "Book.xml";

            if (File.Exists(path))
            {
                using (FileStream readStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    ObservableCollection<Book> read = serializer.Deserialize(readStream) as ObservableCollection<Book>;
                    return read;
                }
            }
            else
            {               
                ObservableCollection<Book> csvCollection = Book.ReadCSV();
                using (FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    //Creates a new "Book.xml" file and populates it with the contents in the ObservableCollection
                    serializer.Serialize(filestream, csvCollection);  //Writes contents of csv file to Book.xml
                    return csvCollection;
                }

            }
        }

        public static ObservableCollection<User> ReadFromMemory()   //Reads from xml file for users
        {
            string path = "User.xml";

            if (File.Exists(path))
            {
                using (FileStream readStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    ObservableCollection<User> read = serializerUser.Deserialize(readStream) as ObservableCollection<User>;
                    return read;
                }
            }
            else
            {
                using (FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    ObservableCollection<User> newUser = new ObservableCollection<User>(); //Creates a new empty observable collection od users
                    return newUser;
                }

            }
        }

        public static void WriteToXML(ObservableCollection<Book> b, string tempPath)
        {
            
                string path = "Book.xml";

                //If the student collection is empty and the file is empty we delete it
                if (b.Count == 0 && File.Exists(path))
                {
                    File.Delete(path);
                }
                using (FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    //Creates a new "Book.xml" file and populates it with the contents in the ObservableCollection
                    serializer.Serialize(filestream, b);
                }
            
        }

        public static void WriteToXML(ObservableCollection<User> b, string tempath)
        {

            string path = "User.xml";

            //If the student collection is empty and the file is empty we delete it
            if (b.Count == 0 && File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                //Creates a new "Book.xml" file and populates it with the contents in the ObservableCollection
                serializerUser.Serialize(filestream, b);
            }

        }

    }
}
