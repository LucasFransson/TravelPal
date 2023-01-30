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
using TravelPal.Managers;

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

        }

        private void btnAboutUs_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveTravel_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignedInAdmin.RemoveSelectedTravel(lvBookedTravels);
        }

        private void btnAccountSettings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnShowUsers_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignedInAdmin.ShowAllUsers(lvBookedTravels);
        }

        private void btnShowAllTravels_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignedInAdmin.ShowAllTravels(lvBookedTravels);
        }
    }
}
