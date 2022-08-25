using SeaAPI.Models;

namespace SeaAPI.DTO
{
    public class CalculatorDTO
    {
        public int time;
        public int cost;
        public string arrivalDate;
        public BookingDTO[] bookings;

        public CalculatorDTO(int time, int cost, DateTime startDate, List<RouteModel> routes, string category)
        {
            this.time = time;
            this.cost = cost;
            bookings = new BookingDTO[routes.Count];
            int i = 0;
            DateTime arrivalDate = startDate;
            foreach(var route in routes)
            {
                arrivalDate = arrivalDate.AddMinutes(route.time);
                bookings[i] = new BookingDTO();
                bookings[i].startDate = startDate;
                bookings[i].source = route.source;
                bookings[i].destination = route.destination;
                bookings[i].arrivalDate = arrivalDate;
                bookings[i].category = category;
                i++;
                startDate = arrivalDate;
            }
            this.arrivalDate = arrivalDate.ToString("d");
        }
    }
}
