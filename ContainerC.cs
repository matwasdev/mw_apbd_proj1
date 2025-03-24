namespace mw_apbd_proj1;

public class ContainerC : Container
{
    private double temperature;
    private string productType;

    public ContainerC(double masaLadunku, double height, double wagaSamegoKontenera, double depth, 
        double maxCapacity, string productType, double temperature)
        : base(masaLadunku, height, wagaSamegoKontenera, depth, maxCapacity)
    {
        this.temperature = temperature;
        this.productType = productType;
        
        serialNumber = "KON-C-"+CONTAINER_NUMBER;
    }
    
    
    public override void fillContainer(int weightToFill)
    {
        if (weightToFill+masaLadunku > maxCapacity)
            throw new OverfillException();
        
        masaLadunku += weightToFill;
    }

    public override void unfillContainer()
    {
        masaLadunku = 0;
    }
    
    
}