using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace PilotBuddy.Models
{
    public static class Extensions
    {
        public static double ToRadian(this double a)
        {
            return Math.PI * a / 180;
        }
        public static double ToDegree(this double a)
        {
            return a * (180 / Math.PI);
        }
    }
    public class NavigationHelper
    {
        
        public static double GetHeading(Geopoint p1, Geopoint p2)
        {
            var latitude1 = p1.Position.Latitude.ToRadian();
            
            var latitude2 = p2.Position.Latitude.ToRadian();
            var longitudeDifference = (p2.Position.Longitude - p1.Position.Longitude).ToRadian();
            var y = Math.Sin(longitudeDifference) * Math.Cos(latitude2);

            var x = Math.Cos(latitude1) * Math.Sin(latitude2) -

            Math.Sin(latitude1) * Math.Cos(latitude2) * Math.Cos(longitudeDifference);


            return (Math.Atan2(y, x).ToDegree() + 360) % 360;
        }

        public static double GetDistanceBetween(Geopoint p1, Geopoint p2)
        {
            double distance = 0;
            var long1 = p1.Position.Longitude.ToRadian();
            var long2 = p2.Position.Longitude.ToRadian();
            var lat1 = p1.Position.Latitude.ToRadian();
            var lat2 = p2.Position.Latitude.ToRadian();

            var dLat = lat1 - lat2;
            var dLon = long1 - long2;

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));


            distance = c.ToDegree() * 60;

            return distance;
        }
    }
}
