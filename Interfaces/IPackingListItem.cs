using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.Interfaces
{
    public interface IPackingListItem : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string GetInfo();
    }
}
