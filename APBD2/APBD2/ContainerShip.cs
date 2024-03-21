
namespace APBD2
{
    public class ContainerShip
    {
        public List<Container> Containers { get; private set; }
        public string Name { get; private set; }
        public int MaxContainers { get; }
        public double MaxWeightCapacity { get; }
        public int MaxSpeedKnots { get; }

        public ContainerShip(string name, int maxContainers, double maxWeightCapacity, int maxSpeedKnots)
        {
            Containers = new List<Container>();
            Name = name;
            MaxContainers = maxContainers;
            MaxWeightCapacity = maxWeightCapacity;
            MaxSpeedKnots = maxSpeedKnots;
        }

        public static List<ContainerShip> CreateShips()
        {
            List<ContainerShip> ships = new List<ContainerShip>();

            ships.Add(new ContainerShip("Ruzgar", 100, 2000, 30));
            ships.Add(new ContainerShip("Kaptan", 150, 2500, 35));
            ships.Add(new ContainerShip("Gullu", 200, 3000, 40));
            ships.Add(new ContainerShip("Karayip Korsani", 250, 3500, 45));
            ships.Add(new ContainerShip("Mavi balina", 300, 4000, 50));

            return ships;
        }
    

    public void LoadContainer(Container container)
        {
            if (Containers.Count >= MaxContainers)
            {
                throw new InvalidOperationException("Container ship is already at maximum capacity.");
            }

            double totalWeight = Containers.Sum(c => c.CargoMass) + container.CargoMass;
            if (totalWeight > MaxWeightCapacity)
            {
                throw new InvalidOperationException("Loading this container exceeds the maximum weight capacity of the ship.");
            }

            Containers.Add(container);
        }

        public void UnloadContainer(Container container)
        {
            Containers.Remove(container);
        }

        public void ReplaceContainer(string serialNumber, Container newContainer)
        {
            Container existingContainer = Containers.Find(c => c.SerialNumber == serialNumber);
            if (existingContainer != null)
            {
                int index = Containers.IndexOf(existingContainer);
                Containers[index] = newContainer;
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, - Max Containers: {MaxContainers}, Max Weight Capacity: {MaxWeightCapacity} tons, Max Speed: {MaxSpeedKnots} knots";
        }
    }

}
