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

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
 
        private TravelTypes _travelType = TravelTypes.None;
        public AddTravelWindow()
        {
            InitializeComponent();
            cboTravelType.Items.Add(Enum.GetName(typeof(TravelTypes), TravelTypes.Vacation));
            cboTravelType.Items.Add(Enum.GetName(typeof(TravelTypes), TravelTypes.Trip));




            cboDestinationCountry.ItemsSource = Enum.GetNames(typeof(Countries));     // Sets the combobox itemssource to the Countries Enum
            cboTripType.ItemsSource = Enum.GetNames(typeof(TripTypes));    // Sets the combobox itemssource to the TripTypes Enum
            dtpStart.BlackoutDates.AddDatesInPast();    // Blackouts dates that are unavailable 
            dtpEnd.BlackoutDates.AddDatesInPast();

            TravelManager.CheckMandatoryInputForSaving(_travelType, txtDestination, dtpStart, dtpEnd, cboDestinationCountry, txtTravelerNr, btnSaveTravelInfo, cboTripType);
        }
        
        private void btnSaveTravelInfo_Click(object sender, RoutedEventArgs e)
        {


            bool isNrOk = int.TryParse(txtTravelerNr.Text, out int number);     // Tries to parse the text from tbxTravelerNr to an integer
            if (!isNrOk )   // If the parse failed
            {
                MessageBox.Show("Please only enter numbers into the \"Number of Travellers\" Field.", "Wrong Input");
                return; // If the textbox was not parsable to an int "return" to stop the rest of code to execute.
            } 


            if (_travelType == TravelTypes.Vacation)
            {
                bool isAllInclusive = false; 
                if(rbtnAllInclusive.IsChecked== true) { isAllInclusive = true; }

                Vacation newVacation = TravelManager.CreateVacation(txtDestination.Text,
                                                     UserManager.ParseStringToCountryEnum(cboDestinationCountry.SelectedItem.ToString()),
                                                     int.Parse(txtTravelerNr.Text),
                                                     dtpStart.SelectedDate,
                                                     dtpEnd.SelectedDate,
                                                     isAllInclusive);

                UserManager.SignedInUser.travels.Add(newVacation);
                MessageBox.Show("You have succesfully added a Vacation Plan!", "Travel Plan Added");
            }

            else if (_travelType == TravelTypes.Trip )
            {
                Trip newTrip = TravelManager.CreateTrip(txtDestination.Text,
                                             UserManager.ParseStringToCountryEnum(cboDestinationCountry.SelectedItem.ToString()),
                                             int.Parse(txtTravelerNr.Text),
                                             dtpStart.SelectedDate,
                                             dtpEnd.SelectedDate,
                                             TravelManager.ParseStringToTripTypeEnum(cboTripType.SelectedItem.ToString()));

                UserManager.SignedInUser.travels.Add(newTrip);
                MessageBox.Show("You have succesfully added a Trip Plan!", "Travel Plan Added");
            }

            //else
            //{
            // Unknown error message box? Failsafe?
            //    MessageBox.Show("You must choose either \"Trip\" or \"Vacation\". Please make sure you have correctly filled in all the fields.", "Error");
            //}

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWin = new();
            homeWin.Show();
            this.Close();
        }

        private void cboTravelType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            switch (cboTravelType.SelectedItem.ToString())      // Changes visibility of elements connected to specific Types of Travel
            {
                case "Vacation":
                    {
                        _travelType = TravelTypes.Vacation;     // Sets the traveltype variable to "Vacation"

                        rbtnAllInclusive.Visibility = Visibility.Visible;
                        cboTripType.Visibility = Visibility.Collapsed;

                        TravelManager.CheckMandatoryInputForSaving(_travelType, txtDestination, dtpStart, dtpEnd, cboDestinationCountry, txtTravelerNr, btnSaveTravelInfo, cboTripType);
                        break;
                    }
                   
                case "Trip":
                    {
                        _travelType = TravelTypes.Trip;     // Sets the traveltype variable to "Trip"

                        rbtnAllInclusive.Visibility = Visibility.Collapsed;
                        cboTripType.Visibility = Visibility.Visible;

                        TravelManager.CheckMandatoryInputForSaving(_travelType, txtDestination, dtpStart, dtpEnd, cboDestinationCountry, txtTravelerNr, btnSaveTravelInfo, cboTripType);
                        break;
                    }
                    
                default:
                    {
                        _travelType = TravelTypes.None;      // Sets the traveltype variable to "None"

                        TravelManager.CheckMandatoryInputForSaving(_travelType, txtDestination, dtpStart, dtpEnd, cboDestinationCountry, txtTravelerNr, btnSaveTravelInfo, cboTripType);
                        break;
                    }
            }
        }


        // Code for checking if input fields are valid
        // There was a lot of work/problem with solving this problem by using the MVVM-pattern for me and the "working" code I ended up with was not good, so I choose to instead just create a method(CheckMandatoryInputForSaving()) that
        // Checks if every mandatory input field isn't empty and then create ...Changed() methods on every related element and then run the CheckMandatoryInputForSaving-method on every single elements ...Changed() Method
        // This is a more crude and basic solution but it is more reliable and easier to read

        private void txtDestination_TextChanged(object sender, TextChangedEventArgs e)
        {
            TravelManager.CheckMandatoryInputForSaving(_travelType, txtDestination, dtpStart, dtpEnd, cboDestinationCountry, txtTravelerNr, btnSaveTravelInfo, cboTripType);
        }

        private void cboDestinationCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TravelManager.CheckMandatoryInputForSaving(_travelType, txtDestination, dtpStart, dtpEnd, cboDestinationCountry, txtTravelerNr, btnSaveTravelInfo, cboTripType);
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
            
            TravelManager.CheckMandatoryInputForSaving(_travelType, txtDestination,dtpStart,dtpEnd,cboDestinationCountry,txtTravelerNr,btnSaveTravelInfo,cboTripType);
        }
    }

}
