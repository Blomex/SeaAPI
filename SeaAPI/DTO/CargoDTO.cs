using SeaAPI.Domain;
using SeaAPI.Utils;
using System.Text.Json.Serialization;

namespace SeaAPI.DTO
{
    public class CargoDTO
    {
        public DateTime StartDate { get; set; }
        public int Weight { get; set; }
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }
        public int DimensionZ { get; set; }
        public string Category { get; set; }
    }
}
