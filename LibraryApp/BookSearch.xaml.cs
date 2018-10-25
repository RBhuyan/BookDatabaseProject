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

namespace LibraryApp
{
    /// <summary>
    /// Interaction logic for BookSearch.xaml
    /// </summary>
    public partial class BookSearch : Window
    {
        ObservableCollection<Book> inventory;

        public BookSearch(List<Book> books)
        {
            InitializeComponent();

            inventory = new ObservableCollection<Book>(books);
        }

        private void BookSearch_Click(object sender, RoutedEventArgs e)
        {
            bool titleValid = string.IsNullOrWhiteSpace(TitleEntry.Text) ? false : ValidateTitle(TitleEntry.Text);
            bool authorValid = string.IsNullOrWhiteSpace(AuthorEntryFirst.Text) ? false : ValidateAuthor(AuthorEntryFirst.Text);
            bool authorSurnameValid = string.IsNullOrWhiteSpace(AuthorEntryLast.Text) ?  false : ValidateForLetters(AuthorEntryLast.Text);
            bool genreValid = string.IsNullOrWhiteSpace(GenreEntry.Text) ? false : ValidateForLetters(GenreEntry.Text);
            bool publisherValid = string.IsNullOrWhiteSpace(PublisherEntry.Text) ? false : ValidateForPublisher(PublisherEntry.Text);

            if (NoEntries())
            {
                TitleEntry.Background = Brushes.Pink;
                TitleWarning.Visibility = Visibility.Visible;

                AuthorEntryFirst.Background = Brushes.Pink;
                AuthorFirstWarning.Visibility = Visibility.Visible;

                AuthorEntryLast.Background = Brushes.Pink;
                AuthorLastWarning.Visibility = Visibility.Visible;

                GenreEntry.Background = Brushes.Pink;
                GenreWarning.Visibility = Visibility.Visible;

                PublisherEntry.Background = Brushes.Pink;
                PublisherWarning.Visibility = Visibility.Visible;
            }

            #region All Values True

            if (titleValid && authorValid && authorSurnameValid && genreValid && publisherValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.Title == TitleEntry.Text && 
                x.AuthorFirstName == AuthorEntryFirst.Text && x.AuthorLastName == AuthorEntryLast.Text && 
                x.Genre == GenreEntry.Text && x.Publisher == PublisherEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            #endregion

            #region Cases Where Title is Valid

            else if (titleValid && authorValid && authorSurnameValid && genreValid && !publisherValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.Title == TitleEntry.Text && 
                x.AuthorFirstName == AuthorEntryFirst.Text && x.AuthorLastName == AuthorEntryLast.Text && 
                x.Genre == GenreEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (titleValid && authorValid && authorSurnameValid && publisherValid && !genreValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.Title == TitleEntry.Text &&
                x.AuthorFirstName == AuthorEntryFirst.Text && x.AuthorLastName == AuthorEntryLast.Text &&
                x.Publisher == PublisherEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (titleValid && authorValid && genreValid && publisherValid && !authorSurnameValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.Title == TitleEntry.Text &&
                x.AuthorFirstName == AuthorEntryFirst.Text && x.Genre == GenreEntry.Text &&
                x.Publisher == PublisherEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (titleValid && authorSurnameValid && genreValid && publisherValid && !authorValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.Title == TitleEntry.Text &&
                x.AuthorLastName == AuthorEntryLast.Text && x.Genre == GenreEntry.Text &&
                x.Publisher == PublisherEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }
                        
            else if (titleValid && authorValid && authorSurnameValid && !genreValid && !publisherValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.Title == TitleEntry.Text &&
                x.AuthorFirstName == AuthorEntryFirst.Text && x.AuthorLastName == AuthorEntryLast.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (titleValid && authorValid && genreValid && !authorSurnameValid && !publisherValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.Title == TitleEntry.Text &&
                x.AuthorFirstName == AuthorEntryFirst.Text && x.Genre == GenreEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (titleValid && authorValid && publisherValid && !authorSurnameValid && !genreValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.Title == TitleEntry.Text &&
                x.AuthorFirstName == AuthorEntryFirst.Text && x.Publisher == PublisherEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (titleValid && authorSurnameValid && genreValid && !authorValid && !publisherValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.Title == TitleEntry.Text &&
                x.AuthorLastName == AuthorEntryLast.Text && x.Genre == GenreEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (titleValid && authorSurnameValid && publisherValid && !genreValid && !authorValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.Title == TitleEntry.Text &&
                x.AuthorLastName == AuthorEntryLast.Text && x.Publisher == PublisherEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (titleValid && genreValid && publisherValid && !authorValid && !authorSurnameValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.Title == TitleEntry.Text &&
                x.Genre == GenreEntry.Text && x.Publisher == PublisherEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (titleValid && authorValid && !authorSurnameValid && !publisherValid && !genreValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.Title == TitleEntry.Text &&
                x.AuthorFirstName == AuthorEntryFirst.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (titleValid && authorSurnameValid && !authorValid && !genreValid && !publisherValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.Title == TitleEntry.Text &&
                x.AuthorLastName == AuthorEntryLast.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (titleValid && genreValid && !authorValid && !authorSurnameValid && !publisherValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.Title == TitleEntry.Text &&
                x.Genre == GenreEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (titleValid && publisherValid && !authorValid && !authorSurnameValid && !genreValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.Title == TitleEntry.Text &&
                x.Publisher == PublisherEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }


            #endregion

            #region Cases Where Author First Name is Valid

            else if (authorValid && authorSurnameValid && genreValid && publisherValid && !titleValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.AuthorFirstName == AuthorEntryFirst.Text &&
                x.AuthorLastName == AuthorEntryLast.Text && x.Genre == GenreEntry.Text
                && x.Publisher == PublisherEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (authorValid && authorSurnameValid && genreValid && !titleValid && !publisherValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.AuthorFirstName == AuthorEntryFirst.Text &&
                x.AuthorLastName == AuthorEntryLast.Text && x.Genre == GenreEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (authorValid && authorSurnameValid && publisherValid && !titleValid && !genreValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.AuthorFirstName == AuthorEntryFirst.Text &&
                x.AuthorLastName == AuthorEntryLast.Text && x.Publisher == PublisherEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (authorValid && genreValid && publisherValid && !titleValid && !authorSurnameValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.AuthorFirstName == AuthorEntryFirst.Text &&
                x.Genre == GenreEntry.Text && x.Publisher == PublisherEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (authorValid && authorSurnameValid && !titleValid && !genreValid && !publisherValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.AuthorFirstName == AuthorEntryFirst.Text &&
                x.AuthorLastName == AuthorEntryLast.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (authorValid && genreValid && !titleValid && !authorSurnameValid && !publisherValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.AuthorFirstName == AuthorEntryFirst.Text &&
                x.Genre == GenreEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (authorValid && publisherValid && !titleValid && !authorSurnameValid && !genreValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.AuthorFirstName == AuthorEntryFirst.Text &&
                x.Publisher == PublisherEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }


            #endregion

            #region Cases Where Author Last Name is Valid

            else if (authorSurnameValid && genreValid && publisherValid && !titleValid && ! authorValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.AuthorLastName == AuthorEntryLast.Text &&
                x.Genre == GenreEntry.Text && x.Publisher == PublisherEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (authorSurnameValid && genreValid && !publisherValid && !authorValid && !titleValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.AuthorLastName == AuthorEntryLast.Text &&
                x.Genre == GenreEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (authorSurnameValid && publisherValid && !titleValid && !authorValid && !genreValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.AuthorLastName == AuthorEntryLast.Text &&
                x.Publisher == PublisherEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            #endregion

            #region Cases Where Genre is Valid

            else if (genreValid && publisherValid && !authorValid && !authorSurnameValid && !titleValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.Genre == GenreEntry.Text &&
                x.Publisher == PublisherEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            #endregion

            else if (titleValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.Title == TitleEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (authorValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.AuthorFirstName == AuthorEntryFirst.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (authorSurnameValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.AuthorLastName == AuthorEntryLast.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (genreValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.Genre == GenreEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }

            else if (publisherValid)
            {
                IEnumerable<Book> temp = inventory.Where(x => x.Publisher == PublisherEntry.Text);

                if (temp.Count() == 0)
                    MessageBox.Show("No books available that match the criteria.", "Search Failure");
                else
                    BookList.ItemsSource = temp;
            }
        }

        private bool ValidateAuthor(string text)
        {
            return text.Where(x => char.IsLetter(x) || char.IsWhiteSpace(x) || x == '.').Count() == text.Length; // Accounts for publishing companies whose names are more than one word (i.e. strings with white space)
        }

        private bool NoEntries()
        {
            bool title = string.IsNullOrWhiteSpace(TitleEntry.Text) ? false : true;
            bool authorFirst = string.IsNullOrWhiteSpace(AuthorEntryFirst.Text) ? false : true;
            bool authorLast = string.IsNullOrWhiteSpace(AuthorEntryLast.Text) ? false : true;
            bool genre = string.IsNullOrWhiteSpace(GenreEntry.Text) ? false : true;
            bool publisher = string.IsNullOrWhiteSpace(PublisherEntry.Text) ? false : true;


            // All the entries cannot be empty
            if ((title || authorFirst || authorLast || genre || publisher) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateForPublisher(string text)
        {
            return text.Where(x => char.IsLetter(x) || char.IsWhiteSpace(x)).Count() == text.Length; // Accounts for publishing companies whose names are more than one word (i.e. strings with white space)
        }

        private bool ValidateForLetters(string text)
        {
            return text.Where(x => char.IsLetter(x)).Count() == text.Length; // Verfies that the string consists only of letters (counts how many characters in string are letters, compares it to length of string)
        }

        private bool ValidateTitle(string text)
        {
            return text.Where(x => char.IsLetterOrDigit(x) || char.IsWhiteSpace(x) || char.IsPunctuation(x) || char.IsSymbol(x)).Count() == text.Length;
        }

        private void BorrowBook_Click(object sender, RoutedEventArgs e)
        {
            if (BookList.SelectedItem != null)
            {
                Book book = BookList.SelectedItem as Book;
                //Checkout win = new Checkout(book);
            }
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox text = (sender as TextBox);

            if (text.Name == TitleEntry.Name)
            {
                TitleEntry.Background = Brushes.White;
                TitleWarning.Visibility = Visibility.Hidden;
            }
            if (text.Name == AuthorEntryFirst.Name)
            {
                AuthorEntryFirst.Background = Brushes.White;
                AuthorFirstWarning.Visibility = Visibility.Hidden;
            }
            if (text.Name == AuthorEntryLast.Name)
            {
                AuthorEntryLast.Background = Brushes.White;
                AuthorLastWarning.Visibility = Visibility.Hidden;
            }
            if (text.Name == GenreEntry.Name)
            {
                GenreEntry.Background = Brushes.White;
                GenreWarning.Visibility = Visibility.Hidden;
            }
            if (text.Name == PublisherEntry.Name)
            {
                PublisherEntry.Background = Brushes.White;
                PublisherWarning.Visibility = Visibility.Hidden;
            }
        }
    }
}
