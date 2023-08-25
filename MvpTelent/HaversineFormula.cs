using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MvpTelent
{
    public class HaversineFormula
    {
        public static readonly double R = 6371e3; // metres
        public static readonly double MilesInOneMetre = 0.00062137;
        public static readonly double KiloMetresInOneMetre = 0.001;
        /// <summary>
        /// </summary>
        /// <param name="lat1">Latitue of the First Point</param>
        /// <param name="lon1">Longitude of the First Point</param>
        /// <param name="lat2">Latitue of the Second Point</param>
        /// <param name="lon2">Longitude of the Second Point</param>
        /// <returns>Distance between two longitude and latitude in Metres</returns>
        public static double Distance(double lat1, double lon1, double lat2, double lon2)
        {
            return CalculateDistance(lat1, lon1, lat2, lon2);
        }
         
        public static double Distance(double lat1, double lon1, double lat2, double lon2, int decimalDegits)
        {
            return CalculateDistance(lat1, lon1, lat2, lon2, decimalDigit: decimalDegits);
        }
        

        #region Private Method To Calculate the Distance
        private static double CalculateDistance(double lat1, double lon1, double lat2, double lon2  , int decimalDigit = 2)
        {
            double φ1 = lat1 * Math.PI / 180; // φ, λ in radians
            double φ2 = lat2 * Math.PI / 180;
            double Δφ = (lat2 - lat1) * Math.PI / 180;
            double Δλ = (lon2 - lon1) * Math.PI / 180;

            double a = Math.Sin(Δφ / 2) * Math.Sin(Δφ / 2) +
                 Math.Cos(φ1) * Math.Cos(φ2) *
                 Math.Sin(Δλ / 2) * Math.Sin(Δλ / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var distanceInMetres = R * c;
        
            return Math.Round( distanceInMetres * MilesInOneMetre, decimalDigit) ;
        }
        #endregion 





   

    }
}