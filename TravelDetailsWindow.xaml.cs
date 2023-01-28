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
            this.DataContext = _travel;

            string travelInformation = _travel.GetInfo();
            StringBuilder sb = new StringBuilder();

            lvTravelSelected.Items.Add(_travel.ToString());
            //sb.AppendLine(Environment.NewLine);

            sb.AppendLine($"Destination: {travel.Destination}");
            if (travel is Trip trip)
            {
                sb.AppendLine("Trip");
                sb.AppendLine($"Type: {trip.Type}");
            }
            else if (travel is Vacation vacation)
            {
                sb.AppendLine("Vacation");
                sb.AppendLine($"All Inclusive: {vacation.IsAllInClusive}");
            }

            sb.AppendLine($"Destination Country: {travel.Country}");
            sb.AppendLine($"Number Of Travellers: {travel.NumberOfTravellers}");
            sb.AppendLine($"StartDate: {travel.StartDate}");
            sb.AppendLine($"EndDate: {travel.EndDate}");
            sb.AppendLine($"Duration: {travel.TravelDuration} days");

            tbxTravelInfo.Text = sb.ToString();
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
