using BasicConnectivityWithClass;
using BasicConnectivityWithClass.Models;
using System.Security.Cryptography;

namespace BasicConnectivityWithClass.Views;

public class LocationsView : GeneralView
{
    public Locations InsertInput()
    {
        Console.WriteLine("Insert employee id");
        int.TryParse(Console.ReadLine(), out int id);
        Console.WriteLine("Insert street address");
        string streetAddress = Console.ReadLine();
        Console.WriteLine("Insert postal code");
        string postalCode = Console.ReadLine();
        Console.WriteLine("Insert city");
        string city = Console.ReadLine();
        Console.WriteLine("Insert state province");
        string stateProvince = Console.ReadLine();
        Console.WriteLine("Insert country id");
        string countryId = Console.ReadLine();

        return new Locations
        {
            Id = id,
            Street_Address = streetAddress,
            Postal_Code = postalCode,
            City = city,
            State_Province = stateProvince,
            Country_Id = countryId
        };
    }

    public Locations Update()
    {
        Console.WriteLine("Insert employee id");
        int.TryParse(Console.ReadLine(), out int id);
        Console.WriteLine("Insert street address");
        string streetAddress = Console.ReadLine();
        Console.WriteLine("Insert postal code");
        string postalCode = Console.ReadLine();
        Console.WriteLine("Insert city");
        string city = Console.ReadLine();
        Console.WriteLine("Insert state province");
        string stateProvince = Console.ReadLine();
        Console.WriteLine("Insert country id");
        string countryId = Console.ReadLine();

        return new Locations
        {
            Id = id,
            Street_Address = streetAddress,
            Postal_Code = postalCode,
            City = city,
            State_Province = stateProvince,
            Country_Id = countryId
        };
    }

    public Locations Delete()
    {
        Console.WriteLine("Delete Country id");
        int.TryParse(Console.ReadLine(), out int id);


        return new Locations
        {
            Id = id

        };

    }
}