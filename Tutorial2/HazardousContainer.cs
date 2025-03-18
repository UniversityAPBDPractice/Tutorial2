using Tutorial2.Interfaces;
namespace Tutorial2;

public class HazardousContainer : Container, IHazardNotifier{
    public HazardousContainer(
        float height,
        float depth,
        float tareWeight,
        float maxPayload,
        Type containerType
    ) : base(height, depth, tareWeight, maxPayload, containerType){}

    public override void Load(float mass){
        if (mass <= 0) if (mass <= 0) throw new ArgumentException("Mass cant be 0 or less");
        
    }
    public void Notify(Container c){
        Console.WriteLine($"WARNING!!! Hazard occured at {c.GetSerialNumber} container");
    }
}