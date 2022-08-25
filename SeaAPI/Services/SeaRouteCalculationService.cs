using SeaAPI.Domain;
using SeaAPI.DTO;

namespace SeaAPI.Services
{
    public class SeaRouteCalculationService
    {
        public List<SeaRouteDTO> GetSeaRoutesForCargo(Cargo cargo)
        {
            SeaRouteGraph seaRouteGraph = new SeaRouteGraph();
            List<SeaRouteDTO> result = new List<SeaRouteDTO>();

            foreach (SeaRoute route in seaRouteGraph.Routes)
            {
                int timeInMinutes = route.Time;
                int costInCents;

                if (cargo.StartDate.CompareTo(new DateTime(cargo.StartDate.Year, 4, 30)) > 0 
                                && cargo.StartDate.CompareTo(new DateTime(cargo.StartDate.Year, 11, 1)) < 0)
                {
                    costInCents = 500 * route.NumberOfSegments;
                } else
                {
                    costInCents = 800 * route.NumberOfSegments;
                }

                switch (cargo.Category)
                {
                    case CargoCategory.WEAPONS:
                    {
                        costInCents = (int) (costInCents * 1.2);
                        break;
                    }
                    case CargoCategory.LIVE_ANIMALS:
                    {
                        costInCents = (int) (costInCents * 1.25);
                        break;
                    }
                    case CargoCategory.REFRIGERATED_GOODS:
                    {
                        costInCents = (int) (costInCents * 1.1);
                        break;
                    }
                    case CargoCategory.PRISONERS_WITH_JOBS:
                    {
                        costInCents = (int) (costInCents * 1.5);
                        break;
                    }
                }

                result.Add(new SeaRouteDTO(route.Source, route.Destination, route.Time, costInCents));
            }

            return result;
        }
    }
}
