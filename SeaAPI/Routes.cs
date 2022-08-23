namespace SeaAPI
{
    public class Routes
    {
        static Dictionary<Tuple<string, string>, int> routeTimes;
        public Routes(){
            if (routeTimes == null)
            {
                routeTimes = new Dictionary<Tuple<string, string>, int>();
                string DeKanariskeOer = "De Kanariske Oer";
                string Tunis = "Tunis";
                string Cairo = "Cairo";
                string Suaken = "Suaken";
                string KapGuardfui = "Kap Guardfui";
                string Amatave = "Amatave";
                string Mocambique = "Mocambique";
                string KapStMarie = "Kap st. Marie";
                string Kapstaden = "Kapstaden";
                string Hvalbugten = "Hvalbugten";
                string SlaveKysten = "Slave-kysten";
                string StHelena = "St. Helena";
                string GuldKysten = "Guld-Kysten";
                string SierraLeone = "Sierra Leone";
                string Dakar = "Dakar";
                string[] cityTables = { "De Kanariske Oer", "Tunis", "Cairo", "Suaken", "Kap Guardfui",
                    "Amatave", "Mocambique", "Kap st. Marie", "Kapstaden", "Hvalbugten", "Slave-kysten", "St. Helena",
                "Guld-Kysten", "Sierra Leone", "Dakar"};
                
            }
            }
        private void addRoute( string source, string destination, int time)
        {
            routeTimes.Add(Tuple.Create<string, string>(source, destination), time);

        }

    }
}
