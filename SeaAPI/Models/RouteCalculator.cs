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
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(seaApiURL);
            httpClient.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ToString();// ReadAsStringAsync().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                //JsonConvert.DeserializeObject <[Your Class] > (responseString.Body.ToString());

                /*foreach (var d in dataObjects)
                {
                    //Console.WriteLine("{0}", d.Name);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }*/

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            httpClient.Dispose();


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
