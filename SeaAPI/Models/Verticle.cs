namespace SeaAPI.Models
{
    public class Verticle
    {
        public string name { get; set; }
        public TransportType transportType { get; set; }
        public Verticle(string name, TransportType transportType) {
            this.name = name;
            this.transportType = transportType;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() + 17 * transportType.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            return Equals(obj as Verticle);
        }

        public bool Equals(Verticle obj)
        {
            return obj != null
                && this.name.Equals(obj.name, StringComparison.OrdinalIgnoreCase)
                && obj.transportType == this.transportType;
        }
    }
}
