﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Enums;
using TravelPal.Interfaces;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public static class UserManager
    {
        public static List<IUser> users = new();
       
        public static User? SignedInUser;
        public static Admin? SignedInAdmin;

        // Create and return an User object
        public static User CreateUser(string firstName, string lastName, string userName, string password, Countries country)
        {
            return new User(firstName,lastName,userName,password,country);
        }

        // Create and return an Admin object
        public static Admin CreateAdmin(string firstName, string lastName, string userName, string password, Countries country)
        {
            return new Admin(firstName,lastName,userName,password,country); 
        }

        // Adds an IUser object to the static "users" list in the "UserManager" class
        public static void AddIUserToList(IUser user)
        {
            users.Add(user);
        }

        // Checks if the IUser exists, then checks if the input of the username and password is the same as that IUser objects username and password, if they are return true else return false
        public static bool CheckLogin(IUser? user, string inputUsername, string inputPassword)
        {
            if(user!=null)
            {
                if(user.UserName == inputUsername && user.Password == inputPassword)
                {
                    return true;
                }
            }
            return false;
        }

        public static void LogInIUser(TextBox tbxUserName,Window LogInWindow)
        {
            IUser user = UserManager.FindIUserByUsername(tbxUserName.Text);  // Safe to use since this code only is reachable if the Username input matches with an existing IUser object
            if(user is User)
            {
                UserManager.SignedInUser = (User)UserManager.FindIUserByUsername(tbxUserName.Text); 
                TravelManager.LoadTestTravels();    // Creates and sets an vacation and a trip object to the user for testing purposes 
                HomeWindow homeWin = new();
                homeWin.Show();
                LogInWindow.Close();
            }
            else if(user is Admin)
            {
                UserManager.SignedInAdmin= (Admin)user;
                AdminHomeWindow adminHomeWin = new();
                adminHomeWin.Show();
                LogInWindow.Close();
            }
        }
        // Checks if the UserName is available
        public static bool CheckUserNameAvailability(string inputUsername)
        {
            if (users.FirstOrDefault(u => u.UserName == inputUsername) == null)
            {
                return true;
            }
            return false;
        }

        // Checks if the Password is complying with rules
        public static bool IsNewPasswordAllowed(string newPassword)
        {
            if (newPassword.Length < 5)
            {
                return false;
            }
            return true;
        }
        // Checks if the UserName is complying with rules
        public static bool IsNewUserNameAllowed(string newUserName)
        {
            if (newUserName.Length < 3)
            {
                return false;
            }
            return true;
        }

        // Method for populating testing users
        public static void PopulateTestUsers()
        {
            //Admin newAdmin = new("Admin", "Admin");
            //AddUserToList(newAdmin);

            User user = new("Gandalf", "Efternamnsson", "Gandalf", "password", Countries.Afghanistan);
            users.Add(user);
            //TravelManager.CreateTrip();

            User newUser = new("Lucas", "Fransson", "Lucas", "password", Countries.Sweden);
            users.Add(newUser);

            Admin admin = new("Alan", "Turing", "admin", "admin", Countries.UnitedKingdom);
            users.Add(admin);
        }

        // Method for logging out the current signed in user, closing the current open window and opening the start window
        public static void LogOutUser(Window currentWindow)
        {
            SignedInUser = null;
            MainWindow mainWin = new();
            mainWin.Show();
            currentWindow.Close();
            
        }

        
        // Takes a string and parses it into an Countries Enum
        // Safe to use since the method only is called by parsing strings from Comboboxes containing only items from the Countries Enum, but can and probably should be refacotered to check if the parse is possible first. 
        public static Countries ParseStringToCountryEnum(string stringToParse)
        {
            return (Countries)Enum.Parse(typeof(Countries), stringToParse);
        }

        // Method for finding an user from the user list by searching the Username
        public static IUser FindIUserByUsername(string searchUsername)
        {
            return users.FirstOrDefault(user => user.UserName == searchUsername);
        }
        // Method for finding an user from the user list by searching the User ID
        public static IUser FindIUserByUserID(int searchUserID)
        {
            return users.FirstOrDefault(user => user.UserID == searchUserID);
        }

        public static int GenerateGUID()    // Method for generating a GUID
        {
            return Guid.NewGuid().GetHashCode();
        }
    }
}
