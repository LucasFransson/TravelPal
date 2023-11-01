using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;

namespace TravelPal.Models
{
    public class TravelDocument : IPackingListItem
    {
        public string Name { get; set; }

        private bool isRequired;
        public bool IsRequired
        {
            get { return isRequired; }
            set
            {
                isRequired = value;
                RaisePropertyChanged("IsRequired");
            }
        }

        public TravelDocument(string name, bool isRequired)
        {
            Name = name;
            IsRequired = isRequired;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string GetInfo()
        {
            return $"{Name} = {IsRequired}";
        }
        public override string ToString()
        {
            return $"{Name} = {IsRequired}";
        }
    }
}
