using SeaAPI.Models;
using Newtonsoft.Json.Linq;
namespace SeaAPI
{
    public class Booking
    {
        public const string seaBookUrl = "";
        public const string carBookUrl = "";
        public const string planeBookUrl = "";

        public bool bookAllRoutes(List<RouteModel> routes)
        {
            foreach (var route in routes)
            {
                if (!book(route))
                {
                    return false;
                }
            }
            return true;
        }
        public bool book(RouteModel route)
        {
            HttpClient httpClient = new HttpClient();
            switch (route.transportType)
            {
                case TransportType.OceanicAirlines:
                    httpClient.BaseAddress = new Uri(planeBookUrl);
                    break;
                case TransportType.EastIndiaCompany:
                    httpClient.BaseAddress = new Uri(seaBookUrl);
                    break;
                case TransportType.Telstar:
                    httpClient.BaseAddress = new Uri(carBookUrl);
                    break;
                default:
                    break;

            }
            httpClient.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                JObject json = JObject.Parse(response.Content.ToString());
                if(json.ContainsKey("id"))
                {
                    Console.WriteLine("booking done! id: {0}", json.GetValue("id"));
                }
            }
            httpClient.Dispose();
            return response.IsSuccessStatusCode;
        }
    }
}
