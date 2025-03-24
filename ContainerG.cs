namespace mw_apbd_proj1;

public class ContainerG : Container, IHazardNotifier
{
    public int pressure;
    
    public ContainerG(double masaLadunku, double height, double wagaSamegoKontenera, double depth, 
        double maxCapacity, int pressure)
        : base(masaLadunku, height, wagaSamegoKontenera, depth, maxCapacity)
    {
        this.pressure = pressure;
        serialNumber = "KON-G-"+CONTAINER_NUMBER;
    }

    
    
    public void sendWarningNotification()
    {
        Console.WriteLine("Dangerous situation occured on container: " + serialNumber);
    }
    

    public override void fillContainer(int weightToFill)
    {
        if (weightToFill+masaLadunku > maxCapacity)
            throw new OverfillException();
        
        masaLadunku += weightToFill;
    }

    public override void unfillContainer()
    {
        masaLadunku = 0 + (0.05 * masaLadunku);
    }
    


}