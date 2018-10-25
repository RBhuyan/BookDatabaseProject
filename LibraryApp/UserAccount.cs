using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibraryApp
{
    [XmlRoot(ElementName = "UserAccount")]
    public class UserAccount
    {
        [XmlAttribute(DataType = "string")]
        public string Username { get; set; }

        [XmlAttribute(DataType = "string")]
        public string Password { get; set; }

        [XmlAttribute(DataType = "string")]
        public string Name { get; set; }

        [XmlAttribute(DataType = "string")]
        public int ID { get; set; }

        public UserAccount() { }

        public UserAccount(string username, string password, string name, int id)
        {
            Username = username;
            Password = password;
            Name = name;
            ID = id;
        }

    }
}
