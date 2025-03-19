namespace Tutorial2.Containers;

public class GasContainer : HazardousContainer
{
    public GasContainer(
        float height,
        float depth,
        float tareWeight,
        float maxPayload
    ) : base(height, depth, tareWeight, maxPayload, Enums.ContainerType.G)
    {
        Pressure = 0;
    }
    
    public float Pressure { get; set; }

    public override void Empty()
    {
        CargoWeight *= 0.05f;
        Pressure *= 0.05f;
    }

    public override void Load(float mass)
    {
        float weightBefore = CargoWeight;
        try
        {
            base.Load(mass);
        }
        catch (ArgumentException e)
        {
            Notify(e.Message);
        }
        finally
        {
            Pressure *= CargoWeight / weightBefore;   
        }
    }
    public override string ToString()
    {
        return $"{GetSerialNumber()}, {CargoWeight}/{MaxPayload}kg, {Pressure} Pascals";
    }
}