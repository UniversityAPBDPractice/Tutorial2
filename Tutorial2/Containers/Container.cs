using Tutorial2.Enums;
using Tutorial2.Exceptions;
namespace Tutorial2.Containers;

public abstract class Container
{
    private static int _counter = 0;
    public float Height { get; }
    public float TareWeight { get; }
    public float CargoWeight { get; protected set; }
    public float Depth { get; }
    public float MaxPayload { get; }
    public ContainerType Type;
    public int Id;
    protected bool IsOnShip = false;

protected Container(
        float height,
        float depth,
        float tareWeight,
        float maxPayload,
        ContainerType containerType
    ){
        Height = height > 0 ? height : throw new ArgumentException("Height must be more than 0");
        Depth = depth > 0 ? depth : throw new ArgumentException("Depth must be more than 0");
        TareWeight = tareWeight > 0 ? tareWeight : throw new ArgumentException("tareWeight must be more than 0");
        MaxPayload = maxPayload > 0 ? maxPayload : throw new ArgumentException("MaxPayload must be more than 0");
        CargoWeight = 0;
        Id = _counter++;
        Type = containerType;
    }

    public String GetSerialNumber()
    {
        return $"KON-{Type}-{Id}";
    }

    public virtual void Empty()
    {
        if (IsOnShip) throw new ArgumentException("You cant empty a container that is on a ship");
        CargoWeight = 0;
    }

    public virtual void Load(float mass)
    {
        if (IsOnShip) throw new ArgumentException("You cant load a container that is on a ship");
        if (mass <= 0) throw new ArgumentException("Mass cant be 0 or less");
        if (!CanLoadCargo(mass))
        {
            throw new OverfillException("The Mass you specified exceeds Payload Capacity");
        }
        CargoWeight += mass;
    }

    protected virtual bool CanLoadCargo(float mass) => mass + CargoWeight <= MaxPayload;

    public override string ToString()
    {
        return $"{GetSerialNumber()}, {CargoWeight}/{MaxPayload}kg";
    }

    public void OnShip()
    {
        IsOnShip = true;
    }

    public void FromShip()
    {
        IsOnShip = false;
    }
}