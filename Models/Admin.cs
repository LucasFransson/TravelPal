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

        public void ShowAllUsers(ListView lvDisplay)
        {
            lvDisplay.Items.Clear();
            foreach (var user in UserManager.users)
            {
                lvDisplay.Items.Add(user.UserName);
            }
        }
        //public void ShowAllTravels(ListView lvDisplay)
        //{
        //    lvDisplay.Items.Clear();
        //    foreach(var iUser in UserManager.users)
        //    {
        //        if (iUser is User user)
        //        {
        //            foreach(var travel in user.travels)
        //            {
        //                lvDisplay.Items.Add(travel.ToString());
        //            }
        //        }
        //    }
        //}

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

        private void SetAdminId()
        {
            UserID = UserManager.GenerateGUID();
        }
        public void RemoveSelectedTravel(ListView lv)
        {
            Travel travel = TravelManager.GetTravelFromListView(lv);
            User user = FindUserByUserID(travel.CreatedByUserID);
            user.travels.Remove(travel);
        }

        public User FindUserByUserID(int searchUserID) => (User)UserManager.users.Where(u => u.UserID == searchUserID).FirstOrDefault();

    }
}
