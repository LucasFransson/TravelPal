using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;
using TravelPal.Interfaces;

namespace TravelPal.Models
{
    public class Travel
    {
        public List<IPackingListItem> PackingList { get; set; } = new();
        public string Destination { get; set; }
        public Countries Country { get; set; }
        public int NumberOfTravellers { get; set; }
        public int TravelDuration { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Travel(string destination, Countries country, int numberOfTravelleres, DateTime? startDate, DateTime? endDate)
        {
            Destination = destination;
            Country = country;
            NumberOfTravellers = numberOfTravelleres;
            StartDate = startDate;
            EndDate = endDate;
        }
        public override string ToString()
        {
            return $"Destination: {Destination} | Country: {Country}";
        }
        public virtual string GetInfo()
        {
            return $"Destination: PlaceHolder | Country: PlaceHolder";
        }

        public void RemoveItem(IPackingListItem item)
        {
            PackingList.Remove(item);
        }
    }
}
