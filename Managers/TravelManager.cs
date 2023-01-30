using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TravelPal.Enums;
using TravelPal.Interfaces;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public static class TravelManager
    {

        // Test puropses only
        // Creates and returns a new Travel Object
        public static Travel CreateTravel(string destination,Countries country,int numberOfTravelers,DateTime start,DateTime end)
        {
            return new Travel(destination,country,numberOfTravelers,start,end);
        }

        // Creates and returns a new Trip Object
        public static Trip CreateTrip(string destination, Countries country, int numberOfTravelers, DateTime? start, DateTime? end,TripTypes type)
        {
            return new Trip(destination, country, numberOfTravelers, start, end,type);
        }

        // Creates and returns a new Vacation Object
        public static Vacation CreateVacation(string destination, Countries country, int numberOfTravelers, DateTime? start, DateTime? end, bool isAllInclusive)
        {
            return new Vacation(destination, country, numberOfTravelers, start, end, isAllInclusive);
        }

        public static TripTypes ParseStringToTripTypeEnum(string stringToParse)
        {
            return (TripTypes)Enum.Parse(typeof(TripTypes), stringToParse);
        }


        // Not in use due to databinding and Itemssource instead
        public static void DisplayPackingListToListView (ObservableCollection<IPackingListItem> list, ListView lv)
        {
                lv.Items.Clear(); // Clears the listview before adding the content

                foreach (var item in list)
                {
                    lv.Items.Add(item.GetInfo());
                }
        }

        // Not in use due to databinding and Itemssource instead
        //public static void DisplayPackingListToListView(Travel travel,ListView lv)
        //{
        //    if (travel != null)
        //    {
        //        lv.Items.Clear(); // Clears the listview before adding the content

        //        foreach (var item in travel.PackingList)
        //        {
        //            lv.Items.Add(item.GetInfo());
        //        }
        //    }
        //}
        // Displays formated text information about a specific Travel object and displays it in a Textbox
        public static void DisplayTravelDetailsTextBox(Travel travel,TextBox tbx)
        {
            if (travel != null)     // null check to prevent crashes from occuring when removing a travel object w using SelectionChanged event
            {
                string travelInformation = travel.GetInfo();
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Destination: {travel.Destination}");
                if (travel is Trip trip)
                {
                    sb.AppendLine("Trip");
                    sb.AppendLine($"Type: {trip.Type}");
                }
                else if (travel is Vacation vacation)
                {
                    sb.AppendLine("Vacation");
                    sb.AppendLine($"All Inclusive: {vacation.IsAllInClusive}");
                }

                sb.AppendLine($"Destination Country: {travel.Country}");
                sb.AppendLine($"Number Of Travellers: {travel.NumberOfTravellers}");
                sb.AppendLine($"StartDate: {travel.StartDate}");
                sb.AppendLine($"EndDate: {travel.EndDate}");
                sb.AppendLine($"Duration: {travel.TravelDuration} days");

                tbx.Text = sb.ToString();
            }
        }

        public static void LoadTestTravels()
        {
            Trip trip = CreateTrip("Ankeborg", Countries.UnitedStates, 1, DateTime.Now, DateTime.Now, TripTypes.Work);
            Vacation vacation = CreateVacation("Mustafar",Countries.Australia,3,DateTime.Now,DateTime.Now,false);
            UserManager.SignedInUser.travels.Add(trip);
            UserManager.SignedInUser.travels.Add(vacation);
        }

        public static void CheckMandatoryInputForSaving(TravelTypes travelType, TextBox tbxDestination, DatePicker dtpStart, DatePicker dtpEnd, ComboBox cboDestinationCountry, TextBox tbxTravelerNr, Button btnSaveTravelInfo, ComboBox cboTripType)
        {
            if (travelType == TravelTypes.Vacation
                        && tbxDestination.Text.Length != 0
                        && dtpStart.SelectedDate != null
                        && dtpEnd.SelectedDate != null
                        && cboDestinationCountry.SelectedItem != null
                        && tbxTravelerNr.Text.Length != 0
                        )
            {
                btnSaveTravelInfo.IsEnabled = true;
            }
            else if (travelType == TravelTypes.Trip
                                    && tbxDestination.Text.Length != 0
                                    && dtpStart.SelectedDate != null
                                    && dtpEnd.SelectedDate != null
                                    && cboDestinationCountry.SelectedItem != null
                                    && cboTripType.SelectedItem != null
                                    && tbxTravelerNr.Text != null
                                    )
            {
                btnSaveTravelInfo.IsEnabled = true;
            }
            else
            {
                btnSaveTravelInfo.IsEnabled = false;
            }
        }
    }
}
