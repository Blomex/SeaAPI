using SeaAPI.Domain;
using SeaAPI.DTO;

namespace SeaAPI.Services
{
    public class SeaRouteCalculationService
    {
        public List<SeaRouteDTO> GetSeaRoutesForCargo(CargoDTO cargoDTO)
        {
            Cargo cargo = new Cargo(cargoDTO);
            SeaRouteGraph seaRouteGraph = new SeaRouteGraph();
            List<SeaRouteDTO> result = new List<SeaRouteDTO>();

            foreach (SeaRoute route in seaRouteGraph.Routes)
            {
                int timeInMinutes = route.Time;
                int costInDollars;

                if (cargo.StartDate.CompareTo(new DateTime(cargo.StartDate.Year, 4, 1)) > 0 
                                && cargo.StartDate.CompareTo(new DateTime(cargo.StartDate.Year, 11, 1)) < 0)
                {
                    costInDollars = 8;
                } else
                {
                    costInDollars = 5;
                }

                switch (cargo.Category)
                {
                    case CargoCategory.WEAPONS:
                    {
                        costInDollars = (int) (costInDollars * 1.2);
                        break;
                    }
                    case CargoCategory.LIVE_ANIMALS:
                    {
                        costInDollars = (int) (costInDollars * 1.25);
                        break;
                    }
                    case CargoCategory.REFRIGERATED_GOODS:
                    {
                        costInDollars = (int) (costInDollars * 1.1);
                        break;
                    }
                    case CargoCategory.PRISONERS_WITH_JOBS:
                    {
                        costInDollars = (int) (costInDollars * 1.5);
                        break;
                    }
                }

                result.Add(new SeaRouteDTO(route.Source, route.Destination, route.Time, costInDollars * 100));
            }

            return result;
        }
    }
}
