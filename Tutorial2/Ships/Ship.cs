using Tutorial2.Containers;
namespace Tutorial2.Ships;

public class Ship
{
    public static int _counter { get; set; }
    private int Id { get; set; }
    private List<Container> Containers { get; set; }
    private float CargoWeight { get; set; }
    private float MaxSpeed { get; set; }
    private float MaxContainers { get; set; }
    private float MaxCargoWeight { get; set; }

    public Ship(
        float maxSpeed,
        float maxContainers,
        float maxCargoWeight
    )
    {
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxCargoWeight = maxCargoWeight;
        Containers = new List<Container>();
        Id = _counter++;
    }

    public void RemoveContainer(Container c)
    {
        for (int i = 0; i < Containers.Count; i++)
        {
            if (Containers[i] == c)
            {
                c.FromShip();
                Containers.RemoveAt(i);
                UpdateCargoWeight();
                return;
            }
        }

        throw new ArgumentException("Specified Container was not found on the ship.");
    }

    public void ReplaceContainer(string serialNumber, Container newC)
    {
        for (int i = 0; i < Containers.Count; i++)
        {
            if (Containers[i].GetSerialNumber().Equals(serialNumber))
            {
                Containers[i].FromShip();
                Containers[i] = newC;
                newC.OnShip();
                UpdateCargoWeight();
                return;
            }
        }
        
        throw new ArgumentException("Specified Container was not found on the ship.");
    }

    public void LoadContainers(List<Container> Cs)
    {
        foreach (Container c in Cs)
        {
            try
            {
                LoadContainer(c);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    
    public void LoadContainer(Container c)
    {
        if (!CanLoad(c))
        {
            throw new ArgumentException("The Container is too big.");
        }

        Containers.Add(c);
        c.OnShip();
        UpdateCargoWeight();
    }

    public void UpdateCargoWeight()
    {
        CargoWeight = 0;
        foreach (Container c in Containers)
        {
            CargoWeight += c.CargoWeight;
        }
    }

    private bool CanLoad(Container c)
    {
        if (CargoWeight + c.CargoWeight <= MaxCargoWeight) return true;
        return false;
    }

    public override string ToString()
    {
        string containerString = "";
        Containers.ForEach(container => containerString += container.ToString()+'\n');
        return $"\nShip {Id}(speed={MaxSpeed}; containers=\n{containerString}; {CargoWeight}/{MaxCargoWeight}kg)\n";
    }
}