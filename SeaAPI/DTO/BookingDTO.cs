namespace SeaAPI.DTO
{
    public class BookingDTO
    {
        public DateTime startDate { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public DateTime arrivalDate { get; set; }
        public string category { get; set; }
    }
}
