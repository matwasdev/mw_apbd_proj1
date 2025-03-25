namespace mw_apbd_proj1;

public class ContainerG : Container, IHazardNotifier
{
    public int Pressure;
    
    public ContainerG(double masaLadunku, double height, double wagaSamegoKontenera, double depth, 
        double maxCapacity, int pressure)
        : base(masaLadunku, height, wagaSamegoKontenera, depth, maxCapacity)
    {
        this.Pressure = pressure;
        SerialNumber = "KON-G-"+CONTAINER_NUMBER;
    }

    
    
    public void SendWarningNotification()
    {
        Console.WriteLine("Dangerous situation occured on container: " + SerialNumber);
    }
    

    public override void FillContainer(double weightToFill)
    {
        if (weightToFill+MasaLadunku > MaxCapacity)
            throw new OverfillException();
        
        MasaLadunku += weightToFill;
    }

    public override void UnfillContainer()
    {
        MasaLadunku = 0 + (0.05 * MasaLadunku);
    }
    


}