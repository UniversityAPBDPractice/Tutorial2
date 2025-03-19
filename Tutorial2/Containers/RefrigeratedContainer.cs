namespace Tutorial2.Containers;
using Tutorial2.Enums;

public class RefrigeratedContainer : Container
{
    private ProductType Product { get; set; }
    private float Temperature { get; set; }
    public RefrigeratedContainer(
        float height,
        float depth,
        float tareWeight,
        float maxPayload,
        ProductType product,
        float temperature
    ) : base(height, depth, tareWeight, maxPayload, Enums.ContainerType.C)
    {
        if (ProductTemperatures.GetTemperature(product) < temperature)
            throw new ArgumentException("Wrong temperature was specified");
        Product = product;
        Temperature = temperature;
    }
    public override string ToString()
    {
        return $"{GetSerialNumber()}, {CargoWeight}/{MaxPayload}kg, {Product}";
    }
}