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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for BookRequest.xaml
    /// </summary>
    public partial class BookRequest : Window
    {
        public BookRequest()
        {
            InitializeComponent();
            var requestedBooks = from Book b in MainWindow.BookCollection
                                 where b.InLibrary == 0
                                 select b;

            ListView.ItemsSource = requestedBooks;
        }

        private void RequestButton_Click(object sender, RoutedEventArgs e)
        {
            if (BookValidation())  //If the user inputted parameters are all valid
            {
                string[] author = AuthorInput.Text.Trim().Split(' ');
                string authorFirstName = author[0];
                string authorLastName = author[1];
                Book newBook = new Book(BookTitle.Text, authorLastName, authorFirstName, Genre.Text, Publisher.Text, "", 0); //False parameter because this book will be a requested book, hence not in the library
                MainWindow.BookCollection.Add(newBook);
                XMLHandler.WriteToXML(MainWindow.BookCollection, "Book.xml");

                var requestedBooks = from Book b in MainWindow.BookCollection
                                     where b.InLibrary == 0
                                     select b;

                ListView.ItemsSource = requestedBooks;
                ListView.Items.Refresh();
            }
            else
            {
                //MessageBox.Show("Input validation error occurred, please check the help menu on correct input parameters");
            }
        }

        private bool BookValidation()
        {
            try
            {
                string[] authorName = AuthorInput.Text.Trim().Split(' ');
                string authorFirstName = authorName[0];
                string authorLastName = authorName[1];

                //Checks if any input parameters are null or white space as well as checking the author has an actual first and last name
                if (String.IsNullOrWhiteSpace(BookTitle.Text) || String.IsNullOrWhiteSpace(authorFirstName) || String.IsNullOrWhiteSpace(authorLastName) || String.IsNullOrWhiteSpace(Genre.Text) || String.IsNullOrWhiteSpace(Subgenre.Text) || String.IsNullOrWhiteSpace(Publisher.Text))
                {
                    MessageBox.Show("Input validation error occurred, please check the help menu on correct input parameters");
                    return false;
                }


                var duplicateCheck = from Book b in MainWindow.BookCollection
                                     where (b.Title == BookTitle.Text && b.AuthorFirstName == authorFirstName && b.AuthorLastName == authorLastName)
                                     select b;
                if (duplicateCheck.Count() > 0)
                {
                    MessageBox.Show("Requested book has already been requested");
                    return false;
                }
                return true;
            }
            catch
            {
                MessageBox.Show("Input validation error occurred, please check the help menu on correct input parameters");
                return false; //Some error in data handling, return false
            }
        }

        private void ExitProgram_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ReturnToMain_click(object sender, RoutedEventArgs e)
        {
            this.Close(); //Returns to main Window
        }

        private void Info_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You can request a book from the library here. You can also see if the book has already been requested");
        }

        private void Help_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Title must be a string\nAuthor must be two strings separated by a white space\nGenre must be a string\nSubgenre must be a string\nPublisher must be a string");
        }
    }
}
