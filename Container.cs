namespace mw_apbd_proj1;


public abstract class Container
{
    public double MasaLadunku { get; set; }
    public double Height { get; set; }
    public double WagaSamegoKontenera { get; set; }
    public double Depth { get; set; }
    public double MaxCapacity { get; set; }
    public string SerialNumber { get; set; }

    public static int CONTAINER_NUMBER { get; set; } = 0;

    public bool IsOnShip { get; set; } = false;
    public Container(double masaLadunku, double height, double wagaSamegoKontenera, double depth,
        double maxCapacity)
    {
        MasaLadunku = masaLadunku;
        Height = height;
        WagaSamegoKontenera = wagaSamegoKontenera;
        Depth = depth;
        MaxCapacity = maxCapacity;

        ++CONTAINER_NUMBER;
    }

    

    public abstract void FillContainer(double weightToFill);
    public abstract void UnfillContainer();


    public void InfoAboutContainer()
    {
        Console.WriteLine("SERIAL-NUMBER: " +SerialNumber);
        Console.WriteLine("LOADED-WEIGHT: " +MasaLadunku);
        Console.WriteLine("HEIGHT: " +Height);
        Console.WriteLine("ONLY-CONTAINER-WEIGHT: " + WagaSamegoKontenera);
        Console.WriteLine("MAX-CAPACITY: " +MaxCapacity);
        Console.WriteLine();
    }

    public String InfoContainerShorter()
    {
        String onship = "";
        if(IsOnShip)
            onship = "ON SHIP!";
            
        
        return "(ID: " + SerialNumber + ", loadedWeight="+MasaLadunku+", height="+Height+", " +
               "onlyContainerWeight="+WagaSamegoKontenera+", maxCapacity="+MaxCapacity+") "+onship;
    }



}