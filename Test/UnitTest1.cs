
using Newtonsoft.Json.Linq;
using SeaAPI.Models;

namespace Test
{
    public class Tests
    {
        const string planeBookUrl = "";
        const string seaBookUrl = "https://wa-eit-dk1.azurewebsites.net/api/BookingModels";
        const string carBookUrl = "";
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void bookingIsSuccessul()
        {
            //Arrange
            HttpClient httpClient = new HttpClient();
            RouteModel route = new RouteModel(
                source: "Cairo",
                destination: "Kongo",
                cost: 120,
                time: 3600,
                TransportType.EastIndiaCompany);
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
            HttpResponseMessage response = httpClient.PostAsync(httpClient.BaseAddress, new StringContent("{\"startDate\":\"2022-08-25T08:15:30-05:00\",\"source\":\"Kongo\",\"destination\":\"Cairo2\",\"arrivalDate\": \"2022-08-28T08:15:30-05:00\",\"category\":\"weapons\"}")).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                //TODO check body
                Console.WriteLine(response.Content.ToString());
                JObject json = JObject.Parse(response.Content.ToString());
                if (json.ContainsKey("id"))
                {
                    Console.WriteLine("booking done! id: {0}", json.GetValue("id"));
                    httpClient.Dispose();
                    Assert.Pass();
                }
            }
            else
            {
                Console.WriteLine(response.ToString());
                httpClient.Dispose();
                Assert.Fail();
            }
        }
    }
}