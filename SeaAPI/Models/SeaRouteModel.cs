using System.ComponentModel.DataAnnotations;

namespace SeaAPI.Models
{
    public class SeaRouteModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public string DimensionX { get; set; }

        public string DimensionY { get; set; }
        public string DimensionZ { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}