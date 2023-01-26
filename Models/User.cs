using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;
using TravelPal.Interfaces;
using TravelPal.Managers;

namespace TravelPal.Models
{
    public class User : IUser, INotifyPropertyChanged
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged("UserName"); }       // Notifies the View that the property "UserName" has changed
        }
        public string Password { get; set; }

        public int UserID { get; set; }

        public Countries Location { get; set; }

        //public List<Travel> travels { get; set; } = new();

        public ObservableCollection <Travel> travels { get; set; } = new();     // Using an "ObservableCollection" instead of a list to gain access to the INotifyPropertyChanged interface 

        public event PropertyChangedEventHandler? PropertyChanged;

        public User(string firstName, string lastName, string username, string password, Countries location)
        {
            UserName = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Location = location;

            SetUserID();

        }
        public void SetUserID()
        {
            UserID = UserManager.GenerateGUID(); 
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
