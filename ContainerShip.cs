namespace mw_apbd_proj1;

public class ContainerShip
{
    List<Container> containers = new List<Container>();
    private double maxSpeed;
    private int containersLimit;
    private double maxPossibleWeight;
    private double currentWeight;

    public ContainerShip(double maxSpeed,int containersLimit,double maxPossibleWeight)
    {
        this.maxSpeed = maxSpeed;
        this.containersLimit = containersLimit;
        this.maxPossibleWeight = maxPossibleWeight;
    }


    public void addContainer(Container container)
    {
        if (containers.Count + 1 > containersLimit)
            throw new OverfillException();

        if (currentWeight + container.masaLadunku + container.wagaSamegoKontenera> maxPossibleWeight)
            throw new OverfillException();
                
        containers.Add(container);
        container.isOnShip=true;
        currentWeight += container.masaLadunku+container.wagaSamegoKontenera;
    }

    public void addListOfContainers(List<Container> listOfContainersToAdd)
    {
        
        double weightToLoad = 0;

        if (containers.Count + listOfContainersToAdd.Count > containersLimit)
        {
            Console.WriteLine("Limit of possible containers exceeded, cannot make an operation");
            return;
        }
        
        for (int i = 0; i < listOfContainersToAdd.Count; i++)
        {
            weightToLoad += listOfContainersToAdd[i].masaLadunku+listOfContainersToAdd[i].wagaSamegoKontenera;
        }

        if (currentWeight + weightToLoad > maxPossibleWeight)
        {
            Console.WriteLine("Limit of possible weight exceeded, cannot make an operation");
            return;
        }

        for (int i = 0; i < listOfContainersToAdd.Count; i++)
        {
            containers.Add(listOfContainersToAdd[i]);
            listOfContainersToAdd[i].isOnShip=true;
            currentWeight+=listOfContainersToAdd[i].masaLadunku+listOfContainersToAdd[i].wagaSamegoKontenera;
        }
        
        Console.WriteLine(listOfContainersToAdd.Count + " containers added");
    }
    

    public void removeContainer(Container container)
    {
        containers.Remove(container);
        container.isOnShip = false;
        currentWeight -= container.masaLadunku;
        currentWeight -= container.wagaSamegoKontenera;
    }

    public void changeContainerForContainer(string containerToChangeNr, Container containerToAdd)
    {
        
        for (int i = 0; i < containers.Count; i++)
        {
            if (containers[i].serialNumber == containerToChangeNr)
            {
                containers[i].isOnShip = false;
                containers.RemoveAt(i);
                addContainer(containerToAdd);
                containerToAdd.isOnShip = true;
                return;
            }
        }
        throw new Exception("No such container found");
        
    }

    public static void relocateContainer(string containerNr, ContainerShip shipFrom, ContainerShip shipTo)
    {
        bool doesExist = false;
        Container contToRelocate = null;
        for (int i = 0; i < shipFrom.containers.Count; i++)
        {
            if (shipFrom.containers[i].serialNumber == containerNr)
            {
                contToRelocate = shipFrom.containers[i];
                shipFrom.containers.RemoveAt(i);
                doesExist = true;
                break;
            }
        }
        if(!doesExist)
            throw new Exception("No such container found");
        
        shipTo.addContainer(contToRelocate);
    }

    public void infoAboutShip()
    {
        Console.WriteLine("NUMBER-OF-CONTAINERS-ON-THE-SHIP: " + containers.Count);
        Console.WriteLine("MAX-SPEED: "+maxSpeed);
        Console.WriteLine("MAX-CONTAINERS-NUMBER: "+containersLimit);
        Console.WriteLine("MAX-WEIGHT-OF-ALL-CONTAINERS: "+maxPossibleWeight);
        Console.WriteLine("=================================================");
        Console.WriteLine("LIST-OF-CARRIED-CONTAINERS:");
        for (int i = 0; i < containers.Count; i++)
        {
            Console.WriteLine(containers[i].serialNumber);
        }
        Console.WriteLine();
    }

    public string InfoShorter()
    {
        return "(speed="+maxSpeed+", maxContainerNum="+containersLimit+", maxWeight="+maxPossibleWeight+")";
    }



}