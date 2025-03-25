namespace mw_apbd_proj1;

public class ContainerC : Container
{
    public double Temperature { get; set; }
    public string ProductType { get; set; }

    public ContainerC(double masaLadunku, double height, double wagaSamegoKontenera, double depth, 
        double maxCapacity, string productType, double temperature)
        : base(masaLadunku, height, wagaSamegoKontenera, depth, maxCapacity)
    {
        this.Temperature = temperature;
        this.ProductType = productType;
        
        SerialNumber = "KON-C-"+CONTAINER_NUMBER;
    }
    
    
    public override void FillContainer(double weightToFill)
    {
        if (weightToFill+MasaLadunku > MaxCapacity)
            throw new OverfillException();
        
        MasaLadunku += weightToFill;
    }

    public override void UnfillContainer()
    {
        MasaLadunku = 0;
    }
    
    
}