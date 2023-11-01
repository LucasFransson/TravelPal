using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;

namespace TravelPal.Models
{
    public class OtherItem : IPackingListItem
    {
        public string Name { get; set; }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                RaisePropertyChanged(nameof(Quantity));     // Testing Suggestion from intellicode, RaisePropertyChanged("Quantity") Worked afai
                //RaisePropertyChanged("Quantity");
            }
        }

        public OtherItem(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string GetInfo()
        {
            return $"{Name} Quantity: {Quantity}";
        }
        public override string ToString()
        {
            return $"{Name} = {Quantity}";
        }
    }
}
