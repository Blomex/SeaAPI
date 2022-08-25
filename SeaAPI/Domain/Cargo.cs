using SeaAPI.DTO;

namespace SeaAPI.Domain
{
    public class Cargo
    {
        public DateTime StartDate { get; set; }
        public int Weight { get; set; }
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }
        public int DimensionZ { get; set; }
        public CargoCategory Category { get; set; }

        public Cargo(CargoDTO cargoDTO)
        {
            DateTime date = new DateTime();
            //DateOnly.TryParseExact(cargoDTO.StartDate, "yyyy-dd-MM", out date);
            StartDate = date;
            Weight = cargoDTO.Weight;
            DimensionX = cargoDTO.DimensionX;
            DimensionY = cargoDTO.DimensionY;
            DimensionZ = cargoDTO.DimensionZ;
            switch (cargoDTO.Category)
            {
                case "recorded_delivery":
                {
                    Category = CargoCategory.RECORDED_DELIVERY;
                    break;
                }
                case "weapons":
                {
                    Category = CargoCategory.WEAPONS;
                    break;
                }
                case "live_animals":
                {
                    Category = CargoCategory.LIVE_ANIMALS;
                    break;
                }
                case "catious_parcels":
                {
                    Category = CargoCategory.CAUTIOUS_PARCELS;
                    break;
                }
                case "refrigerated_goods":
                {
                    Category = CargoCategory.REFRIGERATED_GOODS;
                    break;
                }
                case "prisoners_with_jobs":
                {
                    Category = CargoCategory.PRISONERS_WITH_JOBS;
                    break;
                }
            }
        }
    }
}
