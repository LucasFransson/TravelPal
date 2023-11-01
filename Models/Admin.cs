using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public int UserID { get; set; }
        public Countries Location { get; set; }

        public Admin(string firstName, string lastName, string username, string password, Countries country)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = username;
            Password = password;
            Location = country;

            SetAdminId();

        }

        // Clears a listview, iterates through all IUsers in UserManagers.users list and adds the IUser as an item to the listview
        public void ShowAllUsers(ListView lvDisplay)
        {
            lvDisplay.Items.Clear();
            foreach (var user in UserManager.users)
            {
                lvDisplay.Items.Add(user.UserName);
            }
        }


        // Clears a listview, iterates through the all IUsers in UserManagers.users list, if IUser is an User iterates through that users travels and creates listviewitem with tag/content then adds the listviewitem to the listview.
        public void ShowAllTravels(ListView lvDisplay)
        {
            lvDisplay.Items.Clear();
            foreach (var iUser in UserManager.users)
            {
                if (iUser is User user)
                {
                    foreach (var travel in user.travels)
                    {
                        TravelManager.AddLvItemToLv(TravelManager.CreateListViewItem(travel, travel.ToString()),lvDisplay);
                    }
                }
            }
        }
        // -||- But only with all Trip objects instead of all Travel objects
        public void ShowAllTrips(ListView lvDisplay)
        {
            lvDisplay.Items.Clear();
            foreach (var iUser in UserManager.users)
            {
                if (iUser is User user)
                {
                    foreach (var travel in user.travels)
                    {
                        if (travel is Trip trip)     // I'm so sorry for this nested method, I don't have time to test a lambda expression or otherwise refactor this.
                        {
                            TravelManager.AddLvItemToLv(TravelManager.CreateListViewItem(trip, trip.ToString()), lvDisplay);
                        }
                    }
                }
            }
        }
        // -||- But only with all Vacation objects instead of all Travel objects
        public void ShowAllVacations(ListView lvDisplay)
        {
            lvDisplay.Items.Clear();
            foreach (var iUser in UserManager.users)
            {
                if (iUser is User user)
                {
                    foreach (var travel in user.travels)
                    {
                        if (travel is Vacation vacation)
                        {
                            TravelManager.AddLvItemToLv(TravelManager.CreateListViewItem(vacation, vacation.ToString()), lvDisplay);
                        }
                    }
                }
            }
        }

        private void SetAdminId()
        {

            UserID = UserManager.GenerateGUID();
        }
        // Removes a selected travel from a listview, if the selecteditem is null or not a Travel Object display an error message
        public void RemoveSelectedTravel(ListView lv)
        {
            Travel? travel = TravelManager.GetTravelFromListView(lv);

            if (travel != null && travel is Travel)
            {
                User user = FindUserByUserID(travel.CreatedByUserID);
                user.travels.Remove(travel);
                MessageBox.Show($"You have removed the Travel Plan {travel.ToString()} ! ", "Travel Plan Removed");
            }
            else { MessageBox.Show("You must select a Travel Plan to remove!", "Error"); }
        }

        public User FindUserByUserID(int searchUserID) => (User)UserManager.users.Where(u => u.UserID == searchUserID).FirstOrDefault();

    }
}
