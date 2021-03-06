using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WayFinder.GPS
{
    static class Utils
    {
        public enum DistanceUnit { Miles, Kilometers };

        /// <summary>
        /// Extension method - converts a double value to radian
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToRadian(this double value) // Extension method - converts a double value to radian
        {
            return (Math.PI / 180) * value;
        }

        /// <summary>
        /// gets the distance in radius based on two given coordinate points.
        /// </summary>
        /// <param name="coord1"></param>
        /// <param name="coord2"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static double HaversineDistance(LatLng coord1, LatLng coord2, DistanceUnit unit) // gets the distance in radius based on two given coordinate points.
        {
            double R = (unit == DistanceUnit.Miles) ? 3960 : 6371;
            var lat = (coord2.Latitude - coord1.Latitude).ToRadian();
            var lng = (coord2.Longitude - coord1.Longitude).ToRadian();

            var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) +
                     Math.Cos(coord1.Latitude.ToRadian()) * Math.Cos(coord2.Latitude.ToRadian()) *
                     Math.Sin(lng / 2) * Math.Sin(lng / 2);

            var h2 = 2 * Math.Asin(Math.Min(1, Math.Sqrt(h1)));

            return R * h2;
        }
    }
}