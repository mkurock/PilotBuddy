using PilotBuddy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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
    public sealed partial class NavigationPage : Page
    {

        private DispatcherTimer _timer;
        private Geolocator _gps;
        private bool systemSetCenter = false;
        private bool _blockCenter = false;
        private NavigationViewModel _vm;

        public NavigationPage()
        {
            this.InitializeComponent();
            _vm = App.VM.NavigationViewModel;
            this.DataContext = _vm;
            _gps = new Geolocator();
            MyMap.Style = MapStyle.None;
            MyMap.MapElements.Add(_vm.Airplane);
            systemSetCenter = true;
            MyMap.Center = _vm.PointBuffer;
            MyMap.ZoomLevel = _vm.ZoomLevel;
            MyMap.ZoomLevelChanged += (s, e) =>
            {
                if (s.ZoomLevel > _vm.MaxZoomLevel)
                {
                    s.ZoomLevel = _vm.MaxZoomLevel;
                }
                _vm.ZoomLevel = s.ZoomLevel;
            };
            switch (_vm.ActiveTileSource)
            {
                case MapTileLayerTypes.Icao:
                    MyMap.TileSources.Add(_vm.IcaoTileSource);
                    break;
                case MapTileLayerTypes.VFR:
                    MyMap.TileSources.Add(_vm.VfrTileSource);
                    break;
                case MapTileLayerTypes.LowLevel:
                    MyMap.TileSources.Add(_vm.LLTileSource);
                    break;
                default:
                    break;
            }
            _vm.VelocityUnit = VelocityUnits.Knots;
            SetRefresh();
        }

        private void SetRefresh()
        {
            if (_timer == null)
            {
                _timer = new DispatcherTimer();
                _timer.Interval = TimeSpan.FromSeconds(_vm.RefreshRateInSec);
                _timer.Tick += timerTick;
                _timer.Start();
            }
            if (!_timer.IsEnabled)
            {
                _timer.Start();
            }
        }

        private async void timerTick(object sender, object e)
        {
            var location = await _gps.GetGeopositionAsync();
            var currentPos = new Geopoint(new BasicGeoposition() { Longitude = location.Coordinate.Longitude, Latitude = location.Coordinate.Latitude });
            double heading = 0;
            //var heading = NavigationHelper.GetHeading(_vm.PointBuffer, currentPos);
            //if (heading >= 0)
            //{
            //    _vm.Track = Math.Round(heading, 0);
            //    if (!_blockCenter)
            //    {
            //        MyMap.Heading = heading;
            //    } else
            //    {
                    
            //    }
            //}
            
            if(location.Coordinate.Heading <= 0)
            {
                heading = (double)location.Coordinate.Heading + 360;
            } else
            {
                heading = (double)location.Coordinate.Heading;
            }
            if (!_blockCenter)
            {
                MyMap.Heading = heading;
            }
            _vm.Track = Math.Round(heading, 0);

            //_vm.Velocity = NavigationHelper.GetDistanceBetween(currentPos, _vm.PointBuffer) / _vm.RefreshRateInSec * 3600;

            if (_vm.VelocityUnit == VelocityUnits.KilometerPerHour)
                _vm.Velocity = Math.Round((double)location.Coordinate.Speed * 3.6, 0);
            else if (_vm.VelocityUnit == VelocityUnits.Knots)
                _vm.Velocity = Math.Round((double)location.Coordinate.Speed * 1.94384449, 0);
                
            _vm.Airplane.Location = currentPos;
            if (!_blockCenter)
            {
                systemSetCenter = true;
                MyMap.Center = currentPos;
            }
            _vm.PointBuffer = currentPos;
        }



        private void ICAO_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MyMap.TileSources.Clear();
            _vm.ActiveTileSource = MapTileLayerTypes.Icao;
            MyMap.TileSources.Add(_vm.IcaoTileSource);
        }

        private void LOWLVL_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MyMap.TileSources.Clear();
            _vm.ActiveTileSource = MapTileLayerTypes.LowLevel;
            MyMap.TileSources.Add(_vm.LLTileSource);
        }

        private void VFR_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MyMap.TileSources.Clear();
            _vm.ActiveTileSource = MapTileLayerTypes.VFR;
            MyMap.TileSources.Add(_vm.VfrTileSource);
        }

        private void zoomOut_Click(object sender, RoutedEventArgs e)
        {
            MyMap.ZoomLevel -= 0.5;
        }

        private void zoomIn_Click(object sender, RoutedEventArgs e)
        {
            MyMap.ZoomLevel += 0.5;
        }

        private void MyMap_CenterChanged(MapControl sender, object args)
        {
            if (systemSetCenter)
            {
                systemSetCenter = false;
                return;
            }
            _blockCenter = true;

        }

        private void Center_Click(object sender, RoutedEventArgs e)
        {
            _blockCenter = false;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //_timer.Stop();
            base.OnNavigatedFrom(e);
        }
    }
}
