namespace Tutorial2;
using Containers;
using Enums;
using Exceptions;
using Interfaces;
using Ships;
public class Program
{
    private static List<Ship> Ships = new List<Ship>();
    private static List<Container> Containers = new List<Container>();
    public static void Main()
    {
        // RunDemo();
        int userInput = 0;
        string shipString;
        string containerString;

        float maxSpeed;
        float shipMaxPayload;
        int maxContainers;

        int i;
        while (userInput != -1)
        {
            shipString = "\nList of container ships:";
            Ships.ForEach(ship => shipString += $"\n{ship}");
            Console.WriteLine(shipString);

            containerString = "\nList of containers:";
            Containers.ForEach(container=> containerString += $"\n{container}");
            Console.Write(containerString);
            Console.Write("\n\n\n");
            
            Console.WriteLine("-1. Exit");
            Console.WriteLine("1. Add a container ship");
            if (Ships.Count > 0)
            {
                Console.WriteLine("2. Remove a container ship");
            }
            userInput = Int32.Parse(Console.ReadLine());
            if (userInput == 1)
            {
                Console.WriteLine("Enter Max Speed: ");
                maxSpeed = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter Max Payload of the ship: ");
                shipMaxPayload = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter Max Containers: ");
                maxContainers = Int32.Parse(Console.ReadLine());
                Ship ship = new Ship(maxSpeed, maxContainers, shipMaxPayload);
                Ships.Add(ship);
            }else if (userInput == 2 && Ships.Count > 0)
            {
                Console.WriteLine("Enter Index of a Ship to be removed");
                i = int.Parse(Console.ReadLine());
                Ships.RemoveAt(i);
            }
        }
    }
    public static void RunDemo()
    {
        // CREATING CONTAINERS
        
        float height = 2;
        float depth = 3;
        float tareWeight = 500;
        float maxPayload = 2000;
        float temperature = 12.5f;
        ProductType bananas = ProductType.Bananas; // Today, we steal the Moon!!!
        RefrigeratedContainer r1 = new RefrigeratedContainer(
            height,
            depth,
            tareWeight,
            maxPayload,
            bananas,
            temperature
        );
        RefrigeratedContainer r2 = new RefrigeratedContainer(height / 3,
            depth / 3,
            tareWeight / 3,
            maxPayload / 3,
            bananas,
            temperature);
        r1.Load(2000); // That is "вагон и маленькая тележка" of bananas
        r2.Load(300);

        LiquidContainer l1 = new LiquidContainer(height, depth, tareWeight, maxPayload)
        {
            Cargo = LiquidCargo.Milk
        };
        
        l1.Load(1337, LiquidCargo.Milk); // No wonder I am Milko

        GasContainer g1 = new GasContainer(height, depth, tareWeight, maxPayload/1000);
        g1.Load(1);

        Console.WriteLine(r1);
        Console.WriteLine(r2);
        Console.WriteLine(l1);
        Console.WriteLine(g1);
        
        
        // SHOWCASING SHIP
        Ship s = new Ship(3, 6, 4000);
        List<Container> containersList = new List<Container>();
        containersList.Add(r1);
        containersList.Add(r2);
        containersList.Add(l1);
        s.LoadContainers(containersList);
        Console.WriteLine(s);
        s.LoadContainer(g1);
        Console.WriteLine(s);
        s.RemoveContainer(r1);
        Console.WriteLine(s);
        r1.Empty();
        Console.WriteLine(r1);
        s.ReplaceContainer("KON-C-1", r1);
        Console.WriteLine(s);
    }
}