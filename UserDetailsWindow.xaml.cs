using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
using TravelPal.ViewModels;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {

        UserViewModel _userViewModel;

        // Moved colors to ViewHandler class 
        // Color _highlightedBlueColor = (Color)ColorConverter.ConvertFromString("#FF91E4E9");
        // Color _defaultWhiteColor = (Color)ColorConverter.ConvertFromString("#FFCCD3D4");
        public UserDetailsWindow(UserViewModel userViewModel)
        {
            InitializeComponent();

            _userViewModel = userViewModel;
            DataContext = _userViewModel;

            cboLocation.ItemsSource = Enum.GetNames(typeof(EUCountries));
        }

        private void btnLastNameSave_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignedInUser.LastName = tbxLastName.Text;
            btnLastNameSave.Visibility= Visibility.Collapsed;
        }

        private void btnFirstNameSave_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignedInUser.FirstName = tbxFirstName.Text;
            btnFirstNameSave.Visibility= Visibility.Collapsed;
        }

        private void btnUserNameSave_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignedInUser.UserName = tbxUsername.Text;
            btnUserNameSave.Visibility= Visibility.Collapsed;
        }
        private void btnCountrySave_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignedInUser.Location=UserManager.ParseStringToCountryEnum(cboLocation.SelectedItem.ToString());
            cboLocation.Visibility= Visibility.Collapsed;    // Hides the combobox after saving the new country location
            btnCountrySave.Visibility= Visibility.Collapsed;
         
        }

        private void btnSavePassword_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignedInUser.Password = tbxNewPassword.Text;
            ToggleInputElementsOff();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            // Returns to HomeWindow and Close this Window
            ViewHandler.OpenHomeWindowCloseThis(this);
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            //ToggleInputElementsComboboxOff();    // Collapses the Elements Connected to Change Location
            ToggleInputElementsOn();     // Enables Elements Connected to Change Password. Must be in this order since both use the same button
        }
        private void btnChangeLocation_Click(object sender, RoutedEventArgs e)
        {

            ViewHandler.ChangeNViewElementsForeground<FrameworkElement>(ViewHandler.highlightedBlueColor, btnChangeLocation, lblCountry);
            ViewHandler.ChangeNViewElementsForeground<FrameworkElement>(ViewHandler.defaultWhiteColor,btnChangeUserName, btnChangeFirstName, btnChangeLastName,lblUserName, lblFirstName, lblLastName);
     
            //ToggleInputElementsOff();     // Collapses the Elements Connected to Change Password
            ToggleInputElementsComboboxOn();     // Enables Elements Connected to Change Location

        }

        private void btnChangeUserName_Click(object sender, RoutedEventArgs e)
        {

            ViewHandler.ChangeNViewElementsForeground<FrameworkElement>(ViewHandler.highlightedBlueColor, btnChangeUserName, lblUserName);
            ViewHandler.ChangeNViewElementsForeground<FrameworkElement>(ViewHandler.defaultWhiteColor,btnChangeFirstName,btnChangeLastName,btnChangeLocation,lblFirstName,lblLastName,lblCountry);

            tbxUsername.IsReadOnly = false;
            tbxFirstName.IsReadOnly = true;
            tbxLastName.IsReadOnly = true;

            // Second Refactoring
            //ViewHandler.ChangeNViewElementsForeground(ViewHandler.highlightedBlueColor,lblUsername);
            //ViewHandler.ChangeNViewElementsForeground(ViewHandler.defaultWhiteColor, lblFirstName,lblLastName);

            // First Refactoring
            //ViewHandler.ChangeViewElementForeground(lblUsername, ViewHandler.highlightedBlueColor);

            // Init
            //lblUsername.Foreground = new SolidColorBrush(_highlightedBlueColor);
            //lblFirstName.Foreground = new SolidColorBrush(_defaultWhiteColor);
            //lblLastName.Foreground = new SolidColorBrush(_defaultWhiteColor);
        }

        private void btnChangeFirstName_Click(object sender, RoutedEventArgs e)
        {
            ViewHandler.ChangeNViewElementsForeground<FrameworkElement>(ViewHandler.highlightedBlueColor, btnChangeFirstName, lblFirstName);
            ViewHandler.ChangeNViewElementsForeground<FrameworkElement>(ViewHandler.defaultWhiteColor,btnChangeUserName,btnChangeLastName,btnChangeLocation,lblUserName,lblLastName,lblCountry);

            tbxUsername.IsReadOnly = true;
            tbxFirstName.IsReadOnly = false;
            tbxLastName.IsReadOnly = true;
        }

        private void btnChangeLastName_Click(object sender, RoutedEventArgs e)
        {
            ViewHandler.ChangeNViewElementsForeground<FrameworkElement>(ViewHandler.highlightedBlueColor,btnChangeLastName, lblLastName);
            ViewHandler.ChangeNViewElementsForeground<FrameworkElement>(ViewHandler.defaultWhiteColor,btnChangeUserName,btnChangeFirstName,btnChangeLocation,lblUserName,lblFirstName,lblCountry);

            tbxUsername.IsReadOnly = true;
            tbxFirstName.IsReadOnly = true;
            tbxLastName.IsReadOnly = false;
            
        }

        private void cboLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnCountrySave.Visibility = Visibility.Visible;
        }

        private void tbxUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbxUsername.IsReadOnly == false)
            {
                btnUserNameSave.Visibility = Visibility.Visible;
            }
        }

        private void tbxFirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbxFirstName.IsReadOnly == false)
            {
                btnFirstNameSave.Visibility = Visibility.Visible;
            }
        }


        private void tbxLastName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbxLastName.IsReadOnly == false)
            {
                btnLastNameSave.Visibility = Visibility.Visible;
            }
        }


        // View Methods => Refactor to ViewHandler 
        public void ToggleInputElementsComboboxOff()    // This Method was creates when I had a completely different layout for changing User Settings, this is safe to remove and replace with the line of code that's inside the method from where it's called
        {
            cboLocation.Visibility = Visibility.Collapsed;
        }

        public void ToggleInputElementsComboboxOn()     // This Method was creates when I had a completely different layout for changing User Settings, this is safe to remove and replace with the line of code that's inside the method from where it's called
        {
            cboLocation.Visibility = Visibility.Visible;
        }

        public void ToggleInputElementsOff()
        {
            tbxNewPassword.Visibility = Visibility.Collapsed;
            lblNewPassword.Visibility = Visibility.Collapsed;
            btnSavePassword.Visibility = Visibility.Collapsed;
        }

        public void ToggleInputElementsOn()
        {
            tbxNewPassword.Visibility = Visibility.Visible;
            lblNewPassword.Visibility = Visibility.Visible;
            btnSavePassword.Visibility = Visibility.Visible;
        }


    }
}
