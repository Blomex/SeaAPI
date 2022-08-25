namespace SeaAPI.Domain
{
    public class SeaRoute
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Time { get; set; } // time in minutes
        public int Cost { get; set; } // cost in cents

        public SeaRoute(string source, string destination, int numberOfStepsOnMap)
        {
            Source = source;
            Destination = destination;
            Time = numberOfStepsOnMap * 12 * 60; // number of steps times 12 hours time 60 minutes
        }
    }
}
