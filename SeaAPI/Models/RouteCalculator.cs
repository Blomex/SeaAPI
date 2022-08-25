using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SeaAPI.DTO;

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
        string seaApiURL = "";
        string carApiURL = "";
        string planeApiURL = "";
        List<RouteModel> retrieveShipRoutes(CargoModel cargo)
        {
            var routes = new List<RouteModel>();
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(seaApiURL);
            httpClient.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync(seaApiURL).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var jsonString = response.Content.ToString();
                SeaRouteDTO[] seaRoutes = JsonConvert.DeserializeObject<SeaRouteDTO[]>(jsonString);
                foreach(SeaRouteDTO r in seaRoutes)
                {
                    routes.Add(new RouteModel(r));
                }
            }
            httpClient.Dispose();
            return routes;
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
