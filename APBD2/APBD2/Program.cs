using APBD2;

public class Program
{
    static List<ContainerShip> containerShips = new List<ContainerShip>();
    static List<Container> containers = new List<Container>();
    private static double cargoMass;
    private static double height;
    private static double tareWeight;
    private static double depth;
    private static double maxPayload;

    public static void Main()
    {

        Console.WriteLine("List of container ships: None");
        Console.WriteLine("List of containers: None");
        

        bool a = false;
        while (!a)
        {
            Console.WriteLine("\nPossible actions:");
            Console.WriteLine("1. Show container ships");
            Console.WriteLine("2. Remove a container ship");
            Console.WriteLine("3. Add a container");
            Console.WriteLine("4. Load container onto a ship");
            Console.WriteLine("5. Remove a container from a ship");
            Console.WriteLine("6. Print information");
            Console.WriteLine("7. Replace containers");
            Console.WriteLine("8. Transfer containers Between ships");
            Console.WriteLine("9. Print container info");
            Console.WriteLine("10. Print ship information");
            Console.Write("\nEnter your choice (1-10): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Showships();
                    break;
                case "2":
                    RemoveContainerShip();
                    break;
                case "3":
                    AddContainer();
                    break;
                case "4":
                    LoadContainerOnShip();
                    break;
                case "5":
                    RemoveContainerFromShip();
                    break;
                case "6":
                    PrintInformation();
                    break;
                case "7":
                    ReplaceContainer();
                    break;
                case "8":
                    TransferContainerBetweenShips();
                    break;
                case "9":
                    PrintContainerInfo();
                    break;
                case "10":
                    PrintShipInfo();
                    break;
                default:
                    a = true;
                    break;
            }
        }
    }

    private static void Showships()
    {
        containerShips = ContainerShip.CreateShips();
        PrintContainerShips();
    }
    

    static void RemoveContainerShip()
    {
        Console.WriteLine("\nEnter the index of the ship to remove:");
        PrintContainerShips();
        int index = int.Parse(Console.ReadLine());

        if (index >= 0 && index < containerShips.Count)
        {
            containerShips.RemoveAt(index);
            Console.WriteLine("\nContainer ship removed successfully!\n");
        }
        else
        {
            Console.WriteLine("\nInvalid ship index!\n");
        }
    }

    private static void AddContainer()
    {
        Console.WriteLine("Select the type of cargo:");
        Console.WriteLine("1. Liquid");
        Console.WriteLine("2. Refrigerated");
        Console.WriteLine("3. Gas");
        Console.Write("Enter your choice (1-3): ");
        int cargoTypeChoice = int.Parse(Console.ReadLine());
        switch (cargoTypeChoice)
        {
            case 1:
                Console.WriteLine("Enter what product it is:");
                string productTypeLiquid = Console.ReadLine();
                Console.WriteLine("Enter amount of " + productTypeLiquid);
                double amountLiquid = double.Parse(Console.ReadLine());

                try
                {
                    if (productTypeLiquid == "liquid hydrogen")
                    {
                        Console.WriteLine("\nIf you carry Liquid hydrogen you can carry only %50 of the capacity\n");
                        amountLiquid = amountLiquid / 2;
                        Console.WriteLine("New amount of " + productTypeLiquid + " is " + amountLiquid);
                    }

                    LiquidContainer newLiquidContainer = new LiquidContainer(cargoMass, height, tareWeight, depth, maxPayload, productTypeLiquid);

                    containers.Add(newLiquidContainer);
                    Console.WriteLine(productTypeLiquid + " is added into Liquid container!\n");
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Error: {error.Message}");
                }
                break;


            case 2:
                Console.Write("Enter what product it is: ");
                string productTypeRefrigerated = Console.ReadLine();
                Console.Write("Enter the maintained temperature for the container (°C): ");
                double maintainedTemperature = double.Parse(Console.ReadLine());

                RefrigeratedContainer newContainer = new RefrigeratedContainer(cargoMass, height, tareWeight, depth, maxPayload, productTypeRefrigerated, maintainedTemperature);
                containers.Add(newContainer);
                Console.WriteLine(productTypeRefrigerated + " added into Refrigerated container!\n");
                break;

            case 3:
                Console.Write("Enter what product it is: ");
                string productTypeGas = Console.ReadLine();
                Console.WriteLine("Enter amount of gas");
                double GasVolume = double.Parse(Console.ReadLine());
                Console.WriteLine("Notification:  When emptying a gas container - we leave 5% of its cargo inside the container.");

                GasContainer newGasContainer = new GasContainer(cargoMass, height, tareWeight, depth, maxPayload, productTypeGas);
                containers.Add(newGasContainer);
                Console.WriteLine(productTypeGas + " added into Gas container!\n");
                break;
        }
    }


    static void LoadContainerOnShip()
    {
        Console.WriteLine("\nEnter the index of the ship to load the container onto:");
        PrintContainerShips();
        int shipIndex = int.Parse(Console.ReadLine());

        Console.WriteLine("\nEnter the index of the container to load:");
        PrintContainers();
        int containerIndex = int.Parse(Console.ReadLine());

        if (shipIndex >= 0 && shipIndex < containerShips.Count && containerIndex >= 0 && containerIndex < containers.Count)
        {
            containerShips[shipIndex].LoadContainer(containers[containerIndex]);
            containers.RemoveAt(containerIndex);
            Console.WriteLine("\nContainer loaded onto the ship successfully!\n");
        }
        else
        {
            Console.WriteLine("\nInvalid ship or container index!\n");
        }
    }


    static void RemoveContainerFromShip()
    {
        Console.WriteLine("\nEnter the index of the ship to remove the container from:");
        PrintContainerShips();
        int shipIndex = int.Parse(Console.ReadLine());

        Console.WriteLine("\nEnter the index of the container to remove:");
        PrintContainers();
        int containerIndex = int.Parse(Console.ReadLine());

        if (shipIndex >= 0 && shipIndex < containerShips.Count && containerIndex >= 0 && containerIndex < containerShips[shipIndex].Containers.Count)
        {
            containers.Add(containerShips[shipIndex].Containers[containerIndex]);
            containerShips[shipIndex].Containers.RemoveAt(containerIndex);
            Console.WriteLine("\nContainer removed from the ship successfully!\n");
        }
        else
        {
            Console.WriteLine("\nInvalid ship or container index!\n");
        }
    }


    static void PrintInformation()
    {
        Console.WriteLine("\nList of container ships:");
        PrintContainerShips();

        Console.WriteLine("\nList of containers:");
        PrintContainers();
    }


    static void ReplaceContainer()
    {
        Console.WriteLine("\nEnter the serial number of the container to replace:");
        string serialNumber = Console.ReadLine();

        Console.WriteLine("\nEnter the details of the new container:");
        Console.Write("Cargo Mass (kg): ");
        double cargoMass = double.Parse(Console.ReadLine());
        Console.Write("Height (cm): ");
        double height = double.Parse(Console.ReadLine());
        Console.Write("Tare Weight (kg): ");
        double tareWeight = double.Parse(Console.ReadLine());
        Console.Write("Depth (cm): ");
        double depth = double.Parse(Console.ReadLine());
        Console.Write("Max Payload (kg): ");
        double maxPayload = double.Parse(Console.ReadLine());

        Container newContainer = new Container(cargoMass, height, tareWeight, depth, maxPayload);
        bool replaced = false;

        foreach (ContainerShip ship in containerShips)
        {
            Container existingContainer = ship.Containers.Find(c => c.SerialNumber == serialNumber);
            if (existingContainer != null)
            {
                ship.ReplaceContainer(serialNumber, newContainer);
                replaced = true;
                Console.WriteLine("\nContainer replaced successfully!\n");
                break;
            }
        }

        if (!replaced)
        {
            Console.WriteLine("\nContainer with the specified serial number not found!\n");
        }
    }


    static void TransferContainerBetweenShips()
    {
        Console.WriteLine("\nEnter the serial number of the container to transfer:");
        string serialNumber = Console.ReadLine();

        Console.WriteLine("\nEnter the index of the source ship:");
        PrintContainerShips();
        int sourceShipIndex = int.Parse(Console.ReadLine());

        Console.WriteLine("\nEnter the index of the destination ship:");
        PrintContainerShips();
        int destinationShipIndex = int.Parse(Console.ReadLine());

        if (sourceShipIndex >= 0 && sourceShipIndex < containerShips.Count &&
            destinationShipIndex >= 0 && destinationShipIndex < containerShips.Count)
        {
            Container containerToTransfer = null;

            foreach (Container container in containerShips[sourceShipIndex].Containers)
            {
                if (container.SerialNumber == serialNumber)
                {
                    containerToTransfer = container;
                    break;
                }
            }

            if (containerToTransfer != null)
            {
                containerShips[sourceShipIndex].UnloadContainer(containerToTransfer);
                containerShips[destinationShipIndex].LoadContainer(containerToTransfer);
                Console.WriteLine("\nContainer transferred successfully!\n");
            }
            else
            {
                Console.WriteLine("\nContainer with the specified serial number not found in the source ship!\n");
            }
        }
        else
        {
            Console.WriteLine("\nInvalid source or destination ship index!\n");
        }
    }

    static void PrintContainerInfo()
    {
        Console.WriteLine("\nEnter the serial number of the container:");
        string serialNumber = Console.ReadLine();

        bool found = false;
        foreach (Container container in containers)
        {
            if (container.SerialNumber == serialNumber)
            {
                Console.WriteLine($"\nContainer Information - Serial Number: {container.SerialNumber}");
                Console.WriteLine($"Cargo Mass (kg): {container.CargoMass}");
                Console.WriteLine($"Height (cm): {container.Height}");
                Console.WriteLine($"Tare Weight (kg): {container.TareWeight}");
                Console.WriteLine($"Depth (cm): {container.Depth}");
                Console.WriteLine($"Max Payload (kg): {container.MaxPayload}\n");

                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("\nContainer not found!\n");
        }
    }


    static void PrintShipInfo()
    {
        Console.WriteLine("\nEnter the index of the ship:");
        PrintContainerShips();
        int shipIndex = int.Parse(Console.ReadLine());

        if (shipIndex >= 0 && shipIndex < containerShips.Count)
        {
            ContainerShip ship = containerShips[shipIndex];
            Console.WriteLine($"\nShip Information - Max Containers: {ship.MaxContainers}, Max Weight Capacity: {ship.MaxWeightCapacity} tons, Max Speed: {ship.MaxSpeedKnots} knots");

            Console.WriteLine("\nContainers on the ship:");
            foreach (Container container in ship.Containers)
            {
                Console.WriteLine($"Serial Number: {container.SerialNumber}, Cargo Mass (kg): {container.CargoMass}, Height (cm): {container.Height}, Tare Weight (kg): {container.TareWeight}, Depth (cm): {container.Depth}, Max Payload (kg): {container.MaxPayload}");
            }

            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("\nInvalid ship index!\n");
        }
    }






    static void PrintContainerShips()
    {
        for (int i = 0; i < containerShips.Count; i++)
        {
            Console.WriteLine($"{i}. {containerShips[i]}");
        }
    }

    static void PrintContainers()
    {
        for (int i = 0; i < containers.Count; i++)
        {
            Console.WriteLine($"{i}. {containers[i]}");
        }
    }
}


