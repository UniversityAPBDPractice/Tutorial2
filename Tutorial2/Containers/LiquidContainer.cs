using Tutorial2.Enums;

namespace Tutorial2.Containers;
public class LiquidContainer : HazardousContainer{
    public LiquidCargo Cargo { get; set; }
    public LiquidContainer(
        float height,
        float depth,
        float tareWeight,
        float maxPayload
    ) : base(height, depth, tareWeight, maxPayload, Enums.ContainerType.L)
    {}

    public void Load(float mass, LiquidCargo cargo)
    {
        if (mass <= 0) throw new ArgumentException("Mass cant be 0 or less");
        if (!CanLoadCargo(mass, cargo))
        {
            Notify("Exceeded capacity limits");
        }
        else
        {
            CargoWeight += mass;
            Cargo = cargo;
        }
    }

    protected bool CanLoadCargo(float mass, LiquidCargo cargo)
    {
        if (cargo == LiquidCargo.Fuel)
        {
            if (mass + CargoWeight <= 0.5 * MaxPayload) return true;
            return false;
        }
        
        if (mass + CargoWeight <= 0.9 * MaxPayload) return true;
        return false;
    }
    
    public override string ToString()
    {
        return $"{GetSerialNumber()}, {CargoWeight}/{MaxPayload}kg, Liquid: {Cargo}";
    }
}

// TODO add enum for Products
// TODO create TemperatureValidator
// TODO Refrigerated container should have ProductType, MainteinedTemperature fields
// TODO check if maintained temperature for this product suitable using TemperatureValidator. Throw exception otherwise
// TODO enum ProductType
// TODO check pressure for gas container with ? :

// Do the additional optional task