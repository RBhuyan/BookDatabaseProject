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
        List<string> GenreOptions = new List<string> { "Science Fiction", "Satire", "Action and Adventure", "Romance", "Horror", "Mystery", "Non-Fiction", "Poetry" };
        public Book EditingBook { get; set; }

        //XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Book>));


        public MainWindow()
        {
            InitializeComponent();
            //COMBOBOX.ItemsSource = GenreOptions;

            //BookCollection.Add(testing);

            try { BookCollection = XMLHandler.ReadStudentsFromMemory(); }
            catch (Exception ex)
            {
                Console.WriteLine("******* Unable to read xml file*********", ex.InnerException);
                MessageBox.Show($"Unable to read xml file\nInner Exception:{ex.InnerException.Message}");
            }

            XMLHandler.WriteToXML(BookCollection);

            listView.ItemsSource = BookCollection;
        }

        private void submit_click(object sender, RoutedEventArgs e)
        {
            BookRequest win = new BookRequest();
            win.ShowDialog();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
