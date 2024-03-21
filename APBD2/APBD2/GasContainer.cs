using System;

namespace APBD2
{
    public class GasContainer : Container, IHazardNotifier
    {
        private string productTypeGas;

        public double Pressure { get; private set; }
        public string GasVolume { get; private set; }
        public string? ProductTypeGas { get; }

        public GasContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload, string gasType, double pressure)
            : base(cargoMass, height, tareWeight, depth, maxPayload)
        {
            if (cargoMass > MaxPayload)
            {
                throw new InvalidOperationException("Cargo mass exceeds the allowable payload for this container.");
            }

            productTypeGas = gasType;
            Pressure = pressure;
        }

        public GasContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload, string? productTypeGas) : base(cargoMass, height, tareWeight, depth, maxPayload)
        {
            ProductTypeGas = productTypeGas;
        }

        public void NotifyHazard(string containerNumber, string message)
        {
            Console.WriteLine($"Container {containerNumber}: Hazardous situation detected - {message}");
        }

        public override string ToString()
        {
            return $"Gas Container {SerialNumber}: Cargo Mass={CargoMass}kg, Height={Height}cm, Tare Weight={TareWeight}kg, Depth={Depth}cm, Pressure={Pressure} atm";
        }
    }
}
