namespace SeaAPI.Models
{
    public class RouteModel
    {
        public RouteModel(string source, string destination, int cost, int time, TransportType transportType)
        {
            this.source = source;
            this.destination = destination;
            this.cost = cost;
            this.time = time;
            this.transportType = transportType;
        }
        public string source { get; set; }
        public string destination {  get; set; }
        public int cost { get; set; }
        public int time { get; set; }
        public TransportType transportType { get; set; }
    }
}
