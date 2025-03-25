// See https://aka.ms/new-console-template for more information

using mw_apbd_proj1;

List<ContainerShip> wszystkieShips = new List<ContainerShip>();
List<Container> wszystkieContainers = new List<Container>();
String resp = "";

while (true)
{
    Console.WriteLine("Lista kontenerowców:");
    if (wszystkieShips.Count == 0)
    {
        Console.WriteLine("Brak");
    }
    else
    {
        for (int i = 0; i < wszystkieShips.Count; i++)
        {
            Console.WriteLine("Statek: "+i +" "+wszystkieShips[i].InfoShorter());
        }
    }
    Console.WriteLine();
    
    Console.WriteLine("Lista kontenerów:");
    if (wszystkieContainers.Count == 0)
    {
        Console.WriteLine("Brak");
    }
    else
    {
        for (int i = 0; i < wszystkieContainers.Count; i++)
        {
            Console.WriteLine(wszystkieContainers[i].InfoContainerShorter());
        }
    }
    Console.WriteLine();
    
    Console.WriteLine("Możliwe akcje:");
    Console.WriteLine("1. Dodaj kontenerowiec");
    Console.WriteLine("2. Usun kontenerowiec");
    Console.WriteLine("3. Dodaj kontener");
    Console.WriteLine("4. Usun kontener");
    Console.WriteLine("5. Załaduj kontener");
    Console.WriteLine("6. Rozładuj kontener");
    Console.WriteLine("=====================");
    Console.WriteLine("7. Dodaj kontener na statek");
    Console.WriteLine("8. Dodaj listę kontenerów na statek");
    Console.WriteLine("9. Usuń kontener ze statku");
    Console.WriteLine("10. Zastąp kontener na statku innym kontenerem");
    Console.WriteLine("11. Przenieś kontener między dwoma statkami");
    Console.WriteLine("12. Wypisz info o kontenerze");
    Console.WriteLine("13. Wypisz info o statku");
    
    string response = Console.ReadLine();
    if (response.Equals("1"))
    {
        
        Console.WriteLine("Podaj: speed");
        double speed = double.Parse(Console.ReadLine());
        Console.WriteLine("Podaj: maxContainerNum");
        int maxContainerNum  = int.Parse(Console.ReadLine());
        Console.WriteLine("Podaj: maxWeight");
        double maxPossibleWeight = double.Parse(Console.ReadLine());

        ContainerShip ship = new ContainerShip(speed,maxContainerNum,maxPossibleWeight);
        wszystkieShips.Add(ship);
    }

    if (response.Equals("2"))
    {
        Console.WriteLine("Podaj indeks kontenerowca do usunięcia");
        int index = int.Parse(Console.ReadLine());
        if (index > wszystkieShips.Count-1)
        {
            Console.WriteLine("Brak takiego indeksu");
            continue;
        }

        if (wszystkieShips[index].Containers.Count == 0)
        {
            wszystkieShips.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Wpierw trzeba usunąć kontenery ze statku!");
        }
    }

    if (response.Equals("3"))
    {
        Console.WriteLine("Podaj: masaLadunku");
        double masaLadunku = double.Parse(Console.ReadLine());
        Console.WriteLine("Podaj: height");
        double height = double.Parse(Console.ReadLine());
        Console.WriteLine("Podaj: wagaSamegoKontenera");
        double wagaSamegoKontenera = double.Parse(Console.ReadLine());
        Console.WriteLine("Podaj: depth");
        double depth = double.Parse(Console.ReadLine());
        Console.WriteLine("Podaj: maxCapacity");
        double maxCapacity = double.Parse(Console.ReadLine());
        Console.WriteLine("Podaj: TYP KONTENERA (C/G/L)");
        string typ = Console.ReadLine();
        
        if (typ.Equals("C"))
        {
            Console.WriteLine("Podaj: productType");
            string productType = Console.ReadLine();
            Console.WriteLine("Podaj: temperature");
            double temperature = double.Parse(Console.ReadLine());
            ContainerC containerC = new ContainerC(masaLadunku,height,wagaSamegoKontenera,depth,maxCapacity,productType,temperature);
            wszystkieContainers.Add(containerC);
            continue;
        }
        if (typ.Equals("G"))
        {
            Console.WriteLine("Podaj: pressure");
            int pressure = int.Parse(Console.ReadLine());
            ContainerG containerG = new ContainerG(masaLadunku,height,wagaSamegoKontenera,depth,maxCapacity,pressure);
            wszystkieContainers.Add(containerG);
            continue;
        }

        if (typ.Equals("L"))
        {
            Console.WriteLine("Podaj: isHazardous? (false/true)");
            bool isHazardous = bool.Parse(Console.ReadLine());
            ContainerL containerL = new ContainerL(masaLadunku,height,wagaSamegoKontenera,depth,maxCapacity,isHazardous);
            wszystkieContainers.Add(containerL);
            continue;
        }
        
        Console.WriteLine("SOMETHING WENT WRONG");
    }

    if (response.Equals("4"))
    {
        Console.WriteLine("Podaj serial number kontenera (np. KON-C-1)");
        string serialNumber = Console.ReadLine();
        for (int i = 0; i < wszystkieContainers.Count; i++)
        {
            if (wszystkieContainers[i].SerialNumber.Equals(serialNumber))
            {
                wszystkieContainers.RemoveAt(i);
                Console.WriteLine("Usunieto: "+serialNumber);
                break;
            }
        }
    }

    if (response.Equals("6"))
    {
        Console.WriteLine("Podaj serial number kontenera (np. KON-C-1)");
        string serialNumber = Console.ReadLine();
        for (int i = 0; i < wszystkieContainers.Count; i++)
        {
            if (wszystkieContainers[i].SerialNumber.Equals(serialNumber))
            {
                wszystkieContainers[i].UnfillContainer();
                Console.WriteLine("Rozładowano: "+serialNumber);
                break;
            }
        }
    }
    
    if (response.Equals("5"))
    {
        Console.WriteLine("Podaj serial number kontenera (np. KON-C-1)");
        string serialNumber = Console.ReadLine();
        char contType = serialNumber[4];
        int occuranceIndex = 0;
        for (int i = 0; i < wszystkieContainers.Count; i++)
        {
            if (wszystkieContainers[i].SerialNumber.Equals(serialNumber))
            {
                occuranceIndex = i;
                break;
            }
        }

        Console.WriteLine("Podaj wage do załadowania");
        double waga = double.Parse(Console.ReadLine());
        
        string productTypeResponse = "";
        if (contType=='C')
        {
            ContainerC containerC = (ContainerC) wszystkieContainers[occuranceIndex];
            Console.WriteLine("Podaj rodzaj ładunku który chcesz załadowac:");
            productTypeResponse = Console.ReadLine();
            if (containerC.ProductType.Equals(productTypeResponse))
            {
                containerC.FillContainer(waga);
            }
            else
                Console.WriteLine("Nie można załadować tego produktu - jest niezgodny");
        }
        else
        {
            Container container = wszystkieContainers[occuranceIndex];
            container.FillContainer(waga);
        }
    }
    

    if (response.Equals("7"))
    {
        Container container = null;
        Console.WriteLine("Podaj serial number kontenera (np. KON-C-1)");
        string serialNumber = Console.ReadLine();
        for (int i = 0; i < wszystkieContainers.Count; i++)
        {
            if (wszystkieContainers[i].SerialNumber.Equals(serialNumber))
            {
                container = wszystkieContainers[i];
                break;
            }
        }
        Console.WriteLine("Podaj indeks statku");
        int index = int.Parse(Console.ReadLine());
        for (int i = 0; i < wszystkieShips.Count; i++)
        {
            if (index==i)
            {
                wszystkieShips[i].AddContainer(container);
            }
        }
    }

    if (response.Equals("8"))
    {
        List<Container> containers = new List<Container>();
        while (true)
        {
            Console.WriteLine("Podaj serial number kontenera do listy (np. KON-C-1) albo QUIT");
            string serialNumber = Console.ReadLine();
            for (int i = 0; i < wszystkieContainers.Count; i++)
            {
                if (wszystkieContainers[i].SerialNumber.Equals(serialNumber))
                {
                    Container container = wszystkieContainers[i];
                    containers.Add(container);
                    break;
                }
            }
            if(serialNumber.Equals("QUIT"))
                break;
        }

        Console.WriteLine("Podaj indeks statku");
        int index = int.Parse(Console.ReadLine());
        for (int i = 0; i < wszystkieShips.Count; i++)
        {
            if (index==i)
            {
                wszystkieShips[i].AddListOfContainers(containers);
                break;
            }
        }
    }

    if (response.Equals("9"))
    {
        Container container = null;
        
        Console.WriteLine("Podaj serial number kontenera do listy (np. KON-C-1)");
        string serialNumber = Console.ReadLine();
        for (int i = 0; i < wszystkieContainers.Count; i++)
        {
            if (wszystkieContainers[i].SerialNumber.Equals(serialNumber))
            {
                container = wszystkieContainers[i];
                break;
            }
        }
        
        Console.WriteLine("Podaj indeks statku");
        int index = int.Parse(Console.ReadLine());
        for (int i = 0; i < wszystkieShips.Count; i++)
        {
            if (index==i)
            {
                wszystkieShips[i].RemoveContainer(container);
                Console.WriteLine("Usunieto ze statku: "+i + " , kontener: "+container.SerialNumber);
                break;
            }
        }
    }
    
    
    if (response.Equals("10"))
    {
        Console.WriteLine("Podaj serial number starego kontenera do zamiany");
        string staryCont = Console.ReadLine();
        Console.WriteLine("Podaj serial number nowego kontenera do zamian");
        string nowyCont = Console.ReadLine();
        Console.WriteLine("Podaj indeks statku");
        int index = int.Parse(Console.ReadLine());
        
        Container staryContainer = null;
        Container nowyContainer = null;
        ContainerShip ship = null;
        for (int i = 0; i < wszystkieContainers.Count; i++)
        {
            if (wszystkieContainers[i].SerialNumber.Equals(staryCont) && wszystkieContainers[i].IsOnShip)
            {
                staryContainer = wszystkieContainers[i];
            }

            if (wszystkieContainers[i].SerialNumber.Equals(nowyCont) && wszystkieContainers[i].IsOnShip == false)
            {
                nowyContainer = wszystkieContainers[i];
            }
        }

        for (int i = 0; i < wszystkieShips.Count; i++)
        {
            if (index == i)
            {
                ship= wszystkieShips[i];
                ship.RemoveContainer(staryContainer);
                ship.AddContainer(nowyContainer);
                break;
            }
        }
    }
    


    if (response.Equals("11"))
    {
        Console.WriteLine("Podaj serial number kontenera do przeniesienia (np. KON-C-1)");
        string serialNumber = Console.ReadLine();
        Console.WriteLine("Podaj indeks statku, z ktorego przenosimy");
        int indexFrom = int.Parse(Console.ReadLine());
        Console.WriteLine("Podaj indeks statku, do ktorego przenosimy");
        int indexTo = int.Parse(Console.ReadLine());
        ContainerShip shipFrom = null;
        ContainerShip shipTo = null;

        for (int i = 0; i < wszystkieShips.Count; i++)
        {
            if (i == indexFrom)
            {
                shipFrom = wszystkieShips[i];
            }

            if (i == indexTo)
            {
                shipTo = wszystkieShips[i];
            }
        }
        if(shipFrom!=null && shipTo!=null && serialNumber!=null)
            ContainerShip.RelocateContainer(serialNumber,shipFrom,shipTo);
    }

    if (response.Equals("12"))
    {
        Console.WriteLine("Podaj serial number kontenera");
        string serialNumber = Console.ReadLine();
        for (int i = 0; i < wszystkieContainers.Count; i++)
        {
            if (serialNumber.Equals(wszystkieContainers[i].SerialNumber))
            {
                wszystkieContainers[i].InfoAboutContainer();
                break;
            }
        }
    }

    if (response.Equals("13"))
    {
        Console.WriteLine("Podaj index statku");
        int index = int.Parse(Console.ReadLine());
        for (int i = 0; i < wszystkieShips.Count(); i++)
        {
            if (index == i)
            {
                wszystkieShips[i].InfoAboutShip();
                break;
            }
        }
    }
    
    
    
    
    
    
    
    Console.WriteLine();
    Console.WriteLine();
    
    
}

