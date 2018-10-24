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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public User currentUser = new User();
        public ObservableCollection<User> userList = XMLHandler.ReadFromMemory(); //Contains the complete list of users in xml database
        public Login()
        {
            InitializeComponent();
        
        }

        private void ExitProgram_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Help_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is the student database project login screen");
        }

        private void Login_click(object sender, RoutedEventArgs e)
        {
            if (login_authenticate())
            {
                MainWindow win = new MainWindow(currentUser);
                win.Show();
                this.Close(); //Opens up user profile, closes login window
            }
            else
            {
                MessageBox.Show("Incorrect username or password. Make sure you typed your account details correctly or consider registering a new account");
            }
        }

        private bool login_authenticate()
        {
            var currentUsers = from s in userList
                               where (s.Username == usernameInput.Text && s.Password == passwordInput.Password)
                               select s;
            if (currentUsers.Count() == 0)  //This means there were no Users in User.xml where the username and password matched  
            {
                return false;
            }
            return true;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            //Put something in here that directs you to the register
            //Register win = new Reigster()
            //win.ShowDisplay();
        }
    }
}
