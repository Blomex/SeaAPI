namespace SeaAPI.Domain
{
    public class SeaRoute
    {
        public string source;
        public string destination;
        public int time; // time in minutes
        public int cost; // cost in cents

        public SeaRoute(string source, string destination, int numberOfStepsOnMap)
        {
            this.source = source;
            this.destination = destination;
            this.time = numberOfStepsOnMap * 12 * 60;
        }
    }
}
