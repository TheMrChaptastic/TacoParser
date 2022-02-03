using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");
            var lines = File.ReadAllLines(csvPath);
            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable tracked1 = null; //Keeps track of 2 furthest stores during foreach loop and overwrites them
            ITrackable tracked2 = null;
            var distance = 0.0; //tempDistance is used for each check during loops and overwrites distance and tracked stores if tempDistance exceeds it.
            var tempDistance = 0.0;

            foreach(var store1 in locations)
            {
                var locA = new GeoCoordinate(store1.Location.Latitude, store1.Location.Longitude);  //current store getting distance to other stores
                foreach (var store2 in locations)
                {
                    var locB = new GeoCoordinate(store2.Location.Latitude, store2.Location.Longitude);
                    tempDistance = locA.GetDistanceTo(locB);

                    if(tempDistance > distance)
                    {
                        distance = tempDistance;
                        tracked1 = store1;
                        tracked2 = store2;
                    }
                }
            }
            Console.WriteLine($"\n{tracked1.Name} and {tracked2.Name} are the farthest apart with a distance of {distance} meters");
        }
    }
}
