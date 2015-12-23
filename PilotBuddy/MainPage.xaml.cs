using PilotBuddy.Pages;
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


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PilotBuddy
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(WeatherPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MySPlitView.IsPaneOpen = !MySPlitView.IsPaneOpen;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentItem = ((ListView)sender).SelectedItem as ListViewItem;
            if (currentItem != null && ContentFrame != null)
            {
                switch (currentItem.Name)
                {
                    case "Map":
                        ContentFrame.Navigate(typeof(NavigationPage));
                        break;
                    case "Weather":
                        ContentFrame.Navigate(typeof(WeatherPage));
                        break;
                    case "Times":
                        ContentFrame.Navigate(typeof(Times));
                        break;
                    case "Checklists":
                        ContentFrame.Navigate(typeof(Checklists));
                        break;
                    default:
                        ContentFrame.Navigate(typeof(WeatherPage));
                        break;
                }
                MySPlitView.IsPaneOpen = false;
            }
        }
    }
}
