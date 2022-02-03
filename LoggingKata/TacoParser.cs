namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");
            var cells = line.Split(',');
            var latitude = 0.0;
            var longitude = 0.0;
            if (cells.Length < 3) //Makes sure lines are correctly formatted (why the try parse after isnt really needed since we can see its laid out as number,number,name)
            {
                logger.LogError("Cells more than 3: " + line);
                return null; 
            }

            latitude = double.Parse(cells[0]); //Took out try Parse because input isnt going to be changing and works as is
            longitude = double.Parse(cells[1]);
            var name = cells[2];

            var tacoBell = new TacoBell(name, new Point() { Longitude = longitude, Latitude = latitude });

            return tacoBell;
        }
    }
}