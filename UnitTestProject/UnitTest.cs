using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.Devices.Geolocation;
using PilotBuddy.Models;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDistanceStraightLat()
        {
            var p1 = new Geopoint(new BasicGeoposition { Longitude = 6, Latitude = 46 });
            var p2 = new Geopoint(new BasicGeoposition { Longitude = 6, Latitude = 47 });
            var distance = NavigationHelper.GetDistanceBetween(p1, p2);

            Assert.AreEqual(60, distance);
        }

        [TestMethod]
        public void TestDistanceStraightLongEquator()
        {
            var p1 = new Geopoint(new BasicGeoposition { Longitude = 6, Latitude = 0 });
            var p2 = new Geopoint(new BasicGeoposition { Longitude = 7, Latitude = 0 });
            var distance = NavigationHelper.GetDistanceBetween(p1, p2);

            Assert.AreEqual(60, distance);
        }

        [TestMethod]
        public void TestDistanceRandom()
        {
            var p1 = new Geopoint(new BasicGeoposition { Longitude = 15, Latitude = 56 });
            var p2 = new Geopoint(new BasicGeoposition { Longitude = 7, Latitude = 44 });
            var distance = NavigationHelper.GetDistanceBetween(p1, p2);

            Assert.AreEqual(60, distance);
        }
    }
}
