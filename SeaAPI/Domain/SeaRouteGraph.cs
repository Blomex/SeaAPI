namespace SeaAPI.Domain
{
    public class SeaRouteGraph
    {
        public SeaRoute[] Routes { get; set; }

        public SeaRouteGraph()
        {
            Routes = new SeaRoute[]
            {
                new SeaRoute("Tunis", "Tanger", 3),
                new SeaRoute("Tanger", "De Kanariske Oer", 3),
                new SeaRoute("De Kanariske Oer", "Dakar", 5),
                new SeaRoute("Dakar", "Sierra Leone", 3),
                new SeaRoute("Dakar", "St. Helena", 10),
                new SeaRoute("Sierra Leone", "Guld Kysten", 4),
                new SeaRoute("Guld Kysten", "Slave Kysten", 4),
                new SeaRoute("Slave Kysten", "Hvalbugten", 9),
                new SeaRoute("St. Helena", "Hvalbugten", 10),
                new SeaRoute("Hvalbugten", "Kapstaden", 3),
                new SeaRoute("Kapstaden", "Kap St. Marie", 8),
                new SeaRoute("Kap St. Marie", "Mocambique", 3),
                new SeaRoute("Amatave", "Kap Guardafui", 8),
                new SeaRoute("Mocambique", "Kap Guardafui", 8),
                new SeaRoute("Kap Guardafui", "Suakin", 4),
                new SeaRoute("Suakin", "Cairo", 4),
                new SeaRoute("Cairo", "Tunis", 5)
           };
        }
    }
}
