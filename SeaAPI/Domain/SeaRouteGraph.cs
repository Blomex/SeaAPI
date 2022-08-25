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
                new SeaRoute("St. Helena", "Kapstaden", 9),
                new SeaRoute("Hvalbugten", "Kapstaden", 3),
                new SeaRoute("Kapstaden", "Kap St. Marie", 8),
                new SeaRoute("Kap St. Marie", "Mocambique", 3),
                new SeaRoute("Amatave", "Kap Guardafui", 8),
                new SeaRoute("Mocambique", "Kap Guardafui", 8),
                new SeaRoute("Kap Guardafui", "Suakin", 4),
                new SeaRoute("Suakin", "Cairo", 4),
                new SeaRoute("Cairo", "Tunis", 5),
                new SeaRoute("Tanger", "Tunis", 3),
                new SeaRoute("De Kanariske Oer","Tanger", 3),
                new SeaRoute("Dakar", "De Kanariske Oer", 5),
                new SeaRoute("Sierra Leone", "Dakar", 3),
                new SeaRoute("St. Helena", "Dakar", 10),
                new SeaRoute("Guld Kysten", "Sierra Leone", 4),
                new SeaRoute("Slave Kysten", "Guld Kysten",  4),
                new SeaRoute("Hvalbugten", "Slave Kysten", 9),
                new SeaRoute("Hvalbugten","St. Helena", 10),
                new SeaRoute("Kapstaden", "St. Helena", 9),
                new SeaRoute("Kapstaden","Hvalbugten", 3),
                new SeaRoute("Kap St. Marie","Kapstaden",  8),
                new SeaRoute("Mocambique", "Kap St. Marie", 3),
                new SeaRoute("Kap Guardafui", "Amatave", 8),
                new SeaRoute("Kap Guardafui", "Mocambique", 8),
                new SeaRoute("Suakin", "Kap Guardafui", 4),
                new SeaRoute("Cairo", "Suakin", 4),
                new SeaRoute("Tunis", "Cairo", 5),
                new SeaRoute("Guld Kysten", "Hvalbugten", 11),
                new SeaRoute( "Hvalbugten", "Guld Kysten", 11),
           };
        }
    }
}
