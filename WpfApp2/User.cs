using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp2
{
    [XmlRoot(ElementName = "User")]
    public class User
    {
        [XmlAttribute(DataType = "string")]
        public string UserFirstName { get; set; }

        [XmlAttribute(DataType = "string")]
        public string UserLastName { get; set; }

        [XmlAttribute(DataType = "string")]
        public string UserID { get; set; }

        [XmlAttribute(DataType = "string")]
        public string Username { get; set; }

        [XmlAttribute(DataType = "string")]
        public string Password { get; set; }

        public User() { } //Default constructor for User creation with empty paramters

        public User(string userFirstName, string userLastName, string userID, string username, string password)
        {
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            UserID = userID;
            Username = username;
            Password = password;
        }
    }
}
