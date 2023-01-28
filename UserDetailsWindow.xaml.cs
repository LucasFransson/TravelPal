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
using TravelPal.ViewModels;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {

        UserViewModel _userViewModel;
        Color _highlightedBlueColor = (Color)ColorConverter.ConvertFromString("#FF91E4E9");
        Color _defaultWhiteColor = (Color)ColorConverter.ConvertFromString("#FFCCD3D4");
        public UserDetailsWindow(UserViewModel userViewModel)
        {
            InitializeComponent();
            _userViewModel = userViewModel;
            DataContext = _userViewModel;

            //tbxFirstName.Text = UserManager.SignedInUser.FirstName;
            //tbxLastName.Text = UserManager.SignedInUser.LastName;
            //tbxUsername.Text = UserManager.SignedInUser.UserName;
            //tbxLocation.Text = UserManager.SignedInUser.Location.ToString();
            //tbxFirstName.Text = UserManager.SignedInUser.FirstName;

            cboLocation.ItemsSource = Enum.GetNames(typeof(EUCountries));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWin = new();
            homeWin.Show();
            this.Close();
        }
        private void btnSetNewInfo_Click(object sender, RoutedEventArgs e)
        {
            //switch (lblChangeInfo.Content)
            //{
            //    case "Change Username":
            //        {
            //            if (userManager.ValidateUserName(tbxNewInfoOne.Text) && (userManager.CheckUsernameRequirements(tbxNewInfoOne.Text)))
            //            {
            //                UserManager.ChangeUsername(user, tbxNewInfoOne.Text);
            //                MessageBox.Show("Username Successfully Changed!");
            //                ToggleInputElementsOff();
            //                break;
            //            }
            //            MessageBox.Show("An User with that username already exists!");
            //            break;
            //        }
            //    case "Change First Name":
            //        {
            //            UserManager.ChangeFirstName(user, tbxNewInfoOne.Text);
            //            MessageBox.Show("First Name Successfully Changed!");
            //            ToggleInputElementsOff();
            //            break;
            //        }
            //    case "Change Last Name":
            //        {
            //            UserManager.ChangeLastName(user, tbxNewInfoOne.Text);
            //            MessageBox.Show("Last Name Successfully Changed!");
            //            ToggleInputElementsOff();
            //            break;
            //        }
            //    case "Change Location":
            //        {
            //            UserManager.ChangeLocation(user, cboLocation.SelectedItem.ToString());
            //            MessageBox.Show("Location Successfully Changed!");
            //            ToggleInputElementsComboboxOff();
            //            break;
            //        }
            //    case "Change Password":
            //        {
            //            if (userManager.CheckPasswordRequirements(tbxNewInfoOne.Text))
            //            {
            //                UserManager.ChangePassword(user, tbxNewInfoOne.Text);
            //                MessageBox.Show("Password Successfully Changed!");
            //                ToggleInputElementsOff();

            //                break;
            //            }
            //            else
            //            {
            //                MessageBox.Show("Password does not meet the requirements. Password needs to be atleast 5 characters long.");
            //                break;
            //            }
            //        }
            //    default:
            //        {
            //            MessageBox.Show("Invalid Input");
            //            ToggleInputElementsOff();
            //            break;
            //        }
            //}
        }

        private void btnChangeUsername_Click(object sender, RoutedEventArgs e)
        {
            lblUsername.Foreground = new SolidColorBrush(_highlightedBlueColor);
            lblFirstName.Foreground = new SolidColorBrush(_defaultWhiteColor);
            lblLastName.Foreground = new SolidColorBrush(_defaultWhiteColor);
            tbxUsername.IsReadOnly = false;
            tbxFirstName.IsReadOnly = true;
            tbxLastName.IsReadOnly = true;

            //lblChangeInfo.Content = "Change Username";
            //lblChangeInfo.Visibility = Visibility.Visible;
            //ToggleInputElementsOn();
        }

        private void btnChangeFirstName_Click(object sender, RoutedEventArgs e)
        {
            lblUsername.Foreground = new SolidColorBrush(_defaultWhiteColor);
            lblFirstName.Foreground = new SolidColorBrush(_highlightedBlueColor);
            lblLastName.Foreground = new SolidColorBrush(_defaultWhiteColor);
            tbxUsername.IsReadOnly = true;
            tbxFirstName.IsReadOnly = false;
            tbxLastName.IsReadOnly = true;

            //lblChangeInfo.Content = "Change First Name";
            //ToggleInputElementsOn();
        }

        private void btnChangeLastName_Click(object sender, RoutedEventArgs e)
        {
            lblUsername.Foreground = new SolidColorBrush(_defaultWhiteColor);
            lblFirstName.Foreground = new SolidColorBrush(_defaultWhiteColor);
            lblLastName.Foreground = new SolidColorBrush(_highlightedBlueColor);
            tbxUsername.IsReadOnly = true;
            tbxFirstName.IsReadOnly = true;
            tbxLastName.IsReadOnly = false;
            //lblChangeInfo.Content = "Change Last Name";
            //ToggleInputElementsOn();
        }

        private void btnChangeLocation_Click(object sender, RoutedEventArgs e)
        {
            cboLocation.Visibility = Visibility.Visible;
            //lblChangeInfo.Content = "Change Location";
            //ToggleInputElementsComboboxOn();
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            //lblChangeInfo.Content = "Change Password";
            //ToggleInputElementsOn();
        }



        // ViewModel Methods => Refactore
        public void ToggleInputElementsComboboxOff()
        {
            cboLocation.Visibility = Visibility.Collapsed;
            btnSetNewInfo.Visibility = Visibility.Collapsed;
        }

        public void ToggleInputElementsComboboxOn()
        {
            cboLocation.Visibility = Visibility.Visible;
            btnSetNewInfo.Visibility = Visibility.Visible;
        }

        public void ToggleInputElementsOff()
        {
            tbxNewInfoOne.Visibility = Visibility.Collapsed;
            tbxNewInfoTwo.Visibility = Visibility.Collapsed;
            lblPassword.Visibility = Visibility.Collapsed;
            btnSetNewInfo.Visibility = Visibility.Collapsed;
        }

        public void ToggleInputElementsOn()
        {
            tbxNewInfoOne.Visibility = Visibility.Visible;
            tbxNewInfoTwo.Visibility = Visibility.Visible;
            lblPassword.Visibility = Visibility.Visible;
            btnSetNewInfo.Visibility = Visibility.Visible;
        }










        private void tbxUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbxUsername.IsReadOnly == false)
            {
                btnUserNameSave.Visibility = Visibility.Visible;
            }
        }

        private void tbxUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            btnUserNameSave.Visibility = Visibility.Collapsed;
        }

        private void tbxFirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbxFirstName.IsReadOnly == false)
            {
                btnFirstNameSave.Visibility = Visibility.Visible;
            }
        }

        private void tbxFirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            btnFirstNameSave.Visibility = Visibility.Collapsed;
        }

        private void tbxLastName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbxLastName.IsReadOnly == false)
            {
                btnLastNameSave.Visibility = Visibility.Visible;
            }
        }

        private void tbxLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            btnLastNameSave.Visibility = Visibility.Collapsed;
        }

        private void btnLastNameSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFirstNameSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUserNameSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
