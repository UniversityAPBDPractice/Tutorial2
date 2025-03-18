namespace Tutorial2;

public abstract class Container
{
    public enum Type
    {
        L,
        G,
        C
    }

    private static int _counter = 0;
    public required float Mass { get; }
    public required float Height { get; }
    public required float TareWeight { get; }
    public required float CargoWeight { get; protected set; }
    public required float Depth { get; }
    public required float MaxPayload { get; }
    public required Type ContainerType;
    public required int Id;

    protected Container(
        float height,
        float depth,
        float tareWeight,
        float maxPayload,
        Type containerType
    ){
        Height = height > 0 ? height : throw new ArgumentException("Height must be more than 0");
        Depth = depth > 0 ? depth : throw new ArgumentException("Depth must be more than 0");
        TareWeight = tareWeight > 0 ? tareWeight : throw new ArgumentException("tareWeight must be more than 0");
        MaxPayload = maxPayload > 0 ? maxPayload : throw new ArgumentException("MaxPayload must be more than 0");
    }

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

    public void Load(float mass)
    {
        if (mass <= 0) throw new ArgumentException("Mass cant be 0 or less");
        if (!CanLoadCargo(mass))
        {
            throw new OverfillException("The Mass you specified exceeds Payload Capacity", this);
        }
        CargoWeight += mass;
    }

    protected virtual bool CanLoadCargo(float mass) => mass + CargoWeight <= MaxPayload;
}