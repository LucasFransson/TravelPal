using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TravelPal.Enums;
using TravelPal.Interfaces;
using TravelPal.Managers;

namespace TravelPal.Models
{
    public class Admin : IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserID { get; }
        public Countries Location { get; set; }

        public Admin(string firstName, string lastName, string username, string password, Countries country)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = username;
            Password = password;
            Location = country;
        }

        public void ShowAllUsers(ListView lvDisplay)
        {
            lvDisplay.Items.Clear();
            foreach (var user in UserManager.users)
            {
                lvDisplay.Items.Add(user.UserName);
            }
        }
        public void ShowAllTravels(ListView lvDisplay)
        {
            lvDisplay.Items.Clear();
            foreach(var iUser in UserManager.users)
            {
                if (iUser is User user)
                {
                    foreach(var travel in user.travels)
                    {
                        lvDisplay.Items.Add(travel.ToString());
                    }
                }
            }
        }

        public void RemoveSelectedTravel()
        {

        }
    }
}
