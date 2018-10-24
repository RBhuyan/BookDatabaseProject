using System;
using System.Collections.Generic;
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
    /// Interaction logic for CheckoutConfirm.xaml
    /// </summary>
    public partial class CheckoutConfirm : Window
    {
        public List<Book> CheckoutList;
        public Book CheckoutBook;
        public User EditingUser { get; set; }
        public Book EditingBook { get; set; }
        public CheckoutConfirm(Book checkoutBook, User user)
        {
            CheckoutBook = checkoutBook;
            List <Book>CheckoutList = new List<Book>();
            CheckoutList.Add(CheckoutBook);
            EditingUser = user;
            InitializeComponent();
            listView.ItemsSource = CheckoutList;
        }

        private void Confirm_click(object sender, RoutedEventArgs e)
        {
            //string waitlistMessage = "";
                foreach (Book s in MainWindow.BookCollection)
                {
                    if (s.Title == CheckoutBook.Title && CheckoutBook.AuthorFirstName == s.AuthorFirstName && CheckoutBook.AuthorLastName == s.AuthorLastName) //We cannot actually say b==s because the checkedout parameters will be different
                    {
                        if (String.IsNullOrEmpty(s.CheckedOut))
                        {
                            s.CheckedOut = EditingUser.UserID;
                        }
                        else if (s.CheckedOut == EditingUser.UserID)
                        {
                            MessageBox.Show("You have already checked this book out");
                        }
                        else
                        {
                            MessageBox.Show("That book is already checked out");
                        }
                    }
                }
            
            XMLHandler.WriteToXML(MainWindow.BookCollection, "Book.xml"); //Writes newly edited books to the public static BookCollection
            this.Close();
        }

        private void CancelConfirmation_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
