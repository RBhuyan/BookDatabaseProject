using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Book> books = new ObservableCollection<Book>();
        List<Book> bookCollection;
        List<Book> borrowedBooks; // List holds all of the books the user is currently borrowing from the library

        public MainWindow()
        {
            InitializeComponent();
            bookCollection = ProcessBookFile("books.csv");

            try
            {
                XMLHandler.ReadStudentsFromMemory(books);
            }
            catch (Exception ex)
            {
                Console.WriteLine("******** Unable to read xml file*******", ex.InnerException);
                MessageBox.Show($"Unable to read xml file\nInner Exception:{ex.InnerException}", "Error");
            }

            if (books.Count() == 0)
            {
                books = new ObservableCollection<Book>(bookCollection);
            }

            //IEnumerable<Book> temp = books.Where(x => x.CurrentOwner == );
        }

        private void BookSearch_Click(object sender, RoutedEventArgs e)
        {
            BookSearch search = new BookSearch(bookCollection);
            search.ShowDialog();
        }

        private static List<Book> ProcessBookFile(string path)
        {
            return
            File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1) // Will not read white space as the line length < 1 (0)
                .Select(Book.ParseFromFile).ToList(); // MUST INCLUDE "ToList" to cast it
        }

        private void BookRequest_Click(object sender, RoutedEventArgs e)
        {
            BookRequest request = new BookRequest();
            request.ShowDialog();
        }
    }
}
