namespace SeaAPI.DTO
{
    public class CargoWithRouteDTO
    {
        public int CompanyId { get; set; } = 1;
        public DateTime StartDate { get; set; }
        public int Weight { get; set; }
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }
        public int DimensionZ { get; set; }
        public string Category { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }

    }
}
