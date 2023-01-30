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
using TravelPal.Interfaces;
using TravelPal.Managers;
using TravelPal.Models;
using TravelPal.ViewModels;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AdminHomeWindow.xaml
    /// </summary>
    public partial class AdminHomeWindow : Window
    {
        public AdminHomeWindow()
        {
            InitializeComponent();
            lblUserHeadline.Content = UserManager.SignedInAdmin.UserName;
        }

        private void btnTravelDetails_Click(object sender, RoutedEventArgs e)
        {
            // Only Users can see travels?
        }

        private void btnAboutUs_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. \r\nUt enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.");
        }

        private void btnRemoveTravel_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignedInAdmin.RemoveSelectedTravel(lvDisplay);
            UserManager.SignedInAdmin.ShowAllTravels(lvDisplay);    // Updates the listview view
        }

        //private void btnAccountSettings_Click(object sender, RoutedEventArgs e)
        //{
        //    // Only Users can change settings?
        //}

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignedInAdmin = null;
            ViewHandler.OpenNewWindow(typeof(MainWindow));
            this.Close();
        }

        private void btnShowUsers_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignedInAdmin.ShowAllUsers(lvDisplay);
        }

        private void btnShowAllTravels_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignedInAdmin.ShowAllTravels(lvDisplay);
        }
        private void btnShowAllTrips_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignedInAdmin.ShowAllTrips(lvDisplay);
        }

        private void btnShowAllVacations_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignedInAdmin.ShowAllVacations(lvDisplay);
        }
        private void btnRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            IUser userToRemove = UserManager.users.FirstOrDefault(u => u.UserName==lvDisplay.SelectedItem.ToString());     // Tries to Get the selectedItem as an IUser object
            if (userToRemove != null && userToRemove is User)    // If userToRemove isn't empty and is an User then remove the user from the UserManagers List of all users
            {
                UserManager.users.Remove(userToRemove);
                MessageBox.Show($"You have removed the User : {userToRemove.UserName}! ","User Removed");
                UserManager.SignedInAdmin.ShowAllUsers(lvDisplay);
            }
            else { MessageBox.Show("You must Select an User to remove!", "Error"); }
        }


    }
}
