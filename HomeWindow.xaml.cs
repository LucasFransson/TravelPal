using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.Pkcs;
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
using TravelPal.Managers;
using TravelPal.Models;
using TravelPal.ViewModels;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    { 
        UserViewModel _userViewModel;    // Declare the UserViewModel that will handle the databinding/ Connection between the View ( UI ) and the Model ( User )
        public HomeWindow()
        {
            InitializeComponent();
            User user = (User)UserManager.SignedInUser;     // Create an instance of the User class and reference it to the UserManager.SignedInUser
            _userViewModel = new(user);      // Create an instance of the UserViewModel and assign the new User instance to the UserViewModels User property
            DataContext = _userViewModel;    // Set the Datacontext to the UserViewModel. From now on any changes to either SignedInUser or the User instance will update the userviewmodel         
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            UserManager.LogOutUser(this);   // Logs out the User, Closes this window and opens the start(main) window
        }
      
        private void btnRemoveTravel_Click(object sender, RoutedEventArgs e)
        {
            if (lvBookedTravels.SelectedItem != null)   // Checks if an item (Travel object) in the listview is selected
            {
                UserManager.SignedInUser.travels.Remove(lvBookedTravels.SelectedItem as Travel);    // Casts the Selected ListViewItem to a Travel object and Removes it from the Signed in Users <Travel> List
                MessageBox.Show($"You have removed the selected Travel Plan! ", "Travel Plan Removed");
            }
            else { MessageBox.Show("You must select a Travel Plan to remove","Error: No Travel Plan Selected"); }
        }

        private void btnOpenAddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWin = new(_userViewModel);
            addTravelWin.Show();
            //this.Close();
        }

        private void btnTravelDetails_Click(object sender, RoutedEventArgs e)
        {
            TravelDetailsWindow travelDetailsWin = new(lvBookedTravels.SelectedItem as Travel,_userViewModel);
            travelDetailsWin.Show();
            this.Close();
        }
        private void btnAccountSettings_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow userDetailsWin = new(_userViewModel);
            userDetailsWin.Show();
            this.Close();
        }
        private void btnAboutUs_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. \r\nUt enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.");
        }
    }
}
