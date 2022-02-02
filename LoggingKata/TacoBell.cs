using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingKata
{
    public class TacoBell : ITrackable
    {
        public TacoBell(string name, double lon, double lat) //What I was trying to figure out first time before just sending a Point made during instancing
        {
            Location = new Point() { Latitude = lat, Longitude = lon};
            Name = name;
        }
        public TacoBell(string name, Point loc)
        {
            Location = loc;
            Name = name;
        }
        public string Name { get; set; }
        public Point Location { get; set; }
    }
}
