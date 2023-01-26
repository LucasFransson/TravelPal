using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Vacation : Travel
    {
        public bool IsAllInClusive { get; set; }

        public Vacation(string destination,
                        Countries destinationCountry,
                        int numberOfTravellers,
                        DateTime? startDate,
                        DateTime? endDate,
                        bool isAllInclusive)

                        : base(destination,
                             destinationCountry,
                             numberOfTravellers,
                             startDate,
                             endDate)
        {
            Destination = destination;
            Country = destinationCountry;
            NumberOfTravellers = numberOfTravellers;
            StartDate = startDate;
            EndDate = endDate;
            IsAllInClusive = isAllInclusive;
        }

        public override string GetInfo()
        {
            return $"Destination: {Destination}| All Inclusive: {IsAllInClusive} |  Country: {Country} | Number Of Travellers: {NumberOfTravellers} StartDate: {StartDate} | EndDate: {EndDate} | Duration:{TravelDuration} ";
        }
    }
}