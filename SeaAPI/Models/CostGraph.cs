﻿namespace SeaAPI.Models
{
    public class CostGraph : Graph
    {
        Dictionary<DirectRoute, Edge> edges = new Dictionary<DirectRoute, Edge>();
        HashSet<string> vertices = new HashSet<string>();

        public CostGraph(List<RouteModel> shipRoutes, List<RouteModel> carRoutes, List<RouteModel> planeRoutes)
        {
            foreach(RouteModel shipRoute in shipRoutes)
            {
                vertices.Add(shipRoute.source);
                vertices.Add(shipRoute.destination);
                edges.Add(new DirectRoute(shipRoute.source, shipRoute.destination),
                    value: new Edge(shipRoute.time, shipRoute.cost, TransportType.EastIndiaCompany));
            }
            foreach (RouteModel route in carRoutes)
            {
                vertices.Add(route.source);
                vertices.Add(route.destination);
                Edge edge = null;
                if(edges.TryGetValue(
                    new DirectRoute(route.source,
                    route.destination), out edge)){
                    if(edge.cost > route.cost)
                    {
                        edges.Add(new DirectRoute(route.source, route.destination),
                    value: new Edge(route.time, route.cost, TransportType.Telstar));
                    }
                }
            }
            foreach (RouteModel route in planeRoutes)
            {
                vertices.Add(route.source);
                vertices.Add(route.destination);
                Edge edge;
                if (edges.TryGetValue(
                    new DirectRoute(route.source,
                    route.destination), out edge))
                {
                    if (edge.cost > route.cost)
                    {
                        edges.Add(new DirectRoute(route.source, route.destination),
                    value: new Edge(route.time, route.cost, TransportType.Telstar));
                    }
                }
            }
        }

        public List<RouteModel> findRoute(string source, string destination)
        {
            Dictionary<string, int> dist = new Dictionary<string, int>();
            Dictionary<string, string> prev = new Dictionary<string, string>();
            PriorityQueue<string, int> pq = new PriorityQueue<string, int>();
            dist[source] = 0;
            foreach (string v in vertices)
            {
                if(!v.Equals(source, StringComparison.OrdinalIgnoreCase))
                    dist[v] = int.MaxValue;
                pq.Enqueue(v, dist[v]);
            }

            while (pq.TryDequeue(out string current, out int priority)){
                foreach(string v in vertices)
                {
                    Edge edge;
                    if (edges.TryGetValue(new DirectRoute(current, v), out edge)){
                        int alt = dist[current] + edge.cost;
                        if (alt < dist[v])
                        {
                            dist[v] = alt;
                            prev[v] = current;
                            pq.Enqueue(v, alt);
                        }
                    }
                }
                if (current.Equals(destination))
                {
                    break;
                }
            }
            string verticle = destination;
            List<RouteModel> routes = new List<RouteModel>();
            while(verticle != source)
            {
                routes.Add(new RouteModel(
                    prev[verticle],
                    verticle,
                    edges.GetValueOrDefault(new DirectRoute(prev[verticle], verticle)).cost,
                    edges.GetValueOrDefault(new DirectRoute(prev[verticle], verticle)).time,
                    edges.GetValueOrDefault(new DirectRoute(prev[verticle], verticle)).transportType
                ));
                verticle = prev[verticle];
            }
            return routes;
        }
    }
}