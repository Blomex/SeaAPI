namespace SeaAPI.DTO
{
    public class BookingDTO
    {
        public int companyId { get; set; } = 1; // 1 - EIC, 2 - Telstar, 3 - Oceanic
        public DateTime startDate { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public DateTime arrivalDate { get; set; }
        public string category { get; set; }

        public int cost { get; set; }
        public int time { get; set; }
        public BookingDTO(){}
        public BookingDTO(int companyId, DateTime startDate, string source, string destination, DateTime arrivalDate, string category, int cost, int time)
        {
            this.companyId = companyId;
            this.startDate = startDate;
            this.source = source;
            this.destination = destination;
            this.arrivalDate = arrivalDate;
            this.category = category;
            this.cost = cost;
            this.time = time;
        }

    }
}
