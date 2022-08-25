namespace SeaAPI.Models
{
    public interface Graph
    {
        List<RouteModel> findRoute(string source, string destination);
    }
}
