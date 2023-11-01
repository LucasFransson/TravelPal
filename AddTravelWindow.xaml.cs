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
using TravelPal.Models;
using TravelPal.Managers;
using TravelPal.Enums;
using TravelPal.Interfaces;
using System.Collections.ObjectModel;
using TravelPal.ViewModels;


namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        UserViewModel _userViewModel;
        Travel _travelFromEdit;

        private TravelTypes _travelType = TravelTypes.None;    // Sets the TravelType to 'None' to prevent Crashes if no TravelType is chosen
        
        // Constructor for creating a new Travel from opening "Create new Travel"
        public AddTravelWindow(UserViewModel userViewModel)     
        {
            InitializeComponent();

            _userViewModel = userViewModel;
            DataContext = _userViewModel;    // Sets the DataContext to the ViewModel

            // Loading neccesary Data/Values into the empty View-Elements     // Could be refactored and set in the View/XAML Code instead
            cboTravelType.Items.Add(Enum.GetName(typeof(TravelTypes), TravelTypes.Vacation));
            cboTravelType.Items.Add(Enum.GetName(typeof(TravelTypes), TravelTypes.Trip));
            cboDestinationCountry.ItemsSource = Enum.GetNames(typeof(Countries));     // Sets the combobox itemssource to the Countries Enum
            cboTripType.ItemsSource = Enum.GetNames(typeof(TripTypes));    // Sets the combobox itemssource to the TripTypes Enum
            dtpStart.BlackoutDates.AddDatesInPast();    // Blackouts dates that are unavailable 
            dtpEnd.BlackoutDates.AddDatesInPast();

            TravelManager.CheckMandatoryInputForSaving(_travelType, txtDestination, dtpStart, dtpEnd, cboDestinationCountry, txtTravelerNr, btnSaveTravelInfo, cboTripType);  // Check for enabling 'Save' button
        }

        // Constructor For opening an existing Travel from "Edit Travel" 
        public AddTravelWindow(UserViewModel userViewModel,Travel travel)   
        {
            InitializeComponent();

            _userViewModel = userViewModel;
            _travelFromEdit = travel;

            DataContext = _userViewModel;    // Sets the DataContext to the ViewModel
            _userViewModel.CurrentPackingList = travel.PackingList; // Sets the CurrentPackingList to the Travel objects PackingList

            // Loading neccesary Data/Values into the empty View-Elements     // Could be refactored and set in the View/XAML Code instead
            cboTravelType.Items.Add(Enum.GetName(typeof(TravelTypes), TravelTypes.Vacation));
            cboTravelType.Items.Add(Enum.GetName(typeof(TravelTypes), TravelTypes.Trip));
            cboDestinationCountry.ItemsSource = Enum.GetNames(typeof(Countries));     // Sets the combobox itemssource to the Countries Enum
            cboTripType.ItemsSource = Enum.GetNames(typeof(TripTypes));    // Sets the combobox itemssource to the TripTypes Enum
            dtpStart.BlackoutDates.AddDatesInPast();    // Blackouts dates that are unavailable 
            dtpEnd.BlackoutDates.AddDatesInPast();

            // Parse the Information and Values from the Existing Travel Object and setting it to the View-Elements
            txtDestination.Text = travel.Destination;
            cboDestinationCountry.Text = travel.Country.ToString();

            txtTravelerNr.Text = travel.NumberOfTravellers.ToString();
            dtpStart.Text = travel.StartDate.ToString();
            dtpEnd.Text = travel.EndDate.ToString();

            if (travel is Vacation vacation)
            {
                cboTravelType.Text = "Vacation";
                rbtnAllInclusive.Visibility = Visibility.Visible;
                rbtnAllInclusive.IsChecked = true;
            }
            else if (travel is Trip trip)
            {
                cboTravelType.Text = "Trip";
                cboTripType.Visibility = Visibility.Visible;
                cboTripType.Text = Enum.GetName(typeof(TripTypes),trip.Type);
            }

            TravelManager.CheckMandatoryInputForSaving(_travelType, txtDestination, dtpStart, dtpEnd, cboDestinationCountry, txtTravelerNr, btnSaveTravelInfo, cboTripType);    // Check for enabling 'Save' button
        }
        
        private void btnSaveTravelInfo_Click(object sender, RoutedEventArgs e)
        {
            // Correct Input Checking 
            bool isNrOk = int.TryParse(txtTravelerNr.Text, out int number);     // Tries to parse the text from tbxTravelerNr to an integer
            if (!isNrOk)   // If the parse failed
            {
                MessageBox.Show("Please only enter numbers into the \"Number of Travellers\" Field.", "Wrong Input");
                return; // If the textbox was not parsable to an int call "return" to stop the rest of code to execute.
            }

            else if (!TravelManager.IsStartDateBeforeEndDate(dtpStart.SelectedDate, dtpEnd.SelectedDate))    // Checks so that the endDate is not before the startDate in time
            {
                MessageBox.Show("The Start Date must be before the End Date.", "Wrong Date Input");
                return; // If the Dates were not correct call "return" to stop the rest of code to execute. 
            }

            if (_travelFromEdit != null)
            {
                UserManager.SignedInUser.travels.Remove(_travelFromEdit);
            }

            // If all the User Inputs are correct 
            // Creating and Saving a Travel
            if (_travelType == TravelTypes.Vacation) // If Travel is Vacation
            {
                bool isAllInclusive = false;
                if (rbtnAllInclusive.IsChecked == true) { isAllInclusive = true; }

                Vacation newVacation = TravelManager.CreateVacation(txtDestination.Text,
                                                     UserManager.ParseStringToCountryEnum(cboDestinationCountry.SelectedItem.ToString()),
                                                     int.Parse(txtTravelerNr.Text),
                                                     dtpStart.SelectedDate,
                                                     dtpEnd.SelectedDate,
                                                     isAllInclusive);

                newVacation.PackingList = _userViewModel.CurrentPackingList;    // Sets the objects List<IpackingItem> to this windows List<IPackingItem>
                newVacation.CreatedByUserID = UserManager.SignedInUser.UserID;  // Sets the Vacation objects "CreatedByUserID" to the same id as "SignedInUser.UserID"
                UserManager.SignedInUser.travels.Add(newVacation);    // Adds the Vacation to the SignedInUsers List of Travels
                MessageBox.Show("You have succesfully added a Vacation Plan!", "Travel Plan Added");

                // Returns to HomeWindow and Close this Window
                ViewHandler.OpenHomeWindowCloseThis(this);
            }

            else if (_travelType == TravelTypes.Trip) // If Travel is Trip
            {
                Trip newTrip = TravelManager.CreateTrip(txtDestination.Text,
                                             UserManager.ParseStringToCountryEnum(cboDestinationCountry.SelectedItem.ToString()),
                                             int.Parse(txtTravelerNr.Text),
                                             dtpStart.SelectedDate,
                                             dtpEnd.SelectedDate,
                                             TravelManager.ParseStringToTripTypeEnum(cboTripType.SelectedItem.ToString()));

                newTrip.PackingList = _userViewModel.CurrentPackingList;    // Sets the objects List<IpackingItem> to this windows List<IPackingItem>
                newTrip.CreatedByUserID = UserManager.SignedInUser.UserID;  // Sets the Trip objects "CreatedByUserID" to the same id as "SignedInUser.UserID"
                UserManager.SignedInUser.travels.Add(newTrip);    // Adds the Trip to the SignedInUsers List of Travels
                MessageBox.Show("You have succesfully added a Trip Plan!", "Travel Plan Added");

                // Returns to HomeWindow and Close this Window
                ViewHandler.OpenHomeWindowCloseThis(this);
            }

            else { MessageBox.Show("There was an Error creating your Travel Plan. Please make sure you have correctly filled in all the fields and Try Again.", "Unknown Error"); }    // Unknown error message box, Failsafe for unknown Errors (Redundant?)
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            // Returns to HomeWindow and Close this Window
            ViewHandler.OpenHomeWindowCloseThis(this);
        }

        private void cboTravelType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Changes visibility of elements connected to specific Types of Travel
            switch (cboTravelType.SelectedItem.ToString())     
            {
                case "Vacation":
                    {
                        _travelType = TravelTypes.Vacation;     // Sets the traveltype variable to "Vacation"

                        rbtnAllInclusive.Visibility = Visibility.Visible;
                        cboTripType.Visibility = Visibility.Collapsed;
                        lblTripTypes.Visibility = Visibility.Collapsed;

                        TravelManager.CheckMandatoryInputForSaving(_travelType, txtDestination, dtpStart, dtpEnd, cboDestinationCountry, txtTravelerNr, btnSaveTravelInfo, cboTripType);    // Check for enabling 'Save' button
                        break;
                    }

                case "Trip":
                    {
                        _travelType = TravelTypes.Trip;     // Sets the traveltype variable to "Trip"

                        rbtnAllInclusive.Visibility = Visibility.Collapsed;
                        cboTripType.Visibility = Visibility.Visible;
                        lblTripTypes.Visibility = Visibility.Visible;

                        TravelManager.CheckMandatoryInputForSaving(_travelType, txtDestination, dtpStart, dtpEnd, cboDestinationCountry, txtTravelerNr, btnSaveTravelInfo, cboTripType);    // Check for enabling 'Save' button
                        break;
                    }

                default:
                    {
                        _travelType = TravelTypes.None;      // Sets the traveltype variable to "None". Should not ever happen but IF it does the 'Save' button will not be enabled + the Failsafe code in the 'Save' button will handle this in case it would be enabled.

                        TravelManager.CheckMandatoryInputForSaving(_travelType, txtDestination, dtpStart, dtpEnd, cboDestinationCountry, txtTravelerNr, btnSaveTravelInfo, cboTripType);    // Check for enabling 'Save' button
                        break;
                    }
            }
        }

        private void cbxIsDocument_Click(object sender, RoutedEventArgs e)
        {
            // Toggles Visibility on and off Depending if the Checkbox 'Is Document' is Checked or not 
            if (cbxIsRequired.Visibility == Visibility.Collapsed)   // Enable Elements connected to 'TravelDocument' and Hide 'OtherItem' Elements
            {
                cbxIsRequired.Visibility = Visibility.Visible;
                lblQuantity.Visibility = Visibility.Collapsed;
                tbxQtyInput.Visibility = Visibility.Collapsed;            
            } 
            else    // Enable Elements Connected to 'OtherItem' and Hide 'TravelDocument' Elements
            {
                cbxIsRequired.Visibility = Visibility.Collapsed;
                tbxQtyInput.Visibility = Visibility.Visible;
                lblQuantity.Visibility = Visibility.Visible;
            }
        }

        private void btnPackAdd_Click(object sender, RoutedEventArgs e)
        {
            // Creating TravelDocument
            if(cbxIsDocument.IsChecked== true) 
            {
                bool isRequired = false;    // Initialises a bool that will handle the value from cbxIsRequired, sets the starting value to false. 
                if(cbxIsRequired.IsChecked== true) { isRequired= true; }

                TravelDocument tDoc = new(txtPackingItem.Text,isRequired);
                _userViewModel.CurrentPackingList.Add(tDoc);

            }
            // Creating OtherItem
            else  
            {
                bool isNrOk = int.TryParse(tbxQtyInput.Text, out int number);     // Tries to parse the text from tbxQtyInput to an integer
                if (!isNrOk || string.IsNullOrEmpty(tbxQtyInput.Text))   // If the parse failed or If input is null or empty stop the method
                {
                    MessageBox.Show("You must enter a number in the \"Quantity\" Field.", "Wrong Input");
                    return; // If the textbox was not parsable to an int "return" to stop the rest of code to execute.
                }
                
                OtherItem oItem = new(txtPackingItem.Text, int.Parse(tbxQtyInput.Text));
                _userViewModel.CurrentPackingList.Add(oItem);
            }
        }

        private void btnPackRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lvPackingList.SelectedItem != null)
            {
                _userViewModel.CurrentPackingList.Remove(lvPackingList.SelectedItem as IPackingListItem);
            }
            else { MessageBox.Show("You must select an item from the packing list to remove!", "Error"); }
        }


        // Code for checking if input fields are valid
        // There was a lot of work/problem with solving this problem by using the MVVM-pattern for me and the "working" code I ended up with was not good, so I choose to instead just create a method(CheckMandatoryInputForSaving()) that
        // Checks if every mandatory input field isn't empty and then create ...Changed() methods on every related element and then run the CheckMandatoryInputForSaving-method on every single elements ...Changed() Method

        private void txtDestination_TextChanged(object sender, TextChangedEventArgs e)
        {
            TravelManager.CheckMandatoryInputForSaving(_travelType, txtDestination, dtpStart, dtpEnd, cboDestinationCountry, txtTravelerNr, btnSaveTravelInfo, cboTripType);
        }

        private void cboDestinationCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TravelManager.CheckMandatoryInputForSaving(_travelType, txtDestination, dtpStart, dtpEnd, cboDestinationCountry, txtTravelerNr, btnSaveTravelInfo, cboTripType);
            TravelManager.ManageAutoItemPassPort(cboDestinationCountry,_userViewModel);   // Method build up of smaller methods that handles everything related to the 'TravelDocument' "PassPort"
        }

        private void dtpStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            TravelManager.CheckMandatoryInputForSaving(_travelType, txtDestination, dtpStart, dtpEnd, cboDestinationCountry, txtTravelerNr, btnSaveTravelInfo, cboTripType);
        }

        private void dtpEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            TravelManager.CheckMandatoryInputForSaving(_travelType, txtDestination, dtpStart, dtpEnd, cboDestinationCountry, txtTravelerNr, btnSaveTravelInfo, cboTripType);
        }

        private void txtTravelerNr_TextChanged(object sender, TextChangedEventArgs e)
        {
            TravelManager.CheckMandatoryInputForSaving(_travelType, txtDestination, dtpStart, dtpEnd, cboDestinationCountry, txtTravelerNr, btnSaveTravelInfo, cboTripType);
        }

        private void cboTripType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            TravelManager.CheckMandatoryInputForSaving(_travelType, txtDestination, dtpStart, dtpEnd, cboDestinationCountry, txtTravelerNr, btnSaveTravelInfo, cboTripType);
        }
    }

}
