using SeaAPI.Domain;

namespace SeaAPI.DTO
{
    public class CargoDTO
    {
        public CargoDTO(string startDate, int weight, int dimensionX, int dimensionY, int dimensionZ, string category)
        {
            StartDate = startDate;
            Weight = weight;
            DimensionX = dimensionX;
            DimensionY = dimensionY;
            DimensionZ = dimensionZ;
            Category = category;
        }

        public string StartDate { get; set; }
        public int Weight { get; set; }
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }
        public int DimensionZ { get; set; }
        public string Category { get; set; }
    }
}
