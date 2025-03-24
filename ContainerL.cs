namespace mw_apbd_proj1;

public class ContainerL : Container, IHazardNotifier
{
    private bool isHazardous;

    public ContainerL(double masaLadunku, double height, double wagaSamegoKontenera, double depth, 
        double maxCapacity, bool isHazardous)
        : base(masaLadunku, height, wagaSamegoKontenera, depth, maxCapacity)
    {
        this.isHazardous = isHazardous;
        serialNumber = "KON-L-"+CONTAINER_NUMBER;
    }


    public void sendWarningNotification()
    {
        Console.WriteLine("Dangerous situation occured on container: " + serialNumber);
    }


    public override void fillContainer(int weightToFill)
    {
        if (weightToFill+masaLadunku > maxCapacity)
            throw new OverfillException();
        
        if ( (0.9*weightToFill+masaLadunku>maxCapacity) || (0.5*weightToFill+masaLadunku>maxCapacity && isHazardous))
            sendWarningNotification();
        
        masaLadunku += weightToFill;
    }

    public override void unfillContainer()
    {
        masaLadunku = 0;
    }
    
    
}