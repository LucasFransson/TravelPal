using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        private Travel _travel;
        public TravelDetailsWindow(Travel travel)
        {
            InitializeComponent();
            _travel= travel;
            string travelInformation = _travel.GetInfo();
            StringBuilder sb = new StringBuilder(); 
        }

        private void btnEditTravel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveTravel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
