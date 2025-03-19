namespace Tutorial2.Enums;

public enum ProductType
{
    Bananas,
    Chocolate,
    Fish,
    Meat,
    IceCream,
    FrozenPizza,
    Cheese,
    Sausages,
    Butter,
    Eggs
}

public class ProductTemperatures
{
    private static readonly Dictionary<ProductType, float> TemperatureDict = new ()
    {
        { ProductType.Bananas, 13.3f },
        { ProductType.Fish, 2 },
        { ProductType.Chocolate, 18 },
        { ProductType.Meat, -15 },
        { ProductType.IceCream, -18 },
        { ProductType.FrozenPizza, -30 },
        { ProductType.Cheese, 7.2f },
        { ProductType.Sausages, 5 },
        { ProductType.Butter, 20.5f},
        { ProductType.Eggs, 19}
    };

    public static float GetTemperature(ProductType p) => TemperatureDict[p];
}