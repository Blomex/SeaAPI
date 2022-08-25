using System.ComponentModel.DataAnnotations;

namespace SeaAPI.Models
{
    public class BookingModel
    {
        [Key]
        public int id { get; set; }
        public DateTime startDate { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public string arrivalDate { get; set; }
        public string category { get; set; }
    }
}
