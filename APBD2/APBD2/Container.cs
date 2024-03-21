namespace APBD2
{
    public class Container
    {
        private static int nextSerialNumber = 1;

        public string SerialNumber { get; }
        public double CargoMass { get; private set; } //KG
        public double Height { get; set; } //M
        public double TareWeight { get; set; } //KG
        public double Depth { get; set; } //M
        public double MaxPayload { get; set; } //KG

        public Container(double cargoMass, double height, double tareWeight, double depth, double maxPayload)
        {
            SerialNumber = GenerateSerialNumber();
            CargoMass = cargoMass;
            Height = height;
            TareWeight = tareWeight;
            Depth = depth;
            MaxPayload = maxPayload;
        }

        private string GenerateSerialNumber()
        {
            string serialNumber = $"KON-C-{nextSerialNumber}";
            nextSerialNumber++;
            return serialNumber;
        }

        public override string ToString()
        {
            return $"Container {SerialNumber}: Cargo Mass={CargoMass}kg, Height={Height}m, Tare Weight={TareWeight}kg, Depth={Depth}m";
        }
    }

    public class OverfillException : Exception
    {
        public OverfillException(string message) : base("ERROR404") { }
    }

}
