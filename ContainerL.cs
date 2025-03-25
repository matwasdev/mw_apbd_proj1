namespace mw_apbd_proj1;

public class ContainerL : Container, IHazardNotifier
{
    public bool IsHazardous { get; set; }

    public ContainerL(double masaLadunku, double height, double wagaSamegoKontenera, double depth, 
        double maxCapacity, bool isHazardous)
        : base(masaLadunku, height, wagaSamegoKontenera, depth, maxCapacity)
    {
        IsHazardous = isHazardous;
        SerialNumber = "KON-L-"+CONTAINER_NUMBER;
    }


    public void SendWarningNotification()
    {
        Console.WriteLine("Dangerous situation occured on container: " + SerialNumber);
    }


    public override void FillContainer(double weightToFill)
    {
        if (weightToFill + MasaLadunku > MaxCapacity)
            throw new OverfillException();

        if ((weightToFill + MasaLadunku > 0.9 *  MaxCapacity) || (weightToFill + MasaLadunku > 0.5 *  MaxCapacity && IsHazardous)) 
            SendWarningNotification();
        

        MasaLadunku += weightToFill;
    }

    public override void UnfillContainer()
    {
        MasaLadunku = 0;
    }
    
    
}