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
using TravelPal.Enums;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            cboCountry.ItemsSource = Enum.GetNames(typeof(EUCountries));
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (!UserManager.CheckUserNameAvailability(tbxUserName.Text)) // Checks if the username is taken
            {
                MessageBox.Show($"The Username {tbxUserName.Text} is not avaialable!");
                return;     // Return to stop the rest of this functions code to execute
            }

            User newUser = UserManager.CreateUser(tbxFirstName.Text,    // Create a User Object
                                                  tbxLastName.Text,
                                                  tbxUserName.Text,
                                                  tbxPassword.Text,
                                                  UserManager.ParseStringToCountryEnum(cboCountry.SelectedItem.ToString())
                                                  );
            UserManager.AddIUserToList(newUser);    // Add a User Object to the UserManagers "users" List
            MessageBox.Show("You have sucesfully registered!", "Succes");

            MainWindow mainWin = new();
            mainWin.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new();
            mainWin.Show();
            this.Close();
        }
    }
}
