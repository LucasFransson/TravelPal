using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TravelPal.Enums;

namespace TravelPal.ViewModels
{
    //public class MyViewModel : INotifyPropertyChanged
    //{
    //    private string _textBox1Text;
    //    public string TextBox1Text
    //    {
    //        get { return _textBox1Text; }
    //        set
    //        {
    //            if (_textBox1Text != value)
    //            {
    //                _textBox1Text = value;
    //                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextBox1Text)));
    //                MethodToRun();
    //            }
    //        }
    //    }

    //    private string _textBox2Text;

    //    public event PropertyChangedEventHandler? PropertyChanged;

    //    public string TextBox2Text
    //    {
    //        get { return _textBox2Text; }
    //        set
    //        {
    //            if (_textBox2Text != value)
    //            {
    //                _textBox2Text = value;
    //                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextBox2Text)));
    //                MethodToRun();
    //            }
    //        }
    //    }


    //    public void MethodToRun(TravelTypes travelType,TextBox tbxDestination, DatePicker dtpStart,DatePicker dtpEnd,ComboBox cboDestinationCountry,TextBox tbxTravelerNr, Button btnSaveTravelInfo,ComboBox cboTripType)
    //    {
    //        if (travelType == TravelTypes.Vacation
    //                    && tbxDestination.Text.Length != 0
    //                    && dtpStart.SelectedDate != null
    //                    && dtpEnd.SelectedDate != null
    //                    && cboDestinationCountry.SelectedItem != null
    //                    && tbxTravelerNr.Text.Length != 0
    //                    )
    //        {
    //            btnSaveTravelInfo.IsEnabled = true;
    //        }
    //        else if (travelType == TravelTypes.Trip
    //                                && tbxDestination.Text.Length != 0
    //                                && dtpStart.SelectedDate != null
    //                                && dtpEnd.SelectedDate != null
    //                                && cboDestinationCountry.SelectedItem != null
    //                                && cboTripType.SelectedItem != null
    //                                && tbxTravelerNr.Text != null
    //                                )
    //        {
    //            btnSaveTravelInfo.IsEnabled = true;
    //        }
    //        else
    //        {
    //            btnSaveTravelInfo.IsEnabled = false;
    //        }
    //    }
    //    //and so on for the rest of the textboxes
    //}
}
