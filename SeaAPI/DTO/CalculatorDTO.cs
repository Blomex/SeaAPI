using SeaAPI.Models;

namespace SeaAPI.DTO
{
    public class CalculatorDTO
    {
        public int time;
        public int cost;
        public string arrivalDate;
        public BookingDTO[] bookings;

        CalculatorDTO(int time, int cost, List<RouteModel> routes)
        {
            this.time = time;
            this.cost = cost;
            bookings = new BookingDTO[routes.Count];
            int i = 0;
            foreach(var route in routes)
            {
                bookings[i] = new BookingDTO(
                    );

            }
        }
    }
}
