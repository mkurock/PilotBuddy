using PilotBuddy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PilotBuddy.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class WeatherPage : Page
    {
        private WeatherViewModel _vm;

        public WeatherPage()
        {
            this.InitializeComponent();
            _vm = App.VM.WeatherViewModel;
            this.DataContext = _vm;
        }
        private void tbAirport_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if(args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                sender.ItemsSource = _vm.MetarAirports.Where(x => x.ToLower().Contains(sender.Text.ToLower()));
            }
        }

        private void tbAirport_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if(args.ChosenSuggestion == null)
            {
                _vm.GetWeatherStations(sender.Text);
            }
        }

        private void tbAirport_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            _vm.GetWeatherStations(args.SelectedItem.ToString());
        }
    }
}
