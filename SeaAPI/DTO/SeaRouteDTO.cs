using SeaAPI.Domain;

namespace SeaAPI.DTO
{
    public class SeaRouteDTO
    {
        public SeaRouteDTO(string source, string destination, int time, int cost)
        {
            Source = source;
            Destination = destination;
            Time = time;
            Cost = cost;
        }

        public string Source { get; set; }
        public string Destination { get; set; }
        public int Time { get; set; } // time in minutes
        public int Cost { get; set; } // cost in cents
    }
}
