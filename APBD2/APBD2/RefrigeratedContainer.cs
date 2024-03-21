namespace APBD2
{
    public class RefrigeratedContainer(double cargoMass, double height, double tareWeight, double depth, double maxPayload, string productType, double maintainedTemperature) : Container(cargoMass, height, tareWeight, depth, maxPayload)
    {
        public string ProductType { get; set; } = productType;
        public double MaintainedTemperature { get; set; } = maintainedTemperature;
        public double MinTemperature { get; private set; }

        public bool CheckTemperature(string productType)
        {
            double minTemperatureForProduct = GetMinTemperatureForProduct(productType);
            if (minTemperatureForProduct == 0)
            {
                Console.WriteLine($"Product type '{productType}' not found. Assuming default temperature requirements.");
            }

            return MinTemperature <= minTemperatureForProduct;
        }

        public double GetMinTemperatureForProduct(string productType)
        {
            Dictionary<string, double> minTemperatures = new Dictionary<string, double>
        {
            {"Bananas", 13.3 },
            {"Chocolate", 18 },
            {"Fish", 2 },
            {"Meat", -15 },
            {"Ice cream", -18 },
            {"Frozen pizza", -30 },
            {"Cheese", 7.2 },
            {"Sausages", 5 },
            {"Butter", 20.5 },
            {"Eggs", 19 }
        };

            if (minTemperatures.ContainsKey(productType))
            {
                return minTemperatures[productType];
            }

            return 0;
        }

        public override string ToString()
        {
            return $"Refrigerated Container {SerialNumber}: Cargo Mass={CargoMass}kg, Height={Height}cm, Tare Weight={TareWeight}kg, Depth={Depth}cm, Product={ProductType}, Maintained Temperature={MaintainedTemperature}°C";
        }
    }
}
