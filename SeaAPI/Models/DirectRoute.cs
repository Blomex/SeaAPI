namespace SeaAPI.Models
{
    public class DirectRoute
    {
        readonly string source;
        readonly string destination;
        readonly TransportType transportType;
        public DirectRoute(string source, string destination)
        {
            this.source = source;
            this.destination = destination;
            transportType = TransportType.EastIndiaCompany;
        }
        public DirectRoute(string source, string destination, TransportType transportType) : this(source, destination)
        {
            this.transportType = transportType;
        }

        public override int GetHashCode()
        {
            return source.GetHashCode() +7* destination.GetHashCode() + 17 * transportType.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as DirectRoute);
        }

        public bool Equals(DirectRoute obj)
        {
            return obj != null 
                && this.source.Equals(obj.source, StringComparison.OrdinalIgnoreCase)
                && this.destination.Equals(obj.destination, StringComparison.OrdinalIgnoreCase)
                && obj.transportType == this.transportType;
        }
    }
}
