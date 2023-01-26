using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;
using TravelPal.Models;

namespace TravelPal.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private User _user;
        public User User
        {
            get { return _user; }
            set { _user = value;
                OnPropertyChanged("User");
            }
        }
        public ObservableCollection<Travel> Travels { get; set; } = new();      // Using an "ObservableCollection" instead of a list to gain access to the INotifyPropertyChanged interface 
        //public List<Travel> Travels { get; set; } = new();
        public UserViewModel(User user)
        {
            _user = user;       // Sets this User instance to the User from parameteres by reference
            Travels = user.travels;     // Sets this "List" to the User instances "List" by reference
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
