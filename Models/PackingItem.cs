using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;

namespace TravelPal.Models
{
    public class PackingItem : IPackingListItem
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public PackingItem(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Quantity} {Name}";
        }

        public string GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
