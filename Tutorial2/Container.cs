namespace Tutorial2;

public abstract class Container
{
    public enum Type
    {
        L,
        G,
        C
    }

    private static int counter = 0;
    public required float Mass { get; set; }
    public required float Height { get; set; }
    public required float TareWeight { get; set; }
    public required float CargoWeight { get; set; }
    public required float Depth { get; set; }
    public required float MaxPayload { get; set; }
    public required Type ContainerType;
    public required int Id;

    public static int IncrementCounter()
    {
        return counter++;
    }

    public String GetSerialNumber()
    {
        return $"KON-{ContainerType}-{Id}";
    }

    public void Empty()
    {
        CargoWeight = 0;
    }

    public void Load(float Mass)
    {
        if (Mass > MaxPayload)
        {
            throw new OverfillException("The Mass you specified exceeds Payload Capacity");
        }
    }
}