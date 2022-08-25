namespace SeaAPI.Models
{
    public abstract class Graph
    {
        public abstract List<RouteModel> findRoute(string source, string destination);

    }
}
