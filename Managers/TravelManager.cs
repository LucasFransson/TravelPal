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
using TravelPal.ViewModels;

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

        // Checks that Starting Date is the same date as EndDate or before EndDate
        public static bool IsStartDateBeforeEndDate(DateTime? startDate, DateTime? endDate)
        {
            return startDate <= endDate;
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

        // Creates a travelDocument named "PassPort" and sets true/false depending on parameters
        public static TravelDocument CreatePassPort(bool isRequired)
        {
            return new TravelDocument("PassPort",isRequired);

        }

        // Iterates through the UserViewModel objects CurrentPackingList and checks if any item has the name "PassPort", returns true upon match
        public static bool DoesPackingListContainPassPort(UserViewModel userViewModel)
        {
            foreach(var item in userViewModel.CurrentPackingList)
            {
                if (item.Name == "PassPort")
                {
                    return true;
                }
            }
            return false;

        }

        // Changes a TravelDocument objects 'IsRequired' property to a new boolean value
        public static void ChangeTravelDocumentBoolValue(TravelDocument travelDocument,bool isRequired)
        {
            travelDocument.IsRequired = isRequired;
        }

        // Checks if the name of the Country exists in the EUCountries enum, return true if ít does 
        public static bool IsCountryInEU(string countryName)
        {
            foreach(var country in Enum.GetNames(typeof(EUCountries)))
            {
                if (country.ToString() == countryName)
                {
                    return true;
                }
            }
            return false;
        }

        public static void ManageAutoItemPassPort(ComboBox cboDestinationCountry,UserViewModel userViewModel)
        {
            // This Code should be refactored due to it being hard to read and follow! Comments below are excessive and makes the reading flow slower, but they necessary for easier understanding and refactoring later 
            // This Code was first implemented in the View, 'AddTravelWindow', but due to the amount of code I instead put it all under a broad method that handles everything connected to the automatic 'TravelDocument' "PassPort" 
            // This Method uses the methods:  'IsCountryInEU. Return Value = bool. Purpose = check if Country is in EU', 'DoesPackingListContainPassPort. Return Value = bool. Purpose = check if PackingList have a PassPort'. 'ChangeTravelDocumentBoolValue. Return Value = void. Purpose = change value of bool in PassPort. 

            // Checks if the newly selected Country is in EU
            if (TravelManager.IsCountryInEU(cboDestinationCountry.SelectedItem.ToString()) == true)   // Checks if the newly selected Country is in EU
            {
                // IF the selected Country is in EU
                if (TravelManager.DoesPackingListContainPassPort(userViewModel))   // Checks if the CurrentPackingList contains a passPort
                {
                    foreach (var item in userViewModel.CurrentPackingList)    // Iterates through all 'IPackingListItems'
                    {
                        if (item is TravelDocument travelDocument)    // IF the 'IPackingListItem' is of the type TravelDocument, create a new TravelDocument object called 'travelDocument'
                        {
                            if (travelDocument.Name.Equals("PassPort"))    // IF the 'travelDocuments' 'Name' property is "PassPort"
                            {
                                TravelManager.ChangeTravelDocumentBoolValue(travelDocument, false);    // Set the 'travelDocuments' with the 'Name'="PassPort"'s 'IsRequired' property to 'false', since no passport is needed inside EU
                            }
                        }
                    }
                    // Cast crashes, Using nested iterations and conditionals instead. Refactor this if possible, code is not easily readable! 
                    //TravelDocument passPort = (TravelDocument)_userViewModel.CurrentPackingList.Where(item => item.Name.Equals("PassPort"));    // Gets the TravelDocument PassPort
                    //TravelManager.ChangeTravelDocumentBoolValue(passPort,false);    // Changes the PassPort TravelDocuments IsRequired Property to false;
                }
                else    // IF Country is in Eu but the CurrentPackingList does not contain a 'PassPort'
                {
                    userViewModel.CurrentPackingList.Add(TravelManager.CreatePassPort(false));     // if Country is in EU and if the CurrentPackingList does not already have a 'PassPort', create a new TravelDocument with the 'Name' "PassPort" and the bool 'IsRequired' set to "false";
                }
            }
            else    // IF Country is not in EU
            {
                if (TravelManager.DoesPackingListContainPassPort(userViewModel))   // Checks if the CurrentPackingList contains a passPort
                {
                    // Cast crashes, Using nested iterations and conditionals instead. Refactor this if possible,  code is not easily readable! 
                    // TravelDocument passPort = (TravelDocument)_userViewModel.CurrentPackingList.Where(item => item.Name.Equals("PassPort"));    // Gets the TravelDocument PassPort  
                    // TravelManager.ChangeTravelDocumentBoolValue(passPort, true);    // Changes the PassPort TravelDocuments IsRequired Property to true;

                    foreach (var item in userViewModel.CurrentPackingList)
                    {
                        if (item is TravelDocument travelDocument)
                        {
                            if (travelDocument.Name.Equals("PassPort"))
                            {
                                TravelManager.ChangeTravelDocumentBoolValue(travelDocument, true);
                            }
                        }
                    }
                }
                else    // if Country is in Eu but the CurrentPackingList does not contain a 'PassPort'
                {

                    userViewModel.CurrentPackingList.Add(TravelManager.CreatePassPort(true));     // if Country is not EU and if the CurrentPackingList does not already have a 'PassPort', create a new TravelDocument with the 'Name' "PassPort" and the bool 'IsRequired' set to "true";
                }
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
            trip.CreatedByUserID = UserManager.SignedInUser.UserID;
            vacation.CreatedByUserID = UserManager.SignedInUser.UserID;
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

        public static void AddLvItemToLv(ListViewItem lvItem, ListView listView)
        {
            listView.Items.Add(lvItem);
        }

        public static ListViewItem CreateListViewItem(Object obj, string objContent)
        {
            ListViewItem lvItem = new();
            lvItem.Tag = obj;
            lvItem.Content = objContent;
            return lvItem;
        }
        public static Travel GetTravelFromListView(ListView listView)
        {
            if (listView.SelectedItem != null)
            {
                ListViewItem selectedItem = listView.SelectedItem as ListViewItem;
                Travel? selectedTravel = selectedItem.Tag as Travel;
                return selectedTravel;
            }
            return null;
        }

        public static int GenerateGUID()    // Method for generating a GUID
        {
            return Guid.NewGuid().GetHashCode();
        }
    }
}
