using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace LibraryApp
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public List<UserAccount> Users { get; set; } = new List<UserAccount>();
        XmlSerializer serializer = new XmlSerializer(typeof(List<UserAccount>));

        public SignUp(List<UserAccount> users)
        {
            InitializeComponent();
            Users = users;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            Random rand = new Random();

            int ID = rand.Next(10000000, 99999999);

            IEnumerable<UserAccount> query1 = Users.Where(x => x.Username == UserEntry.Text);
            IEnumerable<UserAccount> query2 = Users.Where(x => x.ID == ID);

            // The loop below ensures that no two users will share the same ID#
            while (query2.Count() > 0)
            {
                ID = rand.Next(10000000, 99999999);
                query2 = Users.Where(x => x.ID == ID);
            }

            if (ValidateEntries())
            {
                if (query1.Count() == 0)
                {
                    UserAccount account = new UserAccount(UserEntry.Text, PasswordEntry.Password, NameEntry.Text, ID);
                    Users.Add(account);

                    string path = "Users.xml";

                    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                    {
                        serializer.Serialize(fs, Users);
                    }

                    MessageBox.Show("Account has been created", "Success");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username already taken. Please choose another.", "Duplicate User");
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool ValidateEntries()
        {
            if (string.IsNullOrWhiteSpace(UserEntry.Text)) { return false; }
            if (string.IsNullOrWhiteSpace(NameEntry.Text)) { return false; }
            if (string.IsNullOrWhiteSpace(PasswordEntry.Password)) { return false; }

            if (PasswordEntry.Password != ConfirmEntry.Password)
            {
                MessageBox.Show("Error. Passwords do not match. Please re-enter.", "Confirm Password Failure");
                return false;
            }

            return true;

        }
    }
}
