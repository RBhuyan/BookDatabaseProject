using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Book> BookCollection = new ObservableCollection<Book>();
        public static ObservableCollection<User> UserCollection = new ObservableCollection<User>();
        List<string> GenreOptions = new List<string> { "Science Fiction", "Satire", "Action and Adventure", "Romance", "Horror", "Mystery", "Non-Fiction", "Poetry" };
        public Book EditingBook { get; set; }
        public User CurrentUser { get; set; }

        //XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Book>));


        public MainWindow(User currentUser)
        {
            InitializeComponent();
            //COMBOBOX.ItemsSource = GenreOptions;
            CurrentUser = currentUser;
            //BookCollection.Add(testing);

            try { BookCollection = XMLHandler.ReadFromMemory("Book.xml"); }
            catch (Exception ex)
            {
                Console.WriteLine("******* Unable to read xml file*********", ex.InnerException);
                MessageBox.Show($"Unable to read xml file\nInner Exception:{ex.InnerException.Message}");
            }

            XMLHandler.WriteToXML(BookCollection, "Book.xml"); //Writes list of books to Book.xml

            var databaseBooks = from Book b in BookCollection  //Now the search will only let you search through books currently in the database system
                                where b.InLibrary == 1
                                select b;

            listView.ItemsSource = databaseBooks;
        }

        private void submit_click(object sender, RoutedEventArgs e)
        {
            BookRequest win = new BookRequest();
            win.ShowDialog();
            BookCollection = XMLHandler.ReadFromMemory("Book.xml");
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void testingConfirmCheckout(object sender, RoutedEventArgs e)
        {
            User testingUser = new User("testingFirstName", "testingLastName", "testingID", "testingUsername", "testingUserpassword");
            //UserCollection.Add(testingUser);
            //XMLHandler.WriteToXML(UserCollection, "User.xml");
            Book testingBook = new Book("ttitle", "tlastname", "tfirstname", "tgenre", "tpublisher", "", 1);

            var b = from Book bb in BookCollection
                    where (bb.Title == "ttitle" && bb.AuthorLastName == "tlastname" && bb.AuthorFirstName == "tfirstname")
                    select bb;

            foreach(Book bb in b)
            {
                testingBook = bb;
            }

            //BookCollection.Add(testingBook);
            //List < Book > testingBookCollection = new List<Book>();
            //testingBookCollection.Add(testingBook);
            CheckoutConfirm win = new CheckoutConfirm(testingBook, testingUser);
            win.ShowDialog();
        }
    }
}
