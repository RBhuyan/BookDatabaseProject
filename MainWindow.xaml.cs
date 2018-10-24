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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BookSearch_Click(object sender, RoutedEventArgs e)
        {
            List<Book> books = ProcessBookFile("books.csv");
            BookSearch search = new BookSearch(books);
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
            //BookRequest request = new BookRequest();
            //request.ShowDialog();
        }
    }
}
