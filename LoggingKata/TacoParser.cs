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
            if (cells.Length < 3)
            {
                logger.LogInfo("Cells more than 3: " + line);
                return null; 
            }

            try //Added try catch just in case (not needed) ¯\_(ツ)_/¯
            {
                latitude = double.Parse(cells[0]);
                longitude = double.Parse(cells[1]);
            }
            catch
            {
                logger.LogError($"Couldn't Parse {cells[0]} or {cells[1]} to doubles."); //Should never happen
            }
            var name = cells[2];

            var tacoBell = new TacoBell(name, new Point() { Longitude = longitude, Latitude = latitude });

            return tacoBell;
        }
    }
}