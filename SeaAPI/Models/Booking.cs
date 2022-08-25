using SeaAPI.Models;

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
               

                return true;
            }
            else
            {
                return false;
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            httpClient.Dispose();
        }
    }
}
