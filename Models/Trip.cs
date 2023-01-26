using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Trip : Travel
    {
        public TripTypes Type { get; set; }

        public Trip(string destination,
                Countries country,
                int numberOfTravellers,               
                DateTime? startDate,
                DateTime? endDate,
                TripTypes type)

                : base(destination,
                     country,
                     numberOfTravellers,
                     startDate,
                     endDate)
        {
            Destination = destination;
            Country = country;
            NumberOfTravellers = numberOfTravellers;    
            StartDate = startDate;
            EndDate = endDate;
            Type = type;
        }

        public override string GetInfo()
        {
            return $"Destination: {Destination}| Type: {Type}  | Country: {Country} | Number Of Travellers: {NumberOfTravellers} StartDate: {StartDate} | EndDate: {EndDate} | Duration:{TravelDuration}";
        }
    }
}