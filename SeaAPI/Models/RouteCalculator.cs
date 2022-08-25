using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SeaAPI.DTO;
using SeaAPI.Services;

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
        string seaApiURL = "https://wa-eit-dk1.azurewebsites.net/api/SeaRoutes";
        string carApiURL = "";
        string planeApiURL = "";
        public RouteCalculator() { }
        public void prepareToCalculate(CargoWithRouteDTO cargo)
        {
            carRoutes = retrieveCarRoutes(cargo);
            planeRoutes = retrievePlaneRoutes(cargo);
            shipRoutes = retrieveShipRoutes(cargo);
        }
        List<RouteModel> retrieveShipRoutes(CargoWithRouteDTO cargo)
        {
            var routes = new List<RouteModel>();
            var seaRoutes = SeaRouteCalculationService.GetSeaRoutesForCargo(new Domain.Cargo(cargo));
            foreach (SeaRouteDTO r in seaRoutes)
            {
                routes.Add(new RouteModel(r));
            }
            /*
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(seaApiURL);
            httpClient.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            CargoDTO cargoDTO = new CargoDTO();
            cargoDTO.StartDate = cargo.StartDate;
            cargoDTO.Category = cargo.Category;
            cargoDTO.DimensionX = cargo.DimensionX;
            cargoDTO.DimensionY = cargo.DimensionY;
            cargoDTO.DimensionZ = cargo.DimensionZ;
            cargoDTO.Weight = cargo.Weight;
            HttpResponseMessage response = httpClient.PostAsync(seaApiURL, JsonContent.Create<CargoDTO>(cargoDTO)).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
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
            httpClient.Dispose();*/
            return routes;
        }
        List<RouteModel> retrieveCarRoutes(CargoWithRouteDTO cargo)
        {
            return new List<RouteModel>();
        }
        List<RouteModel> retrievePlaneRoutes(CargoWithRouteDTO cargo)
        {
            return new List<RouteModel>();
        }
        public void getRoutesForAllGraphs(string source, string destination)
        {
            TimeGraph timeGraph = new TimeGraph(this.shipRoutes, this.carRoutes, this.planeRoutes);
            fastestRoute = timeGraph.findRoute(source, destination);
            CostGraph costGraph = new CostGraph(this.shipRoutes, this.carRoutes, this.planeRoutes);
            cheapestRoute = costGraph.findRoute(source, destination);
            fastestCost = timeGraph.cost;
            fastestTime = timeGraph.time;
            cheapestCost = costGraph.cost;
            cheapestTime = costGraph.time;
        }

    }
}
