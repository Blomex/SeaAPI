namespace SeaAPI.Models
{
    public class TimeGraph : Graph
    {
        Dictionary<DirectRoute, Edge> edges = new Dictionary<DirectRoute, Edge>();
        HashSet<string> vertices = new HashSet<string>();
        const int SHIP_TO_SHIP = 0;
        const int SHIP_TO_PLANE = 0;
        const int SHIP_TO_CAR = 0;
        const int CAR_TO_CAR = 0;
        const int PLANE_TO_PLANE = 0;
        const int CAR_TO_PLANE = 0;
        public int time{get; set;}
        public int cost { get; set;}


        public TimeGraph(List<RouteModel> shipRoutes, List<RouteModel> carRoutes, List<RouteModel> planeRoutes)
        {
            foreach (RouteModel shipRoute in shipRoutes)
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
                if (edges.TryGetValue(
                    new DirectRoute(route.source,
                    route.destination), out edge))
                {
                    if (edge.time > route.time)
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
                    if (edge.time > route.time)
                    {
                        edges.Add(new DirectRoute(route.source, route.destination),
                    value: new Edge(route.time, route.cost, TransportType.Telstar));
                    }
                }
            }
        }
        public override List<RouteModel> findRoute(string source, string destination)
        {
            Dictionary<string, int> dist = new Dictionary<string, int>();
            Dictionary<string, int> costs = new Dictionary<string, int>();
            Dictionary<string, string> prev = new Dictionary<string, string>();
            PriorityQueue<string, int> pq = new PriorityQueue<string, int>();
            dist[source] = 0;
            foreach (string v in vertices)
            {
                if (!v.Equals(source, StringComparison.OrdinalIgnoreCase))
                    dist[v] = int.MaxValue;
                costs[v] = 0;
                pq.Enqueue(v, dist[v]);
            }

            while (pq.TryDequeue(out string current, out int priority))
            {
                foreach (string v in vertices)
                {
                    Edge edge;
                    if (edges.TryGetValue(new DirectRoute(current, v), out edge))
                    {
                        int alt = dist[current] + edge.time;
                        if (alt < dist[v])
                        {
                            dist[v] = alt;
                            costs[v] = costs[current] + edge.cost;
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
            time = 0;
            cost = 0;
            while (verticle != source)
            {

                time += edges.GetValueOrDefault(new DirectRoute(prev[verticle], verticle)).time;
                cost += edges.GetValueOrDefault(new DirectRoute(prev[verticle], verticle)).cost;
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
    
    /*public TimeGraph(List<RouteModel> shipRoutes, List<RouteModel> carRoutes, List<RouteModel> planeRoutes)
    {
        foreach (RouteModel shipRoute in shipRoutes)
        {
            vertices.Add(new Verticle(shipRoute.source, TransportType.EastIndiaCompany));
            vertices.Add(new Verticle(shipRoute.destination, TransportType.EastIndiaCompany));
            edges.Add(new DirectRoute(shipRoute.source, shipRoute.destination, TransportType.EastIndiaCompany),
                value: new Edge(shipRoute.time+ SHIP_TO_SHIP, shipRoute.cost, TransportType.EastIndiaCompany));

            edges.Add(new DirectRoute(shipRoute.source, shipRoute.destination, TransportType.Telstar),
                value: new Edge(shipRoute.time + SHIP_TO_CAR, shipRoute.cost, TransportType.EastIndiaCompany));

            edges.Add(new DirectRoute(shipRoute.source, shipRoute.destination, TransportType.OceanicAirlines),
                value: new Edge(shipRoute.time + SHIP_TO_PLANE, shipRoute.cost, TransportType.EastIndiaCompany));
        }
        foreach (RouteModel route in carRoutes)
        {
            vertices.Add(new Verticle(route.source, TransportType.Telstar));
            vertices.Add(new Verticle(route.destination, TransportType.Telstar));

            edges.Add(new DirectRoute(route.source, route.destination, TransportType.Telstar),
                value: new Edge(route.time + CAR_TO_CAR, route.cost, TransportType.Telstar));

            edges.Add(new DirectRoute(route.source, route.destination, TransportType.OceanicAirlines),
                value: new Edge(route.time + CAR_TO_PLANE, route.cost, TransportType.Telstar));

            edges.Add(new DirectRoute(route.source, route.destination, TransportType.EastIndiaCompany),
                 value: new Edge(route.time + SHIP_TO_CAR, route.cost, TransportType.Telstar));

        }
        foreach (RouteModel route in planeRoutes)
        {
            vertices.Add(new Verticle(route.source, TransportType.OceanicAirlines));
            vertices.Add(new Verticle(route.destination, TransportType.OceanicAirlines));
            edges.Add(new DirectRoute(route.source, route.destination, TransportType.EastIndiaCompany),
                value: new Edge(route.time + SHIP_TO_PLANE, route.cost, TransportType.OceanicAirlines));
            edges.Add(new DirectRoute(route.source, route.destination, TransportType.Telstar),
                value: new Edge(route.time + CAR_TO_PLANE, route.cost, TransportType.OceanicAirlines));
            edges.Add(new DirectRoute(route.source, route.destination, TransportType.OceanicAirlines),
                value: new Edge(route.time + PLANE_TO_PLANE, route.cost, TransportType.OceanicAirlines));
        }
    }
    
    public override List<RouteModel> findRoute(string source, string destination)
    {
        Dictionary<Verticle, int> dist = new Dictionary<Verticle, int>();
        Dictionary<Verticle, int> cost = new Dictionary<Verticle, int>();
        Dictionary<Verticle, Verticle> prev = new Dictionary<Verticle, Verticle>();
        PriorityQueue<Verticle, int> pq = new PriorityQueue<Verticle, int>();
        dist[new Verticle(source, TransportType.EastIndiaCompany)] = 0;
        dist[new Verticle(source, TransportType.Telstar)] = 0;
        dist[new Verticle(source, TransportType.OceanicAirlines)] = 0;
        cost[new Verticle(source, TransportType.EastIndiaCompany)] = 0;
        cost[new Verticle(source, TransportType.Telstar)] = 0;
        cost[new Verticle(source, TransportType.OceanicAirlines)] = 0;

        foreach (Verticle v in vertices)
        {
            if (!v.Equals( new Verticle(source, TransportType.OceanicAirlines))
                && !v.Equals(new Verticle(source, TransportType.Telstar))
                && !v.Equals(new Verticle(source, TransportType.EastIndiaCompany)))
            {
                cost[v] = 0;
                dist[v] = int.MaxValue;
            }
            pq.Enqueue(v, dist[v]);
        }

        while (pq.TryDequeue(out Verticle current, out int priority)){
            while(pq.TryDequeue(out Verticle _current, out int _priority))
            {

            }
            foreach (Verticle v in vertices)
            {
                Edge edge;
                foreach(TransportType type in (TransportType[]) Enum.GetValues(typeof(TransportType))){
                    if (edges.TryGetValue(new DirectRoute(current.name, v.name, type), out edge))
                    {
                        int alt = dist[current] + edge.time;
                        if (alt < dist[v])
                        {
                            dist[v] = alt;
                            cost[v] = cost[current] + edge.cost;
                            prev[v] = current;
                            pq.Enqueue(v, alt);
                        }
                    }
                }
            }
            if (current.name.Equals(destination))
            {
                break;
            }
        }



        Verticle verticle = new Verticle(destination, TransportType.OceanicAirlines);
        int finalTime = int.MaxValue;
        foreach (TransportType type in (TransportType[])Enum.GetValues(typeof(TransportType)))
        {
            if (dist.GetValueOrDefault(new Verticle(name: destination, type), int.MaxValue) < finalTime) {
                finalTime = dist[new Verticle(name: destination, type)];
                this.cost = cost[new Verticle(name: destination, type)];
                verticle = new Verticle(destination, type);
            }
        }
        this.time = finalTime;
        List<RouteModel> routes = new List<RouteModel>();
        while (!verticle.Equals(new Verticle(source, TransportType.Telstar))
            && !verticle.Equals(new Verticle(source, TransportType.OceanicAirlines))
            && !verticle.Equals(new Verticle(source, TransportType.EastIndiaCompany)))
        {
            routes.Add(new RouteModel(
                prev[verticle].name,
                verticle.name,
                edges.GetValueOrDefault(new DirectRoute(prev[verticle].name, verticle.name, prev[verticle].transportType)).cost,
                edges.GetValueOrDefault(new DirectRoute(prev[verticle].name, verticle.name, prev[verticle].transportType)).time,
                edges.GetValueOrDefault(new DirectRoute(prev[verticle].name, verticle.name, prev[verticle].transportType)).transportType
                ));
            verticle = prev[verticle];
        }
        return routes;
    }
}*/
}
