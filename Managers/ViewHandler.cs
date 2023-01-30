using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TravelPal.Managers
{
    public static class ViewHandler
    {
        public static Color highlightedBlueColor = (Color)ColorConverter.ConvertFromString("#FF91E4E9");
        public static Color defaultWhiteColor = (Color)ColorConverter.ConvertFromString("#FFCCD3D4");

        // Change a generic View Elements (Derived from Control) Foreground to a new color
        public static void ChangeViewElementForeground<T>(T element, Color color) where T : FrameworkElement
        {
            if (element is Control control)
            {
                control.Foreground = new SolidColorBrush(color);     // Changes the ViewElements Foreground to a new color
            }
        }

        // Change several generic ViewElements (Derived from Control) Foregrounds to a new color
        public static void ChangeNViewElementsForeground<T>(Color color, params T[] elements) where T : FrameworkElement
        {
            foreach (T element in elements)     // Iterates through the input parameters 
            {
                if (element is Control control)
                {
                    control.Foreground = new SolidColorBrush(color);    // Changes the ViewElements Foreground to a new color
                }
            }
        }

        //public static void ChangeViewObjectForeground(Object viewObject)
        //{

        //}
        // Returns to HomeWindow and Close this Window

        public static void OpenHomeWindowCloseThis(Window currentWindow)
        {
            HomeWindow homeWindow = new();
            homeWindow.Show();
            currentWindow.Close();
        }
        // Open any Window. Syntax for calling this method : typeof(myWindowClass). Example : ViewHandler.OpenNewWindow(typeof(MainWindow));
        // ! Reflection Runtime ! Not tested enough, Don't Use or Use with extreme caution!
        public static void OpenNewWindow(Type window)
        {
            if (!window.IsSubclassOf(typeof(Window)))    // Checks if the passed Type is derived from the Window Class
            {
                throw new ArgumentException("The type must be a derived class of the Window class.");    
            }

            Window newWindow = (Window)Activator.CreateInstance(window);    // Using Reflection to resolve creation of instance at runtime. Tries to Cast the uknown passed Type into a subclass of Window, throws an Error if it's not derived from Window.
            newWindow.Show();
        }
        // Close any Window
        public static void CloseWindow(Window window)
        {
            window.Close();
        }

    }
}
