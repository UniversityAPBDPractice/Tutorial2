namespace Tutorial2.Containers;
using Interfaces;
using Tutorial2.Enums;

public abstract class HazardousContainer : Container, IHazardNotifier{
    public HazardousContainer(
        float height,
        float depth,
        float tareWeight,
        float maxPayload,
        ContainerType containerType
    ) : base(height, depth, tareWeight, maxPayload, containerType){}
    
    public virtual void Notify(string message){
        Console.WriteLine($"WARNING!!! {message} at {GetSerialNumber()} container");
    }
}