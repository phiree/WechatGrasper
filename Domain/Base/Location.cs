using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.Base
{
    public class Location
    {
        public static Location Null
        {
            get { return new Location(0, 0); }
        }
        public Location(double longitude, double latitude)
        {
            this.Longitude = longitude;
            this.Latitude = latitude;
        }
        public double Longitude { get; set; } = 0;
        public double Latitude { get; set; } = 0;

        public override string ToString()
        {
            return  $"{Latitude},{Longitude}";
        }
    }
}
