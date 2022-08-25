namespace SeaAPI.Models
{
    public class RouteModel
    {
        public RouteModel(string v, string verticle, int cost, int time, TransportType transportType)
        {
            this.source = v;
            this.destination = verticle;
            this.cost = cost;
            this.time = time;
            this.transportType = transportType;
        }

        public string source { get; set; }
        public string destination {  get; set; }
        public int cost { get; set; }
        public int time { get; set; }
        TransportType transportType { get; set; }
    }
}
