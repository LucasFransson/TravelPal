using System;
using System.Collections.Generic;
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
using TravelPal.Interfaces;
using TravelPal.Managers;
using TravelPal.Models;
using TravelPal.ViewModels;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        Travel _travel;
        UserViewModel _userViewModel;
        public TravelDetailsWindow(Travel travel,UserViewModel userViewModel)
        {
            InitializeComponent();

            _travel= travel;
            _userViewModel = userViewModel;

            UserManager.SignedInUser.UpdateUserTravel(_travel);
           
            DataContext = _userViewModel;

            TravelManager.DisplayTravelDetailsTextBox(travel, tbxTravelInfo);
        }

        private void btnEditTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow editTravelWin = new(_userViewModel,_travel);
            editTravelWin.Show();
            this.Close();
        }

        private void btnRemoveTravel_Click(object sender, RoutedEventArgs e)
        {
            if (lvTravelSelected.SelectedItem != null)   // Checks if an item (Travel object) in the listview is selected
            {
                UserManager.SignedInUser.travels.Remove(lvTravelSelected.SelectedItem as Travel);    // Casts the Selected ListViewItem to a Travel object and Removes it from the Signed in Users <Travel> List
                MessageBox.Show("You have Removed this Travel Plan!");
            }
            else { MessageBox.Show("You must select a Travel Plan to remove", "Error: No Travel Plan Selected"); }
        }

        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignedInUser.CurrentTravel.RemoveItem(lvTravelPackList.SelectedItem as IPackingListItem);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            // Returns to HomeWindow and Close this Window
            ViewHandler.OpenHomeWindowCloseThis(this);
        }

        private void lvTravelSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _travel = (Travel)lvTravelSelected.SelectedItem;    // Changes the Travel object to the newly selected Travel object

            UserManager.SignedInUser.UpdateUserTravel(_travel);
            TravelManager.DisplayTravelDetailsTextBox(_travel,tbxTravelInfo);

        }
    }
}
