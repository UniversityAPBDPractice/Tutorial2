using Tutorial2.Containers;
namespace Tutorial2;

public class LiquidContainer() : HazardousContainer{
    public LiquidContainer(float height,
        float depth,
        float tareWeight,
        float maxPayload
    ) : base(height, depth, tareWeight, maxPayload, Type.L){}

}

// TODO add enum for Products
// TODO create TemperatureValidator
// TODO Refrigerated container should have ProductType, MainteinedTemperature fields
// TODO check if maintained temperature for this product suitable using TemperatureValidator. Throw exception otherwise
// TODO enum ProductType
// TODO check pressure for gas container with ? :

// Do the additional optional task