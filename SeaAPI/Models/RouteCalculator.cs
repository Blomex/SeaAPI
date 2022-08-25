namespace SeaAPI.Models
{
    public class RouteCalculator
    {
        List<RouteModel> carRoutes;
        List<RouteModel> shipRoutes;
        List<RouteModel> planeRoutes;
        List<Graph> graphs;
        List<RouteModel> fastestRoute;
        List<RouteModel> cheapestRoute;
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
        public void getRoutesForAllGraphs(string source, string destination)
        {
            TimeGraph timeGraph = new TimeGraph(this.shipRoutes, this.carRoutes, this.planeRoutes);
            fastestRoute = timeGraph.findRoute(source, destination);
            CostGraph costGraph = new CostGraph(this.shipRoutes, this.carRoutes, this.planeRoutes);
            cheapestRoute = costGraph.findRoute(source, destination);
        }

    }
}
