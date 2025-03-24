namespace mw_apbd_proj1;


public abstract class Container
{
    public double masaLadunku { get; set; }
    public double height { get; set; }
    public double wagaSamegoKontenera { get; set; }
    public double depth { get; set; }
    public double maxCapacity { get; set; }
    public string serialNumber { get; set; }

    public static int CONTAINER_NUMBER { get; set; } = 0;

    public bool isOnShip { get; set; } = false;
    public Container(double masaLadunku, double height, double wagaSamegoKontenera, double depth,
        double maxCapacity)
    {
        this.masaLadunku = masaLadunku;
        this.height = height;
        this.wagaSamegoKontenera = wagaSamegoKontenera;
        this.depth = depth;
        this.maxCapacity = maxCapacity;

        ++CONTAINER_NUMBER;
    }

    

    public abstract void fillContainer(int weightToFill);
    public abstract void unfillContainer();


    public void infoAboutContainer()
    {
        Console.WriteLine("SERIAL-NUMBER: " +serialNumber);
        Console.WriteLine("LOADED-WEIGHT: " +masaLadunku);
        Console.WriteLine("HEIGHT: " +height);
        Console.WriteLine("ONLY-CONTAINER-WEIGHT: " + wagaSamegoKontenera);
        Console.WriteLine("MAX-CAPACITY: " +maxCapacity);
        Console.WriteLine();
    }

    public String infoContainerShorter()
    {
        String onship = "";
        if(isOnShip)
            onship = "ON SHIP!";
            
        
        return "(ID: " + serialNumber + ", loadedWeight="+masaLadunku+", height="+height+", " +
               "onlyContainerWeight="+wagaSamegoKontenera+", maxCapacity="+maxCapacity+") "+onship;
    }



}