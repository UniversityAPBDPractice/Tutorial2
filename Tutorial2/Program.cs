namespace Tutorial2;
using Containers;
using Enums;
using Exceptions;
using Interfaces;
using Ships;
public class Program
{
    public static void Main()
    {
        RunDemo();
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