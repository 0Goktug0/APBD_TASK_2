namespace APBD2
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        public string LiquidType { get; set; }
        public bool IsHazardous { get; set; }
        public string? ProductTypeLiquid { get; }

        public LiquidContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload, string liquidType, bool isHazardous)
            : base(cargoMass, height, tareWeight, depth, maxPayload)
        {
            LiquidType = liquidType;
            IsHazardous = isHazardous;
        }

        public LiquidContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload, string? productTypeLiquid) : base(cargoMass, height, tareWeight, depth, maxPayload)
        {
            ProductTypeLiquid = productTypeLiquid;
        }

        public void NotifyHazard(string containerNumber, string message)
        {
            Console.WriteLine($"Container {containerNumber}: Hazardous situation detected - {message}");
        }

        public override string ToString()
        {
            return $"Liquid Container {SerialNumber}: Cargo Mass={CargoMass}kg, Height={Height}cm, Tare Weight={TareWeight}kg, Depth={Depth}cm, Hazardous={IsHazardous}";
        }
    }
}
