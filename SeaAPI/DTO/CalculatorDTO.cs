using SeaAPI.Models;

namespace SeaAPI.DTO
{
    public class CalculatorDTO
    {
        public int time;
        public int cost;
        public string arrivalDate;
        public BookingDTO[] bookings;

        public CalculatorDTO(int companyId, int time, int cost, DateTime startDate, List<RouteModel> routes, string category)
        {
            this.time = time;
            this.cost = cost;
            bookings = new BookingDTO[routes.Count];
            int i = 0;
            DateTime arrivalDate = startDate;
            foreach(var route in routes)
            {
                arrivalDate.AddMinutes(route.time);
                bookings[i] = new BookingDTO(
                    companyId,
                    startDate,
                    route.source,
                    route.destination,
                    arrivalDate,
                    category,
                    cost,
                    time
                );
                i++;
                startDate = arrivalDate;
            }
        }
    }
}
