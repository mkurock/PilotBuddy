using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml.Controls.Maps;

namespace PilotBuddy.Models
{
    public class NavigationViewModel : BasicViewModel
    {
        #region Properties and Fields
        MapTileSource _icaoTileSource;
        MapTileSource _vfrTileSource;
        MapTileSource _lowlvlTileSource;
        private const string waterColorUri = "http://c.tile.stamen.com/watercolor/{zoomlevel}/{x}/{y}.jpg";
        private const string IcaoUri = "https://secais.dfs.de/static-maps/ICAO500-2015-EUR-Reprojected_07/tiles/{zoomlevel}/{x}/{y}.png";
        private const string VfrUri = "https://secais.dfs.de/static-maps/vfr_20131114/tiles/{zoomlevel}/{x}/{y}.png";
        private const string LowLvlUri = "https://secais.dfs.de/static-maps/lower_20131114/tiles/{zoomlevel}/{x}/{y}.png";
        private const int maxZoomLevel = 12;
        private const int refreshRateInSec = 1;

        private MapIcon airplane;
        private Geopoint cologne = new Geopoint(new BasicGeoposition() { Longitude = 9.9204493, Latitude = 50.9580867 });
        private RandomAccessStreamReference image;
        private Geopoint position;

        public Point NormalizedAnchorPoint { get; set; }


        private VelocityUnits velocityUnit;
        public VelocityUnits VelocityUnit
        {
            get
            {
                return velocityUnit;
            }
            set
            {
                velocityUnit = value;
            }
        }
        private MapTileLayerTypes activeTileSource;
        public MapTileLayerTypes ActiveTileSource {
            get
            {
                return activeTileSource;
            }
            set
            {
                activeTileSource = value;
            }
        }

        public MapTileSource IcaoTileSource
        {
            get
            {
                return _icaoTileSource;
            }
        }
        public MapTileSource VfrTileSource
        {
            get
            {
                return _vfrTileSource;
            }
        }
        public MapTileSource LLTileSource
        {
            get
            {
                return _lowlvlTileSource;
            }
        }

        public int MaxZoomLevel
        {
            get
            {
                return maxZoomLevel;
            }
        }

        public MapIcon Airplane
        {
            get
            {
                return airplane;
            }
        }

        public int RefreshRateInSec
        {
            get
            {
                return refreshRateInSec;
            }
        }

        public Geopoint Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value; OnPropertyChanged("Position");
            }
        }

        private double track;

        public double Track
        {
            get { return track; }
            set { track = value; OnPropertyChanged("Track"); }
        }
        private double zoomLevel;

        public double ZoomLevel
        {
            get { return zoomLevel; }
            set { zoomLevel = value; OnPropertyChanged("ZoomLevel"); }
        }

        private double velocity;

        public double Velocity
        {
            get { return velocity; }
            set { velocity = value; OnPropertyChanged("Velocity"); }
        }
#endregion




        public NavigationViewModel()
        {
            InitMap();
        }

        private void InitMap()
        {
            
            NormalizedAnchorPoint = new Point(0.5, 0.5);
            zoomLevel = 10;
            Position = cologne;
            image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/images/airplane.png"));

            //Setup Icao Layer
            _icaoTileSource = new MapTileSource();
            var _tileLayer = new HttpMapTileDataSource();
            _tileLayer.UriFormatString = IcaoUri;
            _icaoTileSource.DataSource = _tileLayer;
            _tileLayer.AllowCaching = true;

            //Setup VFR Layer
            _vfrTileSource = new MapTileSource();
            var _vfrtileLayer = new HttpMapTileDataSource();
            _vfrtileLayer.UriFormatString = VfrUri;
            _vfrTileSource.DataSource = _vfrtileLayer;
            _vfrtileLayer.AllowCaching = true;

            //Setup Low Level Layer
            _lowlvlTileSource = new MapTileSource();
            var _lowlvltileLayer = new HttpMapTileDataSource();
            _lowlvltileLayer.UriFormatString = LowLvlUri;
            _lowlvlTileSource.DataSource = _lowlvltileLayer;
            _lowlvltileLayer.AllowCaching = true;

            airplane = new MapIcon()
            {
                Title = "My Position",
                Image = image,
                Visible = true,
                Location = cologne,
                NormalizedAnchorPoint = new Point(0.5, 0.5)

            };
        }

        public void DrawLine(Geopoint one, Geopoint two, MapControl map)
        {
            if (two == null)
                two = cologne;
            var path = new List<BasicGeoposition>();
            path.Add(new BasicGeoposition() { Latitude = one.Position.Latitude, Longitude = one.Position.Longitude });
            path.Add(new BasicGeoposition() { Latitude = two.Position.Latitude, Longitude = two.Position.Longitude });
            var line = new MapPolyline();
            line.StrokeColor = Colors.Purple;
            line.StrokeThickness = 9;
            line.Path = new Geopath(path);
            map.MapElements.Add(line);
        }
    }
    public enum VelocityUnits
    {
        KilometerPerHour,
        Knots
    }
    public enum MapTileLayerTypes
    {
        Icao,
        VFR,
        LowLevel
    }
}
