namespace SeaAPI.DTO
{
    public class BookingDTO
    {
        public DateTime startDate { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public DateTime arrivalDate { get; set; }
        public string category { get; set; }
        public BookingDTO(DateTime startDate, string source, string destination, DateTime arrivalDate, string category)
        {
            this.startDate = startDate;
            this.source = source;
            this.destination = destination;
            this.arrivalDate = arrivalDate;
            this.category = category;
        }
    }
}
