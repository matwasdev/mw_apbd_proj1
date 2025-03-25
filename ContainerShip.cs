namespace mw_apbd_proj1;

public class ContainerShip
{
    public List<Container> Containers = new List<Container>();
    public double MaxSpeed {get; set;}
    public int ContainersLimit {get; set;}
    public double MaxPossibleWeight {get; set;}
    public double CurrentWeight {get; set;}

    public ContainerShip(double maxSpeed,int containersLimit,double maxPossibleWeight)
    {
        this.MaxSpeed = maxSpeed;
        this.ContainersLimit = containersLimit;
        this.MaxPossibleWeight = maxPossibleWeight;
    }


    public void AddContainer(Container container)
    {
        if (container.IsOnShip == true)
        {
            Console.WriteLine("KONTENER JEST JUZ NA STATKU!!!");
            return;
        }
        
        if (Containers.Count + 1 > ContainersLimit)
            throw new OverfillException();

        if (CurrentWeight + container.MasaLadunku + container.WagaSamegoKontenera> MaxPossibleWeight)
            throw new OverfillException();
                
        Containers.Add(container);
        container.IsOnShip=true;
        CurrentWeight += container.MasaLadunku+container.WagaSamegoKontenera;
    }

    public void AddListOfContainers(List<Container> listOfContainersToAdd)
    {
        
        double weightToLoad = 0;

        if (Containers.Count + listOfContainersToAdd.Count > ContainersLimit)
        {
            Console.WriteLine("Limit of possible containers exceeded, cannot make an operation");
            return;
        }
        
        for (int i = 0; i < listOfContainersToAdd.Count; i++)
        {
            if (listOfContainersToAdd[i].IsOnShip == true)
            {
                Console.WriteLine("KONTENER JUZ NA STATKU!!!");
                return;
            }
            weightToLoad += listOfContainersToAdd[i].MasaLadunku+listOfContainersToAdd[i].WagaSamegoKontenera;
        }

        if (CurrentWeight + weightToLoad > MaxPossibleWeight)
        {
            Console.WriteLine("Limit of possible weight exceeded, cannot make an operation");
            return;
        }

        for (int i = 0; i < listOfContainersToAdd.Count; i++)
        {
            Containers.Add(listOfContainersToAdd[i]);
            listOfContainersToAdd[i].IsOnShip=true;
            CurrentWeight+=listOfContainersToAdd[i].MasaLadunku+listOfContainersToAdd[i].WagaSamegoKontenera;
        }
        
        Console.WriteLine(listOfContainersToAdd.Count + " containers added");
    }
    

    public void RemoveContainer(Container container)
    {
        Containers.Remove(container);
        container.IsOnShip = false;
        CurrentWeight -= container.MasaLadunku;
        CurrentWeight -= container.WagaSamegoKontenera;
    }
    
    public static void RelocateContainer(string containerNr, ContainerShip shipFrom, ContainerShip shipTo)
    {
        bool doesExist = false;
        Container contToRelocate = null;
        for (int i = 0; i < shipFrom.Containers.Count; i++)
        {
            if (shipFrom.Containers[i].SerialNumber == containerNr)
            {
                contToRelocate = shipFrom.Containers[i];
                shipFrom.Containers.RemoveAt(i);
                doesExist = true;
                break;
            }
        }
        if(!doesExist)
            throw new Exception("No such container found");

        contToRelocate.IsOnShip = false;
        shipTo.AddContainer(contToRelocate);
    }

    public void InfoAboutShip()
    {
        Console.WriteLine("NUMBER-OF-CONTAINERS-ON-THE-SHIP: " + Containers.Count);
        Console.WriteLine("MAX-SPEED: "+MaxSpeed);
        Console.WriteLine("MAX-CONTAINERS-NUMBER: "+ContainersLimit);
        Console.WriteLine("MAX-WEIGHT-OF-ALL-CONTAINERS: "+MaxPossibleWeight);
        Console.WriteLine("=================================================");
        Console.WriteLine("LIST-OF-CARRIED-CONTAINERS:");
        for (int i = 0; i < Containers.Count; i++)
        {
            Console.WriteLine(Containers[i].SerialNumber);
        }
        Console.WriteLine();
    }

    public string InfoShorter()
    {
        return "(speed="+MaxSpeed+", maxContainerNum="+ContainersLimit+", maxWeight="+MaxPossibleWeight+")";
    }



}