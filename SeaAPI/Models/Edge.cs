namespace SeaAPI.Models
{
    public class Edge
    {
        public TransportType transportType { get; set; }
        public int time { get; set; }
        public int cost { get; set; }

        public Edge(int time, int cost, TransportType eastIndiaCompany)
        {
            this.time = time;
            this.cost = cost;
            this.transportType = eastIndiaCompany;
        }

    }
}
