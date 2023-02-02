using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using TravelPal.Interfaces;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _hasUserNameBeenClicked;
        private bool _hasPasswordBeenClicked;
        public MainWindow()
        {
            InitializeComponent();
            UserManager.PopulateTestUsers();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            if(UserManager.CheckLogin(UserManager.FindIUserByUsername(tbxUserName.Text), // Search the UserManager class "users" List and if a match is found, return it to a new IUser object  
                                                                      tbxUserName.Text,
                                                                      pbxPassword.Password)) // If an IUser object is found and the username and password matches with that IUser object return true else return false
            {
                UserManager.LogInIUser(tbxUserName, this);  // Logs in Users to "HomeWindow" and Admins to "AdminHomeWindow"

            }
            else { MessageBox.Show("Username or Password was not correct!", "Wrong Input"); }   // Display an Error Message 
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow regWin = new();
            regWin.Show();
            this.Close();

        }
        


        // Code for mimicking a "Watermark" on the textboxes
        private void tbxUserName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!_hasUserNameBeenClicked)
            {
                TextBox tbxUserName = sender as TextBox;
                tbxUserName.Text = String.Empty;
                _hasUserNameBeenClicked = true;
            }
        }
        private void tbxUserName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxUserName.Text == "")
            {
                tbxUserName.Text = "Enter Username";
                _hasUserNameBeenClicked = false;
            }
        }
        private void pbxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            tbxPasswordFacade.Visibility = Visibility.Collapsed;  // Sets the facadetextbox overlapping the pbx to collapsed visibility
        }
        private void tbxPasswordFacade_GotFocus(object sender, RoutedEventArgs e)
        {      
            pbxPassword.Focus(); // if the user clicks on the facadetextbox this method sets the focus to the pbx behind the tbx
            tbxPasswordFacade.Visibility = Visibility.Collapsed;
            _hasPasswordBeenClicked = true;

        }
        private void pbxPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pbxPassword.Password.Length==0 )
            {
                tbxPasswordFacade.Visibility = Visibility.Visible;
                _hasPasswordBeenClicked = false;
            }
        }
    }
}
