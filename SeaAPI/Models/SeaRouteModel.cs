using System.ComponentModel.DataAnnotations;

namespace SeaAPI.Models
{
    public class SeaRouteModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Height{ get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Depth { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public string Category { get; set; }
    }
}