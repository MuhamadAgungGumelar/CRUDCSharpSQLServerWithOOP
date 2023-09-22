using BasicConnectivityWithClass;
using BasicConnectivityWithClass.Models;
using System.Security.Cryptography;

namespace BasicConnectivityWithClass.Views;

public class CountriesView : GeneralView
{
    public Countries InsertInput()
    {
        Console.WriteLine("Insert employee id");
        string id = Console.ReadLine();
        Console.WriteLine("Insert country name");
        string countryName = Console.ReadLine();
        Console.WriteLine("Insert region id");
        int.TryParse(Console.ReadLine(), out int rId);
 

        return new Countries
        {
            Id = id,
            Name = countryName,
            RegionId = rId
        };
    }

    public Countries Update()
    {
        Console.WriteLine("Insert employee id");
        string id = Console.ReadLine();
        Console.WriteLine("Insert country name");
        string countryName = Console.ReadLine();
        Console.WriteLine("Insert region id");
        int.TryParse(Console.ReadLine(), out int rId);


        return new Countries
        {
            Id = id,
            Name = countryName,
            RegionId = rId
        };
    }

    public Countries Delete()
    {
        Console.WriteLine("Delete Country id");
        string id = Console.ReadLine();


        return new Countries
        {
            Id = id
        };
    }
}