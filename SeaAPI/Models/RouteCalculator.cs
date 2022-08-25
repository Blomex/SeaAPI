namespace SeaAPI.Models
{
    public class RouteCalculator
    {
        List<RouteModel> carRoutes;
        List<RouteModel> shipRoutes;
        List<RouteModel> planeRoutes;
        List<Graph> graphs;
        public List<RouteModel> fastestRoute { get; set; }
        public List<RouteModel> cheapestRoute { get; set; }
        public int fastestTime {get; set;}
        public int fastestCost { get; set; }
        public int cheapestTime { get; set; }
        public int cheapestCost { get; set; }
        string seaApiURL = "";
        string carApiURL = "";
        string planeApiURL = "";
        public RouteCalculator() { }

        List<RouteModel> retrieveShipRoutes(CargoModel cargo)
        {
            throw new NotImplementedException();
        }
        List<RouteModel> retrieveCarRoutes(CargoModel cargo)
        {
            throw new NotImplementedException();
        }
        List<RouteModel> retrievePlaneRoutes(CargoModel cargo)
        {
            throw new NotImplementedException();
        }
        public void getRoutesForAllGraphs()
        {
            TimeGraph timeGraph = new TimeGraph(this.shipRoutes, this.carRoutes, this.planeRoutes);
            fastestRoute = timeGraph.findRoute();
            CostGraph costGraph = new CostGraph(this.shipRoutes, this.carRoutes, this.planeRoutes);
            cheapestRoute = costGraph.findRoute();
        }

    }
}
