using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TravelPal.Enums;
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
